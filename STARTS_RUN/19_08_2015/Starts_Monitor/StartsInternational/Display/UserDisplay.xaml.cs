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

namespace StartsInternational.Display
{
    /// <summary>
    /// Interaction logic for UserDisplay.xaml
    /// </summary>
    public partial class UserDisplay : DockableContent
    {
        public UserDisplay()
        {
            InitializeComponent();
        }

        List<User_Info> c_lst = new List<User_Info>();
        int c_row_select = 0;
        User_Controller c_User_Controller = new User_Controller();

        private void frmUserDisplay_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void frmUserDisplay_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.F3:
                    Insert_User();
                    break;
                case Key.F9:
                    LoadData();
                    break;
                case Key.F4:
                    User_Update();
                    break;
                case Key.F5:
                    User_View();
                    break;
                case Key.F6:
                    User_Reset_Pass();
                    break;
                case Key.F7:
                    User_View();
                    break;
            }
        }

        private void dgrUser_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void dgrUser_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                Delete_User();
                e.Handled = true;
            }
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            Insert_User();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            User_Update();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Delete_User();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            User_Reset_Pass();
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            User_View();
        }

        private void btnPhanQuyen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User_Info ms = new User_Info();
                ms = (User_Info)dgrUser.SelectedItem;

                c_row_select = dgrUser.SelectedIndex;
                if (ms != null)
                {
                    User_Rights frm_GroupUser_Right = new User_Rights();
                    frm_GroupUser_Right.Owner = Window.GetWindow(this);
                    frm_GroupUser_Right.c_UsersInfo = ms;
                    frm_GroupUser_Right.ShowDialog();
                    if (frm_GroupUser_Right.c_ok == 1)
                    {
                        DataGridHelper.NVSFocus(dgrUser, c_row_select, 1);
                        frm_GroupUser_Right.c_ok = 0;
                    }
                    else
                        DataGridHelper.NVSFocus(dgrUser, c_row_select, 1);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
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
                User_View();
                e.Handled = true;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        #region Methods

        void LoadData()
        {
            try
            {
                c_lst = c_User_Controller.User_Get_All();
                dgrUser.ItemsSource = c_lst;
                DataGridHelper.NVSFocus(dgrUser, 0, 0);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        void Insert_User()
        {
            try
            {
                frmCreate_User _frmCreate_User = new frmCreate_User();
                _frmCreate_User.c_type = Convert.ToInt16(Form_Type.Insert);
                _frmCreate_User.Owner = Window.GetWindow(this);
                _frmCreate_User.ShowDialog();

                if (_frmCreate_User.c_id_insert != 0)
                {
                    LoadData();

                    for (int i = 0; i < c_lst.Count; i++)
                    {
                        User_Info ui = (User_Info)c_lst[i];
                        if (ui.User_Id == _frmCreate_User.c_id_insert)
                        {
                            c_row_select = i;
                            _frmCreate_User.c_id_insert = 0;
                            break;
                        }
                    }
                }

                DataGridHelper.NVSFocus(dgrUser, c_row_select, 0);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        void User_Update()
        {
            try
            {
                c_row_select = dgrUser.SelectedIndex;
                User_Info _User_Info = (User_Info)dgrUser.SelectedItem;

                if (_User_Info == null) return;
                frmCreate_User _frmCreate_User = new frmCreate_User();
                _frmCreate_User.c_type = Convert.ToInt16(Form_Type.Update);
                _frmCreate_User.c_User_Info = _User_Info;
                _frmCreate_User.Owner = Window.GetWindow(this);
                _frmCreate_User.ShowDialog();

                if (_frmCreate_User.c_id_insert != 0)
                    LoadData();

                DataGridHelper.NVSFocus(dgrUser, c_row_select, 0);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        void Delete_User()
        {
            try
            {
                c_row_select = dgrUser.SelectedIndex;
                User_Info _User_Info = (User_Info)dgrUser.SelectedItem;

                if (_User_Info == null) return;

                MessageBoxResult result = NoteBox.Show("Bạn chắc chắn muốn xóa người dùng này hay không?", "Thông báo", NoteBoxLevel.Question);
                if (MessageBoxResult.Yes == result)
                {
                    if (c_User_Controller.User_Delete(_User_Info.User_Id))
                    {
                        NoteBox.Show("Xóa dữ liệu thành công");
                        LoadData();
                    }
                }
                else
                    DataGridHelper.NVSFocus(dgrUser, c_row_select, 0);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        void User_Reset_Pass()
        {
            try
            {
                c_row_select = dgrUser.SelectedIndex;
                User_Info _User_Info = (User_Info)dgrUser.SelectedItem;

                if (_User_Info == null) return;
                Update_Pass _Update_Pass = new Update_Pass();
                _Update_Pass.c_is_reset = 1;

                _Update_Pass.c_User_Info = _User_Info;
                _Update_Pass.Owner = Window.GetWindow(this);
                _Update_Pass.ShowDialog();

                if (_Update_Pass.c_ok != 0)
                    LoadData();

                DataGridHelper.NVSFocus(dgrUser, c_row_select, 0);
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
                c_row_select = dgrUser.SelectedIndex;

                User_Rights frmUser_Rights = new User_Rights();
                frmUser_Rights.Owner = Window.GetWindow(this);

                User_Info _us = new User_Info();
                _us = (User_Info)dgrUser.SelectedItem;
                if (_us != null)
                {
                    frmUser_Rights.c_UsersInfo = _us;
                    frmUser_Rights.ShowDialog();

                    DataGridHelper.NVSFocus(dgrUser, c_row_select, 1);
                }
                else
                {
                    NoteBox.Show("Bạn chưa chọn user để set quyền", "Thông báo", NoteBoxLevel.Error);
                    DataGridHelper.NVSFocus(dgrUser, 0, 1);
                }

            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        void User_View()
        {
            try
            {
                c_row_select = dgrUser.SelectedIndex;
                User_Info _User_Info = (User_Info)dgrUser.SelectedItem;

                if (_User_Info == null) return;
                
                frmCreate_User _Users_View = new frmCreate_User();
                _Users_View.Owner = Window.GetWindow(this);

                _Users_View.c_User_Info = _User_Info;
                _Users_View.c_type = Convert.ToInt16(Form_Type.View);
                _Users_View.ShowDialog();

                DataGridHelper.NVSFocus(dgrUser, c_row_select, 0);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }
        #endregion

       
    }
}
