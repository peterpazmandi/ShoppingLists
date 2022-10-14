using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using WPF.Helpers;

namespace WPF.Converters
{
    public sealed class ListItemToPositionConverter : IValueConverter
    {
        #region Implementation of IValueConverter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var item = value as ListBoxItem;
            if (item != null)
            {
                var lb = Ancestor.FindAncestor<ListBox>(item);
                if (lb != null)
                {
                    var index = lb.Items.IndexOf(item.Content);
                    return index;
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
