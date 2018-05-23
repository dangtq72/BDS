using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

using System.Collections;
using ObjInfo;
using AvalonDock;
using Starts_Monitor.User;
using Starts_Controller;
using StartsInternational.Control.Created;
using StartsInternational.Common;
using MemoryData;
using System.Data;
namespace StartsInternational.Estate_Object
{
    /// <summary>
    /// Interaction logic for Estate_Object_Display.xaml
    /// </summary>
    public partial class Estate_Object_Display : DockableContent
    {
        public Estate_Object_Display()
        {
            InitializeComponent();
        }

        List<Estate_Object_Info> c_lst = new List<Estate_Object_Info>();
        int c_row_select = 0;
        Estate_Object_Controller c_Estate_Object_Controller = new Estate_Object_Controller();
        bool c_isLoadFirst = false;

        private void frmEstate_Object_Display_Loaded(object sender, RoutedEventArgs e)
        {
            if (c_isLoadFirst == false)
            {
                LoadCombobox();
                //LoadData();
                c_isLoadFirst = true;
            }
        }

        private void frmEstate_Object_Display_KeyDown(object sender, KeyEventArgs e)
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

        private void dgrEstate_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void dgrEstate_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                Delete();
                e.Handled = true;
            }
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

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            View();
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

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Search();
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            Export();
        }

        #region Methods

        void LoadCombobox()
        {
            try
            {
                AllCode_Info _AllCode_Info = new AllCode_Info();
                _AllCode_Info.Content = CommonData.c_All_Content;
                _AllCode_Info.CdValue = CommonData.c_All_Value;

                List<AllCode_Info> _lst_c_Status = DBMemory.AllCode_GetBy_CdNameCdType("ESTATE", "STATUS");
                _lst_c_Status.Insert(0, _AllCode_Info);
                cboStatus.ItemsSource = _lst_c_Status;
                cboStatus.DisplayMemberPath = "Content";
                cboStatus.SelectedValuePath = "CdValue";
                cboStatus.SelectedIndex = 0;

                List<AllCode_Info> _lst_c_type = DBMemory.AllCode_GetBy_CdNameCdType("ESTATE", "TYPE");
                _lst_c_type.Insert(0, _AllCode_Info);
                cboType.ItemsSource = _lst_c_type;
                cboType.DisplayMemberPath = "Content";
                cboType.SelectedValuePath = "CdValue";
                cboType.SelectedIndex = 0;
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
                c_lst = c_Estate_Object_Controller.Estate_Object_GetAll();
                dgrEstate.ItemsSource = c_lst;
                DataGridHelper.NVSFocus(dgrEstate, 0, 0);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        void Insert()
        {
            try
            {
                Create_Estate_Object _Create_Estate_Object = new Create_Estate_Object();
                _Create_Estate_Object.Owner = Window.GetWindow(this);
                _Create_Estate_Object.ShowDialog();

                if (_Create_Estate_Object.c_id_insert != 0)
                {
                    LoadData();

                    for (int i = 0; i < c_lst.Count; i++)
                    {
                        Estate_Object_Info ui = (Estate_Object_Info)c_lst[i];
                        if (ui.Estate_Id == _Create_Estate_Object.c_id_insert)
                        {
                            c_row_select = i;
                            _Create_Estate_Object.c_id_insert = 0;
                            break;
                        }
                    }
                }

                DataGridHelper.NVSFocus(dgrEstate, c_row_select, 0);
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
                c_row_select = dgrEstate.SelectedIndex;
                Estate_Object_Info _Estate_Object_Info = (Estate_Object_Info)dgrEstate.SelectedItem;

                if (_Estate_Object_Info == null) return;
                Update_Estate_Object _Update_Estate_Object = new Update_Estate_Object();
                _Update_Estate_Object.c_Estate_Object_Info = _Estate_Object_Info;
                _Update_Estate_Object.Owner = Window.GetWindow(this);
                _Update_Estate_Object.ShowDialog();

                LoadData();
                DataGridHelper.NVSFocus(dgrEstate, c_row_select, 0);
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
                c_row_select = dgrEstate.SelectedIndex;
                Estate_Object_Info _Estate_Object_Info = (Estate_Object_Info)dgrEstate.SelectedItem;

                if (_Estate_Object_Info == null) return;

                bool _ck = c_Estate_Object_Controller.Check_Exit_EstateInContract(_Estate_Object_Info.Estate_Id);
                if (_ck == true)
                {
                    NoteBox.Show("Đối tượng bất động sản đã cho thuê hoặc đã thuê, không thể xóa", "", NoteBoxLevel.Error);
                    return;
                }

                MessageBoxResult result = NoteBox.Show("Bạn chắc chắn muốn xóa đối tượng BĐS này hay không?", "Thông báo", NoteBoxLevel.Question);
                if (MessageBoxResult.Yes == result)
                {

                    if (c_Estate_Object_Controller.Estate_Object_Delete(_Estate_Object_Info.Estate_Id))
                    {
                        NoteBox.Show("Xóa dữ liệu thành công");
                        LoadData();
                    }
                }
                else
                    DataGridHelper.NVSFocus(dgrEstate, c_row_select, 0);
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
                c_row_select = dgrEstate.SelectedIndex;
                Estate_Object_Info _Estate_Object_Info = (Estate_Object_Info)dgrEstate.SelectedItem;

                if (_Estate_Object_Info == null) return;

                View_Estate_Object _View_Estate_Object = new View_Estate_Object();
                _View_Estate_Object.Owner = Window.GetWindow(this);

                _View_Estate_Object.c_Estate_Object_Info = _Estate_Object_Info;
                _View_Estate_Object.ShowDialog();

                DataGridHelper.NVSFocus(dgrEstate, c_row_select, 0);
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

                c_lst = c_Estate_Object_Controller.Estate_Object_Search(_code, cboType.SelectedValue.ToString(), cboStatus.SelectedValue.ToString());


                Mouse.OverrideCursor = null;
                dgrEstate.ItemsSource = c_lst;
                DataGridHelper.NVSFocus(dgrEstate, 0, 0);
            }
            catch (Exception ex)
            {
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
                string _fileExcelName = "Estate_Object.xls";

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
                ds_all.Tables[0].TableName = "Estate_Object";

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
        #endregion
       
    }
}
