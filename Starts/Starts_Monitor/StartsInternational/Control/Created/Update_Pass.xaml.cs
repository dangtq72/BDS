using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;

using ObjInfo;
using System.Data;
using StartsInternational.Common;
using System.Collections;
using Starts_Controller;

namespace StartsInternational.Control.Created
{
    /// <summary>
    /// Interaction logic for Update_Pass.xaml
    /// </summary>
    public partial class Update_Pass : Window
    {
        public Update_Pass()
        {
            InitializeComponent();
        }

        public int c_is_reset = 0;
        public User_Info c_User_Info;
        public int c_ok = 0;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (c_is_reset == 1) // e
            {
                txtPassword_Old.Visibility = Visibility.Collapsed;
                lblOld.Visibility = Visibility.Collapsed;
            }
            txtPassword_Old.Focus();
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

        void exitForm()
        {
            MessageBoxResult result = NoteBox.Show("Bạn có muốn thoát khỏi form hay không?", "Thông báo", NoteBoxLevel.Question);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
            else
                this.Focus();
        }

        void Accept()
        {
            try
            {
                if (!CheckValidate_F()) return;

                MessageBoxResult result = NoteBox.Show("Bạn chắc chắn muốn đổi mật khẩu hay không", "Thông báo", NoteBoxLevel.Question);
                if (MessageBoxResult.Yes == result)
                {
                    decimal _id = CommonData.c_Urser_Info.User_Id;
                    if (c_is_reset == 1)
                    {
                        _id = c_User_Info.User_Id;
                    }

                    User_Controller _User_Controller = new User_Controller();
                    if (_User_Controller.User_Update_Pass(_id, txtPassword_New.Text))
                    {
                        NoteBox.Show("Đổi mật khẩu thành công");
                        c_ok = 1;
                        this.Close();
                    }
                    else
                    {
                        NoteBox.Show("Có lỗi trong quá trình đổi mật khẩu", "", NoteBoxLevel.Error);
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

                if (txtPassword_Old.Text == "" && c_is_reset == 0)
                {
                    NoteBox.Show("Mật khẩu cũ không được để trống");
                    txtPassword_Old.Focus();
                    return false;
                }
                else if (c_is_reset == 0 && txtPassword_Old.Text != CommonData.c_Urser_Info.Pass)
                {
                    NoteBox.Show("Mật khẩu cũ không đúng");
                    txtPassword_New.Focus();
                    return false;
                }
                else if (txtPassword_New.Text == "")
                {
                    NoteBox.Show("Mật khẩu mới không được để trống");
                    txtPassword_New.Focus();
                    return false;
                }
                else if (txtPassword_ReNew.Text == "")
                {
                    NoteBox.Show("Mật khẩu nhắc lại không được để trống");
                    txtPassword_ReNew.Focus();
                    return false;
                }
                else if (txtPassword_ReNew.Text != txtPassword_New.Text)
                {
                    NoteBox.Show("Mật khẩu nhắc lại không đúng");
                    txtPassword_ReNew.Focus();
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
    }
}
