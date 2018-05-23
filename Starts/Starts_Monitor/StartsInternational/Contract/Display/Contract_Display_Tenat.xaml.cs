﻿using System;
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
using StartsInternational.Payment;

namespace StartsInternational.Contract.Display
{
    /// <summary>
    /// Interaction logic for UserDisplay.xaml
    /// </summary>
    public partial class Contract_Display_Tenat : DockableContent
    {
        public Contract_Display_Tenat()
        {
            InitializeComponent();
        }

        List<Contract_Info> c_lst = new List<Contract_Info>();
        int c_row_select = 0;
        Contract_Controller c_Contract_Controller = new Contract_Controller();
        Estate_Object_Controller _Estate_Object_Controller = new Estate_Object_Controller();
        Customer_Controller _Customer_Controller = new Customer_Controller();
        Fees_Revenue_Controller _Fees_Revenue_Controller = new Fees_Revenue_Controller();

        string _tenant = ((decimal)Enum_Contract_Type.Tenant).ToString();
        bool Is_Load = false;

        private void frmContract_Display_Loaded(object sender, RoutedEventArgs e)
        {
            _tenant = ((decimal)Enum_Contract_Type.Tenant).ToString();
            if (Is_Load == false)
            {
                LoadCombobox();
                txtCode.Focus();
            }

            //dangtq sửa lại
            System.Data.DataTable temp = Common.ConvertData.ConvertToDatatable<Contract_Info>(DBMemory.c_lst_contract_tennat);
            CommonFunction.NVS_BindTextboxComplete(txtCode, temp, "Contract_Code");
        }

        private void frmContract_Display_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.F3:
                    Insert_Contract_Tenant();
                    break;
                case Key.F4:
                    Contract_Update();
                    break;
                case Key.F5:
                    View_Contract();
                    break;
                case Key.F7:
                    Payment_Contract();
                    break;
                case Key.F8:
                    Export_Payment();
                    break;
                case Key.F9:
                    Search();
                    break;
                case Key.Delete:
                    e.Handled = true;
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
                Delete_Contract();
                e.Handled = true;
            }
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            Insert_Contract_Tenant();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Contract_Update();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Delete_Contract();
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

        private void btnSearch_Click_1(object sender, RoutedEventArgs e)
        {
            Search();
        }

        private void btnExport_Click_1(object sender, RoutedEventArgs e)
        {
            Export();
        }

        private void btnPay_Click_1(object sender, RoutedEventArgs e)
        {
            Payment_Contract();
        }

        private void btnRequestPay_Click(object sender, RoutedEventArgs e)
        {
            Export_Payment();
        }

        #region Methods

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

                List<AllCode_Info> _lst_Fee = DBMemory.AllCode_GetBy_CdNameCdType("FEE_TENANT", "STATUS");
                _lst_Fee.Insert(0, _AllCode_Info);
                cboFee.ItemsSource = _lst_Fee;
                cboFee.DisplayMemberPath = "Content";
                cboFee.SelectedValuePath = "CdValue";
                cboFee.SelectedIndex = 0;

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

                //List<Contract_Info> _lst_contract = new List<Contract_Info>();
                //_lst_contract = c_Contract_Controller.Contract_GetBy_Type((decimal)Enum_Contract_Type.Tenant);

             
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        void Insert_Contract_Tenant()
        {
            try
            {
                Contract_Insert_Tenant _Contract_Insert_Tenant = new Contract_Insert_Tenant();
                _Contract_Insert_Tenant.Owner = Window.GetWindow(this);
                _Contract_Insert_Tenant.ShowDialog();

                if (_Contract_Insert_Tenant.c_id_insert != 0)
                {
                    Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;

                    Search();

                    DBMemory.LoadFeeTenant();

                    for (int i = 0; i < c_lst.Count; i++)
                    {
                        Contract_Info ui = (Contract_Info)c_lst[i];
                        if (ui.Contract_Id == _Contract_Insert_Tenant.c_id_insert)
                        {
                            c_row_select = i;
                            _Contract_Insert_Tenant.c_id_insert = 0;
                            break;
                        }
                    }
                }

                Mouse.OverrideCursor = null;
                DataGridHelper.NVSFocus(dgrContract, c_row_select, 0);
            }
            catch (Exception ex)
            {
                Mouse.OverrideCursor = null;
                CommonData.log.Error(ex.ToString());
            }
        }

        void Contract_Update()
        {
            try
            {
                c_row_select = dgrContract.SelectedIndex;
                Contract_Info _Contract_Info = (Contract_Info)dgrContract.SelectedItem;

                if (_Contract_Info == null) return;
                Update_Contract_Tenant _Update_Contract_Insert_Tenant = new Update_Contract_Tenant();
                _Update_Contract_Insert_Tenant.c_Contract_Info = _Contract_Info;
                _Update_Contract_Insert_Tenant.Owner = Window.GetWindow(this);
                _Update_Contract_Insert_Tenant.ShowDialog();

                if (_Update_Contract_Insert_Tenant.c_id_insert != 0)
                {
                    Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;

                    Search();
                    DBMemory.LoadFeeTenant();

                    Mouse.OverrideCursor = null;
                }

                DataGridHelper.NVSFocus(dgrContract, c_row_select, 0);
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
                c_row_select = dgrContract.SelectedIndex;
                Contract_Info _Contract_Info = (Contract_Info)dgrContract.SelectedItem;

                if (_Contract_Info == null) return;

                MessageBoxResult result = NoteBox.Show("Bạn chắc chắn muốn xóa hợp đồng này hay không?", "Thông báo", NoteBoxLevel.Question);
                if (MessageBoxResult.Yes == result)
                {
                    if (c_Contract_Controller.Contract_Delete(_Contract_Info.Contract_Id))
                    {
                        NoteBox.Show("Xóa dữ liệu thành công");
                        Search();
                    }
                }
                else
                    DataGridHelper.NVSFocus(dgrContract, c_row_select, 0);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
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

        void Payment_Contract()
        {
            try
            {
                c_row_select = dgrContract.SelectedIndex;
                Contract_Info _Contract_Info = (Contract_Info)dgrContract.SelectedItem;

                if (_Contract_Info == null) return;

                Tenant_Payment _Tenant_Payment = new Tenant_Payment();
                _Tenant_Payment.Owner = Window.GetWindow(this);

                _Tenant_Payment.c_Contract_Info = _Contract_Info;
                _Tenant_Payment.ShowDialog();

                if (_Tenant_Payment.c_ok == true)
                {
                    Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;

                    Search();

                    DBMemory.LoadFeeTenant();

                    Mouse.OverrideCursor = null;
                }

                DataGridHelper.NVSFocus(dgrContract, c_row_select, 0);
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

                string _Building = "-1";
                if (cboBuilding.Text != CommonData.c_All_Content)
                {
                    _Building = cboBuilding.SelectedValue.ToString();
                }

                c_lst = c_Contract_Controller.Contract_Search_ByContract_Type(_tenant, _code, cboStatus.SelectedValue.ToString(), CommonData.c_All_Value, _Building);

                #region Tìm theo tên bên YC môi giới
                if (txtObject_Name.Text != "")
                {
                    List<Contract_Info> _tem = new List<Contract_Info>();
                    foreach (Contract_Info item in c_lst)
                    {
                        if (item.Object_Name.ToUpper().Contains(txtObject_Name.Text.ToUpper()))
                        {
                            _tem.Add(item);
                        }
                    }

                    c_lst = _tem;
                }
                #endregion

                #region Tìm theo trạng thái thanh toán phí

                if (cboFee.SelectedValue.ToString() != CommonData.c_All_Value)
                {
                    List<Contract_Info> _tem = new List<Contract_Info>();

                    if (cboFee.SelectedValue.ToString() == ((decimal)Enum_HanFee.QuaHan).ToString())
                    {
                        foreach (Contract_Info item in c_lst)
                        {
                            if (DBMemory.KiemTra_QuaHan_ThanhToan(item.Contract_Id))
                            {
                                _tem.Add(item);
                            }
                        }
                    }
                    else
                    {
                        foreach (Contract_Info item in c_lst)
                        {
                            if (DBMemory.KiemTra_SapDenHan_ThanhToan(item.Contract_Id))
                            {
                                _tem.Add(item);
                            }
                        }
                    }

                    c_lst = _tem;
                }

                #endregion

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
                string _fileExcelName = "Contract_Tenant.xls";

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

        void Export_Payment()
        {
            try
            {
                c_row_select = dgrContract.SelectedIndex;
                Contract_Info _Contract_Info = (Contract_Info)dgrContract.SelectedItem;

                if (_Contract_Info == null) return;

                List<Fees_Revenue_Info> _lst = _Fees_Revenue_Controller.Fees_Revenue_GetByContract(_Contract_Info.Contract_Id);
                Fees_Revenue_Info _Fees_Revenue_Info = new Fees_Revenue_Info();

                bool _is_not_pay = false;

                // kiểm tra xem đã thanh toán hết chưa
                foreach (Fees_Revenue_Info item in _lst)
                {
                    if (item.Pay_Status == (decimal)Enum_Fee_Status.No_Pay)
                    {
                        _is_not_pay = true;
                        _Fees_Revenue_Info = item;
                        break;
                    }
                }

                if (_is_not_pay == false)
                {
                    NoteBox.Show("Đã thanh toán hết, không thể yêu cầu thanh toán", "", NoteBoxLevel.Error);
                    return;
                }

                Estate_Object_Info _Estate_Object_Info = _Estate_Object_Controller.Estate_Object_GetById(_Contract_Info.Estate_Id, (decimal)Enum_Contract_Type.Tenant);
                Customer_Info _Customer_Info = _Customer_Controller.Customer_GetById(_Contract_Info.Object_Id);

                CommonFunction.Export_payment(_Contract_Info, _Customer_Info, _Estate_Object_Info, _Fees_Revenue_Info);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        #endregion
    }
}
