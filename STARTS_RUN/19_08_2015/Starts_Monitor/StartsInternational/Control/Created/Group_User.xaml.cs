using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Collections;

using Starts_Controller;
using ObjInfo;

namespace StartsInternational.Control.Created
{
    /// <summary>
    /// Interaction logic for Group_User.xaml
    /// </summary>
    public partial class Group_User : Window
    {
        #region Contrustor and params

        public Group_User()
        {
            InitializeComponent();
        }
        public int c_createOk = 0;
        GroupUserController moncon = new GroupUserController();

        #endregion

        #region Events

        private void frmGroupUserCreate_Loaded(object sender, RoutedEventArgs e)
        {
            txtName.Focus();
        }

        private void frmGroupUserCreate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                exitForm();
            if (e.Key == Key.Enter)
                GroupUser_Add();
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            GroupUser_Add();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            exitForm();
        }

        #endregion

        #region Private methods

        private void exitForm()
        {
            MessageBoxResult result = NoteBox.Show("Bạn có muốn thoát hay không", "Thông báo", NoteBoxLevel.Question);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
            else
                this.Focus();
        }

        /// <summary>
        /// check trùng Group name
        /// </summary>
        private bool CheckNameNotSame(string name)
        {
            try
            {
                bool _ck = true;
                List<GroupUserInfo> _arr = moncon.GroupUser_GetAll();
                if (_arr.Count > 0 && _arr != null)
                {
                    foreach (GroupUserInfo item in _arr)
                    {
                        if (item.Name.ToUpper() == name.ToUpper())
                        {
                            _ck = false;
                            break;
                        }
                    }
                }
                return _ck; ;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return false;
            }
        }

        private bool GroupUser_CheckValidate()
        {
            try
            {
                string name = txtName.Text;
                if (name == "")
                {
                    NoteBox.Show("Tên nhóm người dùng không được để trống", "Lỗi", NoteBoxLevel.Error);
                    txtName.Focus();
                    return false;
                }
                else if (CheckValidate.checkAllSpace(name))
                {
                    NoteBox.Show("Tên nhóm người dùng không được chứa toàn dấu cách", "Lỗi", NoteBoxLevel.Error);
                    txtName.Clear();
                    txtName.Focus();
                    return false;
                }

                else if (!CheckNameNotSame(txtName.Text.Trim().ToUpper()))
                {
                    NoteBox.Show("Tên nhóm người dùng đã tồn tại trong cơ sở dữ liệu", "Lỗi", NoteBoxLevel.Error);
                    txtName.Focus();
                    return false;
                }

                else return true;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return false;
            }
        }

        void GroupUser_Add()
        {
            try
            {
                if (GroupUser_CheckValidate())
                {
                    GroupUserInfo _GroupUserInfo = new GroupUserInfo();
                    _GroupUserInfo.Name = txtName.Text.Trim();
                    _GroupUserInfo.Group_Type = 1;
                    _GroupUserInfo.Note = txtNotes.Text.Trim();

                    decimal id = moncon.GroupUser_Insert(_GroupUserInfo);
                    if (id > 0)
                    {
                        c_createOk = 1;
                        Group_User_Display.c_IdInsert = id;
                        NoteBox.Show("Thêm mới dữ liệu thành công", "", NoteBoxLevel.Note);
                        this.Close();
                    }
                    else NoteBox.Show("Thêm mới không thành công", "Lỗi", NoteBoxLevel.Error);
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
