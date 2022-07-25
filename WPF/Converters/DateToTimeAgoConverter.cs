using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WPF.Converters
{
    public class DateToTimeAgoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                DateTime date = (DateTime)value;

                if (date.Date == DateTime.Now.Date)
                {
                    return $"Today at {date.ToString("HH:mm:ss")}";
                }
                else if (date.Date == DateTime.Now.AddDays(-1).Date)
                {
                    return $"Yesterday at {date.ToString("HH:mm:ss")}";
                }
                else if (date.Date == DateTime.Now.AddDays(-2).Date)
                {
                    return $"2 days ago at {date.ToString("HH:mm:ss")}";
                }
                else if (date.Date == DateTime.Now.AddDays(-2).Date)
                {
                    return $"3 days ago at {date.ToString("HH:mm:ss")}";
                }
                else
                {
                    return date.ToString("yyyy MMM dd, dddd");
                }
            }

            return String.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
