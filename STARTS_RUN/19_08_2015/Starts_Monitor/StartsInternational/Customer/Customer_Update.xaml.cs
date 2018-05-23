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
    public partial class Customer_Update : Window
    {
        public Customer_Update()
        {
            InitializeComponent();
        }

        Customer_Controller c_Customer_Controller = new Customer_Controller();
        public Customer_Info c_Customer_Info;
        public decimal c_id_insert = 0;

        private void frmCustomer_Update_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
            txtCustomer_Name.Focus();
        }

        private void frmCustomer_Update_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
            else if (e.Key == Key.Enter)
            {
                Accept();
            }
        }

        private void btnChapNhan_Click(object sender, RoutedEventArgs e)
        {
            Accept();
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

        bool Customer_CheckValidate()
        {
            try
            {
                #region Renter

                if (txtCustomer_Name.Text == "")
                {
                    NoteBox.Show("Tên công ty yêu cầu môi giới không được để trống", "", NoteBoxLevel.Error);
                    txtCustomer_Name.Focus();
                    return false;
                }

                if (txtAddress.Text == "")
                {
                    NoteBox.Show("Địa chỉ khách hàng không được để trống", "", NoteBoxLevel.Error);
                    txtAddress.Focus();
                    return false;
                }

                if (txtPhone.Text == "")
                {
                    NoteBox.Show("Số điện thoại không được để trống", "", NoteBoxLevel.Error);
                    txtPhone.Focus();
                    return false;
                }
                #endregion

                return true;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }

        }

        void Accept()
        {
            try
            {
                if (Customer_CheckValidate() == false) return;

                MessageBoxResult result = NoteBox.Show("Bạn có muốn thêm khách hàng này hay không?", "Thông báo", NoteBoxLevel.Question);
                if (MessageBoxResult.Yes != result)
                {
                    return;
                }

                
                Customer_Info _Customer_Info = Get_Customer_Info();
                if (_Customer_Info == null)
                {
                    NoteBox.Show("Lỗi khởi tạo khách thuê nhà", "", NoteBoxLevel.Error);
                    return;
                }

                if (c_Customer_Controller.Customer_Update(c_Customer_Info.Customer_Id, _Customer_Info,c_Customer_Info) == false)
                {
                    NoteBox.Show("Lỗi cập nhật mới khách thuê nhà", "", NoteBoxLevel.Error);
                    return;
                }

                c_id_insert = c_Customer_Info.Customer_Id;
                NoteBox.Show("Sửa dữ liệu thành công", "");

                this.Close();
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        Customer_Info Get_Customer_Info()
        {
            try
            {
                Customer_Info _Customer_Info = new Customer_Info();
                _Customer_Info.Customer_Name = txtCustomer_Name.Text;
                _Customer_Info.Address = txtAddress.Text;
                _Customer_Info.Phone = txtPhone.Text;
                _Customer_Info.Identity_Card = txtIdentity_Card.Text;
                _Customer_Info.Fax = txtFax.Text;
                _Customer_Info.Is_Person = Convert.ToDecimal(cboType.SelectedValue);
                _Customer_Info.Tax_Code = txtTaxCode.Text;
                _Customer_Info.Position = txtPosition.Text;

                _Customer_Info.Modifi_By = CommonData.c_Urser_Info.User_Name;
                _Customer_Info.Modifi_Date = DateTime.Now;

                return _Customer_Info;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return null;
            }
        }
    }
}
