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
    public partial class View_Contract_Renter : Window
    {

        #region Contrustor and params

        public View_Contract_Renter()
        {
            InitializeComponent();
        }

        Estate_Object_Controller _Estate_Object_Controller = new Estate_Object_Controller();
        Customer_Controller c_Customer_Controller = new Customer_Controller();
        Fees_Revenue_Controller _Fees_Revenue_Controller = new Fees_Revenue_Controller();

        public Contract_Info c_Contract_Info;

        #endregion

        #region Event

        private void frmView_Contract_Renter_Loaded_1(object sender, RoutedEventArgs e)
        {
            LoadData();
            txtRenter_Name.Focus();
        }

        private void frmView_Contract_Renter_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        private void btnHuy_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
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

        #endregion

        #region Methods

        void LoadData()
        {
            try
            {
                List<AllCode_Info> _lst_C_T = DBMemory.AllCode_GetBy_CdNameCdType("CONTRACT", "STATUS");

                cboStatus.ItemsSource = _lst_C_T;
                cboStatus.DisplayMemberPath = "Content";
                cboStatus.SelectedValuePath = "CdValue";

                List<AllCode_Info> _lst_Currency = DBMemory.AllCode_GetBy_CdNameCdType("CONTRACT", "CURENCY");
                cboCurrency.ItemsSource = _lst_Currency;
                cboCurrency.DisplayMemberPath = "Content";
                cboCurrency.SelectedValuePath = "CdValue";

                Estate_Object_Info _Estate_Object_Info = _Estate_Object_Controller.Estate_Object_GetById(c_Contract_Info.Estate_Id, (decimal)Enum_Contract_Type.Renter);
                lbl_Estate_Name.Content = _Estate_Object_Info.Estate_Name;
                lbl_Estate_Code.Content = _Estate_Object_Info.Estate_Code;
                lbl_Estate_Type_Name.Content = _Estate_Object_Info.Estate_Type_Name;
                lbl_Estate_Area.Content = _Estate_Object_Info.Area;
                lbl_Address.Content = _Estate_Object_Info.Address;

                Customer_Info _Customer_Info = c_Customer_Controller.Customer_GetById(c_Contract_Info.Object_Id);
                if (_Customer_Info != null)
                {
                    txtRenter_Name.Text = _Customer_Info.Customer_Name;
                    txtAddress.Text = _Customer_Info.Address;
                    txtPhone.Text = _Customer_Info.Phone;
                    txtFax.Text = _Customer_Info.Fax;
                    txtRepresentive.Text = c_Contract_Info.Representive;
                    txtUsers.Text = c_Contract_Info.Users;
                    txtTaxCode.Text = _Customer_Info.Tax_Code;
                    txtIdentity_Card.Text = _Customer_Info.Identity_Card;
                }

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
                cboStatus.SelectedValue = c_Contract_Info.Status;

                txtFee.Text = c_Contract_Info.Fee.ToString("#,##0.#");

                List<Fees_Revenue_Info> c_lst_Fee = new List<Fees_Revenue_Info>();
                List<Fees_Revenue_Info> c_lst_Fee_Extend = new List<Fees_Revenue_Info>();

                if (c_Contract_Info.Status == (decimal)Enum_Contract_Status.Gia_Han)
                {
                    Extend_Contract_Controller _Extend_Contract_Controller = new Extend_Contract_Controller();
                    List<Extend_Contract_Info> _lst_ex = _Extend_Contract_Controller.Extend_Contract_GetByContractId(c_Contract_Info.Contract_Id);
                    if (_lst_ex.Count > 0)
                    {
                        txtFeeOnePay_Extend.Text = _lst_ex[0].FeeOnePay.ToString("#,##0.#");
                        txtFee_Extend.Text = _lst_ex[0].Fee.ToString("#,##0.#");
                        dpFromDate_Extend.Text = _lst_ex[0].Contract_FromDate.ToString("dd/MM/yyyy");
                        dpToDate_Extend.Text = _lst_ex[0].Contract_ToDate.ToString("dd/MM/yyyy");
                    }

                    tabExtend.Visibility = Visibility.Visible;
                    List<Fees_Revenue_Info> _lst = _Fees_Revenue_Controller.Fees_Revenue_GetByContract(c_Contract_Info.Contract_Id);

                    foreach (Fees_Revenue_Info item in _lst)
                    {
                        if (item.Is_Extend == 1)
                        {
                            c_lst_Fee_Extend.Add(item);
                        }
                        else
                            c_lst_Fee.Add(item);
                    }

                    txtFee_Vnd_Extend.Text = c_lst_Fee_Extend[c_lst_Fee_Extend.Count - 1].Fee_Vnd.ToString("#,##0.#");
                    txtFee_Vnd_Extend.Focusable = false;
                    txtFee_Vnd_Extend.IsHitTestVisible = false;
                }
                else
                {
                    tabExtend.Visibility = Visibility.Collapsed;
                    c_lst_Fee = _Fees_Revenue_Controller.Fees_Revenue_GetByContract(c_Contract_Info.Contract_Id);
                    txtFee_Vnd.Text = c_lst_Fee[c_lst_Fee.Count - 1].Fee_Vnd.ToString("#,##0.#");

                    txtFee_Vnd.Focusable = false;
                    txtFee_Vnd.IsHitTestVisible = false;
                }

                dgrFee.ItemsSource = c_lst_Fee;
                dgrFee_Extend.ItemsSource = c_lst_Fee_Extend;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        #endregion
    }
}
