using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StartsInternational.CustomUserControl
{
    /// <summary>
    /// Interaction logic for LoadControl.xaml
    /// </summary>
    public partial class LoadControl : UserControl
    {
        public LoadControl()
        {
            InitializeComponent();
        }

        public void LoadPercent(string p_percent)
        {
            try
            {
                //lblPercent.Content = p_percent;
            }
            catch { }
        }
    }
}
