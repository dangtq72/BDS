using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Collections;
using System.Windows.Media;
using MemoryData;
using ObjInfo;
using Starts_Controller;
using StartsInternational.Common;

namespace StartsInternational.User
{
    /// <summary>
    /// Interaction logic for GroupUser_Right.xaml
    /// </summary>
    public partial class GroupUser_Right : Window
    {
        #region Contrustor and params

        public GroupUser_Right()
        {
            InitializeComponent();
        }

        public GroupUserInfo c_GroupUserInfo;

        FunctionsController c_FunctionsController = new FunctionsController();
        User_RightsController _User_RightsController = new User_RightsController();
        Function_GroupController _Function_GroupController = new Function_GroupController();

        public int c_ok = 0;
        BrushConverter bc = new BrushConverter();
        ArrayList c_arrUserRight = new ArrayList();

        // lưu các quyền của group_user load ban đầu, để check với lúc cập nhật xem có khác vs thằng ban đầu hay không
        Hashtable c_hs_UserRight_First = new Hashtable();

        Hashtable c_hs_Function_OfGroup = new Hashtable();             // danh sách quyền của nhóm

        #endregion

        #region Events

        private void frmGroupUser_Right_Loaded(object sender, RoutedEventArgs e)
        {
            loaddata();
            DataGridHelper.NVSFocus(dgFunctions, 0, 0);
        }

        private void frmGroupUser_Right_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                exitForm();
            if (e.Key == Key.Enter)
                Update();
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FunctionsInfo item = (FunctionsInfo)dgFunctions.SelectedItem;
                if (item.last == "N") // nếu là cha
                {
                    // duyệt tất cả thằng con của nó
                    foreach (FunctionsInfo fri in c_arrUserRight)
                    {
                        if (fri.prid == item.id)
                        {
                            if (item.ofgroup == 0)
                            {
                                fri.ofgroup = 1;
                            }
                            else
                            {
                                fri.ofgroup = 0;
                            }
                        }
                    }
                }
                if (item.ofgroup == 0)
                {
                    item.ofgroup = 1;
                }
                else
                {
                    item.ofgroup = 0;
                }

                dgFunctions.Items.Refresh();
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        private void dgFunctions_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void CheckBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Space)
                {
                    int rowselect = dgFunctions.SelectedIndex;
                    CheckBox_Click(null, null);
                    dgFunctions.Items.Refresh();
                    DataGridHelper.NVSFocus(dgFunctions, rowselect, 2);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            exitForm();
        }

        private void ckAll_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ckAll.IsChecked == true)
                {
                    NoteBox.Show("Có sự thay đổi về quyền của nhóm,quyền của người sử dụng thuộc nhóm sẽ được cập nhật lại", "", NoteBoxLevel.Note);
                    foreach (FunctionsInfo item in dgFunctions.ItemsSource)
                    {
                        item.ofgroup = 1;
                    }
                }
                else
                {
                    NoteBox.Show("Đang có nhóm người dùng thuộc nhóm, những người dùng này sẽ tự động bị mất quyền", "", NoteBoxLevel.Note);
                    foreach (FunctionsInfo item in dgFunctions.ItemsSource)
                    {
                        item.ofgroup = 0;
                    }
                }
                dgFunctions.Items.Refresh();
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        #endregion

        #region Private method

        private void loaddata()
        {
            try
            {
                c_arrUserRight = c_FunctionsController.Function_GetAll();
                c_hs_Function_OfGroup = _Function_GroupController.Get_Function_ByGroup(c_GroupUserInfo.Id);

                foreach (FunctionsInfo item in c_arrUserRight)
                {
                    if (c_hs_Function_OfGroup.ContainsKey(item.id))
                    {
                        item.ofgroup = 1;
                    }
                    else item.ofgroup = 0;
                }


                foreach (FunctionsInfo item in c_arrUserRight)
                {
                    if (item.last == "Y") // Y là con
                    {
                        Brush brush = (Brush)bc.ConvertFromString("#003D76");
                        brush.Freeze();
                        item.Br_N = brush;
                    }
                    else // n là cha
                    {
                        item.Br_N = Brushes.Red;
                    }

                    if (item.ofgroup == 1)
                        c_hs_UserRight_First[item.id] = item;
                }

                dgFunctions.ItemsSource = c_arrUserRight;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        private void Update()
        {
            try
            {
                MessageBoxResult result1 = NoteBox.Show("Có sự thay đổi quyền của nhóm, quyền của người sử dụng thuộc nhóm sẽ được cập nhật lại. Bạn có muốn sửa thông tin này không?", "", NoteBoxLevel.Question);
                if (result1 == MessageBoxResult.Yes)
                {
                    Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;

                    ArrayList _arrInsert = new ArrayList();
                    Hashtable _hs_new_check = new Hashtable();
                    foreach (FunctionsInfo item in c_arrUserRight)
                    {
                        if (item.ofgroup == 1)
                        {
                            _arrInsert.Add(item);
                            _hs_new_check[item.id] = item;
                        }
                    }
                    Function_GroupController _Function_GroupController = new Function_GroupController();

                    //xoa bo toan bo du lieu cu
                    _Function_GroupController.Function_Group_DelByGroup(c_GroupUserInfo.Id);

                    //insert moi
                    _Function_GroupController.Function_Group_Insert_Batch(_arrInsert, c_GroupUserInfo.Id);

                    GetFunctionGroupAdd(_arrInsert, _hs_new_check);

                    Mouse.OverrideCursor = null;

                    NoteBox.Show("Cập nhật dữ liệu thành công", "", NoteBoxLevel.Note);
                    c_ok = 1;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Mouse.OverrideCursor = null;
                ErrorLog.log.Error(ex.ToString());
            }
        }

        private void exitForm()
        {
            MessageBoxResult result = NoteBox.Show("Bạn có muốn thoát khỏi form hay không?", "",
                NoteBoxLevel.Question);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
            else
                this.Focus();
        }

        void GetFunctionGroupAdd(ArrayList p_arr_new, Hashtable _hs_new_check)
        {
            try
            {
                #region Lấy thằng function nào đc add mới hoặc bỏ đi

                // xem những thằng nào được check thêm thì add thêm quyền cho nó
                ArrayList _funt_add = new ArrayList();
                Hashtable _hs_funt_remove = new Hashtable();
                foreach (FunctionsInfo item in p_arr_new)
                {
                    // xem những thằng nào được check thêm thì add thêm quyền cho nó
                    FunctionsInfo _tem = new FunctionsInfo();
                    _tem = (FunctionsInfo)c_hs_UserRight_First[item.id];
                    if (_tem == null)
                        _funt_add.Add(item);
                }

                // xem những thằng nào mà lúc đầu có lúc sau ko có thì xóa quyền của nó đi
                foreach (FunctionsInfo item in c_hs_UserRight_First.Values)
                {
                    FunctionsInfo _tem = new FunctionsInfo();
                    _tem = (FunctionsInfo)_hs_new_check[item.id];
                    if (_tem == null)
                    {
                        _hs_funt_remove[item.id] = item;
                    }
                }
                #endregion

                #region Xóa quyền cho những function mới thêm vào cho all các user thuộc group đó

                if (_hs_funt_remove.Count > 0)
                {
                    foreach (User_Info item_us in DBMemory.c_hash_Users.Values)
                    {
                        ArrayList _arrRightByUser = new ArrayList();
                        if (item_us.Group_Id == c_GroupUserInfo.Id)
                        {
                            foreach (FunctionsInfo fun in _hs_funt_remove.Values)
                            {
                                _User_RightsController.Delete_User_Right_By_UserFuntion(item_us.User_Name, fun.id);
                            }
                        }
                    }
                }

                #endregion

                #region Thêm full quyền cho những function mới thêm vào cho all các user thuộc group đó
                if (_funt_add.Count > 0)
                {
                    // lấy all user thuộc nhóm đó

                    foreach (User_Info item_us in DBMemory.c_hash_Users.Values)
                    {
                        List<User_RightsInfo> _lstRightByUser = new List<User_RightsInfo>();

                        if (item_us.Group_Id == c_GroupUserInfo.Id)
                        {
                            #region Add thêm quyền vào user đó
                            // add thêm những quyền mới thêm vào user đó
                            foreach (FunctionsInfo fun in _funt_add)
                            {
                                User_FunctionsInfo _us_fun = new User_FunctionsInfo();
                                _us_fun.functionId = fun.id;
                                _us_fun.authcode = 1;
                                User_RightsInfo _User_RightsInfo = ConvertToUser_RightsInfo(_us_fun, item_us.User_Id);
                                _User_RightsInfo.User_Name = item_us.User_Name;
                                _lstRightByUser.Add(_User_RightsInfo);
                            }

                            _User_RightsController.User_Rights_Insert_Barth(_lstRightByUser);

                            #endregion
                        }
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        private User_RightsInfo ConvertToUser_RightsInfo(User_FunctionsInfo _User_FunctionsInfo, decimal user_id)
        {
            try
            {
                User_RightsInfo _User_RightsInfo = new User_RightsInfo();
                _User_RightsInfo.id = user_id;
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

        #endregion
    }
}
