using AvalonDock;
using MemoryData;
using ObjInfo;
using Starts_Controller;
using StartsInternational.Common;
using StartsInternational.Customer;
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
    public partial class Customer_Display : DockableContent
    {
        public Customer_Display()
        {
            InitializeComponent();
        }

        Customer_Controller c_Customer_Controller = new Customer_Controller();
        List<Customer_Info> c_lst = new List<Customer_Info>();
        int c_row_select = 0;

        private void frmCustomer_Display_Loaded(object sender, RoutedEventArgs e)
        {
            txtRenterName.Focus();
        }

        private void frmCustomer_Display_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.F3:
                    Insert_Customer();
                    break;
                case Key.F4:
                    Update_Customer();
                    break;
                case Key.F5:
                    View_Customer();
                    break;
                case Key.F9:
                    Search();
                    break;
                case Key.Delete:
                    e.Handled = true;
                    break;
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

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            View_Customer();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            Insert_Customer();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Update_Customer();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Delete_Contract();
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
                View_Customer();
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
                c_lst = c_Customer_Controller.Customer_GetAll();
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

                string _phone = txtPhone.Text.ToUpper();
                if (_phone == "") _phone = CommonData.c_All_Value;

                c_lst = c_Customer_Controller.Customer_Search(_name, _phone);

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
                string _fileExcelName = "Customer.xls";

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
                ds_all.Tables[0].TableName = "Customer";

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

        void Insert_Customer()
        {
            try
            {
                Customer_Insert _Customer_Insert = new Customer_Insert();
                _Customer_Insert.Owner = Window.GetWindow(this);
                _Customer_Insert.ShowDialog();

                if (_Customer_Insert.c_id_insert != 0)
                {
                    Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;

                    Search();

                    DBMemory.LoadFeeRender();

                    for (int i = 0; i < c_lst.Count; i++)
                    {
                        Customer_Info ui = (Customer_Info)c_lst[i];
                        if (ui.Customer_Id == _Customer_Insert.c_id_insert)
                        {
                            c_row_select = i;
                            _Customer_Insert.c_id_insert = 0;
                            break;
                        }
                    }
                }

                Mouse.OverrideCursor = null;
                DataGridHelper.NVSFocus(dgrRenter, c_row_select, 0);
            }
            catch (Exception ex)
            {
                Mouse.OverrideCursor = null;
                CommonData.log.Error(ex.ToString());
            }
        }

        void Update_Customer()
        {
            try
            {
                c_row_select = dgrRenter.SelectedIndex;
                Customer_Info _Customer_Info = (Customer_Info)dgrRenter.SelectedItem;

                if (_Customer_Info == null) return;
                Customer_Update _Customer_Update = new Customer_Update();
                _Customer_Update.c_Customer_Info = _Customer_Info;
                _Customer_Update.Owner = Window.GetWindow(this);
                _Customer_Update.ShowDialog();

                if (_Customer_Update.c_id_insert != 0)
                {
                    Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
                    Search();
                    Mouse.OverrideCursor = null;
                }

                DataGridHelper.NVSFocus(dgrRenter, c_row_select, 0);
            }
            catch (Exception ex)
            {
                Mouse.OverrideCursor = null;
                CommonData.log.Error(ex.ToString());
            }
        }

        void View_Customer()
        {
            try
            {
                c_row_select = dgrRenter.SelectedIndex;
                Customer_Info _Customer_Info = (Customer_Info)dgrRenter.SelectedItem;

                if (_Customer_Info == null) return;
                Customer_View _Customer_View = new Customer_View();
                _Customer_View.c_Customer_Info = _Customer_Info;
                _Customer_View.Owner = Window.GetWindow(this);
                _Customer_View.ShowDialog();

                 
                DataGridHelper.NVSFocus(dgrRenter, c_row_select, 0);
            }
            catch (Exception ex)
            {
                Mouse.OverrideCursor = null;
                CommonData.log.Error(ex.ToString());
            }
        }

        void Delete_Contract()
        {
            try
            {
                c_row_select = dgrRenter.SelectedIndex;
                Customer_Info _Customer_Info = (Customer_Info)dgrRenter.SelectedItem;

                if (_Customer_Info == null) return;

                if (c_Customer_Controller.Customer_Check_In_Contract(_Customer_Info.Customer_Id) == false)
                {
                    NoteBox.Show("Tồn tại khách hàng trong hợp đồng, không thể xóa","",NoteBoxLevel.Error);
                    return;
                }

                MessageBoxResult result = NoteBox.Show("Bạn chắc chắn muốn xóa khách hàng này hay không?", "Thông báo", NoteBoxLevel.Question);
                if (MessageBoxResult.Yes == result)
                {
                    if (c_Customer_Controller.Customer_Delete(_Customer_Info.Customer_Id))
                    {
                        NoteBox.Show("Xóa dữ liệu thành công");
                        Search();
                        DBMemory.LoadFeeRender();
                    }
                }
                else
                    DataGridHelper.NVSFocus(dgrRenter, c_row_select, 0);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }
    }
}
