using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

using ObjInfo;
using System.Data;
using StartsInternational.Common;
using Starts_Controller;

namespace StartsInternational.Control.Created
{
    /// <summary>
    /// Interaction logic for frmCreate_User.xaml
    /// </summary>
    public partial class frmCreate_User : Window
    {
        public frmCreate_User()
        {
            InitializeComponent();
        }

        public int c_type = 0;
        public User_Info c_User_Info;

        public decimal c_id_insert = 0;

        User_Controller c_User_Controller = new User_Controller();
        List<User_Info> c_lst = new List<User_Info>();

        #region Event

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            c_lst = c_User_Controller.User_Get_All();
            LoadData();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape) exitForm();
            else if (e.Key == Key.Enter) Accept();
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            Accept();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            exitForm();
        }
        #endregion

        #region Methods

        void LoadData()
        {
            try
            {

                GroupUserController _GroupUserController = new GroupUserController();
                List<GroupUserInfo> _lst = _GroupUserController.GroupUser_GetAll();

                cbo_Group_User.SelectedValuePath = "Id";
                cbo_Group_User.DisplayMemberPath = "Name";
                cbo_Group_User.ItemsSource = _lst;
                cbo_Group_User.SelectedIndex = 0;

                if (c_type == Convert.ToInt16(Form_Type.Insert))
                {
                    txtFullName.Focus();
                }
                else if (c_type == Convert.ToInt16(Form_Type.Update))
                {
                    this.Title = "Cập nhật thông tin người dùng [" + c_User_Info.User_Name + "]";

                    txtFullName.Text = c_User_Info.FullName;
                    txtUserName.Text = c_User_Info.User_Name;
                    txtPass.Text = c_User_Info.Pass;
                    txtPhone.Text = c_User_Info.Phone;
                    cbo_Group_User.SelectedValue = c_User_Info.Group_Id;

                    txtUserName.IsEnabled = false;
                    txtPass.IsEnabled = false;
                    txtFullName.Focus();
                }
                else if (c_type == Convert.ToInt16(Form_Type.View))
                {
                    this.Title = "Thông tin người dùng [" + c_User_Info.User_Name + "]";

                    txtFullName.Text = c_User_Info.FullName;
                    txtUserName.Text = c_User_Info.User_Name;
                    txtPass.Text = c_User_Info.Pass;
                    txtPhone.Text = c_User_Info.Phone;
                    cbo_Group_User.SelectedValue = c_User_Info.Group_Id;

                    txtFullName.IsEnabled = false;
                    txtUserName.IsEnabled = false;
                    txtPhone.IsEnabled = false;
                    txtPass.IsEnabled = false;
                    cbo_Group_User.IsHitTestVisible = false;
                    cbo_Group_User.Focusable = false;
                }
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        void Accept()
        {
            try
            {
                if (!CheckValidate_F()) return;

                if (c_type == Convert.ToInt16(Form_Type.Insert))
                {

                    MessageBoxResult result = NoteBox.Show("Bạn chắc chắn muốn thêm mới người sử dụng hay không?", "Thông báo", NoteBoxLevel.Question);
                    if (MessageBoxResult.Yes == result)
                    {
                        User_Info _User_Info = new User_Info();
                        _User_Info.FullName = txtFullName.Text;
                        _User_Info.User_Name = txtUserName.Text;
                        _User_Info.Phone = txtPhone.Text;
                        _User_Info.Pass = txtPass.Text;
                        _User_Info.User_Type = 1;
                        _User_Info.Group_Id = Convert.ToInt16(cbo_Group_User.SelectedValue);
                        _User_Info.Status = Convert.ToInt16(User_Status_Type.Active);

                        decimal _id = c_User_Controller.User_Insert(_User_Info);

                        if (_id > 0)
                        {
                            NoteBox.Show("Thêm mới thành công");
                            c_id_insert = _id;
                            this.Close();
                        }
                        else
                        {
                            NoteBox.Show("Có lỗi trong quá trình thêm mới", "", NoteBoxLevel.Error);
                        }
                    }
                }
                else
                {
                    MessageBoxResult result = NoteBox.Show("Bạn chắc chắn muốn cập nhật hay không?", "Thông báo", NoteBoxLevel.Question);
                    if (MessageBoxResult.Yes == result)
                    {
                        User_Info _User_Info = new User_Info();
                        _User_Info.FullName = txtFullName.Text;
                        _User_Info.User_Name = txtUserName.Text;
                        _User_Info.Phone = txtPhone.Text;
                        _User_Info.Pass = txtPass.Text;
                        _User_Info.User_Type = 1;
                        _User_Info.Group_Id = Convert.ToInt16(cbo_Group_User.SelectedValue.ToString());
                        _User_Info.Status = c_User_Info.Status;

                        if (c_User_Controller.User_Update(c_User_Info.User_Id, _User_Info))
                        {
                            NoteBox.Show("Cập nhật dữ liệu thành công");
                            c_id_insert = 1;
                            this.Close();
                        }
                        else
                        {
                            NoteBox.Show("Có lỗi trong quá trình cập nhật dữ liệu", "", NoteBoxLevel.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        bool CheckValidate_F()
        {
            try
            {

                if (txtFullName.Text == "")
                {
                    NoteBox.Show("Tên đầy đủ không được để trống không được để trống", "Lỗi", NoteBoxLevel.Error);
                    txtFullName.Focus();
                    return false;
                }
                else if (txtUserName.Text == "")
                {
                    NoteBox.Show("Tên đăng nhập không được để trống không được để trống", "Lỗi", NoteBoxLevel.Error);
                    txtUserName.Focus();
                    return false;
                }
                else if (txtUserName.Text.Contains(" "))
                {
                    NoteBox.Show("Tên đăng nhập không được chứa dấu cách", "Lỗi", NoteBoxLevel.Error);
                    txtUserName.Focus();
                    return false;
                }
                else if (c_type == Convert.ToInt16(Form_Type.Insert) && !CheckUserNotSame(txtUserName.Text.Trim()))
                {
                    NoteBox.Show("Tên đăng nhập đã tồn tại trong CSDL", "Lỗi", NoteBoxLevel.Error);
                    txtUserName.Focus();
                    return false;
                }
                else if (txtPass.Text == "")
                {
                    NoteBox.Show("Mật khẩu không được để trống không được để trống");
                    txtPass.Focus();
                    return false;
                }
                else if (CheckValidate.checkAllSpace(txtPass.Text))
                {
                    NoteBox.Show("Mật khẩu không được chứa toàn dấu cách", "Lỗi", NoteBoxLevel.Error);
                    txtPass.Focus();
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return false;
            }
        }

        private void exitForm()
        {
            if (c_type == Convert.ToInt16(Form_Type.View))
                this.Close();
            else
            {
                MessageBoxResult result = NoteBox.Show("Bạn có muốn thoát khỏi form hay không?", "Thông báo", NoteBoxLevel.Question);
                if (result == MessageBoxResult.Yes)
                {
                    this.Close();
                }
                else
                    this.Focus();
            }
        }

        bool CheckUserNotSame(string code)
        {
            try
            {
                User_Controller _UsersController = new User_Controller();
                foreach (User_Info item in c_lst)
                {
                    if (item.User_Name.ToUpper() == code.ToUpper())
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return false;
            }
        }

        #endregion`
    }
}
