using MemoryData;
using ObjInfo;
using Starts_Controller;
using StartsInternational.Common;
using StartsInternational.Customer;
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

namespace StartsInternational.Contract.Create
{
    /// <summary>
    /// Interaction logic for Chose_Customer.xaml
    /// </summary>
    public partial class Chose_Customer : Window
    {
        public Chose_Customer()
        {
            InitializeComponent();
        }

        Customer_Controller c_Customer_Controller = new Customer_Controller();
        List<Customer_Info> c_lst = new List<Customer_Info>();
        public int c_ok = 0;
        public Customer_Info c_Customer_Info_Search = new Customer_Info();
        int c_row_select = 0;

        private void frmChose_Customer_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //c_lst = c_Customer_Controller.Customer_GetAll();
                //dgrRenter.ItemsSource = c_lst;
                //DataGridHelper.NVSFocus(dgrRenter, 0, 0);

                txtRenterName.Focus();
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        private void frmChose_Customer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        private void dgrRenter_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void dgrRenter_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                e.Handled = true;
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Search();
        }

        /// <summary>
        /// hàm dùng cho EventsSetter trong form display
        /// </summary>
        void DoubleClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Customer_Info _Customer_Info = (Customer_Info)dgrRenter.SelectedItem;

                if (_Customer_Info != null)
                {
                    c_Customer_Info_Search = _Customer_Info;
                    c_ok = 1;
                    this.Close();
                }
                e.Handled = true;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            Insert_Customer();
        }

        void Search()
        {
            try
            {
                Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;

                string _name = txtRenterName.Text.ToUpper();
                if (_name == "") _name = CommonData.c_All_Value;

                string _phone = txtPhone.Text.ToUpper();
                if (_phone == "") _phone = CommonData.c_All_Value;

                c_lst = c_Customer_Controller.Customer_Search(_name, _phone);

                Mouse.OverrideCursor = null;
                dgrRenter.ItemsSource = c_lst;
                DataGridHelper.NVSFocus(dgrRenter, 0, 0);
            }
            catch (Exception ex)
            {
                Mouse.OverrideCursor = null;
                ErrorLog.log.Error(ex.ToString());
            }
        }

        void Insert_Customer()
        {
            try
            {
                Customer_Insert _Customer_Insert = new Customer_Insert();
                _Customer_Insert.Owner = Window.GetWindow(this);
                _Customer_Insert.ShowDialog();

                if (_Customer_Insert.c_id_insert != 0)
                {
                    Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;

                    Search();

                    DBMemory.LoadFeeRender();

                    for (int i = 0; i < c_lst.Count; i++)
                    {
                        Customer_Info ui = (Customer_Info)c_lst[i];
                        if (ui.Customer_Id == _Customer_Insert.c_id_insert)
                        {
                            c_row_select = i;
                            _Customer_Insert.c_id_insert = 0;
                            break;
                        }
                    }
                }

                Mouse.OverrideCursor = null;
                DataGridHelper.NVSFocus(dgrRenter, c_row_select, 0);
            }
            catch (Exception ex)
            {
                Mouse.OverrideCursor = null;
                CommonData.log.Error(ex.ToString());
            }
        }
    }
}
