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
using AvalonDock;
using StartsInternational.Common;
using System.Data;
using StartsInternational.Contract;

namespace StartsInternational.Report
{
    /// <summary>
    /// Interaction logic for Report_Status_Contract.xaml
    /// </summary>
    public partial class Report_Fees : DockableContent
    {
        public Report_Fees()
        {
            InitializeComponent();
        }

        List<Fee_Report_Info> c_lst = new List<Fee_Report_Info>();
        Fees_Revenue_Controller c_Fees_Revenue_Controller = new Fees_Revenue_Controller();
        Estate_Object_Controller _Estate_Object_Controller = new Estate_Object_Controller();
        Customer_Controller _Customer_Controller = new Customer_Controller();
        Contract_Controller c_Contract_Controller = new Contract_Controller();

        bool Is_Load = false;

        private void frmReport_Fees_Loaded(object sender, RoutedEventArgs e)
        {
            if (Is_Load == false)
            {
                LoadCombobox();

                dpFromDate.Text = DateTime.Now.AddDays(-30).ToString("dd/MM/yyyy");
                dpToDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }

        private void frmReport_Fees_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Delete:
                    e.Handled = true;
                    break;
                case Key.F8:
                    Export_Payment();
                    break;
            }
        }

        private void dgrContract_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void dgrContract_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                e.Handled = true;
            }
        }

        private void btnSearch_Click_1(object sender, RoutedEventArgs e)
        {
            Search();
        }

        private void btnExport_Click_1(object sender, RoutedEventArgs e)
        {
            Export();
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            Export_Payment();
        }

        /// <summary>
        /// hàm dùng cho EventsSetter trong form display
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void DoubleClick(object sender, RoutedEventArgs e)
        {
            try
            {
                e.Handled = true;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        void LoadCombobox()
        {
            try
            {
                AllCode_Info _AllCode_Info = new AllCode_Info();
                _AllCode_Info.Content = CommonData.c_All_Content;
                _AllCode_Info.CdValue = CommonData.c_All_Value;

                Estate_Object_Controller _Estate_Object_Controller = new Estate_Object_Controller();
                List<Estate_Object_Info> _lst_eb = _Estate_Object_Controller.Estate_Object_GetAll();

                Estate_Object_Info _Estate_Object_Info = new Estate_Object_Info();
                _Estate_Object_Info.Estate_Code = CommonData.c_All_Value;
                _Estate_Object_Info.Estate_Name = CommonData.c_All_Value;
                _lst_eb.Insert(0, _Estate_Object_Info);
                cboEsateCode.ItemsSource = _lst_eb;
                cboEsateCode.DisplayMemberPath = "Estate_Name";
                cboEsateCode.SelectedValuePath = "Estate_Code";
                cboEsateCode.SelectedIndex = 0;

                User_Controller c_User_Controller = new User_Controller();
                List<User_Info> _lst_us = c_User_Controller.User_Get_All();
                User_Info _User_Info = new User_Info();
                _User_Info.User_Name = CommonData.c_All_Value;
                _User_Info.User_Name = CommonData.c_All_Value;
                _lst_us.Insert(0, _User_Info);
                cboCreatedBy.ItemsSource = _lst_us;
                cboCreatedBy.DisplayMemberPath = "User_Name";
                cboCreatedBy.SelectedValuePath = "User_Name";
                cboCreatedBy.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        void Search()
        {
            try
            {
                Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;

                if (dpFromDate.Text == "")
                {
                    NoteBox.Show("Thời gian từ ngày không được để trống", "", NoteBoxLevel.Error);
                    dpFromDate.Focus();
                    return;
                }
                if (CheckValidate.CheckValidDate(dpFromDate.Text) == false)
                {
                    NoteBox.Show("Thời gian từ ngày không đúng định dạng", "", NoteBoxLevel.Error);
                    dpFromDate.Focus();
                    return;
                }

                if (dpToDate.Text == "")
                {
                    NoteBox.Show("Thời gian đến ngày không được để trống", "", NoteBoxLevel.Error);
                    dpToDate.Focus();
                    return;
                }
                if (CheckValidate.CheckValidDate(dpToDate.Text) == false)
                {
                    NoteBox.Show("Thời gian đến ngày không đúng định dạng", "", NoteBoxLevel.Error);
                    dpToDate.Focus();
                    return;
                }

                if (ConvertData.ConvertString2Date(dpFromDate.Text).Date > ConvertData.ConvertString2Date(dpToDate.Text).Date)
                {
                    NoteBox.Show("Thời gian từ ngày phải nhỏ hơn đến ngày", "", NoteBoxLevel.Error);
                    dpFromDate.Focus();
                    return;
                }

                string _created_by = cboCreatedBy.SelectedValue.ToString().ToUpper();
                if (_created_by == "")
                    _created_by = "ALL";

                string _estate_code = cboEsateCode.SelectedValue.ToString().ToUpper();
                if (_estate_code == "")
                    _estate_code = "ALL";

                string _user = txtUser.Text.ToUpper();
                if (_user == "")
                    _user = "ALL";

                string _Customer = txtCustomer.Text.ToUpper();
                if (_Customer == "")
                    _Customer = "ALL";

                DateTime _fromdate = ConvertData.ConvertString2Date(dpFromDate.Text);
                DateTime _todate = ConvertData.ConvertString2Date(dpToDate.Text);
                string _str_from_date = ConvertData.ConvertDate2String(_fromdate);
                string _str_to_date = ConvertData.ConvertDate2String(_todate);

                c_lst = c_Fees_Revenue_Controller.Fees_Report(_str_from_date, _str_to_date,
                    _created_by, _estate_code, _user, _Customer);

                Mouse.OverrideCursor = null;
                dgrContract.ItemsSource = c_lst;
                DataGridHelper.NVSFocus(dgrContract, 0, 0);
            }
            catch (Exception ex)
            {
                Mouse.OverrideCursor = null;
                ErrorLog.log.Error(ex.ToString());
            }
        }

        void Export()
        {
            try
            {
                #region Kết xuất

                FlexCel.Report.FlexCelReport flcReport = new FlexCel.Report.FlexCelReport();
                string _path = CommonData.ExcelDesignFilePath;
                string _fileExcelName = "Report_Fee.xls";

                foreach (Fee_Report_Info item in c_lst)
                {
                    if (item.Currency == (decimal)Enum_Contract_Currency.VND)
                    {
                        item.PhiMoiGio_VND = item.PhiMoiGio;
                        item.TienChuaVe_VND = item.TienChuaVe;
                        item.TienDaVe_VND = item.TienDaVe;

                        item.PhiMoiGio_USD = 0;
                        item.TienChuaVe_USD = 0;
                        item.TienDaVe_USD = 0;
                    }
                    else
                    {
                        item.PhiMoiGio_USD = item.PhiMoiGio;
                        item.TienChuaVe_USD = item.TienChuaVe;
                        item.TienDaVe_USD = item.TienDaVe;

                        item.PhiMoiGio_VND = 0;
                        item.TienChuaVe_VND = 0;
                        item.TienDaVe_VND = 0;
                    }
                }

                DataSet ds_all = new DataSet();
                DataTable _dt = ConvertData.ConvertToDatatable(c_lst);
                _dt.Columns.Add("STT");
                int index = 1;
                foreach (DataRow item in _dt.Rows)
                {
                    item["STT"] = index;
                    index++;
                }

                ds_all.Tables.Add(_dt);
                ds_all.Tables[0].TableName = "Fee";

                if (ds_all.Tables.Count <= 0)
                {
                    Mouse.OverrideCursor = null;
                    NoteBox.Show("Không có dữ liệu để kết xuất", "Thông báo", NoteBoxLevel.Note);
                    return;
                }
                if (ds_all.Tables[0].Rows.Count <= 0)
                {
                    Mouse.OverrideCursor = null;
                    NoteBox.Show("Không có dữ liệu để kết xuất", "Thông báo", NoteBoxLevel.Note);
                    return;
                }

                _path += _fileExcelName;

                CommonFunction.SetValueExportByDataTable(ref flcReport, ds_all);

                System.Windows.Forms.SaveFileDialog saveReport = new System.Windows.Forms.SaveFileDialog();
                saveReport.Filter = "Excel files (*.xls)|*.xls";
                if (saveReport.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    CommonFunction.ExportExcel(flcReport, _path, saveReport);
                }
                #endregion
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        void Export_Payment()
        {
            try
            {
                Fee_Report_Info _Fees_Revenue_Info = (Fee_Report_Info)dgrContract.SelectedItem;

                if (_Fees_Revenue_Info == null) return;
                Customer_Info _Customer_Info = _Customer_Controller.Customer_GetById(_Fees_Revenue_Info.Object_Id);
                Estate_Object_Info _Estate_Object_Info = _Estate_Object_Controller.Estate_Object_GetById(_Fees_Revenue_Info.Estate_Id, _Fees_Revenue_Info.Contract_Type);

                #region Kết xuất

                FlexCel.Report.FlexCelReport flcReport = new FlexCel.Report.FlexCelReport();
                string _path = CommonData.ExcelDesignFilePath;
                string _fileExcelName = "Payment_Request_VND.xls";

                if (_Fees_Revenue_Info.Currency == (decimal)Enum_Contract_Currency.USD)
                {
                    _fileExcelName = "Payment_Request_USD.xls";
                }

                _path += _fileExcelName;

                CommonFunction.SetValueExportByString(ref flcReport, "CurrentDate", DateTime.Now.ToString("dd/MM/yyyy"));
                CommonFunction.SetValueExportByString(ref flcReport, "Tenat_Name", _Customer_Info.Customer_Name);
                CommonFunction.SetValueExportByString(ref flcReport, "Address", _Customer_Info.Address);
                CommonFunction.SetValueExportByString(ref flcReport, "Users", _Fees_Revenue_Info.Users);
                CommonFunction.SetValueExportByString(ref flcReport, "TaxCode", _Customer_Info.Tax_Code);
                CommonFunction.SetValueExportByString(ref flcReport, "Estate_Name", _Estate_Object_Info.Estate_Name);
                CommonFunction.SetValueExportByString(ref flcReport, "Contract_FromDate", _Fees_Revenue_Info.Contract_FromDate.ToString("dd/MM/yyyy"));
                CommonFunction.SetValueExportByString(ref flcReport, "Contract_ToDate", _Fees_Revenue_Info.Contract_ToDate.ToString("dd/MM/yyyy"));

                //decimal _VAT_Fee = Math.Round(_Fees_Revenue_Info.Fee_Expected * 10 / 100);
                //decimal _Fee = _Fees_Revenue_Info.Fee_Expected - _VAT_Fee;

                //decimal _p = 110 / 100;
                //decimal _Fee = _Fees_Revenue_Info.Fee_Expected / _p;
                //decimal _VAT_Fee = Math.Round(_Fee * 10 / 100);
                decimal _Fee = (_Fees_Revenue_Info.Fee_Expected / 110) * 100;
                decimal _VAT_Fee = Math.Round(_Fee * 10 / 100);

                CommonFunction.SetValueExportByString(ref flcReport, "Fee", _Fee.ToString("###,##0"));
                CommonFunction.SetValueExportByString(ref flcReport, "VAT_Fee", _VAT_Fee.ToString("###,##0"));
                CommonFunction.SetValueExportByString(ref flcReport, "Total_Fee", _Fees_Revenue_Info.Fee_Expected.ToString("###,##0"));

                if (_Fees_Revenue_Info.Contract_Type == (decimal)Enum_Contract_Type.Tenant)
                {
                    #region Kỳ thanh toán
                    string _Kytt = "Thanh toán phí MG lần " + _Fees_Revenue_Info.Number_Payment
                                    + " từ ngày " + _Fees_Revenue_Info.HanChuyenTien.ToString("dd/MM/yyyy") + " đến ngày " +
                                    _Fees_Revenue_Info.HanChuyenTien.AddDays(30).ToString("dd/MM/yyyy");

                    if (_Fees_Revenue_Info.Term == (decimal)Enum_Fee_Maturity.One)
                    {
                        _Kytt = "Thanh toán phí MG lần " + _Fees_Revenue_Info.Number_Payment
                        + " từ ngày " + _Fees_Revenue_Info.HanChuyenTien.ToString("dd/MM/yyyy") + " đến ngày " +
                        _Fees_Revenue_Info.HanChuyenTien.AddDays(30).ToString("dd/MM/yyyy");
                    }
                    else if (_Fees_Revenue_Info.Term == (decimal)Enum_Fee_Maturity.One_Month)
                    {
                        _Kytt = "Thanh toán phí MG lần " + _Fees_Revenue_Info.Number_Payment
                        + " từ ngày " + _Fees_Revenue_Info.HanChuyenTien.ToString("dd/MM/yyyy") + " đến ngày " +
                        _Fees_Revenue_Info.HanChuyenTien.AddMonths(1).ToString("dd/MM/yyyy");
                    }
                    else if (_Fees_Revenue_Info.Term == (decimal)Enum_Fee_Maturity.Three_Month)
                    {
                        _Kytt = "Thanh toán phí MG lần " + _Fees_Revenue_Info.Number_Payment
                        + " từ ngày " + _Fees_Revenue_Info.HanChuyenTien.ToString("dd/MM/yyyy") + " đến ngày " +
                        _Fees_Revenue_Info.HanChuyenTien.AddMonths(3).ToString("dd/MM/yyyy");
                    }
                    else if (_Fees_Revenue_Info.Term == (decimal)Enum_Fee_Maturity.Six_Month)
                    {
                        _Kytt = "Thanh toán phí MG lần " + _Fees_Revenue_Info.Number_Payment
                        + " từ ngày " + _Fees_Revenue_Info.HanChuyenTien.ToString("dd/MM/yyyy") + " đến ngày " +
                        _Fees_Revenue_Info.HanChuyenTien.AddMonths(6).ToString("dd/MM/yyyy");
                    }
                    else if (_Fees_Revenue_Info.Term == (decimal)Enum_Fee_Maturity.One_Year)
                    {
                        _Kytt = "Thanh toán phí MG lần " + _Fees_Revenue_Info.Number_Payment
                        + " từ ngày " + _Fees_Revenue_Info.HanChuyenTien.ToString("dd/MM/yyyy") + " đến ngày " +
                        _Fees_Revenue_Info.HanChuyenTien.AddYears(1).ToString("dd/MM/yyyy");
                    }

                    CommonFunction.SetValueExportByString(ref flcReport, "KyThanhToan", _Kytt); 
                    #endregion
                }
                else
                    CommonFunction.SetValueExportByString(ref flcReport, "KyThanhToan", "");

                DateTime _dt_from = DateTime.Now;
                DateTime _dt_To = _dt_from.AddDays(30);

                CommonFunction.SetValueExportByString(ref flcReport, "From", _dt_from.ToString("dd/MM/yyyy"));
                CommonFunction.SetValueExportByString(ref flcReport, "To", _dt_To.ToString("dd/MM/yyyy"));

                //CommonFunction.SetValueExportByString(ref flcReport, "From", _Fees_Revenue_Info.HanChuyenTien.ToString("dd/MM/yyyy"));
                //CommonFunction.SetValueExportByString(ref flcReport, "To", _Fees_Revenue_Info.HanChuyenTien.AddDays(30).ToString("dd/MM/yyyy"));

                if (_Fees_Revenue_Info.Price != 0)
                    CommonFunction.SetValueExportByString(ref flcReport, "Price", _Fees_Revenue_Info.Price.ToString("###,##0"));
                else
                    CommonFunction.SetValueExportByString(ref flcReport, "Price", "");

                string _tienBangChu = ConvertData.ConvertMoneyToStr(Convert.ToDouble(_Fees_Revenue_Info.Fee_Expected));
                if (_Fees_Revenue_Info.Currency == (decimal)Enum_Contract_Currency.USD)
                {
                    _tienBangChu = c_Contract_Controller.Convert_Dola(_Fees_Revenue_Info.Fee_Expected);
                }

                if (_Fees_Revenue_Info.Currency == (decimal)Enum_Contract_Currency.USD)
                {
                    CommonFunction.SetValueExportByString(ref flcReport, "VND", _Fees_Revenue_Info.Fee_Vnd.ToString("###,##0"));
                }

                CommonFunction.SetValueExportByString(ref flcReport, "BangChu", _tienBangChu.ToLower());

                System.Windows.Forms.SaveFileDialog saveReport = new System.Windows.Forms.SaveFileDialog();
                saveReport.Filter = "Excel files (*.xls)|*.xls";
                if (saveReport.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    CommonFunction.ExportExcel(flcReport, _path, saveReport);
                }

                #endregion
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }
    }
}
