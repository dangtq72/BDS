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
using AvalonDock;
using System.Collections;
using ObjInfo;
using Starts_Controller;

namespace StartsInternational.User
{
    public partial class Functions_Display : DockableContent
    {
        #region Constructor and Param
        public Functions_Display()
        {
            InitializeComponent();
        }

        FunctionsController c_FunctionsController = new FunctionsController();
        ArrayList arrFunctions_By_System = new ArrayList();
        #endregion

        #region Events

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Search_By_System();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            Functions_Insert();
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            Functions_Delete();
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            exitForm();
        }

        private void frmFunctions_Loaded(object sender, RoutedEventArgs e)
        {
            if (IsFistLoad)
            {
                IsFistLoad = false;//nhớ cập nhật lại biến
                LoadData();
            }
        }

        private void frmFunctions_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.Key)
                {
                    case Key.F6:
                        txtSearch.Focus();
                        break;
                    case Key.F9:
                        LoadData();
                        break;
                    case Key.Enter:
                        Search_By_System();
                        break;
                }
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        private void dgFunctions_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            try
            {
                e.Row.Header = (e.Row.GetIndex() + 1).ToString();
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }



        #endregion

        #region Private Methods

        private void Functions_Insert()
        {
            //try
            //{
            //    if (!this.NVSQuyen_Core.RIGHT_ADD)
            //    {
            //        NoteBox.Show("Bạn không có quyền sử dụng chức năng này",  "Thông báo", NoteBoxLevel.Note);
            //        return;
            //    }
            //    Created.Functions frmFunctions = new Created.Functions();
            //    frmFunctions.Owner = Window.GetWindow(this);
            //    frmFunctions.ShowDialog();
            //    if (frmFunctions.InsertSucceeded)
            //    {
            //        LoadData();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    CommonData.log.Error(ex.ToString());
            //}
        }

        private void exitForm()
        {
            MessageBoxResult result = NoteBox.Show("Bạn có muốn thoát khỏi form này không?", "Thông báo",
                NoteBoxLevel.Question);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
            else
                this.Focus();
        }

        private void Functions_Delete()
        {
            try
            {
                if (!this.NVSQuyen_Core.RIGHT_DEL)
                {
                    NoteBox.Show("Bạn không có quyền sử dụng chức năng này.", "Thông báo", NoteBoxLevel.Note);
                    return;
                }
                FunctionsInfo _FunctionsInfo = new FunctionsInfo();
                _FunctionsInfo = (FunctionsInfo)dgFunctions.SelectedItem;

                ArrayList arrdelete = new ArrayList();
                arrdelete.Add(_FunctionsInfo);
                BuidlTreeFuction(_FunctionsInfo, (ArrayList)dgFunctions.ItemsSource, ref arrdelete);

                if (arrdelete.Count > 0)
                {
                    MessageBoxResult rs = NoteBox.Show("Bạn có muốn xóa chức năng này hay không?", "Thông báo", NoteBoxLevel.Question);
                    if (rs == MessageBoxResult.Yes)
                    {
                        foreach (FunctionsInfo item in arrdelete)
                        {
                            c_FunctionsController.Function_Delete(item.id, item.name);
                        }
                        NoteBox.Show("Xóa dữ liệu thành công", "", NoteBoxLevel.Note);
                        LoadData();
                        if (dgFunctions.Items.Count > 0)
                        {
                            dgFunctions.SelectedIndex = 0;
                        }
                        dgFunctions.Focus();
                    }
                    else if (rs == MessageBoxResult.No)
                        dgFunctions.Focus();
                }
                else
                    NoteBox.Show("Bạn chưa chọn dòng muốn xóa. Hãy chọn lại", "Thông báo", NoteBoxLevel.Note);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        private void BuidlTreeFuction(FunctionsInfo p_parentItem, ArrayList arrAllFunction, ref ArrayList new_arr)
        {
            foreach (FunctionsInfo _info in arrAllFunction)
            {
                if (_info.prid == p_parentItem.id)
                {
                    new_arr.Add(_info);
                    BuidlTreeFuction(_info, arrAllFunction, ref new_arr);
                }
            }
        }

        private void LoadData()
        {
            try
            {
                arrFunctions_By_System = c_FunctionsController.Function_Get_By_System("", "CommonData.c_cultureName_lang");


                dgFunctions.ItemsSource = arrFunctions_By_System;
                dgFunctions.Items.Refresh();


                if (arrFunctions_By_System != null)
                {
                    txtTotal.Text = arrFunctions_By_System.Count.ToString();
                    txtTotal.IsReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        private void Search_By_System()
        {
            try
            {
                //if (!this.NVSQuyen_Core.RIGHT_SEARCH)
                //{
                //    NoteBox.Show("Bạn không có quyền sử dụng chức năng này",  "Thông báo", NoteBoxLevel.Note);
                //    return;
                //}
                string str = txtSearch.Text.ToUpper().Trim();
                if (txtSearch.Text != "")
                {
                    if (txtSearch.Text == "_-$NVS@NEW$-_")
                    {
                        Functions_Insert();
                    }
                    if (txtSearch.Text == "_-$NVS@DEL$-_")
                    {
                        Functions_Delete();
                    }
                    if (arrFunctions_By_System != null && arrFunctions_By_System.Count > 0)
                    {
                        foreach (FunctionsInfo item in arrFunctions_By_System)
                        {
                            if (item.name.ToUpper().Contains(str))
                            {
                                dgFunctions.SelectedItem = item;
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }



        #endregion

    }
}
