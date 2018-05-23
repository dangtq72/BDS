using MemoryData;
using ObjInfo;
using Starts_Controller;
using StartsInternational.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace StartsInternational.Contract.Create
{
    /// <summary>
    /// Interaction logic for Chose_Estate_Object.xaml
    /// </summary>
    public partial class Chose_Estate_Object : Window
    {
        public Chose_Estate_Object()
        {
            InitializeComponent();
        }

        List<Estate_Object_Info> c_lst = new List<Estate_Object_Info>();
        int c_row_select = 0;
        Estate_Object_Controller c_Estate_Object_Controller = new Estate_Object_Controller();

        public int c_ok = 0;
        public Estate_Object_Info c_Estate_Object_Info_Search = new Estate_Object_Info();

        private void frmChose_Estate_Object_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                AllCode_Info _AllCode_Info = new AllCode_Info();
                _AllCode_Info.Content = CommonData.c_All_Content;
                _AllCode_Info.CdValue = CommonData.c_All_Value;

                List<AllCode_Info> _lst_c_Status = DBMemory.AllCode_GetBy_CdNameCdType("ESTATE", "STATUS");
                _lst_c_Status.Insert(0, _AllCode_Info);
                cboStatus.ItemsSource = _lst_c_Status;
                cboStatus.DisplayMemberPath = "Content";
                cboStatus.SelectedValuePath = "CdValue";
                cboStatus.SelectedIndex = 0;

                List<AllCode_Info> _lst_c_type = DBMemory.AllCode_GetBy_CdNameCdType("ESTATE", "TYPE");
                _lst_c_type.Insert(0, _AllCode_Info);
                cboType.ItemsSource = _lst_c_type;
                cboType.DisplayMemberPath = "Content";
                cboType.SelectedValuePath = "CdValue";
                cboType.SelectedIndex = 0;

                //c_lst = c_Estate_Object_Controller.Estate_Object_GetAll();
                //dgrEstate.ItemsSource = c_lst;
                //DataGridHelper.NVSFocus(dgrEstate, 0, 0);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        private void frmChose_Estate_Object_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        private void dgrEstate_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void dgrEstate_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                e.Handled = true;
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Search();
        }

        void DoubleClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Estate_Object_Info _Estate_Object_Info = (Estate_Object_Info)dgrEstate.SelectedItem;
                if (_Estate_Object_Info != null)
                {
                    c_Estate_Object_Info_Search = _Estate_Object_Info;
                    c_ok = 1;
                    this.Close();
                }
                e.Handled = true;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        void Search()
        {
            try
            {
                Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;

                string _code = txtCode.Text.ToUpper();
                if (_code == "") _code = CommonData.c_All_Value;

                c_lst = c_Estate_Object_Controller.Estate_Object_Search(_code, cboType.SelectedValue.ToString(), cboStatus.SelectedValue.ToString());


                Mouse.OverrideCursor = null;
                dgrEstate.ItemsSource = c_lst;
                DataGridHelper.NVSFocus(dgrEstate, 0, 0);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }


    }
}
