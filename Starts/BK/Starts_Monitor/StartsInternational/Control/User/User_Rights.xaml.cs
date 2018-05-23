
using System;
using System.Collections.Generic;

using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Collections;
using ObjInfo;
using System.Windows.Media;
using Starts_Controller;
using MemoryData;
using StartsInternational;
using StartsInternational.Common;

namespace Starts_Monitor.User
{
    /// <summary>
    /// Interaction logic for USER_RIGHTS.xaml
    /// </summary>
    public partial class User_Rights : Window
    {

        #region Constructor and Param

        public User_Rights()
        {
            InitializeComponent();
        }

        User_RightsController _usRc0n = new User_RightsController();

        ArrayList c_arrFunction = new ArrayList();
        public User_Info c_UsersInfo = new User_Info();
        BrushConverter bc = new BrushConverter();

        bool c_change = false;
        public int c_ok = 0;

        #endregion

        #region Events

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Title = "Phân quyền cho người dùng" + " " + c_UsersInfo.User_Name;
            LoadRight();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                exitForm();
        }

        private void btnChapNhan_Click(object sender, RoutedEventArgs e)
        {
            User_Right_Insert();
        }

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            exitForm();
        }

        private void chkCheckAll_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    if (chkCheckAll.IsChecked == true)
            //    {
            //        foreach (User_FunctionsInfo _User_FunctionsInfo in grUser_Rights.ItemsSource)
            //        {
            //            _User_FunctionsInfo.use_right = 1;
            //            _User_FunctionsInfo.view_right = 1;
            //            _User_FunctionsInfo.insert_right = 1;
            //            _User_FunctionsInfo.update_right = 1;
            //            _User_FunctionsInfo.delete_right = 1;
            //            _User_FunctionsInfo.approveInfo_right = 1;
            //            _User_FunctionsInfo.Full_Right = 1;
            //            grUser_Rights.EndInit();
            //            grUser_Rights.Items.Refresh();
            //        }
            //    }
            //    else
            //    {
            //        foreach (User_FunctionsInfo _User_FunctionsInfo in grUser_Rights.ItemsSource)
            //        {
            //            _User_FunctionsInfo.use_right = 0;
            //            _User_FunctionsInfo.view_right = 0;
            //            _User_FunctionsInfo.insert_right = 0;
            //            _User_FunctionsInfo.update_right = 0;
            //            _User_FunctionsInfo.delete_right = 0;
            //            _User_FunctionsInfo.approveInfo_right = 0;
            //            _User_FunctionsInfo.Full_Right = 0;
            //            grUser_Rights.EndInit();
            //            grUser_Rights.Items.Refresh();
            //        }
            //    }
            //    c_change = true;
            //}
            //catch (Exception ex)
            //{
            //    ErrorLog.log.Error(ex.ToString());
            //}
        }

        private void us_right_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                User_FunctionsInfo _User_FunctionsInfo = (User_FunctionsInfo)gr_Rights.SelectedItem;
                int rowselect = gr_Rights.SelectedIndex;

                if (_User_FunctionsInfo.last == "N") // nếu là cha
                {
                    #region nếu mà là cha
                    // duyệt tất cả thằng con của nó
                    // thì gán all theo thằng cha
                    foreach (User_FunctionsInfo ufri in c_arrFunction)
                    {
                        if (ufri.prid == _User_FunctionsInfo.functionId)
                        {
                            if (_User_FunctionsInfo.authcode == 0)
                            {
                                ufri.authcode = 1;
                            }
                            else
                            {
                                ufri.authcode = 0;
                            }
                        }
                    }
                    #endregion
                }
                else
                {
                    #region nếu mà là con
                    if (_User_FunctionsInfo.authcode == 1)
                    {
                        #region nếu bỏ chọn thì bỏ check thằng cha
                        foreach (User_FunctionsInfo ufri in c_arrFunction)
                        {
                            if (ufri.functionId == _User_FunctionsInfo.prid)
                            {
                                ufri.authcode = 0;
                                break;
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        #region nếu mà chọn thì check all thằng con cùng cha vs nó nếu mà all thằng con cùng check thì,thì check thằng cha đó

                        bool _ck_all_view = true;
                        foreach (User_FunctionsInfo ufri in c_arrFunction)
                        {
                            // kiểm tra tất cả thằng con cùng cha vs nó
                            // nếu mà tick hết thì check thằng cha, không kiểm tra chính thằng đang được chọn
                            if (ufri.prid == _User_FunctionsInfo.prid && ufri.functionId != _User_FunctionsInfo.functionId)
                            {
                                if (ufri.authcode == 0)
                                {
                                    _ck_all_view = false;
                                    break;
                                }
                            }
                        }

                        if (_ck_all_view)
                        {
                            foreach (User_FunctionsInfo ufri in c_arrFunction)
                            {
                                if (ufri.functionId == _User_FunctionsInfo.prid)
                                {
                                    ufri.authcode = 1;
                                    break;
                                }
                            }
                        }
                        #endregion
                    }
                    #endregion
                }

                if (_User_FunctionsInfo.authcode == 0)
                {
                    _User_FunctionsInfo.authcode = 1;
                    gr_Rights.EndInit();
                    gr_Rights.Items.Refresh();
                }
                else
                {
                    _User_FunctionsInfo.authcode = 0;
                    gr_Rights.EndInit();
                    gr_Rights.Items.Refresh();
                }
                c_change = true;
                DataGridHelper.NVSFocus(gr_Rights, rowselect, (gr_Rights.CurrentColumn).DisplayIndex);

            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        private void Use_Right_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                us_right_Click_1(null, null);
            }
        }

        private void grUser_Rights_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Delete) e.Handled = true;

                if (e.Key == Key.Enter) e.Handled = true;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        private void grUser_Rights_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        #endregion

        #region Private Methods

        void LoadRight()
        {
            try
            {
                c_arrFunction = _usRc0n.User_Rights_GetByUser(c_UsersInfo.Group_Id, c_UsersInfo.User_Name);

                foreach (User_FunctionsInfo item in c_arrFunction)
                {
                    if (item.last == "Y")
                    {
                        Brush brush = (Brush)bc.ConvertFromString("#003D76");
                        brush.Freeze();
                        item.Br_N = brush;
                    }
                    else
                        item.Br_N = Brushes.Red;
                }

                gr_Rights.ItemsSource = c_arrFunction;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        private void User_Right_Insert()
        {
            try
            {
                if (c_change)
                {

                    User_RightsController _User_RightsController = new User_RightsController();

                    List<User_RightsInfo> _lstRight = new List<User_RightsInfo>();

                    foreach (User_FunctionsInfo item in c_arrFunction)
                    {
                        if (item.authcode != 0)
                        {
                            User_RightsInfo _User_RightsInfo = ConvertToUser_RightsInfo(item, c_UsersInfo.User_Id);
                            _User_RightsInfo.User_Name = c_UsersInfo.User_Name;
                            _lstRight.Add(_User_RightsInfo);
                        }
                    }
                    if (_lstRight.Count > 0)
                    {
                        MessageBoxResult result1 = NoteBox.Show("Bạn có muốn cập nhật hay không?", "", NoteBoxLevel.Question);
                        if (result1 == MessageBoxResult.Yes)
                        {
                            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;

                            _User_RightsController.User_Rights_DelByUser(c_UsersInfo.User_Name);
                            _User_RightsController.User_Rights_Insert_Barth(_lstRight);

                            Mouse.OverrideCursor = null;

                            c_ok = 1;
                            NoteBox.Show("Cập nhật dữ liệu thành công", "", NoteBoxLevel.Note);
                            this.Close();
                        }
                    }
                    else
                    {
                        Mouse.OverrideCursor = null;
                        NoteBox.Show("Bạn chưa đặt quyền cho chức năng nào", "", NoteBoxLevel.Error);
                    }
                }
                else
                {
                    Mouse.OverrideCursor = null;
                    NoteBox.Show("Bạn chưa thực hiện thay đổi quyền nào", "", NoteBoxLevel.Error);
                }
            }
            catch (Exception ex)
            {
                Mouse.OverrideCursor = null;
                ErrorLog.log.Error(ex.ToString());
                NoteBox.Show("Cập nhật dữ liệu không thành công", "Lỗi", NoteBoxLevel.Error);
            }

        }

        private User_RightsInfo ConvertToUser_RightsInfo(User_FunctionsInfo _User_FunctionsInfo, decimal user_id)
        {
            try
            {
                User_RightsInfo _User_RightsInfo = new User_RightsInfo();
                _User_RightsInfo.userid = user_id;
                _User_RightsInfo.funcid = _User_FunctionsInfo.functionId;
                _User_RightsInfo.authcode = _User_FunctionsInfo.authcode;
                return _User_RightsInfo;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return null;
            }
        }

        private void exitForm()
        {
            MessageBoxResult result = NoteBox.Show("Bạn có muốn thoát form này hay không?", "Thông báo", NoteBoxLevel.Question);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
            else
                this.Focus();
        }

        void Check_Is_CheckALl()
        {
            try
            {
                bool _ck = true;
                foreach (User_FunctionsInfo item in c_arrFunction)
                {
                    if (item.authcode == 0)
                    {
                        _ck = false;
                        break;
                    }
                }

                //if (_ck)
                //    chkCheckAll.IsChecked = true;
                //else
                //    chkCheckAll.IsChecked = false;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        #endregion
    }
}
