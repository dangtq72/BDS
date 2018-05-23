using AvalonDock;
using Microsoft.Windows.Controls.Ribbon;
using ObjInfo;
using StartsInternational.Control;
using StartsInternational.Control.Alert;
using StartsInternational.Control.Created;
using StartsInternational.Display;
using Starts_Monitor.User;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using MemoryData;
using StartsInternational.Common;
using StartsInternational.Contract;
using StartsInternational.Contract.Display;
using StartsInternational.Estate_Object;
using StartsInternational.Report;
using StartsInternational.Building;
using Starts_Controller;

namespace StartsInternational
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            log4net.Config.XmlConfigurator.Configure();

            if (DockingManager.MainDocking == null)
            {
                DockingManager.MainDocking = DockManager;
                DockingManager.MainDocking.Tag = "Dock Main";
            }

            UserLogin();

            AddHandler(Keyboard.PreviewKeyDownEvent, (KeyEventHandler)HandleKeyDownEvent);

            TimerSP.Interval = new TimeSpan(0, 0, 1);
            TimerSP.IsEnabled = true;
            TimerSP.Tick += new EventHandler(TimerSP_Tick);

        }

        DispatcherTimer TimerSP = new DispatcherTimer();//ham timmer de hien thi dong ho
        private static bool ForceClose = false;
        private Hashtable AllManagerForm = new Hashtable(); //Biến lưu trữ các docking form của chương trình
        private Hashtable hashRibbonButtonFunction = new Hashtable(); //danh sach cac ribbon button ma co tag trong function list (chinh la nhung ribbon button can phan quyen)

        #region Event
        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

            try
            {
                #region Tạm thời bỏ
                //List<Contract_Info> _lst_tem = new List<Contract_Info>();
                //List<Contract_Info> _lst = new List<Contract_Info>();
                //List<Contract_Info> _lst_nopay = new List<Contract_Info>();
                //Contract_Controller _Contract_Controller = new Contract_Controller();
                //_lst_tem = _Contract_Controller.Get_Contract_Exprire_Date(ConvertData.ConvertDate2String(DateTime.Now));
                //foreach (Contract_Info item in _lst_tem)
                //{
                //    if (item.Fee_Status == (decimal)Enum_Fee_Status.Payed)
                //    {
                //        _lst.Add(item);
                //    }
                //    else
                //        _lst_nopay.Add(item);
                //}

                //if (_lst.Count > 0)
                //{
                //    StartsInternational.Contract.Create.Auto_StatusContract _Auto_StatusContract = new Contract.Create.Auto_StatusContract();
                //    _Auto_StatusContract.c_lst = _lst;
                //    _Auto_StatusContract.Owner = Window.GetWindow(this);
                //    _Auto_StatusContract.ShowDialog();
                //} 
                #endregion

                Contract_Controller _Contract_Controller = new Contract_Controller();
                List<Contract_Info> _lst_nopay = _Contract_Controller.Contract_Search_DenHanTB(ConvertData.ConvertDate2String(DateTime.Now), ConvertData.ConvertDate2String(DateTime.Now.AddDays(60)));

                if (_lst_nopay.Count > 0)
                {
                    Contract_HetHan_Display _Contract_HetHan_Display = new Contract_HetHan_Display();
                    _Contract_HetHan_Display.c_lst = _lst_nopay;
                    _Contract_HetHan_Display.Owner = Window.GetWindow(this);
                    _Contract_HetHan_Display.ShowDialog();
                }
                InitAllDockForm();
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (true)
            {

            }
        }

        private void frmmain_Closed_1(object sender, EventArgs e)
        {

        }

        private void HandleKeyDownEvent(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.L && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                {
                    LockSystem();
                }
                else if (e.Key == Key.System && e.SystemKey == Key.F4)
                {
                    Application.Current.Shutdown();
                }
                else if (e.Key == Key.F2)
                {
                    frmSuggest _frmSuggest = new frmSuggest();
                    _frmSuggest.Owner = Window.GetWindow(this);
                    _frmSuggest.ShowDialog();
                }
                else if (e.Key == Key.R && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                {
                    Contract_Insert_Renter _Contract_Insert_Renter = new Contract_Insert_Renter();
                    _Contract_Insert_Renter.Owner = Window.GetWindow(this);
                    _Contract_Insert_Renter.ShowDialog();
                }
                else if (e.Key == Key.T && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                {
                    Contract_Insert_Tenant _Contract_Insert_Tenant = new Contract_Insert_Tenant();
                    _Contract_Insert_Tenant.Owner = Window.GetWindow(this);
                    _Contract_Insert_Tenant.ShowDialog();
                }
                else if (e.Key == Key.F && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                {

                }
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        private void DockManager_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnDockingForm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string frmName = ((RibbonButton)sender).Tag.ToString();
                object objForm = AllManagerForm[frmName];

                if (objForm != null)
                {
                    DockableContent _ContentForm = (DockableContent)objForm;
                    ((DockableContent)objForm).NVSQuyen_Core = new SecurityLevel(checkfunction(frmName));
                    _ContentForm.IsFistLoad = true;
                    if (_ContentForm.State == DockableContentState.None)
                    {
                        _ContentForm.ShowAsDocument();
                        _ContentForm.Activate();
                    }
                    else
                    {
                        _ContentForm.Show();
                    }
                }
                else
                {
                    NoteBox.Show("Chức năng chưa được khởi tạo, hãy liên lạc với quản trị hệ thống");
                }
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        private void btnLock_Click(object sender, RoutedEventArgs e)
        {
            LockSystem();
        }

        private void Resetpass_Click(object sender, RoutedEventArgs e)
        {
            Update_Pass _frmUpdate_pass = new Update_Pass();
            _frmUpdate_pass.Owner = Window.GetWindow(this);
            _frmUpdate_pass.ShowDialog();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void TimerSP_Tick(object sender, EventArgs e)
        {
            try
            {
                string _time = DateTime.Now.ToLongTimeString() + "  ";
                lbltime.Content = _time;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        private void btnImgUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                frmCreate_User _Users_View = new frmCreate_User();
                _Users_View.Owner = Window.GetWindow(this);

                _Users_View.c_User_Info = CommonData.c_Urser_Info;
                _Users_View.c_type = Convert.ToInt16(Form_Type.View);
                _Users_View.ShowDialog();
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        private void btnGoiY_Click(object sender, RoutedEventArgs e)
        {
            frmSuggest _frmSuggest = new frmSuggest();
            _frmSuggest.Owner = Window.GetWindow(this);
            _frmSuggest.ShowDialog();
        }

        private void rbn_Contract_Insert_Renter_Click_1(object sender, RoutedEventArgs e)
        {
            Contract_Insert_Renter _Contract_Insert_Renter = new Contract_Insert_Renter();
            _Contract_Insert_Renter.Owner = Window.GetWindow(this);
            _Contract_Insert_Renter.ShowDialog();
        }

        private void rbn_Contract_Insert_Tenant_Click_1(object sender, RoutedEventArgs e)
        {
            Contract_Insert_Tenant _Contract_Insert_Tenant = new Contract_Insert_Tenant();
            _Contract_Insert_Tenant.Owner = Window.GetWindow(this);
            _Contract_Insert_Tenant.ShowDialog();
        }

        #endregion

        #region Methods

        private void LockSystem()
        {
            try
            {
                this.Visibility = System.Windows.Visibility.Hidden;
                //Check_Connection _lock = new Check_Connection();
                frmLogOn _lock = new frmLogOn();
                //_lock.c_isLogin = false;
                _lock.Owner = Window.GetWindow(this);
                //_lock.Title = "Hệ thống đã bị khóa";
                _lock.ShowDialog();

                this.Visibility = System.Windows.Visibility.Visible;
                this.Focus();
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        /// <summary>
        /// Định nghĩa các form mà sử dụng avalondock
        /// </summary>
        private void InitAllDockForm()
        {
            try
            {
                UserDisplay _UserDisplay = new UserDisplay();
                _UserDisplay.Manager = DockManager;
                AllManagerForm[_UserDisplay.Name] = _UserDisplay;

                Group_User_Display _Group_User_Display = new Group_User_Display();
                _Group_User_Display.Manager = DockManager;
                AllManagerForm[_Group_User_Display.Name] = _Group_User_Display;

                Contract_Display _Contract_Display = new Contract_Display();
                _Contract_Display.Manager = DockManager;
                AllManagerForm[_Contract_Display.Name] = _Contract_Display;

                Contract_Display_Tenat _Contract_Display_Tenat = new Contract_Display_Tenat();
                _Contract_Display_Tenat.Manager = DockManager;
                AllManagerForm[_Contract_Display_Tenat.Name] = _Contract_Display_Tenat;

                Customer_Display _Customer_Display = new Customer_Display();
                _Customer_Display.Manager = DockManager;
                AllManagerForm[_Customer_Display.Name] = _Customer_Display;

                Estate_Object_Display _Estate_Object_Display = new Estate_Object_Display();
                _Estate_Object_Display.Manager = DockManager;
                AllManagerForm[_Estate_Object_Display.Name] = _Estate_Object_Display;

                Report_Status_Contract _Report_Status_Contract = new Report_Status_Contract();
                _Report_Status_Contract.Manager = DockManager;
                AllManagerForm[_Report_Status_Contract.Name] = _Report_Status_Contract;

                Report_Contract_Renter_NoPay _Report_Contract_Renter_NoPay = new Report_Contract_Renter_NoPay();
                _Report_Contract_Renter_NoPay.Manager = DockManager;
                AllManagerForm[_Report_Contract_Renter_NoPay.Name] = _Report_Contract_Renter_NoPay;

                Report_QuaHan _Report_QuaHan = new Report_QuaHan();
                _Report_QuaHan.Manager = DockManager;
                AllManagerForm[_Report_QuaHan.Name] = _Report_QuaHan;

                Building_Display _Building_Display = new Building_Display();
                _Building_Display.Manager = DockManager;
                AllManagerForm[_Building_Display.Name] = _Building_Display;

                Report_Fees _Report_Fees = new Report_Fees();
                _Report_Fees.Manager = DockManager;
                AllManagerForm[_Report_Fees.Name] = _Report_Fees;

                Report_Ky_Y _Report_Ky_Y = new Report_Ky_Y();
                _Report_Ky_Y.Manager = DockManager;
                AllManagerForm[_Report_Ky_Y.Name] = _Report_Ky_Y;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        void GetAllRibbonButtonFunction()
        {
            try
            {
                hashRibbonButtonFunction.Clear();

                //tạm thời ẩn tất cả các ribbon tab de thuc hien phan quyen user
                foreach (RibbonTab _rt in Common.Ultil.FindLogicalChildren<RibbonTab>(this))
                {
                    _rt.Visibility = System.Windows.Visibility.Hidden;
                }

                //duyệt qua các ribbon button 
                foreach (RibbonButton _rb in Common.Ultil.FindLogicalChildren<RibbonButton>(this))
                {
                    if (_rb.Tag != null && DBMemory.c_hashFunctionList.ContainsKey(_rb.Tag))
                    {
                        //ribbon button co trong danh sach function
                        hashRibbonButtonFunction[_rb.Tag] = _rb;
                        _rb.OverridesDefaultStyle = true; //an để chờ phân quyền
                    }
                    else
                    {
                        ////những ribbon mà không phải phân quyền thì hiện ribbon tab của nó lên 
                        //RibbonTab _rt = Common.Ultil.FindLogicalParent<RibbonTab>(_rb);
                        //if (_rt != null)
                        //    _rt.Visibility = Visibility.Visible;

                        RibbonTab _rt = Common.Ultil.FindLogicalParent<RibbonTab>(_rb);
                        if (_rt != null)
                            _rt.Visibility = Visibility.Collapsed;

                    }
                }
                string str = "test";
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        private void UserLogin()
        {
            try
            {
                this.Visibility = System.Windows.Visibility.Hidden;
                Check_Connection _Check = new Check_Connection();
                if (_Check.ShowDialog() != true)
                {
                    //neu tra ve khong hop le thi dong ung dung
                    ForceClose = true;
                    this.Close();
                }

                this.Visibility = System.Windows.Visibility.Visible;

                #region Lay quyen User Login o day!

                GetAllRibbonButtonFunction();

                foreach (User_FunctionsInfo quyen in DBMemory.c_arrQuyen)
                {
                    try
                    {
                        if (quyen.name != null && hashRibbonButtonFunction.ContainsKey(quyen.name))
                        {
                            RibbonButton _rb = (RibbonButton)hashRibbonButtonFunction[quyen.name];
                            _rb.OverridesDefaultStyle = false; //hien lai ribbon button

                            //hien nhung ribbon tab chua button ()
                            RibbonTab _rt = Common.Ultil.FindLogicalParent<RibbonTab>(_rb);
                            if (_rt != null)
                                _rt.Visibility = System.Windows.Visibility.Visible;
                        }
                    }
                    catch (Exception ex)
                    {
                        string str = ex.ToString();
                    }
                }

                #endregion

                username.Content = CommonData.c_Urser_Info.User_Name;

                this.Focus();
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        string checkfunction(string menuitem)
        {
            try
            {
                string result = "";
                foreach (User_FunctionsInfo quyen in DBMemory.c_arrQuyen)
                {
                    if (quyen.name == menuitem)
                    {
                        result = quyen.authcode.ToString();
                        break;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return "";
            }
        }

        /// <summary>
        /// CLose các tap trên dock
        /// </summary>
        void CloseAllTab()
        {
            try
            {
                foreach (DictionaryEntry de in AllManagerForm)
                {
                    try
                    {
                        object _objForm = de.Value;
                        if (_objForm != null)
                        {
                            ((ManagedContent)_objForm).Hide();
                        }
                    }
                    catch { }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        #endregion

    }
}
