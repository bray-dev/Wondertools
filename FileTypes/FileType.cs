using Avalonia;
using Avalonia.Controls;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using System;

namespace Wondertools.FileTypes
{
    internal abstract class FileType
    {
        public abstract string FileExtension { get; }
        public abstract void CreateUI(byte[] file, Panel parentUI);
        public abstract void Save(string path);

        public bool HasBeenEdited;

        protected static void ModalPopupOK(string title, string text)
        {
            MessageBoxManager.GetMessageBoxStandard(title, text, ButtonEnum.Ok).ShowAsPopupAsync(MainWindow.Instance);
        }

        protected static Grid UIDualItem(string labelText, Control inputControl)
        {
            Grid grid = new()
            {
                ColumnDefinitions =
                {
                    new ColumnDefinition(GridLength.Auto),
                    new ColumnDefinition(GridLength.Star)
                }
            };
            TextBlock label = new()
            {
                Text = labelText + ":",
                VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center,
                Margin = new Thickness(0, 0, 10, 0)
            };
            Grid.SetColumn(label, 0);
            Grid.SetColumn(inputControl, 1);
            grid.Children.Add(label);
            grid.Children.Add(inputControl);
            return grid;
        }

        protected static CheckBox UICheckBox(bool defaultValue, Action<bool> selectedAction)
        {
            CheckBox checkBox = new()
            {
                IsChecked = defaultValue,
            };

            checkBox.IsCheckedChanged += (_, _) =>
            {
                if (checkBox.IsChecked != null)
                    selectedAction((bool)checkBox.IsChecked);
            };

            return checkBox;
        }

        protected static ComboBox UIComboBox(string[] items, string defaultItem, Action<string> selectedAction)
        {
            ComboBox comboBox = new()
            {
                ItemsSource = items,
                SelectedItem = defaultItem,
            };

            comboBox.SelectionChanged += (_, _) =>
            {
                if (comboBox.SelectedItem is string selectedItem)
                    selectedAction(selectedItem);
            };

            return comboBox;
        }

        protected static TextBox UITextBox(string defaultText, Action<string> textChangeAction)
        {
            TextBox textBox = new()
            {
                Text = defaultText,
            };

            textBox.TextChanged += (_, _) =>
            {
                textChangeAction(textBox.Text);
            };

            return textBox;
        }

        protected static NumericUpDown UIIntBox(int defaultValue, Action<int> valueChangeAction)
        {
            NumericUpDown intBox = new()
            {
                Value = defaultValue
            };

            intBox.ValueChanged += (_, _) =>
            {
                intBox.Value = (int)intBox.Value;
                valueChangeAction((int)intBox.Value);
            };

            return intBox;
        }

        protected static NumericUpDown UIDecimalBox(decimal defaultValue, Action<decimal> valueChangeAction)
        {
            NumericUpDown decimalBox = new()
            {
                Value = defaultValue
            };

            decimalBox.ValueChanged += (_, _) =>
            {
                valueChangeAction((decimal)decimalBox.Value);
            };

            return decimalBox;
        }

        protected static TextBlock UIHeader(string text)
        {
            return new TextBlock
            {
                Text = text,
                FontSize = 18,
                FontWeight = Avalonia.Media.FontWeight.Bold,
                Margin = new Thickness(0, 10, 0, 5)
            };
        }
    }
}
