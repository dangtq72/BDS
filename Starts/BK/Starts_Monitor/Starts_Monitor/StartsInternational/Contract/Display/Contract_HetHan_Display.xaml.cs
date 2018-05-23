using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

using System.Collections;
using ObjInfo;
using Starts_Monitor.User;
using Starts_Controller;
using StartsInternational.Control.Created;
using StartsInternational.Common;
using MemoryData;
using System.Data;

namespace StartsInternational.Contract.Display
{
    /// <summary>
    /// Interaction logic for UserDisplay.xaml
    /// </summary>
    public partial class Contract_HetHan_Display : Window
    {
        public Contract_HetHan_Display()
        {
            InitializeComponent();
        }

        public List<Contract_Info> c_lst = new List<Contract_Info>();
        int c_row_select = 0;
        Contract_Controller c_Contract_Controller = new Contract_Controller();
        Estate_Object_Controller _Estate_Object_Controller = new Estate_Object_Controller();
        Customer_Controller _Customer_Controller = new Customer_Controller();
        Fees_Revenue_Controller _Fees_Revenue_Controller = new Fees_Revenue_Controller();

        bool Is_Load = false;

        private void frmContract_HetHan_Display_Loaded(object sender, RoutedEventArgs e)
        {
            if (Is_Load == false)
            {
                LoadData(false);
            }
        }

        private void frmContract_HetHan_Display_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.F8:
                    Export_Payment();
                    break;
                case Key.F5:
                    View_Contract();
                    break;
                case Key.Delete:
                    e.Handled = true;
                    break;
                case Key.Escape:
                    this.Close();
                    break;
            }
        }

        private void dgrContract_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void dgrContract_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                e.Handled = true;
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Contract_Update();
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            View_Contract();
        }

        private void btnRequestPay_Click(object sender, RoutedEventArgs e)
        {
            Export_Payment();
        }

        /// <summary>
        /// hàm dùng cho EventsSetter trong form display
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void DoubleClick(object sender, RoutedEventArgs e)
        {
            try
            {
                View_Contract();
                e.Handled = true;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        #region Methods

        void LoadData(bool p_is_call)
        {
            try
            {
                if (p_is_call == false)
                {
                    dgrContract.ItemsSource = c_lst;
                }
                else
                {
                    Contract_Controller _Contract_Controller = new Contract_Controller();
                    c_lst = _Contract_Controller.Contract_Search_DenHanTB(ConvertData.ConvertDate2String(DateTime.Now), ConvertData.ConvertDate2String(DateTime.Now.AddDays(60)));
                }

                DataGridHelper.NVSFocus(dgrContract, 0, 0);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        void View_Contract()
        {
            try
            {
                c_row_select = dgrContract.SelectedIndex;
                Contract_Info _Contract_Info = (Contract_Info)dgrContract.SelectedItem;

                if (_Contract_Info == null) return;

                //Contract_Info _Contract_Info1 = c_Contract_Controller.Contract_GetById(_Contract_Info.Contract_Id);

                View_Contract_Renter _View_Contract_Renter = new View_Contract_Renter();
                _View_Contract_Renter.Owner = Window.GetWindow(this);

                _View_Contract_Renter.c_Contract_Info = _Contract_Info;
                _View_Contract_Renter.ShowDialog();

                DataGridHelper.NVSFocus(dgrContract, c_row_select, 0);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        void Export_Payment()
        {
            try
            {
                c_row_select = dgrContract.SelectedIndex;
                Contract_Info _Contract_Info = (Contract_Info)dgrContract.SelectedItem;

                if (_Contract_Info == null) return;

                List<Fees_Revenue_Info> _lst = _Fees_Revenue_Controller.Fees_Revenue_GetByContract(_Contract_Info.Contract_Id);
                Fees_Revenue_Info _Fees_Revenue_Info = new Fees_Revenue_Info();

                bool _is_not_pay = false;

                // kiểm tra xem đã thanh toán hết chưa
                foreach (Fees_Revenue_Info item in _lst)
                {
                    if (item.Pay_Status == (decimal)Enum_Fee_Status.No_Pay)
                    {
                        _is_not_pay = true;
                        _Fees_Revenue_Info = item;
                        break;
                    }
                }

                if (_is_not_pay == false)
                {
                    NoteBox.Show("Đã thanh toán hết, không thể yêu cầu thanh toán", "", NoteBoxLevel.Error);
                    return;
                }

                Estate_Object_Info _Estate_Object_Info = _Estate_Object_Controller.Estate_Object_GetById(_Contract_Info.Estate_Id, (decimal)Enum_Contract_Type.Renter);
                Customer_Info _Customer_Info = _Customer_Controller.Customer_GetById(_Contract_Info.Object_Id);

                CommonFunction.Export_payment(_Contract_Info, _Customer_Info, _Estate_Object_Info, _Fees_Revenue_Info);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        void Contract_Update()
        {
            try
            {
                c_row_select = dgrContract.SelectedIndex;
                Contract_Info _Contract_Info = (Contract_Info)dgrContract.SelectedItem;

                if (_Contract_Info == null) return;
                Update_Contract_Tenant _Update_Contract_Insert_Tenant = new Update_Contract_Tenant();
                _Update_Contract_Insert_Tenant.c_Contract_Info = _Contract_Info;
                _Update_Contract_Insert_Tenant.Owner = Window.GetWindow(this);
                _Update_Contract_Insert_Tenant.ShowDialog();

                if (_Update_Contract_Insert_Tenant.c_id_insert != 0)
                {
                    Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;

                    LoadData(true);
                    DBMemory.LoadFeeTenant();

                    Mouse.OverrideCursor = null;
                }

                DataGridHelper.NVSFocus(dgrContract, c_row_select, 0);
            }
            catch (Exception ex)
            {
                Mouse.OverrideCursor = null;
                CommonData.log.Error(ex.ToString());
            }

        }

        #endregion
    }
}
