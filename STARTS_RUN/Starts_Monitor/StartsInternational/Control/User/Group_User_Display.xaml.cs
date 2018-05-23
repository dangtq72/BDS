
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Collections;
using AvalonDock;
using ObjInfo;
using Starts_Controller;
using StartsInternational.Common;
using StartsInternational.User;
using StartsInternational.Control.Created;
using StartsInternational.Update;

namespace StartsInternational
{
    /// <summary>
    /// Interaction logic for Group_User_Display.xaml
    /// </summary>
    public partial class Group_User_Display : DockableContent
    {

        #region Contrustor and Params

        public Group_User_Display()
        {
            InitializeComponent();
        }

        List<GroupUserInfo> arrAllGroupUser = new List<GroupUserInfo>();
        int rowselect = 0;
        public static decimal c_IdInsert = 0;
        GroupUserController _grUsCon = new GroupUserController();
        int c_type_error = 0;
        #endregion

        #region Events

        private void frmGroupUser_Loaded(object sender, RoutedEventArgs e)
        {
            if (IsFistLoad)
            {
                IsFistLoad = false;//nhớ cập nhật lại biến
                LoadData();
                DataGridHelper.NVSFocus(dgrGroupUser, 0, 0);
            }
        }

        private void frmGroupUser_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.Key)
                {
                    case Key.F3:
                        GroupUser_Add();
                        break;
                    case Key.F4:
                        GroupUser_Update();
                        break;
                    case Key.F5:
                        loadView();
                        break;
                    case Key.F9:
                        LoadData();
                        break;
                    case Key.F7:
                        SetRight();
                        break;
                }
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        private void frmGroupUser_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }

        private void dgrGroupUser_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void dgrGroupUser_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                GroupUser_Delete();
                e.Handled = true;
            }
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            GroupUser_Add();
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            GroupUser_Update();
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            GroupUser_Delete();
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Cmu_SetRight_Click(object sender, RoutedEventArgs e)
        {
            SetRight();
        }

        private void Cmu_View_Click(object sender, RoutedEventArgs e)
        {
            loadView();
        }

        /// <summary>
        /// hàm dùng cho EventsSetter trong form display
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void DoubleClick(object sender, RoutedEventArgs e)
        {
            loadView();
            e.Handled = true;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// hiện thị dữ liệu lên datagrid
        /// </summary>
        private void LoadData()
        {
            try
            {
                arrAllGroupUser = _grUsCon.GroupUser_GetAll();
                if (arrAllGroupUser != null && arrAllGroupUser.Count >= 0)
                {
                    dgrGroupUser.ItemsSource = arrAllGroupUser;
                }

                //txtTotal.Text = arrFunctions_By_System.Count.ToString();
                //txtTotal.IsReadOnly = true;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        private GroupUserInfo GetRow()
        {
            try
            {
                GroupUserInfo us = (GroupUserInfo)dgrGroupUser.SelectedItem;
                return us;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// thêm matchType
        /// </summary>
        private void GroupUser_Add()
        {
            try
            {
                Group_User creGroup_User = new Group_User();
                creGroup_User.Owner = Window.GetWindow(this);
                creGroup_User.ShowDialog();
                if (creGroup_User.c_createOk == 1)
                {
                    LoadData();
                    for (int i = 0; i < arrAllGroupUser.Count; i++)
                    {
                        GroupUserInfo ui = (GroupUserInfo)arrAllGroupUser[i];
                        if (ui.Id == c_IdInsert)
                        {
                            rowselect = i;
                            c_IdInsert = 0;
                            break;
                        }
                    }
                    DataGridHelper.NVSFocus(dgrGroupUser, rowselect, 1);
                    creGroup_User.c_createOk = 0;
                }
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        /// <summary>
        /// cập nhật thông tin Match_Type
        /// </summary>
        private void GroupUser_Update()
        {
            try
            {
                Group_User_Update upGroup_User = new Group_User_Update();
                GroupUserInfo ms = new GroupUserInfo();
                ms = GetRow();

                rowselect = dgrGroupUser.SelectedIndex;
                upGroup_User.Owner = Window.GetWindow(this);
                if (ms == null) return;


                upGroup_User.c_GroupUserInfo = ms;
                upGroup_User.NVSQuyen_Core = this.NVSQuyen_Core;

                upGroup_User.ShowDialog();
                if (upGroup_User.c_editOK == 1)
                {
                    LoadData();
                    DataGridHelper.NVSFocus(dgrGroupUser, rowselect, 1);
                    upGroup_User.c_editOK = 0;
                }
                else
                    DataGridHelper.NVSFocus(dgrGroupUser, rowselect, 1);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }


        private void GroupUser_Delete()
        {
            try
            {

                GroupUserInfo mf = new GroupUserInfo();
                mf = GetRow();
                rowselect = dgrGroupUser.SelectedIndex;
                if (mf == null) return;

                if (CheckDeleteGroupUser(mf.Id))
                {
                    MessageBoxResult rs = NoteBox.Show("Bạn có muốn xóa nhóm người sử dụng hay không?", "Thông báo", NoteBoxLevel.Question);
                    if (rs == MessageBoxResult.Yes)
                    {
                        _grUsCon.GroupUser_Delete(mf.Id);
                        NoteBox.Show("Xóa dữ liệu thành công");
                        LoadData();
                        DataGridHelper.NVSFocus(dgrGroupUser, 0, 1);
                        dgrGroupUser.Focus();
                    }
                    else if (rs == MessageBoxResult.No)
                    {
                        DataGridHelper.NVSFocus(dgrGroupUser, rowselect, 1);
                    }
                }
                else
                {
                    NoteBox.Show("Không thể xóa nhóm vì trong nhóm đang có user. Hãy xóa hoặc chuyển tất cả user sang nhóm khác", "Thông báo", NoteBoxLevel.Error);
                    DataGridHelper.NVSFocus(dgrGroupUser, rowselect, 1);
                }

            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        private void SetRight()
        {
            try
            {

                GroupUserInfo ms = new GroupUserInfo();
                ms = GetRow();

                rowselect = dgrGroupUser.SelectedIndex;
                if (ms != null)
                {
                    GroupUser_Right frm_GroupUser_Right = new GroupUser_Right();
                    frm_GroupUser_Right.Owner = Window.GetWindow(this);
                    frm_GroupUser_Right.c_GroupUserInfo = ms;
                    frm_GroupUser_Right.ShowDialog();
                    if (frm_GroupUser_Right.c_ok == 1)
                    {
                        LoadData();
                        DataGridHelper.NVSFocus(dgrGroupUser, rowselect, 1);
                        frm_GroupUser_Right.c_ok = 0;
                    }
                    else
                        DataGridHelper.NVSFocus(dgrGroupUser, rowselect, 1);
                }

            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        private void loadView()
        {
            try
            {
                rowselect = dgrGroupUser.SelectedIndex;
                GroupUserInfo ms = new GroupUserInfo();

                GroupUser_View frmView = new GroupUser_View();
                ms = GetRow();
                if (ms == null) return;
                frmView.Owner = Window.GetWindow(this);
                frmView.c_GroupUserInfo = ms;
                frmView.ShowDialog();
                DataGridHelper.NVSFocus(dgrGroupUser, rowselect, 0);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        /// <summary>
        /// Kiem tra xem co thang user nao dang su dung no ko
        /// </summary>
        /// <param name="p_id_group"></param>
        /// <returns></returns>
        bool CheckDeleteGroupUser(decimal p_id_group)
        {
            try
            {
                bool _ck = true;

                foreach (User_Info item in Common.DBMemory.c_hash_User.Values)
                {
                    if (item.Group_Id == p_id_group)
                    {
                        _ck = false;
                        break;
                    }
                }

                return _ck;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return false;
            }
        }

        #endregion
    }
}
