using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPF.Controls.Custom
{
    public class MyCustomComboBox : ComboBox
    {
        private int currentCaretIndex;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            var child = GetTemplateChild("PART_EditableTextBox");
            if (child != null)
            {
                var textBox = (TextBox)child;
                textBox.SelectionChanged += OnDropSelectionChanged;
                textBox.TextChanged += TextBox_TextChanged;

            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (txt.Text.Length > 2)
            {
                SolidColorBrush solidColorBrush = (SolidColorBrush)txt.SelectionBrush;
                txt.SelectionBrush = new SolidColorBrush();
                base.IsDropDownOpen = true;
                txt.SelectionBrush = solidColorBrush;
            }
        }

        private void OnDropSelectionChanged(object sender, System.Windows.RoutedEventArgs e)
        {
            TextBox txt = (TextBox)sender;

            if (base.IsDropDownOpen && txt.SelectionLength > 0)
            {
                currentCaretIndex = txt.SelectionLength; // currentCaretIndex must be set to TextBox's SelectionLength
                txt.CaretIndex = currentCaretIndex;
            }
            if (txt.SelectionLength == 0 && txt.CaretIndex != 0)
            {
                currentCaretIndex = txt.CaretIndex;
            }
        }
    }
}
