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
using System.Collections;

namespace StartsInternational.Contract
{
    /// <summary>
    /// Interaction logic for Contract_Insert_Renter.xaml
    /// </summary>
    public partial class Update_Contract_Tenant : Window
    {

        #region Contrustor and params

        public Update_Contract_Tenant()
        {
            InitializeComponent();
        }

        Estate_Object_Controller _Estate_Object_Controller = new Estate_Object_Controller();
        Customer_Controller c_Customer_Controller = new Customer_Controller();
        Contract_Controller _Contract_Controller = new Contract_Controller();
        Extend_Contract_Controller _Extend_Contract_Controller = new Extend_Contract_Controller();
        Fees_Revenue_Controller _Fees_Revenue_Controller = new Fees_Revenue_Controller();

        bool c_is_option_pay = false;
        bool c_is_option_pay_Extend = false;

        public Contract_Info c_Contract_Info;

        Extend_Contract_Info c_Extend_Contract_Info;

        List<Fees_Revenue_Info> c_lst_Fee = new List<Fees_Revenue_Info>();
        List<Fees_Revenue_Info> c_lst_Fee_Extend = new List<Fees_Revenue_Info>();

        int c_rowselect = 0;
        int c_rowselect_Extend = 0;

        bool c_ok = true; // biến check đúng dữ liệu
        bool c_ok_Extend = true; // biến check đúng dữ liệu

        bool c_change = false; // xem có sữ ~ về dữ liệu hay không
        public decimal c_id_insert = 0;

        bool c_is_not_first = false;
        decimal c_max_number_extend = 0;

        Hashtable c_hs_fee_old = new Hashtable();
        Hashtable c_hs_fee_ex_old = new Hashtable();

        #endregion

        #region Event

        private void frmContract_Insert_Tenant_Loaded_1(object sender, RoutedEventArgs e)
        {
            LoadData();
            txtRenter_Name.Focus();
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

        private void cboPayStatus_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
        }

        private void btnChapNhan_Click_1(object sender, RoutedEventArgs e)
        {
            Accept();
        }

        private void btnHuy_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cboStatusContract_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                AllCode_Info _AllCode_Info = (AllCode_Info)cboStatusContract.SelectedItem;
                if (_AllCode_Info != null && c_is_not_first == true)
                {
                    if (_AllCode_Info.CdValue == ((decimal)Enum_Contract_Status.Gia_Han).ToString())
                    {
                        // kiểm tra xem có phải trạng thái của nó là hết hạn hợp đồng không
                        if (c_Contract_Info.Status == (decimal)Enum_Contract_Status.Het_Han)
                        {
                            tabExtend.Visibility = Visibility.Visible;
                        }
                        else if (c_Contract_Info.Status != (decimal)Enum_Contract_Status.Gia_Han)
                        {
                            NoteBox.Show("Hợp đồng chưa hết hạn, không thể gia hạn hợp đồng", "", NoteBoxLevel.Error);
                            return;
                        }
                    }
                    else
                    {
                        if (c_Contract_Info.Status == (decimal)Enum_Contract_Status.Gia_Han)
                        {
                            tabExtend.Visibility = Visibility.Visible;
                        }
                        else
                            tabExtend.Visibility = Visibility.Collapsed;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
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
                    case "txtFee_Extend":
                        CommonFunction.Text_Change_Format_Money(txtFee_Extend);
                        break;
                    case "txtFeeOnePay_Extend":
                        CommonFunction.Text_Change_Format_Money(txtFeeOnePay_Extend);
                        break;
                    case "txtNumberPay_Extend":
                        CommonFunction.Text_Change_Format_Money(txtNumberPay_Extend);
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

        private void cboTerm_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (c_is_not_first == false)
                {
                    return;
                }

                AllCode_Info _AllCode_Info = (AllCode_Info)cboTerm.SelectedItem;

                if (_AllCode_Info != null)
                {
                    if (_AllCode_Info.CdValue == c_Contract_Info.Term.ToString())
                    {
                        return;
                    }

                    if (_AllCode_Info.CdValue != ((decimal)Enum_Fee_Maturity.Option).ToString())
                    {
                        lblNumberPay.Visibility = Visibility.Collapsed;
                        txtNumberPay.Visibility = Visibility.Collapsed;
                        btnCall.Visibility = Visibility.Collapsed;
                        txtFeeOnePay.IsReadOnly = true;
                        c_is_option_pay = false;

                        if (Check_Is_ReCall_Fee((decimal)Enum_Extend_Contract.Not_Extend) == false)
                        {
                            cboTerm.SelectedValue = c_Contract_Info.Term;
                            tabFee.Focus();
                            UpdateLayout();
                            cboTerm.Focus();
                            return;
                        }

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

        private void dgrFee_PreviewKeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                e.Handled = true;
            }
        }

        private void btnCall_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = NoteBox.Show("Bạn có muốn reset lại thông tin phí thanh toán hay không?", "Thông báo", NoteBoxLevel.Question);
            if (MessageBoxResult.Yes == result)
            {
                Create_DataFee_Maturity();
            }
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

                if (!CheckValidate.CheckGiaDuong(tem))
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

        #region Gia hạn hợp đồng

        private void btnCall_Extend_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = NoteBox.Show("Bạn có muốn reset lại thông tin phí thanh toán hay không?", "Thông báo", NoteBoxLevel.Question);
            if (MessageBoxResult.Yes == result)
            {
                Create_DataFee_Maturity_Extend();
            }
        }

        private void dgrFee_Extend_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                e.Handled = true;
            }
        }

        private void dgrFee_Extend_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                c_rowselect_Extend = dgrFee_Extend.SelectedIndex;
                string tem = "";
                if (e.EditingElement.ToString() != "")
                {
                    tem = ((System.Windows.Controls.TextBox)(e.EditingElement)).Text;

                    if (tem != txtFeeOnePay_Extend.Text)
                    {
                        c_change = true;
                    }
                }

                if (tem == "")
                {
                    c_ok = false;
                    DataGridHelper.NVSFocus(dgrFee_Extend, c_rowselect_Extend, 2);
                }
                tem = tem.Replace(",", "").Trim();

                if (!CheckValidate.CheckGiaDuong(tem))
                {
                    c_ok_Extend = false;
                    DataGridHelper.NVSFocus(dgrFee_Extend, c_rowselect_Extend, 2);
                }
                else c_ok_Extend = true;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        private void cboTerm_Extend_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (c_is_not_first == false)
                {
                    return;
                }

                AllCode_Info _AllCode_Info = (AllCode_Info)cboTerm_Extend.SelectedItem;

                if (_AllCode_Info != null)
                {
                    if (c_Extend_Contract_Info != null && _AllCode_Info.CdValue == c_Extend_Contract_Info.Term.ToString())
                    {
                        return;
                    }

                    if (_AllCode_Info.CdValue != ((decimal)Enum_Fee_Maturity.Option).ToString())
                    {
                        lblNumberPay_Extend.Visibility = Visibility.Collapsed;
                        txtNumberPay_Extend.Visibility = Visibility.Collapsed;
                        btnCall_Extend.Visibility = Visibility.Collapsed;
                        txtFeeOnePay_Extend.IsReadOnly = true;
                        c_is_option_pay_Extend = false;

                        if (c_Contract_Info.Status == (decimal)Enum_Contract_Status.Gia_Han && Check_Is_ReCall_Fee((decimal)Enum_Extend_Contract.Extend) == false)
                        {
                            cboTerm_Extend.SelectedValue = c_Contract_Info.Term;
                            tabExtend.Focus();
                            UpdateLayout();
                            cboTerm_Extend.Focus();
                            return;
                        }

                        Create_DataFee_Maturity_Extend();
                    }
                    else
                    {
                        lblNumberPay_Extend.Visibility = Visibility.Visible;
                        txtNumberPay_Extend.Visibility = Visibility.Visible;
                        btnCall_Extend.Visibility = Visibility.Visible;

                        txtFeeOnePay_Extend.IsReadOnly = false;
                        c_is_option_pay_Extend = true;

                        c_lst_Fee_Extend = new List<Fees_Revenue_Info>();
                        dgrFee_Extend.ItemsSource = c_lst_Fee_Extend;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        private void txtFee_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            //try
            //{
            //    if (txtFee.Text.Replace(",", "") == c_Contract_Info.Fee.ToString())
            //    {
            //        return;
            //    }

            //    if (Check_Is_ReCall_Fee((decimal)Enum_Extend_Contract.Not_Extend) == false)
            //    {
            //        txtFee.Text = c_Contract_Info.Fee.ToString("#,##0.#");
            //        tabFee.Focus();
            //        UpdateLayout();
            //        txtFee.Focus();
            //        return;
            //    }

            //    Create_DataFee_Maturity();
            //}
            //catch (Exception ex)
            //{
            //    ErrorLog.log.Error(ex.ToString());
            //}
        }

        private void txtFee_Extend_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            //try
            //{
            //    if (c_Extend_Contract_Info != null && txtFee_Extend.Text.Replace(",", "") == c_Extend_Contract_Info.Fee.ToString())
            //    {
            //        return;
            //    }

            //    if (Check_Is_ReCall_Fee((decimal)Enum_Extend_Contract.Extend) == false)
            //    {
            //        txtFee_Extend.Text = c_Extend_Contract_Info.Fee.ToString("#,##0.#");
            //        tabExtend.Focus();
            //        UpdateLayout();
            //        txtFee_Extend.Focus();
            //        return;
            //    }

            //    Create_DataFee_Maturity_Extend();
            //}
            //catch (Exception ex)
            //{
            //    ErrorLog.log.Error(ex.ToString());
            //}
        }

        #endregion

        #endregion

        #region Methods

        void LoadData()
        {
            try
            {
                List<AllCode_Info> _lst_C_T = DBMemory.AllCode_GetBy_CdNameCdType("CONTRACT", "STATUS");

                cboStatusContract.ItemsSource = _lst_C_T;
                cboStatusContract.DisplayMemberPath = "Content";
                cboStatusContract.SelectedValuePath = "CdValue";

                List<AllCode_Info> _lst_Currency = DBMemory.AllCode_GetBy_CdNameCdType("CONTRACT", "CURENCY");
                cboCurrency.ItemsSource = _lst_Currency;
                cboCurrency.DisplayMemberPath = "Content";
                cboCurrency.SelectedValuePath = "CdValue";

                List<AllCode_Info> _lst_Term = DBMemory.AllCode_GetBy_CdNameCdType("FEE", "TERM");
                cboTerm.ItemsSource = _lst_Term;
                cboTerm.DisplayMemberPath = "Content";
                cboTerm.SelectedValuePath = "CdValue";

                cboTerm_Extend.ItemsSource = _lst_Term;
                cboTerm_Extend.DisplayMemberPath = "Content";
                cboTerm_Extend.SelectedValuePath = "CdValue";

                Estate_Object_Info _Estate_Object_Info = _Estate_Object_Controller.Estate_Object_GetById(c_Contract_Info.Estate_Id, (decimal)Enum_Contract_Type.Tenant);
                if (_Estate_Object_Info != null)
                {
                    lbl_Estate_Name.Content = _Estate_Object_Info.Estate_Name;
                    lbl_Estate_Code.Content = _Estate_Object_Info.Estate_Code;
                    lbl_Estate_Type_Name.Content = _Estate_Object_Info.Estate_Type_Name;
                    lbl_Estate_Area.Content = _Estate_Object_Info.Area;
                    lbl_Address.Content = _Estate_Object_Info.Address;
                }

                Customer_Info _Customer_Info = c_Customer_Controller.Customer_GetById(c_Contract_Info.Object_Id);
                if (_Customer_Info != null)
                {
                    txtRenter_Name.Text = _Customer_Info.Customer_Name;
                    txtAddress.Text = _Customer_Info.Address;
                    txtPhone.Text = _Customer_Info.Phone;
                    txtFax.Text = _Customer_Info.Fax;
                    txtPosition.Text = _Customer_Info.Position;
                    txtTaxCode.Text = _Customer_Info.Tax_Code;
                    txtIdentity_Card.Text = _Customer_Info.Identity_Card;
                }

                txtRepresentive.Text = c_Contract_Info.Representive;
                txtUsers.Text = c_Contract_Info.Users;

                txtContract_Code.Text = c_Contract_Info.Contract_Code;
                txtContract_Name.Text = c_Contract_Info.Contract_Name;
                dpContractDate.Text = c_Contract_Info.Contract_Date.ToString("dd/MM/yyyy");
                cboCurrency.SelectedValue = c_Contract_Info.Currency;
                dpFromDate.Text = c_Contract_Info.Contract_FromDate.ToString("dd/MM/yyyy");
                dpToDate.Text = c_Contract_Info.Contract_ToDate.ToString("dd/MM/yyyy");
                txtFee.Text = c_Contract_Info.Fee.ToString("#,##0.#");
                cboTerm.SelectedValue = c_Contract_Info.Term;
                cboStatusContract.SelectedValue = c_Contract_Info.Status;
                txtFeeOnePay.Text = c_Contract_Info.FeeOnePay.ToString("#,##0.#");

                c_max_number_extend = _Extend_Contract_Controller.Get_Number_ExtendContract(c_Contract_Info.Contract_Id);

                if (c_Contract_Info.Status == (decimal)Enum_Contract_Status.Gia_Han)
                {
                    List<Extend_Contract_Info> _lst_ex = _Extend_Contract_Controller.Extend_Contract_GetByContractId(c_Contract_Info.Contract_Id);
                    if (_lst_ex.Count > 0)
                    {
                        c_Extend_Contract_Info = _lst_ex[0];

                        txtFeeOnePay_Extend.Text = c_Extend_Contract_Info.FeeOnePay.ToString("#,##0.#");
                        txtFee_Extend.Text = c_Extend_Contract_Info.Fee.ToString("#,##0.#");
                        dpFromDate_Extend.Text = c_Extend_Contract_Info.Contract_FromDate.ToString("dd/MM/yyyy");
                        dpToDate_Extend.Text = c_Extend_Contract_Info.Contract_ToDate.ToString("dd/MM/yyyy");
                        cboTerm_Extend.SelectedValue = c_Extend_Contract_Info.Term;
                    }

                    tabExtend.Visibility = Visibility.Visible;
                    List<Fees_Revenue_Info> _lst = _Fees_Revenue_Controller.Fees_Revenue_GetByContract(c_Contract_Info.Contract_Id);
                    foreach (Fees_Revenue_Info item in _lst)
                    {
                        if (item.Is_Extend == c_max_number_extend)
                        {
                            c_lst_Fee_Extend.Add(item);
                        }
                        else
                            c_lst_Fee.Add(item);
                    }
                    btnCall.Visibility = Visibility.Collapsed;
                    txtFee.IsEnabled = false;
                    cboTerm.IsEnabled = false;
                }
                else
                {
                    tabExtend.Visibility = Visibility.Collapsed;
                    c_lst_Fee = _Fees_Revenue_Controller.Fees_Revenue_GetByContract(c_Contract_Info.Contract_Id);
                }

                c_hs_fee_old = new Hashtable();
                if (c_lst_Fee.Count > 0)
                {
                    foreach (Fees_Revenue_Info item in c_lst_Fee)
                    {
                        c_hs_fee_old[item.Pay_Date_Expected.ToString("dd/MM/yyyy")] = item;
                    }
                }

                c_hs_fee_ex_old = new Hashtable();
                if (c_lst_Fee_Extend.Count > 0)
                {
                    foreach (Fees_Revenue_Info item in c_lst_Fee_Extend)
                    {
                        c_hs_fee_ex_old[item.Pay_Date_Expected.ToString("dd/MM/yyyy")] = item;
                    }
                }

                dgrFee.ItemsSource = c_lst_Fee;
                dgrFee_Extend.ItemsSource = c_lst_Fee_Extend;

                c_is_not_first = true;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        bool Tenant_CheckValidate()
        {
            try
            {
                #region Tenant
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

                if (!_Contract_Controller.Check_ExistContractCode(txtContract_Code.Text) && txtContract_Code.Text != c_Contract_Info.Contract_Code)
                {
                    NoteBox.Show("Mã hợp đồng đã tồn tại, tạo lại mã", "", NoteBoxLevel.Error);
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
                    txtFeeOnePay.Focus();
                    return false;
                }
                #endregion

                #region Extend

                if (Convert.ToDecimal(cboStatusContract.SelectedValue) == (decimal)Enum_Contract_Status.Gia_Han)
                {
                    if (dpFromDate_Extend.Text == "")
                    {
                        NoteBox.Show("Thời gian thuê từ ngày không được để trống", "", NoteBoxLevel.Error);
                        tabExtend.Focus();
                        UpdateLayout();
                        dpFromDate_Extend.Focus();
                        return false;
                    }
                    if (CheckValidate.CheckValidDate(dpFromDate_Extend.Text) == false)
                    {
                        NoteBox.Show("Thời gian thuê từ ngày không đúng định dạng", "", NoteBoxLevel.Error);
                        tabExtend.Focus();
                        UpdateLayout();
                        dpFromDate_Extend.Focus();
                        return false;
                    }

                    if (dpToDate_Extend.Text == "")
                    {
                        NoteBox.Show("Thời gian thuê đến ngày không được để trống", "", NoteBoxLevel.Error);
                        tabExtend.Focus();
                        UpdateLayout();
                        dpToDate_Extend.Focus();
                        return false;
                    }
                    if (CheckValidate.CheckValidDate(dpToDate_Extend.Text) == false)
                    {
                        NoteBox.Show("Thời gian thuê đến ngày không đúng định dạng", "", NoteBoxLevel.Error);
                        tabExtend.Focus();
                        UpdateLayout();
                        dpToDate_Extend.Focus();
                        return false;
                    }

                    if (ConvertData.ConvertString2Date(dpFromDate_Extend.Text).Date > ConvertData.ConvertString2Date(dpToDate_Extend.Text).Date)
                    {
                        NoteBox.Show("Thời gian thuê từ ngày phải nhỏ hơn đến ngày", "", NoteBoxLevel.Error);
                        tabExtend.Focus();
                        UpdateLayout();
                        dpFromDate_Extend.Focus();
                        return false;
                    }

                    if (txtFee_Extend.Text == "")
                    {
                        NoteBox.Show("Phí môi giới không được để trống", "", NoteBoxLevel.Error);
                        tabExtend.Focus();
                        UpdateLayout();
                        txtFee_Extend.Focus();
                        return false;
                    }

                    if (txtFeeOnePay_Extend.Text == "")
                    {
                        NoteBox.Show("Số tiền 1 lần thanh toán không được để trống", "", NoteBoxLevel.Error);
                        tabExtend.Focus();
                        UpdateLayout();
                        txtFeeOnePay_Extend.Focus();
                        return false;
                    }

                    if (Check_validate_Fee_Extend() == false)
                    {
                        tabExtend.Focus();
                        UpdateLayout();
                        txtFeeOnePay_Extend.Focus();
                        return false;
                    }
                }

                #endregion

                if ((Convert.ToDecimal(cboStatusContract.SelectedValue) == (decimal)Enum_Contract_Status.Close ||
                    Convert.ToDecimal(cboStatusContract.SelectedValue) == (decimal)Enum_Contract_Status.Dong_Trc_Thoi_Han ||
                    Convert.ToDecimal(cboStatusContract.SelectedValue) == (decimal)Enum_Contract_Status.Het_Han)
                    && Check_Is_DongHopDong() == false)
                {
                    NoteBox.Show("Chưa thanh toán hết phí không thể đóng hoặc sửa trạng thái hợp đồng", "", NoteBoxLevel.Error);
                    tabContract.Focus();
                    UpdateLayout();
                    cboStatusContract.Focus();
                    return false;
                }

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
                    NoteBox.Show("Không có thông tin thanh toán phí", "", NoteBoxLevel.Error);
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
                    if (CheckValidate.CheckGiaDuong(_tem) == false)
                    {
                        tabFee.Focus();
                        UpdateLayout();
                        DataGridHelper.NVSFocus(dgrFee, i, 2);
                        return false;
                    }
                }

                if (c_Contract_Info.Term != Convert.ToDecimal(cboTerm.SelectedValue))
                {
                    if (Check_Is_ReCall_Fee((decimal)Enum_Extend_Contract.Not_Extend) == false)
                    {
                        tabFee.Focus();
                        UpdateLayout();
                        cboTerm.Focus();
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

        bool Check_validate_Fee_Extend()
        {

            try
            {
                if (c_lst_Fee_Extend.Count == 0)
                {
                    NoteBox.Show("Không có thông tin thanh toán phí gia hạn", "", NoteBoxLevel.Error);
                    tabExtend.Focus();
                    UpdateLayout();
                    txtFeeOnePay_Extend.Focus();
                    return false;
                }

                if (c_ok_Extend == false)
                {
                    NoteBox.Show("Số tiền 1 lần thanh toán không đúng định dạng", "", NoteBoxLevel.Error);
                    tabExtend.Focus();
                    UpdateLayout();
                    return false;
                }

                for (int i = 0; i < c_lst_Fee_Extend.Count; i++)
                {
                    Fees_Revenue_Info item = c_lst_Fee_Extend[i];

                    string _tem = item.Fee_Expected.ToString().Replace(",", "").Trim();
                    if (CheckValidate.CheckGiaDuong(_tem) == false)
                    {
                        tabExtend.Focus();
                        UpdateLayout();
                        DataGridHelper.NVSFocus(dgrFee_Extend, i, 2);
                        return false;
                    }
                }

                if (c_Contract_Info.Status == (decimal)Enum_Contract_Status.Gia_Han)
                {
                    if (Check_Is_ReCall_Fee(c_max_number_extend) == false)
                    {
                        tabExtend.Focus();
                        UpdateLayout();
                        cboTerm_Extend.Focus();
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

                        if (c_hs_fee_old.ContainsKey(_Fees_Revenue_Info.Pay_Date_Expected.ToString("dd/MM/yyyy")))
                        {
                            Fees_Revenue_Info _Fees_Revenue_Info_Old = (Fees_Revenue_Info)c_hs_fee_old[_Fees_Revenue_Info.Pay_Date_Expected.ToString("dd/MM/yyyy")];

                            if (_Fees_Revenue_Info_Old != null)
                            {
                                _Fees_Revenue_Info.Pay_Date = _Fees_Revenue_Info_Old.Pay_Date;
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

        void Create_DataFee_Maturity_Extend()
        {
            try
            {

                c_lst_Fee_Extend = new List<Fees_Revenue_Info>();

                decimal _fee_one_pay_Extend = 0;
                decimal _term_pay_chose_Extend = Convert.ToDecimal(cboTerm_Extend.SelectedValue);
                int _number_pay_Extend = 1;
                int _number_Ternm_Extend = 1;

                // lấy thời gian thuê nhà theo tháng

                int _month_Extend = Call_Month_ByRangeDate(ConvertData.ConvertString2Date(dpFromDate_Extend.Text), ConvertData.ConvertString2Date(dpToDate_Extend.Text));

                // lấy kỳ hạn thanh toán
                if (_term_pay_chose_Extend == (decimal)Enum_Fee_Maturity.One)
                {
                    _number_pay_Extend = 1;
                }
                else if (_term_pay_chose_Extend == (decimal)Enum_Fee_Maturity.One_Month)
                {
                    _number_pay_Extend = _month_Extend / 1;
                    _number_Ternm_Extend = 1;
                }
                else if (_term_pay_chose_Extend == (decimal)Enum_Fee_Maturity.Three_Month)
                {
                    _number_pay_Extend = _month_Extend / 3;
                    _number_Ternm_Extend = 3;
                }
                else if (_term_pay_chose_Extend == (decimal)Enum_Fee_Maturity.Six_Month)
                {
                    _number_pay_Extend = _month_Extend / 6;
                    _number_Ternm_Extend = 6;
                }
                else if (_term_pay_chose_Extend == (decimal)Enum_Fee_Maturity.One_Year)
                {
                    _number_Ternm_Extend = 12;
                    if (_month_Extend < 12)
                        _number_pay_Extend = 1;
                    else
                        _number_pay_Extend = _month_Extend / 12;
                }

                _fee_one_pay_Extend = Math.Round(Convert.ToDecimal(txtFee_Extend.Text) / _number_pay_Extend);
                if (c_is_option_pay_Extend == true)
                {
                    if (txtFeeOnePay_Extend.Text == "")
                    {
                        NoteBox.Show("Số tiền 1 lần thanh toán không được để trống", "", NoteBoxLevel.Error);
                        return;
                    }

                    if (txtNumberPay_Extend.Text == "")
                    {
                        NoteBox.Show("Số lần thanh toán không được để trống", "", NoteBoxLevel.Error);
                        return;
                    }
                    _fee_one_pay_Extend = Convert.ToDecimal(txtFeeOnePay.Text);
                    _number_pay_Extend = Convert.ToInt16(txtNumberPay.Text);

                    _number_Ternm_Extend = _month_Extend / _number_pay_Extend;
                }

                txtFeeOnePay_Extend.Text = _fee_one_pay_Extend.ToString();

                if (_number_pay_Extend > 0)
                {
                    for (int i = 0; i < _number_pay_Extend; i++)
                    {
                        int _add_month = (i + 1) * _number_Ternm_Extend;

                        Fees_Revenue_Info _Fees_Revenue_Info = new Fees_Revenue_Info();
                        _Fees_Revenue_Info.Number_Payment = i + 1;
                        _Fees_Revenue_Info.Object_Type = (decimal)Enum_Contract_Type.Tenant;
                        _Fees_Revenue_Info.Fee_Expected = _fee_one_pay_Extend;
                        _Fees_Revenue_Info.Debit_Amount = _fee_one_pay_Extend - _Fees_Revenue_Info.Fee;
                        _Fees_Revenue_Info.Pay_Date_Expected = ConvertData.ConvertString2Date(dpFromDate_Extend.Text).AddMonths(3);
                        _Fees_Revenue_Info.Is_Extend = 1;


                        // nếu thanh toán 1 lần thì lấy ngày thanh toán  = ngày ký hợp đồng luôn
                        if (_number_pay_Extend == 1)
                        {
                            _Fees_Revenue_Info.Pay_Date_Expected = ConvertData.ConvertString2Date(dpFromDate_Extend.Text);
                        }
                        else
                        {
                            if (i == 0)
                            {
                                _Fees_Revenue_Info.Pay_Date_Expected = ConvertData.ConvertString2Date(dpFromDate.Text);
                            }
                            else
                            {
                                //// nếu không thì cứ lấy ngày bắt đầu thuê nhà + thêm kỳ hạn thanh toán
                                //_Fees_Revenue_Info.Pay_Date_Expected = ConvertData.ConvertString2Date(dpFromDate_Extend.Text).AddMonths(_add_month - 1);

                                Fees_Revenue_Info _Fees_Pre = c_lst_Fee[i - 1];
                                _Fees_Revenue_Info.Pay_Date_Expected = _Fees_Pre.Pay_Date_Expected.AddMonths(_number_Ternm_Extend);

                                if (_Fees_Revenue_Info.Pay_Date_Expected > ConvertData.ConvertString2Date(dpToDate_Extend.Text))
                                {
                                    _Fees_Revenue_Info.Pay_Date_Expected = ConvertData.ConvertString2Date(dpToDate_Extend.Text);
                                }
                            }
                        }


                        if (c_hs_fee_ex_old.ContainsKey(_Fees_Revenue_Info.Pay_Date_Expected.ToString("dd/MM/yyyy")))
                        {
                            Fees_Revenue_Info _Fees_Revenue_Info_Old = (Fees_Revenue_Info)c_hs_fee_ex_old[_Fees_Revenue_Info.Pay_Date_Expected.ToString("dd/MM/yyyy")];

                            if (_Fees_Revenue_Info_Old != null)
                            {
                                _Fees_Revenue_Info.Pay_Date = _Fees_Revenue_Info_Old.Pay_Date;
                            }
                        }

                        c_lst_Fee_Extend.Add(_Fees_Revenue_Info);
                    }
                }

                dgrFee_Extend.ItemsSource = c_lst_Fee_Extend;
                dgrFee_Extend.Items.Refresh();
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
                _Contract_Info.Price = 0;
                _Contract_Info.Pay_Count = c_lst_Fee.Count;
                _Contract_Info.Term = Convert.ToDecimal(cboTerm.SelectedValue);
                _Contract_Info.Status = Convert.ToDecimal(cboStatusContract.SelectedValue);
                _Contract_Info.Currency = Convert.ToDecimal(cboCurrency.SelectedValue);

                _Contract_Info.Contract_FromDate = ConvertData.ConvertString2Date(dpFromDate.Text);
                _Contract_Info.Contract_ToDate = ConvertData.ConvertString2Date(dpToDate.Text);
                _Contract_Info.Object_Type = (decimal)Enum_Contract_Type.Tenant;
                _Contract_Info.Contract_Type = (decimal)Enum_Contract_Type.Tenant;

                _Contract_Info.Object_Id = p_object_id;
                _Contract_Info.Estate_Id = c_Contract_Info.Estate_Id;
                _Contract_Info.FeeOnePay = Convert.ToDecimal(txtFeeOnePay.Text);

                _Contract_Info.Modifi_Date = DateTime.Now;
                _Contract_Info.Modifi_By = CommonData.c_Urser_Info.User_Name;

                _Contract_Info.Contract_FromDate = ConvertData.ConvertString2Date(dpContractDate.Text);
                _Contract_Info.Users = txtUsers.Text;
                _Contract_Info.Representive = txtRepresentive.Text;

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

                if (_Contract_Info.Status == (decimal)Enum_Contract_Status.Gia_Han)
                {
                    foreach (Fees_Revenue_Info item in c_lst_Fee_Extend)
                    {
                        if (item.Fee == 0)
                        {
                            _Contract_Info.Fee_Status = (decimal)Enum_Fee_Status.No_Pay;
                            break;
                        }
                        else
                            _Contract_Info.Fee_Status = (decimal)Enum_Fee_Status.Payed;
                    }
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
                if (Tenant_CheckValidate() == false) return;

                MessageBoxResult result = NoteBox.Show("Bạn có muốn cập nhật hợp đồng này hay không?", "Thông báo", NoteBoxLevel.Question);
                if (MessageBoxResult.Yes != result)
                {
                    return;
                }

                //Customer_Info _Customer_Info = Get_Customer_Info();

                //if (_Customer_Info == null)
                //{
                //    NoteBox.Show("Lỗi khởi tạo khách cho thuê nhà", "", NoteBoxLevel.Error);
                //    return;
                //}

                //if (c_Customer_Controller.Customer_Update(c_Contract_Info.Object_Id, _Customer_Info) == false)
                //{
                //    NoteBox.Show("Lỗi cập nhật mới khách thuê nhà", "", NoteBoxLevel.Error);
                //    return;
                //}

                Contract_Info _Contract_Info = Get_Contract_Info(c_Contract_Info.Object_Id);
                if (_Contract_Info == null)
                {
                    NoteBox.Show("Lỗi khởi tạo hợp đồng thuê nhà", "", NoteBoxLevel.Error);
                    return;
                }

                if (_Contract_Controller.Contract_Update(c_Contract_Info.Contract_Id, _Contract_Info) == false)
                {
                    NoteBox.Show("Lỗi cập nhật hợp đồng cho thuê nhà", "", NoteBoxLevel.Error);
                    return;
                }

                #region Fee
                // nếu mà kỳ hạn hợp đồng thay đổi thì xóa đi tạo lại dữ liệu thu chi
                _Fees_Revenue_Controller.Fees_Revenue_DeleteByContract(c_Contract_Info.Contract_Id);

                foreach (Fees_Revenue_Info _Fees_Revenue_Info in c_lst_Fee)
                {
                    _Fees_Revenue_Info.Contract_Id = c_Contract_Info.Contract_Id;
                    _Fees_Revenue_Info.Object_Id = c_Contract_Info.Object_Id;
                    _Fees_Revenue_Info.Object_Type = (decimal)Enum_Contract_Type.Tenant;
                    _Fees_Revenue_Info.Currency = Convert.ToDecimal(cboCurrency.SelectedValue);
                    _Fees_Revenue_Info.Debit_Amount = _Fees_Revenue_Info.Fee_Expected - _Fees_Revenue_Info.Fee;

                    if (_Fees_Revenue_Info.Fee != 0)
                    {
                        _Fees_Revenue_Info.Pay_Status = (decimal)Enum_Fee_Status.Payed;

                        if (_Fees_Revenue_Info.Pay_Date.Date == DateTime.MinValue.Date)
                        {
                            _Fees_Revenue_Info.Pay_Date = DateTime.Now;
                        }
                    }

                    if (_Fees_Revenue_Controller.Fees_Revenue_Insert(_Fees_Revenue_Info) == false)
                    {
                        NoteBox.Show("Lỗi thanh toán", "", NoteBoxLevel.Error);
                        return;
                    }
                }
                #endregion

                #region Extend fee
                bool _is_payed = true;
                if (c_lst_Fee_Extend.Count > 0)
                {
                    Extend_Contract_Info _Extend_Contract_Info = new Extend_Contract_Info();
                    _Extend_Contract_Info.Contract_Id = c_Contract_Info.Contract_Id;

                    _Extend_Contract_Info.Contract_FromDate = ConvertData.ConvertString2Date(dpFromDate_Extend.Text);
                    _Extend_Contract_Info.Contract_ToDate = ConvertData.ConvertString2Date(dpToDate_Extend.Text);

                    _Extend_Contract_Info.Fee = Convert.ToDecimal(txtFee_Extend.Text);
                    _Extend_Contract_Info.FeeOnePay = Convert.ToDecimal(txtFeeOnePay_Extend.Text);
                    _Extend_Contract_Info.Term = Convert.ToDecimal(cboTerm_Extend.SelectedValue);
                    _Extend_Contract_Info.Price = 0;

                    foreach (Fees_Revenue_Info _Fees_Revenue_Info in c_lst_Fee_Extend)
                    {
                        _Fees_Revenue_Info.Contract_Id = c_Contract_Info.Contract_Id;
                        _Fees_Revenue_Info.Object_Id = c_Contract_Info.Object_Id;
                        _Fees_Revenue_Info.Object_Type = (decimal)Enum_Contract_Type.Tenant;
                        _Fees_Revenue_Info.Currency = Convert.ToDecimal(cboCurrency.SelectedValue);

                        if (c_Contract_Info.Status == (decimal)Enum_Contract_Status.Het_Han)
                            _Fees_Revenue_Info.Is_Extend = c_max_number_extend + 1;
                        else
                            _Fees_Revenue_Info.Is_Extend = c_max_number_extend;

                        _Fees_Revenue_Info.Debit_Amount = _Fees_Revenue_Info.Fee_Expected - _Fees_Revenue_Info.Fee;

                        if (_Fees_Revenue_Info.Fee != 0)
                        {
                            _Fees_Revenue_Info.Pay_Status = (decimal)Enum_Fee_Status.Payed;

                            if (_Fees_Revenue_Info.Pay_Date.Date == DateTime.MinValue.Date)
                            {
                                _Fees_Revenue_Info.Pay_Date = DateTime.Now;
                            }
                        }
                        else
                            _is_payed = false;

                        if (_Fees_Revenue_Controller.Fees_Revenue_Insert(_Fees_Revenue_Info) == false)
                        {
                            NoteBox.Show("Lỗi thanh toán", "", NoteBoxLevel.Error);
                            return;
                        }
                    }

                    // lần đầu chuyển trạng thái hợp đồng
                    if (c_Extend_Contract_Info == null)
                    {
                        _Extend_Contract_Info.Extend_Date = DateTime.Now;
                        _Extend_Contract_Controller.Extend_Contract_Insert(_Extend_Contract_Info);
                    }
                    else
                    {
                        // update lại thông tin về hợp đồng
                        if (_is_payed == false)
                            _Extend_Contract_Info.Fee_Status = (decimal)Enum_Fee_Status.No_Pay;
                        else
                            _Extend_Contract_Info.Fee_Status = (decimal)Enum_Fee_Status.Payed;

                        _Extend_Contract_Info.Extend_Date = c_Extend_Contract_Info.Extend_Date;
                        _Extend_Contract_Controller.Extend_Contract_Update(_Extend_Contract_Info);
                    }
                }
                #endregion

                c_id_insert = c_Contract_Info.Contract_Id;

                NoteBox.Show("Cập nhật dữ liệu thành công", "");
                this.Close();
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        bool Check_Is_ReCall_Fee(decimal p_is_extend)
        {
            try
            {
                // kiểm tra xem có thằng nào là đã thanh toán rồi hay không
                List<Fees_Revenue_Info> _lst = _Fees_Revenue_Controller.Fees_Revenue_GetByContract(c_Contract_Info.Contract_Id);
                if (_lst.Count > 0)
                {
                    foreach (Fees_Revenue_Info item in _lst)
                    {
                        if (item.Is_Extend == p_is_extend && item.Pay_Status == (decimal)Enum_Fee_Status.Payed)
                        {
                            NoteBox.Show("Đã thanh toán không thể thay đổi kỳ hạn thanh toán", "", NoteBoxLevel.Error);
                            return false;
                        }
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

        bool Check_Is_DongHopDong()
        {
            try
            {
                // kiểm tra xem có thằng nào là đã thanh toán rồi hay không
                List<Fees_Revenue_Info> _lst = _Fees_Revenue_Controller.Fees_Revenue_GetByContract(c_Contract_Info.Contract_Id);
                if (_lst.Count > 0)
                {
                    foreach (Fees_Revenue_Info item in _lst)
                    {
                        if (item.Pay_Status == (decimal)Enum_Fee_Status.No_Pay)
                        {
                            return false;
                        }
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
        #endregion
    }
}
