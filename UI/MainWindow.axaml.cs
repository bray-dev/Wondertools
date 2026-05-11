using Avalonia.Controls;
using Avalonia.Platform.Storage;
using AvaloniaEdit.Utils;
using BymlLibrary;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using SharpYaml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Tmds.DBus.Protocol;
using Wondertools.FileTypes;

namespace Wondertools
{
    public partial class MainWindow : Window
    {
        public static MainWindow Instance { get; private set; }

        readonly Type[] loadedFileTypes;
        readonly Dictionary<string, FileType> supportedFileTypes = [];

        FileType? selectedFile;
        string selectedFilePath = "";

        public MainWindow()
        {
            InitializeComponent();
            Instance = this;

            StaticData.WonderEnvironmentSounds.AddRange(StaticData.EnvironmentSounds);

            TestThing();

            Console.WriteLine("Loading file types...");
            loadedFileTypes = [.. AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(domainAssembly => domainAssembly.GetTypes())
                .Where(type => typeof(FileType).IsAssignableFrom(type) && !type.IsAbstract
            )];

            Console.WriteLine($"File type count: {loadedFileTypes.Length}");

            foreach (Type type in loadedFileTypes)
            {
                FileType? instance = (FileType?)Activator.CreateInstance(type);
                if (instance == null)
                {
                    Console.WriteLine($"Failed to load file type: '{type.FullName}', couldn't create an instance");
                    continue;
                }
                string? extension = (string?)type.GetProperty("FileExtension")?.GetValue(instance);
                if (extension == null)
                {
                    Console.WriteLine($"Failed to load file type: '{type.FullName}', couldn't get extension");
                    continue;
                }
                supportedFileTypes[extension] = instance;
            }
            foreach (var kvp in supportedFileTypes)
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");

            FolderTreeView.DoubleTapped += FolderTreeView_DoubleTapped;

            WorkspaceUISaveBtn.Click += WorkspaceUISaveBtn_Click;
            WorkspaceUISaveAsBtn.Click += WorkspaceUISaveAsBtn_Click;
            MenuItemOpenFile.Click += MenuItemOpenFile_Click;
            MenuItemOpenFolder.Click += MenuItemOpenFolder_Click;
            MenuItemExit.Click += MenuItemExit_Click;
        }

        private void MenuItemExit_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            TryExit();
        }

        public void TryExit()
        {
            if (selectedFile != null && selectedFile.HasBeenEdited)
            {
                MessageBoxManager.GetMessageBoxStandard("Unsaved Changes", "You have unsaved changes. Are you sure you want to exit without saving?", ButtonEnum.YesNo).ShowAsPopupAsync(this).ContinueWith(result =>
                {
                    if (result.Result == ButtonResult.Yes)
                        Environment.Exit(0);
                });
                return;
            }
            Environment.Exit(0);
        }

        private async void MenuItemOpenFile_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var topLevel = GetTopLevel(this);
            if (topLevel == null)
                return;

            var files = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
            {
                Title = "Open File",
                FileTypeFilter = [new FilePickerFileType("All Files") { Patterns = ["*.*"] }, ..supportedFileTypes.Select(kvp => new FilePickerFileType($"{supportedFileTypes[kvp.Key].FileName} Files") { Patterns = [$"*.{kvp.Key}"] })],
                AllowMultiple = false
            });

            if (files.Count >= 1)
            {
                OpenFile(Uri.UnescapeDataString(files[0].Path.AbsolutePath));
            }
        }

        private async void MenuItemOpenFolder_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var topLevel = GetTopLevel(this);
            if (topLevel == null)
                return;

            var folder = await topLevel.StorageProvider.OpenFolderPickerAsync(new FolderPickerOpenOptions
            {
                Title = "Open Folder"
            });

            if (folder.Count > 0)
            {
                FolderTreeViewOpen(Uri.UnescapeDataString(folder[0].Path.AbsolutePath));
            }
        }

        private void OpenFile(string path)
        {
            Console.WriteLine($"Opening {Path.GetFileName(path)}");

            FileType? fileType = GetFileType(path);
            if (fileType == null)
            {
                MessageBoxManager.GetMessageBoxStandard("Unsupported File", "File type is unsupported.", ButtonEnum.Ok).ShowAsPopupAsync(this);
                return;
            }
            byte[] fileData;
            try
            {
                fileData = File.ReadAllBytes(path);
            }
            catch (Exception e)
            {
                MessageBoxManager.GetMessageBoxStandard("Error", e.Message, ButtonEnum.Ok).ShowAsPopupAsync(this);
                return;
            }
            Controls children = [ ..WorkspaceUIPanel.Children];
            WorkspaceUIPanel.Children.Clear();

            try
            {
                fileType.CreateUI(fileData, WorkspaceUIPanel);
            }
            catch (InvalidDataException e)
            {
                MessageBoxManager.GetMessageBoxStandard("Error", e.Message, ButtonEnum.Ok).ShowAsPopupAsync(this);
                WorkspaceUIPanel.Children.AddRange(children);
                return;
            }

            selectedFile = fileType;
            selectedFilePath = path;
            WorkspaceUIOpenedPath.Text = Path.GetFileName(path);
            WorkspaceUITopbar.IsVisible = true;
        }

        private void WorkspaceUISaveBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            selectedFile?.Save(selectedFilePath);
        }

        private async void WorkspaceUISaveAsBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var topLevel = GetTopLevel(this);
            if (topLevel == null || selectedFile == null)
                return;

            var file = await topLevel.StorageProvider.SaveFilePickerAsync(new FilePickerSaveOptions
            {
                Title = "Save File",
                SuggestedFileName = selectedFilePath,
                SuggestedStartLocation = await StorageProvider.TryGetFolderFromPathAsync(Path.GetDirectoryName(selectedFilePath)),
                FileTypeChoices =
                [
                    new FilePickerFileType($"{selectedFile.FileExtension} Files") { Patterns = [$"*.{selectedFile.FileExtension}"] },
                    new FilePickerFileType("All Files") { Patterns = ["*.*"] }
                ]
            });
            if (file is not null)
                selectedFile?.Save(Uri.UnescapeDataString(file.Path.AbsolutePath));
        }

        private void FolderTreeView_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
        {
            TreeViewItem? item = (TreeViewItem?)FolderTreeView.SelectedItem;
            if (item == null || item.Name == null || Directory.Exists(item.Name))
                return;

            OpenFile(item.Name);
        }

        public void FolderTreeViewOpen(string folderDir)
        {
            FolderTreeView.Items.Clear();
            folderDir = folderDir.Replace("%20", " ");
            foreach (string dir in Directory.GetDirectories(folderDir, "*", SearchOption.TopDirectoryOnly))
                FolderTreeView.Items.Add(GetItemsFromDirectory(dir));
            foreach (var file in Directory.GetFiles(folderDir, "*", SearchOption.TopDirectoryOnly))
            {
                TreeViewItem fileItem = new()
                {
                    Header = Path.GetFileName(file),
                    Name = file,
                    IsEnabled = IsFileTypeSupported(file)
                };
                FolderTreeView.Items.Add(fileItem);
            }
        }

        TreeViewItem GetItemsFromDirectory(string directory)
        {
            TreeViewItem item = new()
            {
                Header = Path.GetFileNameWithoutExtension(directory),
                Name = directory
            };
            foreach (string dir in Directory.GetDirectories(directory, "*", SearchOption.TopDirectoryOnly))
                item.Items.Add(GetItemsFromDirectory(dir));

            foreach (var file in Directory.GetFiles(directory, "*", SearchOption.TopDirectoryOnly))
            {
                TreeViewItem fileItem = new()
                {
                    Header = Path.GetFileName(file),
                    Name = file,
                    IsEnabled = IsFileTypeSupported(file)
                };
                item.Items.Add(fileItem);
            }

            return item;
        }

        bool IsFileTypeSupported(string filePath) => GetFileType(filePath) != null;

        FileType? GetFileType(string filePath)
        {
            filePath = Path.GetFileName(filePath);
            string extension = filePath.TrimStart(filePath.Split(".")[0].ToCharArray()).TrimStart('.');
            if (!supportedFileTypes.TryGetValue(extension, out FileType? value))
                return null;
            return value;
        }

        static void TestThing()
        {
            return;
            List<string> bgmTypes = [];
            foreach (var item in Directory.GetFiles("C:\\Users\\charl\\Documents\\Roms\\Switch\\Dumps\\Wonder 1.0\\romfs", "*", SearchOption.AllDirectories))
            {
                if (item.EndsWith(".bgyml"))
                {
                    Byml byml = Byml.FromBinary(File.ReadAllBytes(item));
                    Dictionary<string, object> yaml = YamlSerializer.Deserialize<Dictionary<string, object>>(byml.ToYaml());

                    string searchKey = "ExternalRhythmPatternSet";
                    Dictionary<string, object> dict = yaml;
                    //if (yaml.ContainsKey("ExternalRhythmPatternSet"))
                    //    dict = (Dictionary<string, object>)yaml["ExternalRhythmPatternSet"];
                    if (dict.TryGetValue(searchKey, out object? value) && !bgmTypes.Contains(value))
                        //bgmTypes.Add($"{Path.GetFileNameWithoutExtension(item)}: {dict[searchKey]}");
                        bgmTypes.Add($"{value}");
                }
            }

            bgmTypes.Sort();
            bgmTypes.ForEach(Console.WriteLine);
        }
    }
}