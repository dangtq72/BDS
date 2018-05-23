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

namespace StartsInternational.Contract
{
    /// <summary>
    /// Interaction logic for Contract_Insert_Renter.xaml
    /// </summary>
    public partial class Update_Contract_Insert_Renter : Window
    {

        #region Contrustor and params

        public Update_Contract_Insert_Renter()
        {
            InitializeComponent();
        }

        Estate_Object_Controller _Estate_Object_Controller = new Estate_Object_Controller();
        Customer_Controller c_Customer_Controller = new Customer_Controller();
        Contract_Controller _Contract_Controller = new Contract_Controller();
        Fees_Revenue_Controller _Fees_Revenue_Controller = new Fees_Revenue_Controller();
        Extend_Contract_Controller _Extend_Contract_Controller = new Extend_Contract_Controller();

        public Contract_Info c_Contract_Info;
        public bool c_ok = true;
        bool c_ok_Extend = true; // biến check đúng dữ liệu

        public decimal c_id_insert = 0;

        Extend_Contract_Info c_Extend_Contract_Info;
        List<Fees_Revenue_Info> c_lst_Fee = new List<Fees_Revenue_Info>();
        List<Fees_Revenue_Info> c_lst_Fee_Extend = new List<Fees_Revenue_Info>();

        bool c_is_load_ok = false;

        decimal c_max_number_extend = 0;
        #endregion

        #region Event

        private void frmContract_Insert_Renter_Loaded_1(object sender, RoutedEventArgs e)
        {
            LoadData();
            txtRenter_Name.Focus();
            c_is_load_ok = true;
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
                    case "txtFee_Extend":
                        CommonFunction.Text_Change_Format_Money(txtFee_Extend);
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

        private void txtFee_PreviewLostKeyboardFocus_1(object sender, KeyboardFocusChangedEventArgs e)
        {
            try
            {
                //txtFeePay.Text = txtFee.Text;
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

        private void dgrFee_Extend_PreviewKeyDown(object sender, KeyEventArgs e)
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

        private void cboStatusContract_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                AllCode_Info _AllCode_Info = (AllCode_Info)cboStatusContract.SelectedItem;
                if (_AllCode_Info != null && c_is_load_ok)
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

        private void btnCall_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = NoteBox.Show("Bạn có muốn reset lại thông tin phí thanh toán hay không?", "Thông báo", NoteBoxLevel.Question);
            if (MessageBoxResult.Yes == result)
            {
                Create_Fee();
            }
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

        #region Gia hạn hợp đồng

        private void btnCall_Extend_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = NoteBox.Show("Bạn có muốn reset lại thông tin phí thanh toán hay không?", "Thông báo", NoteBoxLevel.Question);
            if (MessageBoxResult.Yes == result)
            {
                Create_Fee_Extend();
            }
        }

        private void dgrFee_Extend_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
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
                    DataGridHelper.NVSFocus(dgrFee_Extend, 0, 2);
                }
                tem = tem.Replace(",", "").Trim();

                if (!CheckValidate.CheckGiaDuong(tem))
                {
                    c_ok_Extend = false;
                    DataGridHelper.NVSFocus(dgrFee_Extend, 0, 2);
                }
                else c_ok_Extend = true;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
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

                Estate_Object_Info _Estate_Object_Info = _Estate_Object_Controller.Estate_Object_GetById(c_Contract_Info.Estate_Id, (decimal)Enum_Contract_Type.Renter);
                lbl_Estate_Name.Content = _Estate_Object_Info.Estate_Name;
                lbl_Estate_Type_Name.Content = _Estate_Object_Info.Estate_Type_Name;
                lbl_Estate_Code.Content = _Estate_Object_Info.Estate_Code;
                lbl_Estate_Area.Content = _Estate_Object_Info.Area;
                lbl_Address.Content = _Estate_Object_Info.Address;

                Customer_Info _Customer_Info = c_Customer_Controller.Customer_GetById(c_Contract_Info.Object_Id);
                if (_Customer_Info != null)
                {
                    txtRenter_Name.Text = _Customer_Info.Customer_Name;
                    txtAddress.Text = _Customer_Info.Address;
                    txtPhone.Text = _Customer_Info.Phone;
                    txtFax.Text = _Customer_Info.Fax;
                    txtTaxCode.Text = _Customer_Info.Tax_Code;
                    txtIdentity_Card.Text = _Customer_Info.Identity_Card;
                }

                txtRepresentive.Text = c_Contract_Info.Representive;
                txtUsers.Text = c_Contract_Info.Users;
                txtContract_Code.Text = c_Contract_Info.Contract_Code;
                txtContract_Name.Text = c_Contract_Info.Contract_Name;
                dpContractDate.Text = c_Contract_Info.Contract_Date.ToString("dd/MM/yyyy");
                txtPrice.Text = c_Contract_Info.Price.ToString("#,##0.#");
                cboCurrency.SelectedValue = c_Contract_Info.Currency;

                #region Fee VND
                if (c_Contract_Info.Currency == (decimal)Enum_Contract_Currency.USD)
                {
                    if (c_Contract_Info.Status == (decimal)Enum_Contract_Status.Gia_Han)
                    {
                        lblThanhTien_Extend.Visibility = Visibility.Visible;
                        txtFee_Vnd_Extend.Visibility = Visibility.Visible;
                        lblVND_Extend.Visibility = Visibility.Visible;

                        lblThanhTien.Visibility = Visibility.Collapsed;
                        txtFee_Vnd.Visibility = Visibility.Collapsed;
                        lblVND.Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        lblThanhTien.Visibility = Visibility.Visible;
                        txtFee_Vnd.Visibility = Visibility.Visible;
                        lblVND.Visibility = Visibility.Visible;

                        lblThanhTien_Extend.Visibility = Visibility.Collapsed;
                        txtFee_Vnd_Extend.Visibility = Visibility.Collapsed;
                        lblVND_Extend.Visibility = Visibility.Collapsed;
                    }
                }
                else
                {
                    lblThanhTien.Visibility = Visibility.Collapsed;
                    txtFee_Vnd.Visibility = Visibility.Collapsed;
                    lblVND.Visibility = Visibility.Collapsed;

                    lblThanhTien_Extend.Visibility = Visibility.Collapsed;
                    txtFee_Vnd_Extend.Visibility = Visibility.Collapsed;
                    lblVND_Extend.Visibility = Visibility.Collapsed;
                }
                #endregion

                dpFromDate.Text = c_Contract_Info.Contract_FromDate.ToString("dd/MM/yyyy");
                dpToDate.Text = c_Contract_Info.Contract_ToDate.ToString("dd/MM/yyyy");
                cboStatusContract.SelectedValue = c_Contract_Info.Status;
                txtFee.Text = c_Contract_Info.Fee.ToString("#,##0.#");
                c_max_number_extend = _Extend_Contract_Controller.Get_Number_ExtendContract(c_Contract_Info.Contract_Id);

                if (c_Contract_Info.Status == (decimal)Enum_Contract_Status.Gia_Han)
                {
                    List<Extend_Contract_Info> _lst_ex = _Extend_Contract_Controller.Extend_Contract_GetByContractId(c_Contract_Info.Contract_Id);
                    if (_lst_ex.Count > 0)
                    {
                        c_Extend_Contract_Info = _lst_ex[0];

                        txtFee_Extend.Text = c_Extend_Contract_Info.Fee.ToString("#,##0.#");
                        dpFromDate_Extend.Text = c_Extend_Contract_Info.Contract_FromDate.ToString("dd/MM/yyyy");
                        dpToDate_Extend.Text = c_Extend_Contract_Info.Contract_ToDate.ToString("dd/MM/yyyy");
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

                    txtFee_Vnd_Extend.Text = c_lst_Fee_Extend[c_lst_Fee_Extend.Count - 1].Fee_Vnd.ToString("#,##0.#");

                    btnCall.Visibility = Visibility.Collapsed;
                    txtFee.IsEnabled = false;
                    txtFee_Vnd.IsEnabled = false;
                }
                else
                {
                    tabExtend.Visibility = Visibility.Collapsed;
                    c_lst_Fee = _Fees_Revenue_Controller.Fees_Revenue_GetByContract(c_Contract_Info.Contract_Id);
                    txtFee_Vnd.Text = c_lst_Fee[c_lst_Fee.Count - 1].Fee_Vnd.ToString("#,##0.#");
                }

                dgrFee.ItemsSource = c_lst_Fee;
                dgrFee_Extend.ItemsSource = c_lst_Fee_Extend;
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

                if (!_Contract_Controller.Check_ExistContractCode(txtContract_Code.Text) && txtContract_Code.Text != c_Contract_Info.Contract_Code)
                {
                    NoteBox.Show("Mã hợp đồng đã tồn tại, tạo lại mã", "", NoteBoxLevel.Error);
                    tabContract.Focus();
                    UpdateLayout();
                    txtContract_Code.Focus();
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

                if (Check_validate_Fee() == false)
                {
                    tabFee.Focus();
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

                    if (Check_validate_Fee_Extend() == false)
                    {
                        tabExtend.Focus();
                        UpdateLayout();
                        txtFee_Extend.Focus();
                        return false;
                    }

                    if ((_currecy == (decimal)Enum_Contract_Currency.USD) && txtFee_Vnd_Extend.Text == "")
                    {
                        NoteBox.Show("Phí môi giới (VND) không được để trống", "", NoteBoxLevel.Error);
                        tabExtend.Focus();
                        UpdateLayout();
                        txtFee_Vnd_Extend.Focus();
                        return false;
                    }
                }

                #endregion

                if ((Convert.ToDecimal(cboStatusContract.SelectedValue) == (decimal)Enum_Contract_Status.Close ||
                    Convert.ToDecimal(cboStatusContract.SelectedValue) == (decimal)Enum_Contract_Status.Het_Han ||
                    Convert.ToDecimal(cboStatusContract.SelectedValue) == (decimal)Enum_Contract_Status.Dong_Trc_Thoi_Han)
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
                    NoteBox.Show("Số lần thanh toán không được để trống", "", NoteBoxLevel.Error);
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

        bool Check_validate_Fee_Extend()
        {

            try
            {
                if (c_lst_Fee_Extend.Count == 0)
                {
                    NoteBox.Show("Không có thông tin thanh toán phí gia hạn", "", NoteBoxLevel.Error);
                    tabExtend.Focus();
                    UpdateLayout();
                    txtFee_Extend.Focus();
                    return false;
                }

                if (c_ok_Extend == false)
                {
                    NoteBox.Show("Số tiền 1 lần thanh toán gia hạn không đúng định dạng", "", NoteBoxLevel.Error);
                    tabExtend.Focus();
                    UpdateLayout();
                    dgrFee_Extend.Focus();
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

        Contract_Info Get_Contract_Info()
        {
            try
            {
                Contract_Info _Contract_Info = new Contract_Info();
                _Contract_Info.Contract_Code = txtContract_Code.Text;
                _Contract_Info.Contract_Name = txtContract_Name.Text;
                _Contract_Info.Contract_Date = ConvertData.ConvertString2Date(dpContractDate.Text);
                _Contract_Info.Contract_Type = (decimal)Enum_Contract_Type.Renter;
                _Contract_Info.Status = Convert.ToDecimal(cboStatusContract.SelectedValue);
                _Contract_Info.Term = 1;
                _Contract_Info.Pay_Count = 1;

                _Contract_Info.Fee = Convert.ToDecimal(txtFee.Text);
                _Contract_Info.Price = Convert.ToDecimal(txtPrice.Text);
                _Contract_Info.Currency = Convert.ToDecimal(cboCurrency.SelectedValue);

                _Contract_Info.Contract_FromDate = ConvertData.ConvertString2Date(dpFromDate.Text);
                _Contract_Info.Contract_ToDate = ConvertData.ConvertString2Date(dpToDate.Text);
                _Contract_Info.Object_Type = (decimal)Enum_Contract_Type.Renter;
                _Contract_Info.Object_Id = c_Contract_Info.Object_Id;
                _Contract_Info.Estate_Id = c_Contract_Info.Estate_Id;
                _Contract_Info.FeeOnePay = Convert.ToDecimal(txtFee.Text);
                _Contract_Info.Modifi_Date = DateTime.Now;
                _Contract_Info.Modifi_By = CommonData.c_Urser_Info.User_Name;
                _Contract_Info.Contract_FromDate = ConvertData.ConvertString2Date(dpContractDate.Text);
                _Contract_Info.Users = txtUsers.Text;
                _Contract_Info.Representive = txtRepresentive.Text;
                _Contract_Info.Contract_ToDate_Ex = c_Contract_Info.Contract_ToDate_Ex;

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
                    _Contract_Info.Contract_ToDate_Ex = c_Contract_Info.Contract_ToDate_Ex;

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

        void Accept()
        {
            try
            {
                if (Renter_CheckValidate() == false) return;

                MessageBoxResult result = NoteBox.Show("Bạn có muốn cập nhật hợp đồng này hay không?", "Thông báo", NoteBoxLevel.Question);
                if (MessageBoxResult.Yes != result)
                {
                    return;
                }

                //Customer_Info _Customer_Info = Get_Customer_Info();

                //if (_Customer_Info == null)
                //{
                //    NoteBox.Show("Lỗi khởi tạo khách người thuê nhà", "", NoteBoxLevel.Error);
                //    return;
                //}

                //if (c_Customer_Controller.Customer_Update(c_Contract_Info.Object_Id, _Customer_Info) == false)
                //{
                //    NoteBox.Show("Lỗi cập nhật mới khách thuê nhà", "", NoteBoxLevel.Error);
                //    return;
                //}

                Contract_Info _Contract_Info = Get_Contract_Info();
                if (_Contract_Info == null)
                {
                    NoteBox.Show("Lỗi khởi tạo đối tượng hợp đồng thuê nhà", "", NoteBoxLevel.Error);
                    return;
                }

                if (_Contract_Controller.Contract_Update(c_Contract_Info.Contract_Id, _Contract_Info) == false)
                {
                    NoteBox.Show("Lỗi cập nhật mới hợp đồng thuê nhà", "", NoteBoxLevel.Error);
                    return;
                }

                // nếu không phải là gia hạn hợp đồng thì mới xóa đi tạo lại
                if (c_lst_Fee_Extend.Count == 0)
                {
                    // nếu mà kỳ hạn hợp đồng thay đổi thì xóa đi tạo lại dữ liệu thu chi
                    _Fees_Revenue_Controller.Fees_Revenue_DeleteByContract(c_Contract_Info.Contract_Id);

                    #region Thanh toán bình thường
                    foreach (Fees_Revenue_Info _Fees_Revenue_Info in c_lst_Fee)
                    {
                        _Fees_Revenue_Info.Contract_Id = c_Contract_Info.Contract_Id;
                        _Fees_Revenue_Info.Object_Id = c_Contract_Info.Object_Id;
                        _Fees_Revenue_Info.Object_Type = (decimal)Enum_Contract_Type.Tenant;
                        _Fees_Revenue_Info.Currency = Convert.ToDecimal(cboCurrency.SelectedValue);

                        if (_Fees_Revenue_Info.Fee_Expected != Convert.ToDecimal(txtFee.Text))
                        {
                            _Fees_Revenue_Info.Fee_Expected = Convert.ToDecimal(txtFee.Text);
                        }

                        _Fees_Revenue_Info.Debit_Amount = _Fees_Revenue_Info.Fee_Expected - _Fees_Revenue_Info.Fee;

                        if (_Contract_Info.Currency == (decimal)Enum_Contract_Currency.USD)
                            _Fees_Revenue_Info.Fee_Vnd = Convert.ToDecimal(txtFee_Vnd.Text);
                        else
                            _Fees_Revenue_Info.Fee_Vnd = 0;

                        if (_Fees_Revenue_Info.Fee != 0)
                        {
                            _Fees_Revenue_Info.Pay_Status = (decimal)Enum_Fee_Status.Payed;
                        }

                        if (_Fees_Revenue_Controller.Fees_Revenue_Insert(_Fees_Revenue_Info) == false)
                        {
                            NoteBox.Show("Lỗi thanh toán", "", NoteBoxLevel.Error);
                            return;
                        }
                    }
                    #endregion
                }
                else
                {
                    #region Phí gia hạn hợp đồng

                    Extend_Contract_Info _Extend_Contract_Info = new Extend_Contract_Info();
                    _Extend_Contract_Info.Contract_Id = c_Contract_Info.Contract_Id;

                    _Extend_Contract_Info.Contract_FromDate = ConvertData.ConvertString2Date(dpFromDate_Extend.Text);
                    _Extend_Contract_Info.Contract_ToDate = ConvertData.ConvertString2Date(dpToDate_Extend.Text);

                    _Extend_Contract_Info.Fee = Convert.ToDecimal(txtFee_Extend.Text);
                    _Extend_Contract_Info.FeeOnePay = _Extend_Contract_Info.Fee;
                    _Extend_Contract_Info.Term = 1;
                    _Extend_Contract_Info.Price = 0;

                    bool _is_payed = true;
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
                        }
                        else _is_payed = false;

                        if (_Contract_Info.Currency == (decimal)Enum_Contract_Currency.USD)
                            _Fees_Revenue_Info.Fee_Vnd = Convert.ToDecimal(txtFee_Vnd_Extend.Text);
                        else
                            _Fees_Revenue_Info.Fee_Vnd = 0;

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
                        if (_is_payed == false)
                            _Extend_Contract_Info.Fee_Status = (decimal)Enum_Fee_Status.No_Pay;
                        else
                            _Extend_Contract_Info.Fee_Status = (decimal)Enum_Fee_Status.Payed;

                        // update lại thông tin về hợp đồng
                        _Extend_Contract_Info.Extend_Date = c_Extend_Contract_Info.Extend_Date;
                        _Extend_Contract_Controller.Extend_Contract_Update(_Extend_Contract_Info);
                    }

                    #endregion
                }

                c_id_insert = c_Contract_Info.Contract_Id;

                NoteBox.Show("Cập nhật dữ liệu thành công", "");
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

                if (txtFee_Vnd.Text != "")
                    _Fees_Revenue_Info.Fee_Vnd = Convert.ToDecimal(txtFee_Vnd.Text);
                else
                    _Fees_Revenue_Info.Fee_Vnd = 0;

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

        void Create_Fee_Extend()
        {
            try
            {
                if (txtFee.Text == "")
                {
                    NoteBox.Show("Bạn chưa nhập phí môi giới", "", NoteBoxLevel.Error);
                    return;
                }

                c_lst_Fee_Extend = new List<Fees_Revenue_Info>();
                Fees_Revenue_Info _Fees_Revenue_Info = new Fees_Revenue_Info();

                _Fees_Revenue_Info.Number_Payment = 1;
                _Fees_Revenue_Info.Object_Type = (decimal)Enum_Contract_Type.Renter;
                _Fees_Revenue_Info.Fee_Expected = Convert.ToDecimal(txtFee_Extend.Text);
                _Fees_Revenue_Info.Fee = 0;
                _Fees_Revenue_Info.Debit_Amount = _Fees_Revenue_Info.Fee_Expected;
                _Fees_Revenue_Info.Pay_Date_Expected = ConvertData.ConvertString2Date(dpFromDate_Extend.Text);
                _Fees_Revenue_Info.Is_Extend = 1;
                _Fees_Revenue_Info.Pay_Status = (decimal)Enum_Fee_Status.No_Pay;
                c_lst_Fee_Extend.Add(_Fees_Revenue_Info);

                dgrFee_Extend.ItemsSource = c_lst_Fee_Extend;
                dgrFee_Extend.Items.Refresh();
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
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
