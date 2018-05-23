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

using ObjInfo;
using MemoryData;
using Starts_Controller;
using StartsInternational.Common;
using StartsInternational.Contract.Create;

namespace StartsInternational.Contract
{
    /// <summary>
    /// Interaction logic for Contract_Insert_Renter.xaml
    /// </summary>
    public partial class Contract_Insert_Renter : Window
    {

        #region Contrustor and params

        public Contract_Insert_Renter()
        {
            InitializeComponent();
        }

        Estate_Object_Controller _Estate_Object_Controller = new Estate_Object_Controller();
        Contract_Controller _Contract_Controller = new Contract_Controller();
        Fees_Revenue_Controller _Fees_Revenue_Controller = new Fees_Revenue_Controller();
        Customer_Controller c_Customer_Controller = new Customer_Controller();

        public decimal c_id_insert = 0;

        List<Fees_Revenue_Info> c_lst_Fee = new List<Fees_Revenue_Info>();
        bool c_ok = true; // biến check đúng dữ liệu
        bool c_change = false; // xem có sữ ~ về dữ liệu hay không

        Estate_Object_Info c_Estate_Object_Info_Search = new Estate_Object_Info();

        #endregion

        #region Event

        private void frmContract_Insert_Renter_Loaded_1(object sender, RoutedEventArgs e)
        {
            LoadData();
            btnChoseEstate.Focus();
        }

        private void frmContract_Insert_Renter_KeyDown_1(object sender, KeyEventArgs e)
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

        private void cboChose_Estate_Object_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            //try
            //{
            //    Estate_Object_Info _Estate_Object_Info = (Estate_Object_Info)cboChose_Estate_Object.SelectedItem;

            //    if (_Estate_Object_Info != null)
            //    {
            //        lbl_Estate_Name.Content = _Estate_Object_Info.Estate_Name;
            //        lbl_Estate_Type_Name.Content = _Estate_Object_Info.Estate_Type_Name;
            //        lbl_Estate_Code.Content = _Estate_Object_Info.Estate_Code;
            //        lbl_Estate_Area.Content = _Estate_Object_Info.Area;
            //        lbl_Address.Content = _Estate_Object_Info.Address;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ErrorLog.log.Error(ex.ToString());
            //}
        }

        private void cboPayStatus_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            //try
            //{
            //    AllCode_Info _AllCode_Info = (AllCode_Info)cboPayStatus.SelectedItem;

            //    if (_AllCode_Info != null)
            //    {
            //        if (_AllCode_Info.CdValue == ((decimal)Enum_Fee_Status.No_Pay).ToString())
            //        {
            //            txtFeePay.Visibility = Visibility.Collapsed;
            //            lblFeePay.Visibility = Visibility.Collapsed;

            //            lblPayDate.Visibility = Visibility.Collapsed;
            //            dpPayment.Visibility = Visibility.Collapsed;

            //            c_is_pay = false;
            //        }
            //        else
            //        {
            //            txtFeePay.Visibility = Visibility.Visible;
            //            lblFeePay.Visibility = Visibility.Visible;

            //            lblPayDate.Visibility = Visibility.Visible;
            //            dpPayment.Visibility = Visibility.Visible;
            //            dpPayment.Text = DateTime.Now.ToString("dd/MM/yyyy");

            //            c_is_pay = true;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ErrorLog.log.Error(ex.ToString());
            //}
        }

        private void btnChapNhan_Click_1(object sender, RoutedEventArgs e)
        {
            Accept();
        }

        private void btnHuy_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                TextBox textbox = (TextBox)e.Source;
                switch (textbox.Name)
                {
                    case "txtFee":
                        CommonFunction.Text_Change_Format_Money(txtFee);
                        break;
                    case "txtPrice":
                        CommonFunction.Text_Change_Format_Money(txtPrice);
                        break;
                    case "txtFee_Vnd":
                        CommonFunction.Text_Change_Format_Money(txtFee_Vnd);
                        break;
                }
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }

        }

        private void dgrFee_PreviewKeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                e.Handled = true;
            }
        }

        private void dgrFee_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                string tem = "";
                if (e.EditingElement.ToString() != "")
                {
                    tem = ((System.Windows.Controls.TextBox)(e.EditingElement)).Text;
                }

                if (tem == "")
                {
                    c_ok = false;
                    DataGridHelper.NVSFocus(dgrFee, 0, 2);
                }

                tem = tem.Replace(",", "").Trim();

                if (!CheckValidate.CheckGiaDuong(tem))
                {
                    c_ok = false;
                    DataGridHelper.NVSFocus(dgrFee, 0, 2);
                }
                else c_ok = true;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        private void btnCall_Click(object sender, RoutedEventArgs e)
        {
            Create_Fee();
        }

        private void cboCurrency_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                AllCode_Info _AllCode_Info = (AllCode_Info)cboCurrency.SelectedItem;
                if (_AllCode_Info == null) return;

                if (_AllCode_Info.CdValue == ((decimal)Enum_Contract_Currency.USD).ToString())
                {
                    lblThanhTien.Visibility = Visibility.Visible;
                    txtFee_Vnd.Visibility = Visibility.Visible;
                    lblVND.Visibility = Visibility.Visible;
                }
                else
                {
                    lblThanhTien.Visibility = Visibility.Collapsed;
                    txtFee_Vnd.Visibility = Visibility.Collapsed;
                    lblVND.Visibility = Visibility.Collapsed;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        private void btnChose_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Chose_Customer _Chose_Customer = new Chose_Customer();
                _Chose_Customer.Owner = Window.GetWindow(this);
                _Chose_Customer.ShowDialog();

                if (_Chose_Customer.c_ok == 1)
                {
                    Customer_Info _Customer_Info = _Chose_Customer.c_Customer_Info_Search;

                    txtRenter_Name.Text = _Customer_Info.Customer_Name;
                    txtAddress.Text = _Customer_Info.Address;
                    txtPhone.Text = _Customer_Info.Phone;
                    txtFax.Text = _Customer_Info.Fax;
                    txtIdentity_Card.Text = _Customer_Info.Identity_Card;
                    txtTaxCode.Text = _Customer_Info.Tax_Code;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        private void btnChoseEstate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Chose_Estate_Object _Chose_Estate_Object = new Chose_Estate_Object();
                _Chose_Estate_Object.Owner = Window.GetWindow(this);
                _Chose_Estate_Object.ShowDialog();

                if (_Chose_Estate_Object.c_ok == 1)
                {
                    c_Estate_Object_Info_Search = _Chose_Estate_Object.c_Estate_Object_Info_Search;

                    txtChose_Estate_Object.Text = c_Estate_Object_Info_Search.Estate_Code;
                    lbl_Estate_Name.Content = c_Estate_Object_Info_Search.Estate_Name;
                    lbl_Estate_Type_Name.Content = c_Estate_Object_Info_Search.Estate_Type_Name;
                    lbl_Estate_Code.Content = c_Estate_Object_Info_Search.Estate_Code;
                    lbl_Estate_Area.Content = c_Estate_Object_Info_Search.Area;
                    lbl_Address.Content = c_Estate_Object_Info_Search.Address;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        private void btnCode_Click_1(object sender, RoutedEventArgs e)
        {
            AutoCreate_ContractCode();
        }

        #endregion

        #region Methods

        void LoadData()
        {
            try
            {
                //List<Estate_Object_Info> _lst = _Estate_Object_Controller.Estate_Object_GetCbo((decimal)Enum_Contract_Type.Renter);

                //cboChose_Estate_Object.ItemsSource = _lst;
                //cboChose_Estate_Object.DisplayMemberPath = "Estate_Name";
                //cboChose_Estate_Object.SelectedValuePath = "Estate_Id";
                //cboChose_Estate_Object.SelectedIndex = 0;

                List<AllCode_Info> _lst_Currency = DBMemory.AllCode_GetBy_CdNameCdType("CONTRACT", "CURENCY");
                cboCurrency.ItemsSource = _lst_Currency;
                cboCurrency.DisplayMemberPath = "Content";
                cboCurrency.SelectedValuePath = "CdValue";
                cboCurrency.SelectedIndex = 0;

                //decimal _contract_id = _Contract_Controller.Get_Max_Contract_Id();
                //string _str_contract_id = "";
                ////00001
                //if (_contract_id < 10)
                //{
                //    _str_contract_id = "0000" + _contract_id.ToString();
                //}
                //else if (_contract_id <= 99)
                //{
                //    _str_contract_id = "000" + _contract_id.ToString();
                //}
                //else if (_contract_id <= 999)
                //{
                //    _str_contract_id = "00" + _contract_id.ToString();
                //}
                //else if (_contract_id <= 9999)
                //{
                //    _str_contract_id = "0" + _contract_id.ToString();
                //}
                //else
                //{
                //    _str_contract_id = _contract_id.ToString();
                //}

                txtContract_Code.Text = "SIVN/HDMG_";
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        bool Renter_CheckValidate()
        {
            try
            {
                #region Renter
                if (txtChose_Estate_Object.Text == "")
                {
                    NoteBox.Show("Tên đối tượng BĐS không được để trống", "", NoteBoxLevel.Error);
                    tabContract.Focus();
                    UpdateLayout();
                    txtChose_Estate_Object.Focus();
                    return false;
                }

                if (_Contract_Controller.CheckEstateByContract(c_Estate_Object_Info_Search.Estate_Id, (decimal)Enum_Contract_Type.Renter) == false)
                {
                    NoteBox.Show("Đối tượng BĐS được cho thuê", "", NoteBoxLevel.Error);
                    tabContract.Focus();
                    UpdateLayout();
                    txtChose_Estate_Object.Focus();
                    return false;
                }

                if (txtRenter_Name.Text == "")
                {
                    NoteBox.Show("Tên công ty yêu cầu môi giới không được để trống", "", NoteBoxLevel.Error);
                    tabContract.Focus();
                    UpdateLayout();
                    txtRenter_Name.Focus();
                    return false;
                }

                if (txtAddress.Text == "")
                {
                    NoteBox.Show("Địa chỉ công ty yêu cầu môi giới không được để trống", "", NoteBoxLevel.Error);
                    tabContract.Focus();
                    UpdateLayout();
                    txtAddress.Focus();
                    return false;
                }

                if (txtUsers.Text == "")
                {
                    NoteBox.Show("Tên người sử dụng không được để trống", "", NoteBoxLevel.Error);
                    tabContract.Focus();
                    UpdateLayout();
                    txtUsers.Focus();
                    return false;
                }

                if (txtRepresentive.Text == "")
                {
                    NoteBox.Show("Tên người đại diện không được để trống", "", NoteBoxLevel.Error);
                    tabContract.Focus();
                    UpdateLayout();
                    txtRepresentive.Focus();
                    return false;
                }

                if (txtPhone.Text == "")
                {
                    NoteBox.Show("Số điện thoại không được để trống", "", NoteBoxLevel.Error);
                    tabContract.Focus();
                    UpdateLayout();
                    txtPhone.Focus();
                    return false;
                }
                #endregion

                #region Contract

                if (txtContract_Code.Text == "")
                {
                    NoteBox.Show("Mã hợp đồng không được để trống", "", NoteBoxLevel.Error);
                    tabContract.Focus();
                    UpdateLayout();
                    txtContract_Code.Focus();
                    return false;
                }

                //if (txtContract_Name.Text == "")
                //{
                //    NoteBox.Show("Tên hợp đồng không được để trống", "", NoteBoxLevel.Error);
                //    tabContract.Focus();
                //    UpdateLayout();
                //    txtContract_Name.Focus();
                //    return false;
                //}


                if (!_Contract_Controller.Check_ExistContractCode(txtContract_Code.Text))
                {
                    NoteBox.Show("Mã hợp đồng đã tồn tại, tạo lại mã", "", NoteBoxLevel.Error);
                    tabContract.Focus();
                    UpdateLayout();
                    txtContract_Code.Focus();
                    return false;
                }

                if (dpFromDate.Text == "")
                {
                    NoteBox.Show("Thời gian thuê từ ngày không được để trống", "", NoteBoxLevel.Error);
                    tabContract.Focus();
                    UpdateLayout();
                    dpFromDate.Focus();
                    return false;
                }
                if (CheckValidate.CheckValidDate(dpFromDate.Text) == false)
                {
                    NoteBox.Show("Thời gian thuê từ ngày không đúng định dạng", "", NoteBoxLevel.Error);
                    tabContract.Focus();
                    UpdateLayout();
                    dpFromDate.Focus();
                    return false;
                }

                if (dpToDate.Text == "")
                {
                    NoteBox.Show("Thời gian thuê đến ngày không được để trống", "", NoteBoxLevel.Error);
                    tabContract.Focus();
                    UpdateLayout();
                    dpToDate.Focus();
                    return false;
                }
                if (CheckValidate.CheckValidDate(dpToDate.Text) == false)
                {
                    NoteBox.Show("Thời gian thuê đến ngày không đúng định dạng", "", NoteBoxLevel.Error);
                    tabContract.Focus();
                    UpdateLayout();
                    dpToDate.Focus();
                    return false;
                }

                if (dpContractDate.Text == "")
                {
                    NoteBox.Show("Ngày ký hợp đồng không được để trống", "", NoteBoxLevel.Error);
                    tabContract.Focus();
                    UpdateLayout();
                    dpContractDate.Focus();
                    return false;
                }
                if (CheckValidate.CheckValidDate(dpContractDate.Text) == false)
                {
                    NoteBox.Show("Ngày ký hợp đồng không đúng định dạng", "", NoteBoxLevel.Error);
                    tabContract.Focus();
                    UpdateLayout();
                    dpContractDate.Focus();
                    return false;
                }

                if (ConvertData.ConvertString2Date(dpFromDate.Text).Date > ConvertData.ConvertString2Date(dpToDate.Text).Date)
                {
                    NoteBox.Show("Thời gian thuê từ ngày phải nhỏ hơn đến ngày", "", NoteBoxLevel.Error);
                    tabContract.Focus();
                    UpdateLayout();
                    dpFromDate.Focus();
                    return false;
                }

                #endregion

                #region Fee

                if (txtFee.Text == "")
                {
                    NoteBox.Show("Phí môi giới không được để trống", "", NoteBoxLevel.Error);
                    tabFee.Focus();
                    UpdateLayout();
                    txtFee.Focus();
                    return false;
                }

                if (!Check_validate_Fee())
                {
                    
                    UpdateLayout();
                    txtFee.Focus();
                    return false;
                }

                decimal _currecy = Convert.ToDecimal(cboCurrency.SelectedValue);
                if ((_currecy == (decimal)Enum_Contract_Currency.USD) && txtFee_Vnd.Text == "")
                {
                    NoteBox.Show("Phí môi giới (VND) không được để trống", "", NoteBoxLevel.Error);
                    tabFee.Focus();
                    UpdateLayout();
                    txtFee_Vnd.Focus();
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

        bool Check_validate_Fee()
        {

            try
            {
                if (c_lst_Fee.Count == 0)
                {
                    NoteBox.Show("Không có thông tin thanh toán phí gia hạn", "", NoteBoxLevel.Error);
                    tabFee.Focus();
                    UpdateLayout();
                    return false;
                }

                if (c_ok == false)
                {
                    NoteBox.Show("Số tiền thanh toán không đúng định dạng", "", NoteBoxLevel.Error);
                    tabFee.Focus();
                    UpdateLayout();
                    return false;
                }

                for (int i = 0; i < c_lst_Fee.Count; i++)
                {
                    Fees_Revenue_Info item = c_lst_Fee[i];

                    string _tem = item.Fee_Expected.ToString().Replace(",", "").Trim();
                    if (CheckValidate.CheckGiaDuong(_tem) == false)
                    {
                        tabFee.Focus();
                        UpdateLayout();
                        DataGridHelper.NVSFocus(dgrFee, i, 2);
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        Customer_Info Get_Customer_Info()
        {
            try
            {
                Customer_Info _Customer_Info = new Customer_Info();
                _Customer_Info.Customer_Name = txtRenter_Name.Text;
                _Customer_Info.Address = txtAddress.Text;
                _Customer_Info.Phone = txtPhone.Text;
                _Customer_Info.Identity_Card = txtIdentity_Card.Text;
                _Customer_Info.Fax = txtFax.Text;
                _Customer_Info.Customer_Type = (decimal)Enum_Contract_Type.Renter;
                _Customer_Info.Is_Person = 1;
                _Customer_Info.Tax_Code = txtTaxCode.Text;
                _Customer_Info.Position = "";
                return _Customer_Info;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return null;
            }
        }

        Contract_Info Get_Contract_Info(decimal p_customer_id)
        {
            try
            {
                Contract_Info _Contract_Info = new Contract_Info();
                _Contract_Info.Contract_Code = txtContract_Code.Text;
                _Contract_Info.Contract_Name = txtContract_Name.Text;
                _Contract_Info.Contract_Date = ConvertData.ConvertString2Date(dpContractDate.Text);
                _Contract_Info.Contract_Type = (decimal)Enum_Contract_Type.Renter;
                _Contract_Info.Status = (decimal)Enum_Contract_Status.Con_Han;
                _Contract_Info.Term = 1;
                _Contract_Info.Pay_Count = 1;

                _Contract_Info.Fee = Convert.ToDecimal(txtFee.Text);
                _Contract_Info.Price = Convert.ToDecimal(txtPrice.Text);
                _Contract_Info.Currency = Convert.ToDecimal(cboCurrency.SelectedValue);

                _Contract_Info.Contract_FromDate = ConvertData.ConvertString2Date(dpFromDate.Text);
                _Contract_Info.Contract_ToDate = ConvertData.ConvertString2Date(dpToDate.Text);
                _Contract_Info.Object_Type = (decimal)Enum_Contract_Type.Renter;
                _Contract_Info.Object_Id = p_customer_id;

                _Contract_Info.Estate_Id = c_Estate_Object_Info_Search.Estate_Id;

                _Contract_Info.FeeOnePay = Convert.ToDecimal(txtFee.Text);
                _Contract_Info.Created_Date = DateTime.Now;
                _Contract_Info.Created_By = CommonData.c_Urser_Info.User_Name;
                _Contract_Info.Contract_FromDate = ConvertData.ConvertString2Date(dpContractDate.Text);
                _Contract_Info.Users = txtUsers.Text;
                _Contract_Info.Representive = txtRepresentive.Text;
                _Contract_Info.Contract_ToDate_Ex = _Contract_Info.Contract_ToDate;
                foreach (Fees_Revenue_Info item in c_lst_Fee)
                {
                    if (item.Fee == 0)
                    {
                        _Contract_Info.Fee_Status = (decimal)Enum_Fee_Status.No_Pay;
                        break;
                    }
                    else
                        _Contract_Info.Fee_Status = (decimal)Enum_Fee_Status.Payed;
                }
                return _Contract_Info;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return null;
            }
        }

        void Accept()
        {
            try
            {
                if (Renter_CheckValidate() == false) return;

                MessageBoxResult result = NoteBox.Show("Bạn có muốn thêm hợp đồng này hay không?", "Thông báo", NoteBoxLevel.Question);
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

                string _name = txtRenter_Name.Text.ToUpper();
                if (_name == "") _name = CommonData.c_All_Value;

                string _phone = txtPhone.Text.ToUpper();
                if (_phone == "") _phone = CommonData.c_All_Value;

                List<Customer_Info> _lst = c_Customer_Controller.Customer_Search(_name, _phone);

                if (_lst.Count > 0)
                {
                    // có rồi thì sử dụng luôn
                    // update ngược thông tin lại
                    if (c_Customer_Controller.Customer_Update(_lst[0].Customer_Id, _Customer_Info) == false)
                    {
                        NoteBox.Show("Lỗi cập nhật mới khách thuê nhà", "", NoteBoxLevel.Error);
                        return;
                    }

                    _customer_id = _lst[0].Customer_Id;
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

                #region Hợp đồng
                Contract_Info _Contract_Info = Get_Contract_Info(_customer_id);
                if (_Contract_Info == null)
                {
                    NoteBox.Show("Lỗi khởi tạo hợp đồng thuê nhà", "", NoteBoxLevel.Error);
                    return;
                }

                decimal _contract_id = _Contract_Controller.Contract_Insert(_Contract_Info);
                if (_contract_id == -1)
                {
                    NoteBox.Show("Lỗi thêm mới hợp đồng thuê nhà", "", NoteBoxLevel.Error);
                    c_Customer_Controller.Customer_Delete(_customer_id);
                    return;
                }
                #endregion

                #region Phí môi giới
                foreach (Fees_Revenue_Info _Fees_Revenue_Info in c_lst_Fee)
                {
                    _Fees_Revenue_Info.Contract_Id = _contract_id;
                    _Fees_Revenue_Info.Object_Id = _customer_id;
                    _Fees_Revenue_Info.Currency = Convert.ToDecimal(cboCurrency.SelectedValue);

                    if (_Contract_Info.Currency == (decimal)Enum_Contract_Currency.USD)
                        _Fees_Revenue_Info.Fee_Vnd = Convert.ToDecimal(txtFee_Vnd.Text);
                    else
                        _Fees_Revenue_Info.Fee_Vnd = 0;

                    if (_Fees_Revenue_Info.Fee != 0)
                    {
                        _Fees_Revenue_Info.Pay_Status = (decimal)Enum_Fee_Status.Payed;
                        _Fees_Revenue_Info.Pay_Date = DateTime.Now;
                    }

                    if (_Fees_Revenue_Controller.Fees_Revenue_Insert(_Fees_Revenue_Info) == false)
                    {
                        NoteBox.Show("Lỗi thanh toán", "", NoteBoxLevel.Error);
                        c_Customer_Controller.Customer_Delete(_customer_id);
                        _Contract_Controller.Contract_Delete(_contract_id);
                        _Fees_Revenue_Controller.Fees_Revenue_DeleteByContract(_contract_id);
                        return;
                    }
                }
                #endregion

                c_id_insert = _contract_id;

                NoteBox.Show("Thêm mới dữ liệu thành công", "");
                this.Close();
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        void Create_Fee()
        {
            try
            {
                if (txtFee.Text == "")
                {
                    NoteBox.Show("Bạn chưa nhập phí môi giới", "", NoteBoxLevel.Error);
                    return;
                }

                c_lst_Fee = new List<Fees_Revenue_Info>();
                Fees_Revenue_Info _Fees_Revenue_Info = new Fees_Revenue_Info();

                _Fees_Revenue_Info.Number_Payment = 1;
                _Fees_Revenue_Info.Object_Type = (decimal)Enum_Contract_Type.Renter;
                _Fees_Revenue_Info.Fee_Expected = Convert.ToDecimal(txtFee.Text);
                _Fees_Revenue_Info.Fee = 0;
                _Fees_Revenue_Info.Debit_Amount = _Fees_Revenue_Info.Fee_Expected;
                _Fees_Revenue_Info.Pay_Date_Expected = ConvertData.ConvertString2Date(dpFromDate.Text);
                _Fees_Revenue_Info.Is_Extend = 0;
                _Fees_Revenue_Info.Pay_Status = (decimal)Enum_Fee_Status.No_Pay;
                c_lst_Fee.Add(_Fees_Revenue_Info);

                dgrFee.ItemsSource = c_lst_Fee;
                dgrFee.Items.Refresh();
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        void AutoCreate_ContractCode()
        {
            try
            {
                decimal _contract_id = _Contract_Controller.Get_Max_Contract_Id() + 1;
                string _str_contract_id = "";
                //00001
                if (_contract_id < 10)
                {
                    _str_contract_id = "0000" + _contract_id.ToString();
                }
                else if (_contract_id <= 99)
                {
                    _str_contract_id = "000" + _contract_id.ToString();
                }
                else if (_contract_id <= 999)
                {
                    _str_contract_id = "00" + _contract_id.ToString();
                }
                else if (_contract_id <= 9999)
                {
                    _str_contract_id = "0" + _contract_id.ToString();
                }
                else
                {
                    _str_contract_id = _contract_id.ToString();
                }

                txtContract_Code.Text = "SIVN/HDMG_" + _str_contract_id;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        #endregion

    }
}
