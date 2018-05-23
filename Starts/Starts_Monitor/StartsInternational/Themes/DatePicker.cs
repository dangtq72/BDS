using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Media;

namespace StartsInternational.Themes
{
    public partial class DatePicker
    {
        public string s = "";
        BrushConverter bc = new BrushConverter();
        System.Windows.Controls.DatePicker dt;

        private void GotFocused(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Control ctrl = (System.Windows.Controls.Control)sender;
            dt = (System.Windows.Controls.DatePicker) sender;
            s = "#F78A09";
            Brush brush = (Brush)bc.ConvertFromString(s);
            brush.Freeze();
            ctrl.BorderBrush = brush;
        }

        private void LostFocused(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Control ctrl = (System.Windows.Controls.Control)sender;
            s = "#B9B9B9";
            Brush brush = (Brush)bc.ConvertFromString(s);
            brush.Freeze();
            ctrl.BorderBrush = brush;
        }

        private void TextChange(object sender, TextChangedEventArgs e)
        {
            //TextBox txb = (TextBox)sender;
            //System.Globalization.CultureInfo provider = System.Globalization.CultureInfo.CurrentCulture;
            //DateTime temp = DateTime.MinValue;
            //try
            //{
            //    temp = DateTime.ParseExact(txb.Text, "dd/MM/yyyy", provider);
            //}
            //catch {}
            //if (temp > DateTime.ParseExact("01/01/1800", "dd/MM/yyyy", provider))
            //    dt.SelectedDate = DateTime.ParseExact(txb.Text, "dd/MM/yyyy", provider); 
        }
    }
}
