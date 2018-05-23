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
    public partial class Report_Contract_Renter_NoPay : DockableContent
    {
        public Report_Contract_Renter_NoPay()
        {
            InitializeComponent();
        }

        List<Contract_Info> c_lst = new List<Contract_Info>();
        int c_row_select = 0;
        Contract_Controller c_Contract_Controller = new Contract_Controller();

        bool Is_Load = false;

        private void frmReport_Contract_Renter_NoPay_Loaded_1(object sender, RoutedEventArgs e)
        {
        }

        private void frmReport_Contract_Renter_NoPay_PreviewKeyDown_1(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Delete:
                    e.Handled = true;
                    break;
                case Key.Print:
                    Export();
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
            View_Contract();
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
                View_Contract();
                e.Handled = true;
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

                string _code = txtCode.Text.ToUpper();
                if (_code == "") _code = CommonData.c_All_Value;

                c_lst = c_Contract_Controller.Contract_Render_Search(_code, CommonData.c_All_Value, ((decimal)Enum_Fee_Status.No_Pay).ToString(), "-1", CommonData.c_All_Value);

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
                string _fileExcelName = "Contract_Renter_NoPay.xls";

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
                ds_all.Tables[0].TableName = "Renter";

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

        void View_Contract()
        {
            try
            {
                c_row_select = dgrContract.SelectedIndex;
                Contract_Info _Contract_Info = (Contract_Info)dgrContract.SelectedItem;

                if (_Contract_Info == null) return;

                View_Contract_Renter _View_Contract_Renter = new View_Contract_Renter();
                _View_Contract_Renter.Owner = Window.GetWindow(this);

                _View_Contract_Renter.c_Contract_Info = _Contract_Info;
                _View_Contract_Renter.ShowDialog();

                DataGridHelper.NVSFocus(dgrContract, c_row_select, 0);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }
    }
}
