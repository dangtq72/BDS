using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

using Starts_Controller;
using System.Collections;
using ObjInfo;

namespace StartsInternational.Update
{
    /// <summary>
    /// Interaction logic for Group_User_Update.xaml
    /// </summary>
    public partial class Group_User_Update : Window
    {

        #region Contrustor and params

        public Group_User_Update()
        {
            InitializeComponent();
        }

        public GroupUserInfo c_GroupUserInfo;
        public AvalonDock.SecurityLevel NVSQuyen_Core;
        public int c_editOK = 0;
        GroupUserController moncon = new GroupUserController();

        #endregion

        #region Events

        private void frmGroupUserUpdate_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void frmGroupUserUpdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                exitForm();
            if (e.Key == Key.Enter)
                GroupUser_Update();
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            GroupUser_Update();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            exitForm();
        }

        #endregion

        #region Private methods

        private void exitForm()
        {
            MessageBoxResult result = NoteBox.Show("Bạn có muốn thoát khỏi form này hay không ?", "Thông báo", NoteBoxLevel.Question);
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
                if (name.ToUpper() == c_GroupUserInfo.Name.ToUpper())
                    _ck = true;
                else
                {
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

        public void GroupUser_Update()
        {
            try
            {
                if (GroupUser_CheckValidate())
                {
                    MessageBoxResult result = NoteBox.Show("Bạn có muốn sửa thông tin này hay không?", "Thông báo", NoteBoxLevel.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        GroupUserInfo _GroupUserInfo = new GroupUserInfo();
                        _GroupUserInfo.Name = txtName.Text.Trim();
                        _GroupUserInfo.Group_Type = c_GroupUserInfo.Group_Type;
                        _GroupUserInfo.Note = txtNotes.Text.Trim();

                        if (moncon.GroupUser_Update(c_GroupUserInfo.Id, _GroupUserInfo))
                        {
                            c_editOK = 1;
                            NoteBox.Show("Cập nhật dữ liệu thành công", "Thông báo", NoteBoxLevel.Note);
                            this.Close();
                        }
                        else
                            NoteBox.Show("Cập nhật dữ liệu không thành công", "Thông báo", NoteBoxLevel.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

       
        private void LoadData()
        {
            try
            {
                if (c_GroupUserInfo != null)
                {
                    txtName.Text = c_GroupUserInfo.Name;
                    txtNotes.Text = c_GroupUserInfo.Note;
                    txtName.Focus();
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
