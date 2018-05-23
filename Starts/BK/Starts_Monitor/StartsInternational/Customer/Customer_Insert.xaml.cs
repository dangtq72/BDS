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
    public partial class Customer_Insert : Window
    {
        public Customer_Insert()
        {
            InitializeComponent();
        }

        Customer_Controller c_Customer_Controller = new Customer_Controller();
        public decimal c_id_insert = 0;

        private void frmCustomer_Insert_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
            txtCustomer_Name.Focus();
        }

        private void frmCustomer_Insert_KeyDown(object sender, KeyEventArgs e)
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

                #region Thêm mới khách hàng
                Customer_Info _Customer_Info = Get_Customer_Info();
                if (_Customer_Info == null)
                {
                    NoteBox.Show("Lỗi khởi tạo khách thuê nhà", "", NoteBoxLevel.Error);
                    return;
                }
                decimal _customer_id = -1;

                // kiểm tra xem thằng tên khách hàng đó và số đt đó đã có trong db chưa
                // nếu có rồi thì ko insert nữa

                string _name = txtCustomer_Name.Text.ToUpper();
                if (_name == "") _name = CommonData.c_All_Value;

                string _phone = txtPhone.Text.ToUpper();
                if (_phone == "") _phone = CommonData.c_All_Value;

                List<Customer_Info> _lst = c_Customer_Controller.Customer_Search(_name, _phone);

                if (_lst.Count > 0)
                {
                    NoteBox.Show("Đã tồn tại khách hàng", "", NoteBoxLevel.Error);
                    return;
                }
                else
                {
                    // không có thì thêm mới
                    _customer_id = c_Customer_Controller.Customer_Insert(_Customer_Info);

                    if (_customer_id == -1)
                    {
                        NoteBox.Show("Lỗi thêm mới khách thuê nhà", "", NoteBoxLevel.Error);
                        return;
                    }
                }

                #endregion

                c_id_insert = _customer_id;
                NoteBox.Show("Thêm mới dữ liệu thành công", "");

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

                _Customer_Info.Created_By = CommonData.c_Urser_Info.User_Name;
                _Customer_Info.Created_Date = DateTime.Now;
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
