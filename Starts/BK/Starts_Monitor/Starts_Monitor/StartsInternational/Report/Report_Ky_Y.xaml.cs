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
using System.Collections;

namespace StartsInternational.Report
{
    /// <summary>
    /// Interaction logic for Report_Status_Contract.xaml
    /// </summary>
    public partial class Report_Ky_Y : DockableContent
    {
        public Report_Ky_Y()
        {
            InitializeComponent();
        }

        List<Contract_Info> c_lst = new List<Contract_Info>();
        int c_row_select = 0;
        Contract_Controller c_Contract_Controller = new Contract_Controller();

        bool Is_Load = false;

        private void frmReport_Ky_Y_Loaded_1(object sender, RoutedEventArgs e)
        {
            if (Is_Load == false)
            {
                LoadCombobox();
            }
        }

        private void frmReport_Ky_Y_PreviewKeyDown_1(object sender, KeyEventArgs e)
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

        void LoadCombobox()
        {
            try
            {
                AllCode_Info _AllCode_Info = new AllCode_Info();
                _AllCode_Info.Content = CommonData.c_All_Content;
                _AllCode_Info.CdValue = CommonData.c_All_Value;

                List<AllCode_Info> _lst_c_Status = DBMemory.AllCode_GetBy_CdNameCdType("CONTRACT", "STATUS");
                _lst_c_Status.Insert(0, _AllCode_Info);
                cboStatus.ItemsSource = _lst_c_Status;
                cboStatus.DisplayMemberPath = "Content";
                cboStatus.SelectedValuePath = "CdValue";
                cboStatus.SelectedIndex = 0;


                Building_Info _Building_Info_All = new Building_Info();
                _Building_Info_All.Building_Id = -1;
                _Building_Info_All.Building_Name = CommonData.c_All_Content;

                BuildingController _BuildingController = new BuildingController();
                List<Building_Info> _lst_B = _BuildingController.Building_GetAll();
                _lst_B.Insert(0, _Building_Info_All);
                cboBuilding.ItemsSource = _lst_B;
                cboBuilding.DisplayMemberPath = "Building_Name";
                cboBuilding.SelectedValuePath = "Building_Id";
                cboBuilding.SelectedIndex = 0;

                List<Contract_Info> _lst_contract = new List<Contract_Info>();
                _lst_contract = c_Contract_Controller.Contract_GetBy_Type((decimal)Enum_Contract_Type.Tenant);

                //dangtq sửa lại
                System.Data.DataTable temp = Common.ConvertData.ConvertToDatatable<Contract_Info>(_lst_contract);
                CommonFunction.NVS_BindTextboxComplete(txtCode, temp, "Contract_Code");
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

                c_lst = new List<Contract_Info>();

                string _code = txtCode.Text.ToUpper();

                if (_code == "") _code = CommonData.c_All_Value;

                string _Building = "-1";
                if (cboBuilding.Text != CommonData.c_All_Content)
                {
                    _Building = cboBuilding.SelectedValue.ToString();
                }

                List<Contract_Info> _lst = c_Contract_Controller.Contract_Search_ByExtend(CommonData.c_All_Value, _code,
                    cboStatus.SelectedValue.ToString(), CommonData.c_All_Value, _Building);

                Hashtable _hs = new Hashtable();

                if (_lst.Count > 0)
                {
                    for (int i = 0; i < _lst.Count; i++)
                    {
                        Contract_Info _Contract_Info = _lst[i];

                        if (_hs.ContainsKey(_Contract_Info.Contract_Id) == false)
                        {
                            _hs[_Contract_Info.Contract_Id] = _Contract_Info;
                            c_lst.Add(_Contract_Info);
                        }
                    }
                }

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
                string _fileExcelName = "Contract_Report_Ky.xls";

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
                ds_all.Tables[0].TableName = "Contract";

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

                string _title_report =  "BÁO CÁO KỶ Y";

                CommonFunction.SetValueExportByDataTable(ref flcReport, ds_all);
                CommonFunction.SetValueExportByString(ref flcReport, "title_report", _title_report);

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

                View_Contract_Tenant _View_Contract_Tenant = new View_Contract_Tenant();
                _View_Contract_Tenant.Owner = Window.GetWindow(this);

                _View_Contract_Tenant.c_Contract_Info = _Contract_Info;
                _View_Contract_Tenant.ShowDialog();

                DataGridHelper.NVSFocus(dgrContract, c_row_select, 0);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }
    }
}
