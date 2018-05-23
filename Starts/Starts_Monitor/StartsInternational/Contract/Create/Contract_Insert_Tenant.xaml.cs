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
using System.Globalization;
using System.Data;
using StartsInternational.Contract.Create;

namespace StartsInternational.Contract
{
    /// <summary>
    /// Interaction logic for Contract_Insert_Renter.xaml
    /// </summary>
    public partial class Contract_Insert_Tenant : Window
    {

        #region Contrustor and params

        public Contract_Insert_Tenant()
        {
            InitializeComponent();
        }

        Estate_Object_Controller _Estate_Object_Controller = new Estate_Object_Controller();
        Customer_Controller c_Customer_Controller = new Customer_Controller();
        Contract_Controller _Contract_Controller = new Contract_Controller();
        Fees_Revenue_Controller _Fees_Revenue_Controller = new Fees_Revenue_Controller();

        bool c_is_option_pay = false;

        List<Fees_Revenue_Info> c_lst_Fee = new List<Fees_Revenue_Info>();
        int c_rowselect = 0;
        bool c_ok = true; // biến check đúng dữ liệu
        bool c_change = false; // xem có sữ ~ về dữ liệu hay không
        public decimal c_id_insert = 0;

        Estate_Object_Info c_Estate_Object_Info_Search = new Estate_Object_Info();

        #endregion

        #region Event

        private void frmContract_Insert_Tenant_Loaded_1(object sender, RoutedEventArgs e)
        {
            LoadData();
            btnChoseEstate.Focus();
        }

        private void frmContract_Insert_Tenant_KeyDown_1(object sender, KeyEventArgs e)
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
            //        lbl_Estate_Code.Content = _Estate_Object_Info.Estate_Code;
            //        lbl_Estate_Type_Name.Content = _Estate_Object_Info.Estate_Type_Name;
            //        lbl_Estate_Area.Content = _Estate_Object_Info.Area;

            //        // lấy thông tin của ng sở hữu nếu có
            //        //Contract_Info _Contract_Info = _Estate_Object_Controller.Estate_Object_GetByObject(_Estate_Object_Info.Estate_Id, (decimal)Enum_Contract_Type.Renter);
            //        lbl_Address.Content = _Estate_Object_Info.Address;

            //        // lấy thông tin của thằng thê
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ErrorLog.log.Error(ex.ToString());
            //}
        }

        private void cboPayStatus_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //AllCode_Info _AllCode_Info = (AllCode_Info)cboPayStatus.SelectedItem;

                //if (_AllCode_Info != null)
                //{
                //    if (_AllCode_Info.CdValue != ((decimal)Enum_Fee_Status.No_Pay).ToString())
                //    {
                //        lblNumberPay.Visibility = Visibility.Collapsed;
                //        txtNumberPay.Visibility = Visibility.Collapsed;

                //        c_is_option_pay = false;
                //    }
                //    else
                //    {
                //        lblNumberPay.Visibility = Visibility.Visible;
                //        txtNumberPay.Visibility = Visibility.Visible;
                //        c_is_option_pay = true;
                //    }
                //}
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
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
                    case "txtFeeOnePay":
                        CommonFunction.Text_Change_Format_Money(txtFeeOnePay);
                        break;
                    case "txtNumberPay":
                        CommonFunction.Text_Change_Format_Money(txtNumberPay);
                        break;
                    case "txtPrice":
                        CommonFunction.Text_Change_Format_Money(txtPrice);
                        break;
                }
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }

        }

        private void dpContractDate_PreviewLostKeyboardFocus_1(object sender, KeyboardFocusChangedEventArgs e)
        {
            try
            {
                //dpPaymentExpected.Text = dpContractDate.Text;
                //dpPayment.Text = dpContractDate.Text;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        private void txtFee_PreviewLostKeyboardFocus_1(object sender, KeyboardFocusChangedEventArgs e)
        {
            try
            {
                Create_DataFee_Maturity();
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        private void cboTerm_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                AllCode_Info _AllCode_Info = (AllCode_Info)cboTerm.SelectedItem;

                if (_AllCode_Info != null)
                {
                    if (_AllCode_Info.CdValue != ((decimal)Enum_Fee_Maturity.Option).ToString())
                    {
                        lblNumberPay.Visibility = Visibility.Collapsed;
                        txtNumberPay.Visibility = Visibility.Collapsed;
                        btnCall.Visibility = Visibility.Collapsed;
                        txtFeeOnePay.IsReadOnly = true;
                        c_is_option_pay = false;

                        Create_DataFee_Maturity();
                    }
                    else
                    {
                        lblNumberPay.Visibility = Visibility.Visible;
                        txtNumberPay.Visibility = Visibility.Visible;
                        btnCall.Visibility = Visibility.Visible;
                        txtFeeOnePay.IsReadOnly = false;
                        c_is_option_pay = true;


                        c_lst_Fee = new List<Fees_Revenue_Info>();
                        dgrFee.ItemsSource = c_lst_Fee;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        private void dgrFee_LoadingRow_1(object sender, DataGridRowEventArgs e)
        {

        }

        private void dgrFee_PreviewKeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                e.Handled = true;
            }
        }

        private void btnCall_Click_1(object sender, RoutedEventArgs e)
        {
            Create_DataFee_Maturity();
        }

        private void dgrFee_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                c_rowselect = dgrFee.SelectedIndex;
                string tem = "";
                if (e.EditingElement.ToString() != "")
                {
                    tem = ((System.Windows.Controls.TextBox)(e.EditingElement)).Text;

                    if (tem != txtFeeOnePay.Text)
                    {
                        c_change = true;
                    }
                }

                if (tem == "")
                {
                    c_ok = false;
                    DataGridHelper.NVSFocus(dgrFee, c_rowselect, 2);
                }
                tem = tem.Replace(",", "").Trim();

                if (!CheckGiaDuong(tem))
                {
                    c_ok = false;
                    DataGridHelper.NVSFocus(dgrFee, c_rowselect, 2);
                }
                else c_ok = true;
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
                //List<Estate_Object_Info> _lst = _Estate_Object_Controller.Estate_Object_GetCbo((decimal)Enum_Contract_Type.Tenant);

                //cboChose_Estate_Object.ItemsSource = _lst;
                //cboChose_Estate_Object.DisplayMemberPath = "Estate_Name";
                //cboChose_Estate_Object.SelectedValuePath = "Estate_Id";
                //cboChose_Estate_Object.SelectedIndex = 0;

                List<AllCode_Info> _lst_Currency = DBMemory.AllCode_GetBy_CdNameCdType("CONTRACT", "CURENCY");
                cboCurrency.ItemsSource = _lst_Currency;
                cboCurrency.DisplayMemberPath = "Content";
                cboCurrency.SelectedValuePath = "CdValue";
                cboCurrency.SelectedIndex = 0;

                List<AllCode_Info> _lst_Term = DBMemory.AllCode_GetBy_CdNameCdType("FEE", "TERM");
                cboTerm.ItemsSource = _lst_Term;
                cboTerm.DisplayMemberPath = "Content";
                cboTerm.SelectedValuePath = "CdValue";
                cboTerm.SelectedIndex = 0;

                txtContract_Code.Text = "SIVN/HDMG/OW_" ;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        bool Tenat_CheckValidate()
        {
            try
            {
                #region Tenat

                if (txtChose_Estate_Object.Text == "")
                {
                    NoteBox.Show("Tên đối tượng BĐS không được để trống", "", NoteBoxLevel.Error);
                    tabContract.Focus();
                    UpdateLayout();
                    txtChose_Estate_Object.Focus();
                    return false;
                }

                if (_Contract_Controller.CheckEstateByContract(c_Estate_Object_Info_Search.Estate_Id, (decimal)Enum_Contract_Type.Tenant) == false)
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

                if (txtUsers.Text == "")
                {
                    NoteBox.Show("Người sử dụng không được để trống", "", NoteBoxLevel.Error);
                    tabContract.Focus();
                    UpdateLayout();
                    txtUsers.Focus();
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

                if (!_Contract_Controller.Check_ExistContractCode(txtContract_Code.Text))
                {
                    NoteBox.Show("Mã hợp đồng đã tồn tại, tạo lại mã", "", NoteBoxLevel.Error);
                    tabContract.Focus();
                    UpdateLayout();
                    txtContract_Code.Focus();
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

                if (txtPrice.Text == "")
                {
                    NoteBox.Show("Tiền thuê nhà không được để trống", "", NoteBoxLevel.Error);
                    tabContract.Focus();
                    UpdateLayout();
                    txtPrice.Focus();
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

                if (txtFeeOnePay.Text == "")
                {
                    NoteBox.Show("Số tiền 1 lần thanh toán không được để trống", "", NoteBoxLevel.Error);
                    tabFee.Focus();
                    UpdateLayout();
                    txtFeeOnePay.Focus();
                    return false;
                }

                if (Check_validate_Fee() == false)
                {
                    tabFee.Focus();
                    UpdateLayout();
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
                    txtFeeOnePay.Focus();
                    return false;
                }

                if (c_ok == false)
                {
                    NoteBox.Show("Số tiền 1 lần thanh toán không đúng định dạng", "", NoteBoxLevel.Error);
                    tabFee.Focus();
                    UpdateLayout();
                    return false;
                }

                for (int i = 0; i < c_lst_Fee.Count; i++)
                {
                    Fees_Revenue_Info item = c_lst_Fee[i];

                    string _tem = item.Fee_Expected.ToString().Replace(",", "").Trim();
                    if (CheckGiaDuong(_tem) == false)
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

        void Create_DataFee_Maturity()
        {
            try
            {
                c_lst_Fee = new List<Fees_Revenue_Info>();

                decimal _fee_one_pay = 0;
                decimal _term_pay_chose = Convert.ToDecimal(cboTerm.SelectedValue);
                int _number_pay = 1;
                int _number_Ternm = 1;

                // lấy thời gian thuê nhà theo tháng

                int _month = Call_Month_ByRangeDate(ConvertData.ConvertString2Date(dpFromDate.Text), ConvertData.ConvertString2Date(dpToDate.Text));

                // lấy kỳ hạn thanh toán
                if (_term_pay_chose == (decimal)Enum_Fee_Maturity.One)
                {
                    _number_pay = 1;
                }
                else if (_term_pay_chose == (decimal)Enum_Fee_Maturity.One_Month)
                {
                    _number_pay = _month / 1;
                    _number_Ternm = 1;
                }
                else if (_term_pay_chose == (decimal)Enum_Fee_Maturity.Three_Month)
                {
                    _number_pay = _month / 3;
                    _number_Ternm = 3;
                }
                else if (_term_pay_chose == (decimal)Enum_Fee_Maturity.Six_Month)
                {
                    _number_pay = _month / 6;
                    _number_Ternm = 6;
                }
                else if (_term_pay_chose == (decimal)Enum_Fee_Maturity.One_Year)
                {
                    _number_Ternm = 12;
                    if (_month < 12)
                        _number_pay = 1;
                    else
                        _number_pay = _month / 12;
                }

                _fee_one_pay = Math.Round(Convert.ToDecimal(txtFee.Text) / _number_pay);
                if (c_is_option_pay == true)
                {
                    if (txtFeeOnePay.Text == "")
                    {
                        NoteBox.Show("Số tiền 1 lần thanh toán không được để trống", "", NoteBoxLevel.Error);
                        return;
                    }

                    if (txtNumberPay.Text == "")
                    {
                        NoteBox.Show("Số lần thanh toán không được để trống", "", NoteBoxLevel.Error);
                        return;
                    }
                    _fee_one_pay = Convert.ToDecimal(txtFeeOnePay.Text);
                    _number_pay = Convert.ToInt16(txtNumberPay.Text);

                    _number_Ternm = _month / _number_pay;
                }

                txtFeeOnePay.Text = _fee_one_pay.ToString();

                if (_number_pay > 0)
                {
                    for (int i = 0; i < _number_pay; i++)
                    {
                        int _add_month = (i + 1) * _number_Ternm;

                        Fees_Revenue_Info _Fees_Revenue_Info = new Fees_Revenue_Info();
                        _Fees_Revenue_Info.Number_Payment = i + 1;
                        _Fees_Revenue_Info.Object_Type = (decimal)Enum_Contract_Type.Tenant;
                        _Fees_Revenue_Info.Fee_Expected = _fee_one_pay;

                        _Fees_Revenue_Info.Pay_Date_Expected = ConvertData.ConvertString2Date(dpFromDate.Text).AddMonths(3);

                        // nếu thanh toán 1 lần thì lấy ngày thanh toán  = ngày ký hợp đồng luôn
                        if (_number_pay == 1)
                        {
                            _Fees_Revenue_Info.Pay_Date_Expected = ConvertData.ConvertString2Date(dpContractDate.Text);
                        }
                        else
                        {
                            if (i == 0)
                            {
                                _Fees_Revenue_Info.Pay_Date_Expected = ConvertData.ConvertString2Date(dpFromDate.Text);
                            }
                            else
                            {
                                Fees_Revenue_Info _Fees_Pre = c_lst_Fee[i - 1];

                                // nếu không thì cứ lấy ngày bắt đầu thuê nhà + thêm kỳ hạn thanh toán
                                //_Fees_Revenue_Info.Pay_Date_Expected = ConvertData.ConvertString2Date(dpFromDate.Text).AddMonths(_add_month-1);
                                _Fees_Revenue_Info.Pay_Date_Expected = _Fees_Pre.Pay_Date_Expected.AddMonths(_number_Ternm);


                                if (_Fees_Revenue_Info.Pay_Date_Expected > ConvertData.ConvertString2Date(dpToDate.Text))
                                {
                                    _Fees_Revenue_Info.Pay_Date_Expected = ConvertData.ConvertString2Date(dpToDate.Text);
                                }
                            }
                        }
                        c_lst_Fee.Add(_Fees_Revenue_Info);
                    }
                }

                dgrFee.ItemsSource = c_lst_Fee;
                dgrFee.Items.Refresh();
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
                _Customer_Info.Customer_Name = txtRenter_Name.Text;
                _Customer_Info.Address = txtAddress.Text;
                _Customer_Info.Phone = txtPhone.Text;
                _Customer_Info.Identity_Card = txtIdentity_Card.Text;
                _Customer_Info.Fax = txtFax.Text;
                _Customer_Info.Customer_Type = (decimal)Enum_Contract_Type.Tenant;
                _Customer_Info.Is_Person = 0;
                _Customer_Info.Tax_Code = txtTaxCode.Text;
                _Customer_Info.Position = txtPosition.Text;
                return _Customer_Info;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return null;
            }
        }

        Contract_Info Get_Contract_Info(decimal p_object_id)
        {
            try
            {
                Contract_Info _Contract_Info = new Contract_Info();
                _Contract_Info.Contract_Code = txtContract_Code.Text;
                _Contract_Info.Contract_Name = txtContract_Name.Text;
                _Contract_Info.Contract_Date = ConvertData.ConvertString2Date(dpContractDate.Text);
                _Contract_Info.Status = (decimal)Enum_Contract_Status.Con_Han;

                _Contract_Info.Fee = Convert.ToDecimal(txtFee.Text);
                _Contract_Info.Price = Convert.ToDecimal(txtPrice.Text);
                _Contract_Info.Pay_Count = c_lst_Fee.Count;
                _Contract_Info.Term = Convert.ToDecimal(cboTerm.SelectedValue);

                _Contract_Info.Currency = Convert.ToDecimal(cboCurrency.SelectedValue);

                _Contract_Info.Contract_FromDate = ConvertData.ConvertString2Date(dpFromDate.Text);
                _Contract_Info.Contract_ToDate = ConvertData.ConvertString2Date(dpToDate.Text);
                _Contract_Info.Object_Type = (decimal)Enum_Contract_Type.Tenant;
                _Contract_Info.Contract_Type = (decimal)Enum_Contract_Type.Tenant;

                _Contract_Info.Object_Id = p_object_id;
                _Contract_Info.Estate_Id = c_Estate_Object_Info_Search.Estate_Id;

                _Contract_Info.Contract_FromDate = ConvertData.ConvertString2Date(dpContractDate.Text);
                _Contract_Info.FeeOnePay = Convert.ToDecimal(txtFeeOnePay.Text);

                _Contract_Info.Created_Date = DateTime.Now;
                _Contract_Info.Created_By = CommonData.c_Urser_Info.User_Name;
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

        /// <summary>
        /// Tính ra số tháng thuê nhà theo khoảng ngày truyền vào
        /// </summary>
        int Call_Month_ByRangeDate(DateTime date1, DateTime date2)
        {
            try
            {
                var listOfMonths = new List<string>();
                if (date1.CompareTo(date2) == 1)
                {
                    var temp = date2;
                    date2 = date1;
                    date1 = temp;
                }

                var mosSt = date1.Month;
                var mosEn = date2.Month;
                var yearSt = date1.Year;
                var yearEn = date2.Year;

                while ((mosSt <= mosEn) || yearSt < yearEn)
                {
                    var temp = new DateTime(yearSt, mosSt, 1);
                    listOfMonths.Add(temp.ToString("MM", CultureInfo.InvariantCulture));
                    mosSt++;

                    if (temp.Month == mosEn && temp.Year == yearEn)
                    {
                        return listOfMonths.Count;
                    }

                    if (temp.ToString("MM", CultureInfo.InvariantCulture) != "12") continue;
                    yearSt++;
                    mosSt = 1;
                }

                return listOfMonths.Count;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return -1;
            }
        }

        /// <summary>
        /// Kiểm tra xem có lớn hơn 0 hay không
        /// </summary>
        /// <param name="st"></param>
        /// <returns></returns>
        bool CheckGiaDuong(string st)
        {
            try
            {
                if (st.Contains(",") || st.Contains("."))
                    return false;
                else
                {
                    decimal Num;

                    bool isNum = decimal.TryParse(st, out Num);

                    if (isNum)
                    {
                        decimal.TryParse(st, out Num);
                        if (Num < 0)
                            return false;
                        else return true;
                    }
                    else
                        return false;
                }
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
                if (Tenat_CheckValidate() == false) return;

                MessageBoxResult result = NoteBox.Show("Bạn có muốn thêm hợp đồng này hay không?", "Thông báo", NoteBoxLevel.Question);
                if (MessageBoxResult.Yes != result)
                {
                    return;
                }

                #region Thêm mới khách hàng
                Customer_Info _Customer_Info = Get_Customer_Info();
                if (_Customer_Info == null)
                {
                    NoteBox.Show("Lỗi khởi tạo khách cho thuê nhà", "", NoteBoxLevel.Error);
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
                    NoteBox.Show("Lỗi thêm mới hợp đồng cho thuê nhà", "", NoteBoxLevel.Error);
                    c_Customer_Controller.Customer_Delete(_customer_id);
                    return;
                }
                
                #endregion

                #region Phí môi giới
                foreach (Fees_Revenue_Info _Fees_Revenue_Info in c_lst_Fee)
                {
                    _Fees_Revenue_Info.Contract_Id = _contract_id;
                    _Fees_Revenue_Info.Object_Id = _customer_id;
                    _Fees_Revenue_Info.Object_Type = (decimal)Enum_Contract_Type.Tenant;
                    _Fees_Revenue_Info.Currency = Convert.ToDecimal(cboCurrency.SelectedValue);
                    _Fees_Revenue_Info.Fee = 0;
                    _Fees_Revenue_Info.Debit_Amount = _Fees_Revenue_Info.Fee_Expected - _Fees_Revenue_Info.Fee;
                    _Fees_Revenue_Info.Is_Extend = 0;
                    _Fees_Revenue_Info.Fee_Vnd = 0;

                    if (_Fees_Revenue_Info.Fee != 0)
                    {
                        _Fees_Revenue_Info.Pay_Status = (decimal)Enum_Fee_Status.Payed;
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

                txtContract_Code.Text = "SIVN/HDMG/OW_" + _str_contract_id;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        #endregion
    }

    public static class StatusPayment
    {
        public static DataView GetStatus()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("StatusId");
            dt.Columns.Add("StatusName");
            dt.Rows.Add("0", "Chưa thanh toán");
            dt.Rows.Add("1", "Đã thanh toán");
            return dt.DefaultView;
        }
    }
}
