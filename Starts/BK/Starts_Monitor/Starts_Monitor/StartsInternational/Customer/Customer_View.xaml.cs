using MemoryData;
using ObjInfo;
using StartsInternational.Common;
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
using Starts_Controller;

namespace StartsInternational.Customer
{
    /// <summary>
    /// Interaction logic for Customer_Insert.xaml
    /// </summary>
    public partial class Customer_View : Window
    {
        public Customer_View()
        {
            InitializeComponent();
        }

        Customer_Controller c_Customer_Controller = new Customer_Controller();
        public Customer_Info c_Customer_Info;

        private void frmCustomer_View_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
            txtCustomer_Name.Focus();
        }

        private void frmCustomer_View_KeyDown(object sender, KeyEventArgs e)
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
                List<AllCode_Info> _lst_Currency = DBMemory.AllCode_GetBy_CdNameCdType("CUSTOMER", "TYPE");
                cboType.ItemsSource = _lst_Currency;
                cboType.DisplayMemberPath = "Content";
                cboType.SelectedValuePath = "CdValue";
                cboType.SelectedIndex = 0;

                txtCustomer_Name.Text = c_Customer_Info.Customer_Name;
                txtAddress.Text = c_Customer_Info.Address;
                txtPhone.Text = c_Customer_Info.Phone;
                txtFax.Text = c_Customer_Info.Fax;
                txtTaxCode.Text = c_Customer_Info.Tax_Code;
                txtIdentity_Card.Text = c_Customer_Info.Identity_Card;

                cboType.SelectedValue = c_Customer_Info.Is_Person;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }

        }
    }
}
