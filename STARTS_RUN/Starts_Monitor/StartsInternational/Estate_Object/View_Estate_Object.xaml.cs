using System;
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
using System.Windows.Shapes;

using MemoryData;
using ObjInfo;
using Starts_Controller;
using StartsInternational.Common;
using StartsInternational.Contract;

namespace StartsInternational.Estate_Object
{
    /// <summary>
    /// Interaction logic for Create_Estate_Object.xaml
    /// </summary>
    public partial class View_Estate_Object : Window
    {
        public View_Estate_Object()
        {
            InitializeComponent();
        }

        int c_row_select = 0;
        public Estate_Object_Info c_Estate_Object_Info;
        Contract_Controller c_Contract_Controller = new Contract_Controller();

        private void frmUpdate_Estate_Object_Loaded_1(object sender, RoutedEventArgs e)
        {
            LoadCombobox();

            LoadData();

            txt_Estate_Name.Focus();
        }

        private void frmUpdate_Estate_Object_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        private void btnHuy_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
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


        void LoadCombobox()
        {
            try
            {
                List<AllCode_Info> _lst_Status = DBMemory.AllCode_GetBy_CdNameCdType("ESTATE", "STATUS");
                cboStatus.ItemsSource = _lst_Status;
                cboStatus.DisplayMemberPath = "Content";
                cboStatus.SelectedValuePath = "CdValue";
                cboStatus.SelectedIndex = 0;

                List<AllCode_Info> _lst_Type = DBMemory.AllCode_GetBy_CdNameCdType("ESTATE", "TYPE");
                cboType.ItemsSource = _lst_Type;
                cboType.DisplayMemberPath = "Content";
                cboType.SelectedValuePath = "CdValue";
                cboType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        bool Estate_Checkvalidate()
        {
            try
            {
                if (txt_Estate_Name.Text == "")
                {
                    NoteBox.Show("Tên đối tượng bất động sản không được để trống", "", NoteBoxLevel.Error);
                    txt_Estate_Name.Focus();
                    return false;
                }

                if (txt_Estate_Area.Text == "")
                {
                    NoteBox.Show("Diện tích đối tượng bất động sản không được để trống", "", NoteBoxLevel.Error);
                    txt_Estate_Area.Focus();
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        void LoadData()
        {
            try
            {
                txt_Estate_Code.Text = c_Estate_Object_Info.Estate_Name;
                txt_Estate_Name.Text = c_Estate_Object_Info.Estate_Name;
                txtNote.Text = c_Estate_Object_Info.Note;
                txt_Estate_Area.Text = c_Estate_Object_Info.Area;
                cboStatus.SelectedValue = c_Estate_Object_Info.Status;
                cboType.SelectedValue = c_Estate_Object_Info.Estate_Type;
                cboBuilding.Text = c_Estate_Object_Info.Building_Name;

                // lấy danh sách hợp đồng theo id của đối tượng bất động sản
                List<Contract_Info> _lst = c_Contract_Controller.Contract_GetBy_EstateObject(c_Estate_Object_Info.Estate_Id);
                dgrContract.ItemsSource = _lst;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        void View_Contract()
        {
            try
            {
                c_row_select = dgrContract.SelectedIndex;
                Contract_Info _Contract_Info = (Contract_Info)dgrContract.SelectedItem;

                if (_Contract_Info == null) return;
                if (_Contract_Info.Contract_Type == (decimal)Enum_Contract_Type.Renter)
                {
                    View_Contract_Renter _View_Contract_Renter = new View_Contract_Renter();
                    _View_Contract_Renter.Owner = Window.GetWindow(this);

                    _View_Contract_Renter.c_Contract_Info = _Contract_Info;
                    _View_Contract_Renter.ShowDialog();
                }
                else
                {
                    View_Contract_Tenant _View_Contract_Tenant = new View_Contract_Tenant();
                    _View_Contract_Tenant.Owner = Window.GetWindow(this);

                    _View_Contract_Tenant.c_Contract_Info = _Contract_Info;
                    _View_Contract_Tenant.ShowDialog();
                }
                DataGridHelper.NVSFocus(dgrContract, c_row_select, 0);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

    }
}
