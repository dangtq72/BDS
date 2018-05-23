using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

using Starts_Controller;
using System.Collections;
using ObjInfo;

namespace StartsInternational
{
    /// <summary>
    /// Interaction logic for GroupUser_View.xaml
    /// </summary>
    public partial class GroupUser_View : Window
    {
        public GroupUser_View()
        {
            InitializeComponent();
        }

        public GroupUserInfo c_GroupUserInfo;

        #region Events
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Close();
        }
        private void dgrUser_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void dgrUser_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
                e.Handled = true;
        }

        #endregion

        #region Private methods

        private void LoadData()
        {
            try
            {
                if (c_GroupUserInfo != null)
                {
                    txtName.Text = c_GroupUserInfo.Name;
                    txtNotes.Text = c_GroupUserInfo.Note;
                    
                    // load thông tin người dùng
                    ArrayList _arrUser = new ArrayList();
                    foreach (User_Info item in Common.DBMemory.c_hash_User.Values)
                    {
                        if (item.Group_Id == c_GroupUserInfo.Id)
                            _arrUser.Add(item);
                    }
                    dgrUser.ItemsSource = _arrUser;
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
