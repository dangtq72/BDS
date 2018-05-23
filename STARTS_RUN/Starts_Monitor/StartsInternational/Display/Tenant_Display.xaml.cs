using AvalonDock;
using MemoryData;
using ObjInfo;
using Starts_Controller;
using StartsInternational.Common;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace StartsInternational.Display
{
    /// <summary>
    /// Interaction logic for Renter_Display.xaml
    /// </summary>
    public partial class Tenant_Display : DockableContent
    {
        public Tenant_Display()
        {
            InitializeComponent();
        }

        //Tenant_Controller c_Tenant_Controller = new Tenant_Controller();
        List<Tenant_Info> c_lst = new List<Tenant_Info>();

        bool c_is_first = false;

        private void frmRenter_Display_Loaded_1(object sender, RoutedEventArgs e)
        {
            if (c_is_first == false)
            {
                //LoadData();
                c_is_first = true;
            }
            txtRenterName.Focus();
        }

        private void frmRenter_Display_KeyDown_1(object sender, KeyEventArgs e)
        {

        }

        private void btnSearch_Click_1(object sender, RoutedEventArgs e)
        {
            Search();
        }

        private void btnExport_Click_1(object sender, RoutedEventArgs e)
        {
            Export();
        }

        private void dgrRenter_LoadingRow_1(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void dgrRenter_PreviewKeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                e.Handled = true;
            }
        }
      
        private void btnView_Click_1(object sender, RoutedEventArgs e)
        {

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
                //View_Contract();
                e.Handled = true;
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
                //c_lst = c_Tenant_Controller.Tenant_GetAll();
                dgrRenter.ItemsSource = c_lst;
                DataGridHelper.NVSFocus(dgrRenter, 0, 0);
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

                string _name = txtRenterName.Text.ToUpper();
                if (_name == "") _name = CommonData.c_All_Value;

                //c_lst = c_Tenant_Controller.Tenant_Search(_name);

                Mouse.OverrideCursor = null;
                dgrRenter.ItemsSource = c_lst;
                DataGridHelper.NVSFocus(dgrRenter, 0, 0);
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
                string _fileExcelName = "Tenant.xls";

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
                ds_all.Tables[0].TableName = "Tenant";

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
       
    }
}
