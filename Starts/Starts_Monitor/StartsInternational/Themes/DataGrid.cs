using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows.Controls;

namespace StartsInternational.Themes
{
    public partial class DataGrid
    {
        private void Thumb_MouseLeave(object sender, MouseEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Arrow;
        }

        private void Thumb_MouseEnter(object sender, MouseEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.SizeWE;
        }

        private void Thumb_MouseEnter1(object sender, MouseEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.SizeNS;
        }

        private void loading(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        public void LoadingRow(object sender, DataGridRowEventArgs e)
        {
            //e.Row.Header = (e.Row.GetIndex() + 1).ToString()
        }
    }
}
