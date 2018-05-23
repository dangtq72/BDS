using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StartsInternational.Control.Alert
{
    /// <summary>
    /// Interaction logic for frmLogOn.xaml
    /// </summary>
    public partial class frmLogOn : Window
    {
        public frmLogOn()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtPassword.Focus();
            lblUserName.Content = CommonData.c_Urser_Info.User_Name;
        }

        private void passwordBox1_GotFocus(object sender, RoutedEventArgs e)
        {
            txtPassword.Focus();
        }

        private void btnLogon_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CommonData.c_Urser_Info.Pass == txtPassword.Text)
                {
                    this.Close();
                }
                else
                {
                    NoteBox.Show("Mật khẩu không đúng");
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                NoteBox.Show("Đăng nhập thất bại.............");
                App.Current.Shutdown();
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (CommonData.c_Urser_Info.Pass == txtPassword.Text)
                {
                    this.Close();
                }
                else
                {
                    NoteBox.Show("Mật khẩu không đúng");
                    txtPassword.Focus();
                }
            }
        }
    }
}
