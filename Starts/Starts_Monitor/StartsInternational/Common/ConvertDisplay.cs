using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace StartsInternational
{
    class Convert_Date : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime)
            {
                DateTime _date = (DateTime)value;
                if (_date.Date == DateTime.MinValue.Date)
                    return "-";
                else
                    return Common.ConvertData.ConvertDate2String(_date);
            }
            else
                return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
