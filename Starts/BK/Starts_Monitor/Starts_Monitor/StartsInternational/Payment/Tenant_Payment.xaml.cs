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

using MemoryData;
using Starts_Controller;
using ObjInfo;

namespace StartsInternational.Payment
{
    /// <summary>
    /// Interaction logic for Tenant_Payment.xaml
    /// </summary>
    public partial class Tenant_Payment : Window
    {
        public Tenant_Payment()
        {
            InitializeComponent();
        }

        public Contract_Info c_Contract_Info;
        Fees_Revenue_Controller _Fees_Revenue_Controller = new Fees_Revenue_Controller();
        Contract_Controller _Contract_Controller = new Contract_Controller();
        List<Fees_Revenue_Info> c_lst_Fee_Pay = new List<Fees_Revenue_Info>();
        List<Fees_Revenue_Info> c_lst_Fee_All = new List<Fees_Revenue_Info>();
        Fees_Revenue_Info c_Fees_MustPay = new Fees_Revenue_Info();

        int c_index = 0;

        public bool c_ok = false;

        private void frmTenant_Payment_Loaded_1(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void frmTenant_Payment_KeyDown_1(object sender, KeyEventArgs e)
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                TextBox textbox = (TextBox)e.Source;
                switch (textbox.Name)
                {
                    case "txtFeeExpected":
                        CommonFunction.Text_Change_Format_Money(txtFeeExpected);
                        break;
                    case "txtFeePay":
                        CommonFunction.Text_Change_Format_Money(txtFeePay);
                        break;
                }
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }

        }

        void LoadData()
        {
            try
            {
                c_lst_Fee_All = _Fees_Revenue_Controller.Fees_Revenue_GetByContract(c_Contract_Info.Contract_Id);


                foreach (Fees_Revenue_Info item in c_lst_Fee_All)
                {
                    if (item.Pay_Status == (decimal)Enum_Fee_Status.Payed)
                    {
                        c_lst_Fee_Pay.Add(item);
                    }

                }

                c_index = 0;
                foreach (Fees_Revenue_Info item in c_lst_Fee_All)
                {
                    if (item.Pay_Status != (decimal)Enum_Fee_Status.Payed)
                    {
                        c_Fees_MustPay = item;
                        break;
                    }
                    c_index++;
                }

                txtFeeExpected.Text = c_Fees_MustPay.Fee_Expected.ToString();
                txtPay_Date_Expected.Text = c_Fees_MustPay.Pay_Date_Expected.ToString("dd/MM/yyyy");

                dpPay_Date.Text = Common.ConvertData.ConvertDate2String(DateTime.Now);

                dgrFee.ItemsSource = c_lst_Fee_Pay;
                txtFeePay.Focus();
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        void Accept()
        {
            try
            {
                if (txtFeePay.Text == "")
                {
                    NoteBox.Show("Số tiền thanh toán không được để trống");
                    txtFeePay.Focus();
                    return;
                }

                if (dpPay_Date.Text == "")
                {
                    NoteBox.Show("Ngày thanh toán không được để trống", "", NoteBoxLevel.Error);
                    dpPay_Date.Focus();
                    return;
                }
                if (CheckValidate.CheckValidDate(dpPay_Date.Text) == false)
                {
                    NoteBox.Show("Ngày thanh toán không đúng định dạng", "", NoteBoxLevel.Error);
                    dpPay_Date.Focus();
                    return;
                }

                Fees_Revenue_Info _Fees_Revenue_Info = new Fees_Revenue_Info();
                _Fees_Revenue_Info.Fee_Id = c_Fees_MustPay.Fee_Id;
                _Fees_Revenue_Info.Pay_Date = Common.ConvertData.ConvertString2Date(dpPay_Date.Text);
                _Fees_Revenue_Info.Fee = Convert.ToDecimal(txtFeePay.Text);
                _Fees_Revenue_Info.Debit_Amount = c_Fees_MustPay.Fee_Expected - _Fees_Revenue_Info.Fee;
                _Fees_Revenue_Info.Pay_Status = (decimal)Enum_Fee_Status.Payed;

                MessageBoxResult result = NoteBox.Show("Bạn có muốn thanh toán phí môi giới cho hợp đồng này hay không?", "Thông báo", NoteBoxLevel.Question);
                if (MessageBoxResult.Yes != result)
                {
                    return;
                }

                if (_Fees_Revenue_Controller.Fees_Revenue_Update(_Fees_Revenue_Info) == false)
                {
                    NoteBox.Show("Lỗi thanh toán", "", NoteBoxLevel.Error);
                    return;
                }

                Contract_Info _Contract_Info = c_Contract_Info;

                if (c_index == c_lst_Fee_All.Count - 1)
                {
                    _Contract_Info.Fee_Status = (decimal)Enum_Fee_Status.Payed;
                }
                else
                    _Contract_Info.Fee_Status = (decimal)Enum_Fee_Status.No_Pay;

                if (_Contract_Controller.Contract_Update(c_Contract_Info.Contract_Id, _Contract_Info) == false)
                {
                    NoteBox.Show("Lỗi cập nhật hợp đồng cho thuê nhà", "", NoteBoxLevel.Error);
                    return;
                }

                NoteBox.Show("Thanh toán phí thành công");
                c_ok = true;
                this.Close();
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }
    }
}
