using MemoryData;
using ObjInfo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
using Starts_Controller;
using StartsInternational.Common;

namespace StartsInternational.Contract.Create
{
    /// <summary>
    /// Interaction logic for NhanTTLK_Create.xaml
    /// </summary>
    public partial class Auto_StatusContract : Window
    {
        public Auto_StatusContract()
        {
            InitializeComponent();
        }

        Button _btnClose; //nut close trên form
        string c_error_code = ""; // biến báo mess trả về khi nhận dữ liệu từ lưu ký

        bool c_close_form = false;
        int c_number = 0;

        public List<Contract_Info> c_lst = new List<Contract_Info>();
        Contract_Controller c_Contract_Controller = new Contract_Controller();

        private delegate void UpdateProgressBarDelegate(System.Windows.DependencyProperty dp, Object value);
        private void frmReceiveVsd_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadData();

                Thread _thr1 = new Thread(ThreadShowProgress);
                _thr1.IsBackground = true;
                _thr1.Start();

                Thread _thr = new Thread(ThreadReceive);
                _thr.IsBackground = true;
                _thr.Start();
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        void LoadData()
        {
            try
            {
                // lấy thông tin của những thằng quá hạn mà chưa cập nhật trạng thái
                c_lst = c_Contract_Controller.Get_Contract_Exprire_Date(ConvertData.ConvertDate2String(DateTime.Now));
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        private void ThreadReceive()
        {
            try
            {
                // thực hiện cập nhật trạng thái
                try
                {
                    foreach (Contract_Info item in c_lst)
                    {
                        c_Contract_Controller.Update_Status_Contract(item.Contract_Id, (decimal)Enum_Contract_Status.Het_Han, CommonData.c_Urser_Info.User_Name, DateTime.Now);
                    }
                }
                catch (Exception ex)
                {
                    ErrorLog.log.Error(ex.ToString());
                    c_number = (Int32)ERROR_CODE.ERROR_FALSE;
                }

                c_number = (Int32)ERROR_CODE.ERROR_SUSSCESS;
                c_error_code = ShowMes(c_number);

                if (c_number != (Int32)ERROR_CODE.ERROR_SUSSCESS)
                    c_error_code += ". Nhấn ESC để thoát";
                else
                {
                    Thread.Sleep(1000);
                    CloseForm();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        private void ThreadShowProgress()
        {
            try
            {
                int _index = 0;
                while (true)
                {
                    if (c_number != (Int32)ERROR_CODE.ERROR_SUSSCESS)
                    {
                        ShowProgerss(_index);

                        _index++;
                    }

                    Thread.Sleep(1000);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        delegate void DelegateShowControlLable(string p_mes);
        private void ShowControlLable(string p_mes)
        {
            try
            {
                if (lblMes.Dispatcher.CheckAccess() == false)
                {
                    lblMes.Dispatcher.Invoke(new DelegateShowControlLable(ShowControlLable), p_mes);
                }
                else
                {
                    lblMes.Text = p_mes;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        delegate void DelegateCloseForm();
        private void CloseForm()
        {
            try
            {
                if (lblMes.Dispatcher.CheckAccess() == false)
                {
                    lblMes.Dispatcher.Invoke(new DelegateCloseForm(CloseForm));
                }
                else
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        delegate void DelegateProgerss(int p_value);
        private void ShowProgerss(int p_value)
        {
            try
            {
                if (lblMes.Dispatcher.CheckAccess() == false)
                {
                    lblMes.Dispatcher.Invoke(new DelegateProgerss(ShowProgerss), p_value);
                }
                else
                {
                    prgTTLK.Value = p_value;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        string ShowMes(int p_error)
        {
            #region Thông báo lỗi
            switch (p_error)
            {
                case (Int32)ERROR_CODE.ERROR_FALSE:
                    return "Có lỗi trong quá trình cập nhật thông tin....";
                case (Int32)ERROR_CODE.ERROR_SUSSCESS:
                    return "Cập nhật thông tin thành công";
                default:
                    return "Có lỗi trong quá trình cập nhật thông tin....";
            }
            #endregion
        }

        private void frmReceiveVsd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape && c_number != (Int32)ERROR_CODE.ERROR_SUSSCESS)
                this.Close();
        }

        public override void OnApplyTemplate()
        {
            _btnClose = (Button)GetTemplateChild("btnClose");

            _btnClose.Visibility = Visibility.Collapsed;

            base.OnApplyTemplate();
        }
    }

    enum ERROR_CODE
    {
        ERROR_FALSE = -1,
        ERROR_SUSSCESS = 0,
    }
}
