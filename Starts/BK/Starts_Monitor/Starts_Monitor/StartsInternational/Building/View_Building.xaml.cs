using MemoryData;
using ObjInfo;
using Starts_Controller;
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
using System.Windows.Shapes;

namespace StartsInternational.Building
{
    /// <summary>
    /// Interaction logic for Create_Building.xaml
    /// </summary>
    public partial class View_Building : Window
    {
        public View_Building()
        {
            InitializeComponent();
        }

        public Building_Info c_Building_Info;

        private void frmView_Building_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
            txt_Building_Code.Focus();
        }

        private void frmView_Building_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }


        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        void LoadData()
        {
            try
            {
                txt_Building_Code.Text = c_Building_Info.Building_Code;
                //txt_Building_Name.Text = c_Building_Info.Building_Name;
                txtAddress.Text = c_Building_Info.Address;
                txtNote.Text = c_Building_Info.Notes;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }
    }
}
