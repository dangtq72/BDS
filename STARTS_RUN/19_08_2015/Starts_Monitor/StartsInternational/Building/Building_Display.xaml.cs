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

namespace StartsInternational.Building
{
    /// <summary>
    /// Interaction logic for Renter_Display.xaml
    /// </summary>
    public partial class Building_Display : DockableContent
    {
        public Building_Display()
        {
            InitializeComponent();
        }

        BuildingController c_BuildingController = new BuildingController();
        List<Building_Info> c_lst = new List<Building_Info>();
        int c_row_select = 0;
        bool c_is_first = false;

        private void frmBuilding_Display_Loaded_1(object sender, RoutedEventArgs e)
        {
            if (c_is_first == false)
            {
                //LoadData();
                c_is_first = true;
            }
            txtBuildingName.Focus();
        }

        private void frmBuilding_Display_KeyDown_1(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.F3:
                    Insert();
                    break;
                case Key.F4:
                    Update();
                    break;
                case Key.F5:
                    View();
                    break;
                case Key.F9:
                    LoadData();
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
            View();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            Insert();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Delete();
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
                View();
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
                c_lst = c_BuildingController.Building_GetAll();
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

                string _name = txtBuildingName.Text.ToUpper();
                if (_name == "") _name = CommonData.c_All_Value;

                c_lst = c_BuildingController.Building_Search(_name);

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
                string _fileExcelName = "Building.xls";

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
                ds_all.Tables[0].TableName = "Building";

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

        void Insert()
        {
            try
            {
                Create_Building _Create_Building = new Create_Building();
                _Create_Building.Owner = Window.GetWindow(this);
                _Create_Building.ShowDialog();

                if (_Create_Building.c_id_insert != 0)
                {
                    LoadData();

                    for (int i = 0; i < c_lst.Count; i++)
                    {
                        Building_Info ui = (Building_Info)c_lst[i];
                        if (ui.Building_Id == _Create_Building.c_id_insert)
                        {
                            c_row_select = i;
                            _Create_Building.c_id_insert = 0;
                            break;
                        }
                    }
                }

                DataGridHelper.NVSFocus(dgrRenter, c_row_select, 0);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        void Update()
        {
            try
            {
                c_row_select = dgrRenter.SelectedIndex;
                Building_Info _Building_Info = (Building_Info)dgrRenter.SelectedItem;

                if (_Building_Info == null) return;
                Update_Building _Update_Building = new Update_Building();
                _Update_Building.c_Building_Info = _Building_Info;
                _Update_Building.Owner = Window.GetWindow(this);
                _Update_Building.ShowDialog();

                if (_Update_Building.c_id_insert != 0)
                {
                    Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
                    LoadData();

                    Mouse.OverrideCursor = null;
                }

                 
                DataGridHelper.NVSFocus(dgrRenter, c_row_select, 0);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        void Delete()
        {
            try
            {
                c_row_select = dgrRenter.SelectedIndex;
                Building_Info _Building_Info = (Building_Info)dgrRenter.SelectedItem;

                if (_Building_Info == null) return;

                bool _ck = c_BuildingController.Check_Exit_EstateInBuilding(_Building_Info.Building_Id);
                if (_ck == true)
                {
                    NoteBox.Show("Đối tượng BĐS thuộc toà nhà không thể xóa", "", NoteBoxLevel.Error);
                    return;
                }

                MessageBoxResult result = NoteBox.Show("Bạn chắc chắn muốn xóa tòa nhà này hay không?", "Thông báo", NoteBoxLevel.Question);
                if (MessageBoxResult.Yes == result)
                {

                    if (c_BuildingController.Building_Delete(_Building_Info.Building_Id))
                    {
                        NoteBox.Show("Xóa dữ liệu thành công");
                        LoadData();
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

        void View()
        {
            try
            {
                c_row_select = dgrRenter.SelectedIndex;
                Building_Info _Building_Info = (Building_Info)dgrRenter.SelectedItem;

                if (_Building_Info == null) return;

                View_Building _View_Building = new View_Building();
                _View_Building.Owner = Window.GetWindow(this);

                _View_Building.c_Building_Info = _Building_Info;
                _View_Building.ShowDialog();

                DataGridHelper.NVSFocus(dgrRenter, c_row_select, 0);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }
    }
}
