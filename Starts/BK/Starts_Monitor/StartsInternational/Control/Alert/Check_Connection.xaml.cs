using Starts_Controller;
using ObjInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using StartsInternational.Common;
using Starts_Controller.AutoUpdate;
using MemoryData;


namespace StartsInternational.Control
{
    /// <summary>
    /// Interaction logic for Check_Connection.xaml
    /// </summary>
    public partial class Check_Connection : Window
    {
        public Check_Connection()
        {
            InitializeComponent();
        }

        Allcode_Controller c_AllCodeController = new Allcode_Controller();

        int c_LoadCommonDataStatus = 0;//trạng thái của load dữ liệu: 0: dang load, 1: load khong thanh cong, 2: load thanh cong
        string c_msgNotify; //mesage thogn bao
        public bool c_isLogin = true;

        VersionInfo _LocalVersion;

        enum MsgType
        {
            NORMAL = 0,
            ERROR = 1
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = NoteBox.Show(" Bạn có muốn thoát khỏi chương trình không?", "Thông báo", NoteBoxLevel.Question);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
                Application.Current.Shutdown();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Controller _Controller = new Controller();
                _LocalVersion = _Controller.GetLocalVersion();
                if (c_isLogin)
                {
                    stkLoading.Visibility = Visibility.Visible;
                    gr_main.Visibility = Visibility.Collapsed;
                    btnExit.Visibility = Visibility.Visible;
                    Thread _thr = new Thread(ThreadSystemCheck);
                    _thr.IsBackground = true;
                    _thr.Start();

                    txtUsername.Text = System.Configuration.ConfigurationManager.AppSettings["LastestUser"];
                    txtPassword.Text = System.Configuration.ConfigurationManager.AppSettings["Password"];
                }
                else
                {
                    stkLoading.Visibility = Visibility.Collapsed;
                    gr_main.Visibility = Visibility.Visible;

                    txtUsername.Text = CommonData.c_Urser_Info.User_Name;
                    txtUsername.IsHitTestVisible = true;
                    txtUsername.Focusable = false;
                    txtPassword.Text = "";
                    txtPassword.Focus();
                }
                tblError.Visibility = Visibility.Collapsed;

                
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        private void passwordBox1_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void txtUsername_GotFocus(object sender, RoutedEventArgs e)
        {
            txtUsername.Focus();
            txtUsername.SelectAll();
        }

        private void passwordBox1_GotFocus(object sender, RoutedEventArgs e)
        {
            txtPassword.Focus();
        }

        private void btnLogon_Click(object sender, RoutedEventArgs e)
        {
            if (c_isLogin)
            {
                UserLogin();
            }
            else
            {
                UserLock();
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result = NoteBox.Show("Bạn chắc chắn muốn thoát khỏi chương trình?", "Thông báo", NoteBoxLevel.Question);
                if (result == MessageBoxResult.Yes)
                {
                    this.Close();
                    Application.Current.Shutdown();
                }
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    if (c_isLogin)
                    {
                        UserLogin();
                    }
                    else
                    {
                        UserLock();
                    }
                }
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        private void ThreadSystemCheck()
        {
            try
            {
                #region 0. Kiem tra ket noi database WCF
                Allcode_Controller _AllCodeController = new Allcode_Controller();

                c_msgNotify = "Kiểm tra kết nối đến WCF service ...";
                ShowLabel(MsgType.NORMAL, c_msgNotify, 10);

                bool _Result = _AllCodeController.AllCode_checkWCF();
                if (_Result == false)
                {
                    c_LoadCommonDataStatus = 1; //kiẻm tra bị lôi
                    c_msgNotify = "Error: Lỗi kết nối đến WCF service";
                    ShowLabel(MsgType.ERROR, c_msgNotify, 10);
                    return;
                }
                #endregion

                #region 1 Auto Update

                Controller _Controller = new Controller();
                VersionInfo _VersionInfo = _Controller.GetNewnestVersion();
                if (_VersionInfo.Version == "0.0.0.0")
                {
                    //c_CheckOK = false;
                    //ShowLabel(MsgType.ERROR, "Không kết nối được với máy chủ.Không thể tự động cập nhật phiên bản mới !");
                    //return;
                }
                else
                {
                    if (_LocalVersion.Version != _VersionInfo.Version)
                    {
                        c_msgNotify = "Download phiên bản mới";
                        ShowLabel(MsgType.NORMAL, c_msgNotify, 20);
                        if (_Controller.DownloadUpdateFile() == true)
                        {
                            if (System.IO.File.Exists("AutoInstall.exe"))
                            {
                                System.Diagnostics.Process.Start("AutoInstall.exe", "StartsInternational");
                                //  CloseApp();
                            }
                        }
                    }
                }
                #endregion

                #region 2. Kiem tra ket noi database

                c_msgNotify = "Kiểm tra thông số hệ thống";
                ShowLabel(MsgType.NORMAL, c_msgNotify, 30);

                c_msgNotify = "Kiểm tra kết nối đến Database";
                ShowLabel(MsgType.NORMAL, c_msgNotify, 50);
                if (_AllCodeController.AllCode_checkDatabase() == false)
                {
                    c_LoadCommonDataStatus = 1; //kiẻm tra bị lôi
                    c_msgNotify = "Error: Lỗi kết nối đến Database";
                    ShowLabel(MsgType.ERROR, c_msgNotify, 50);
                    return;
                }
               
                #endregion

                #region 3.Load CommonData

                try
                {
                    c_msgNotify = "Load dữ liệu tham số hệ thống ...";
                    ShowLabel(MsgType.NORMAL, c_msgNotify, 70);
                    Common.DBMemory.LoadParamSystem();
                }
                catch (Exception ex)
                {
                    c_LoadCommonDataStatus = 1;
                    c_msgNotify = "Error: tham số hệ thống";
                    ShowLabel(MsgType.ERROR, c_msgNotify, 70);
                    CommonData.log.Error(ex.ToString());
                    return;
                } 

                #endregion

                c_LoadCommonDataStatus = 2;
                Thread.Sleep(2000);
                ShowLabel(MsgType.NORMAL, "Kết nối thành công", 90);

                HidenLoading();

            }
            catch
            {
                c_LoadCommonDataStatus = 1; //kiẻm tra bị lôi
                c_msgNotify = "Error: Lỗi khi load tham số hệ thống";
                ShowLabel(MsgType.ERROR, c_msgNotify, 0);
            }
        }

        #region Delegate

        delegate void DelegateShowLabel(MsgType p_MsgType, string strMsg, int p_pgbValue);
        private void ShowLabel(MsgType p_MsgType, string strMsg, int p_pgbValue)
        {
            if (lblMes.Dispatcher.CheckAccess() == false)
            {
                lblMes.Dispatcher.Invoke(new DelegateShowLabel(ShowLabel), p_MsgType, strMsg, p_pgbValue);
            }
            else
            {
                lblMes.Visibility = Visibility.Visible;
                lblMes.Text = strMsg;
            }
        }

        delegate void DelegateShowControl();
        private void HidenLoading()
        {
            try
            {
                if (lblMes.Dispatcher.CheckAccess() == false)
                {
                    lblMes.Dispatcher.Invoke(new DelegateShowControl(HidenLoading));
                }
                else
                {
                    stkLoading.Visibility = Visibility.Collapsed;
                    gr_main.Visibility = Visibility.Visible;

                    txtUsername.Focus();
                }
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        #endregion

        #region Methods

        private void UserLogin()
        {
            try
            {
                tblError.Visibility = Visibility.Collapsed;
                if (c_LoadCommonDataStatus != 2) return;

                User_Controller _User_Controller = new User_Controller();

                User_Info _User_Info = _User_Controller.User_Login(txtUsername.Text, txtPassword.Text);

                if (_User_Info == null)
                {
                    NoteBox.Show("Sai tên đăng nhập hoặc mật khẩu", "", NoteBoxLevel.Error);
                    txtPassword.Focus();
                    return;
                }

                _User_Controller.User_Update_Last_Login(_User_Info.User_Id, DateTime.Now);
                
                System.Configuration.Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);
                config.AppSettings.Settings.Remove("LastestUser");
                config.AppSettings.Settings.Add("LastestUser", _User_Info.User_Name);

                config.AppSettings.Settings.Remove("Password");
                config.AppSettings.Settings.Add("Password", txtPassword.Text);

                config.Save(System.Configuration.ConfigurationSaveMode.Modified);
                System.Configuration.ConfigurationManager.RefreshSection("appSettings");

                CommonData.c_Urser_Info = _User_Info;
                
                DBMemory.LoadFunctionUsers();

                this.DialogResult = true;
                this.Close();
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                NoteBox.Show("Đăng nhập thất bại", "Thông báo");
            }
        }

        private void UserLock()
        {
            try
            {
                if (CommonData.c_Urser_Info.Pass == txtPassword.Text)
                {
                    this.Close();
                }
                else
                {
                    tblError.Visibility = Visibility.Visible;
                    tblError.Text = "Mật khẩu không đúng.............";
                    //NoteBox.Show("Mật khẩu không đúng", "Thông báo", NoteBoxLevel.Error);
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                tblError.Text = "Đăng nhập thất bại.............";
                //NoteBox.Show("Đăng nhập thất bại", "Thông báo");
                App.Current.Shutdown();
            }
        }
        #endregion

    }
}
