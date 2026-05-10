using Avalonia.Controls;
using BymlLibrary;
using SharpYaml;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Wondertools.FileTypes
{
    internal abstract class BgymlFileType : FileType
    {
        protected Byml? bymlFile;
        protected Dictionary<string, object>? data;
        protected StackPanel stackPanel;

        public override void CreateUI(byte[] file, Panel parentUI)
        {
            bymlFile = Byml.FromBinary(file);
            data = YamlSerializer.Deserialize<Dictionary<string, object>>(bymlFile.ToYaml()) ?? throw new InvalidDataException("Failed to parse AreaParam data.");

            stackPanel = new()
            {
                Spacing = 5
            };

            CreateUI(parentUI);
        }
        public abstract void CreateUI(Panel parentUI);

        protected void SetupCheckBox(string name, string dictName, bool defaultValue, Dictionary<string, object>? dict = null)
        {
            dict ??= data;

            if (!dict.ContainsKey(dictName))
                dict[dictName] = false;

            stackPanel.Children.Add(UIDualItem(name, UICheckBox((bool)dict[dictName], (v) =>
            {
                if (dict[dictName] != (object)v)
                    HasBeenEdited = true;
                dict[dictName] = v;
            })));
        }

        protected void SetupComboBoxArr(string name, string dictName, string defaultValue, string[] options, Dictionary<string, object>? dict = null)
        {
            dict ??= data;

            if (!dict.ContainsKey(dictName))
                dict[dictName] = defaultValue;

            stackPanel.Children.Add(UIDualItem(name, UIComboBox(options, (string)dict[dictName], (v) =>
            {
                if (dict[dictName] != (object)v)
                    HasBeenEdited = true;
                dict[dictName] = v;
            })));
        }

        protected void SetupComboBoxDict(string name, string dictName, string defaultValue, Dictionary<string, string> options, Dictionary<string, object>? dict = null)
        {
            dict ??= data;

            if (!dict.ContainsKey(dictName))
                dict[dictName] = defaultValue;

            stackPanel.Children.Add(UIDualItem(name, UIComboBox([.. options.Values], options[(string)dict[dictName]], (v) =>
            {
                if (dict[dictName] != (object)v)
                    HasBeenEdited = true;
                dict[dictName] = options.FirstOrDefault(x => x.Value == v).Key;
            })));
        }

        protected void SetupIntBox(string name, string dictName, int defaultValue, Dictionary<string, object>? dict = null)
        {
            dict ??= data;

            if (!dict.ContainsKey(dictName))
                dict[dictName] = defaultValue;

            stackPanel.Children.Add(UIDualItem(name, UIIntBox(defaultValue, (v) =>
            {
                if (dict[dictName] != (object)v)
                    HasBeenEdited = true;
                dict[dictName] = v;
            })));
        }

        protected void SetupDecimalBox(string name, string dictName, decimal defaultValue, Dictionary<string, object>? dict = null)
        {
            dict ??= data;

            if (!dict.ContainsKey(dictName))
                dict[dictName] = defaultValue;

            stackPanel.Children.Add(UIDualItem(name, UIDecimalBox(defaultValue, (v) =>
            {
                if (dict[dictName] != (object)v)
                    HasBeenEdited = true;
                dict[dictName] = v;
            })));
        }
    }
}
