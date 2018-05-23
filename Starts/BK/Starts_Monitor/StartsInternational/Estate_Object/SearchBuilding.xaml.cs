using MemoryData;
using ObjInfo;
using Starts_Controller;
using StartsInternational.Common;
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

namespace StartsInternational.Estate_Object
{
    /// <summary>
    /// Interaction logic for SearchBuilding.xaml
    /// </summary>
    public partial class SearchBuilding : Window
    {
        public SearchBuilding()
        {
            InitializeComponent();
        }

        BuildingController c_BuildingController = new BuildingController();
        List<Building_Info> c_lst = new List<Building_Info>();
        public int c_ok = 0;
        public Building_Info c_Building_Info_Search = new Building_Info();


        private void frmSearchBuilding_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //c_lst = c_BuildingController.Building_GetAll();
                //dgrRenter.ItemsSource = c_lst;
                //DataGridHelper.NVSFocus(dgrRenter, 0, 0);

                txtBuildingName.Focus();
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        private void frmSearchBuilding_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        private void dgrRenter_LoadingRow_1(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void dgrRenter_PreviewKeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                e.Handled = true;
            }
        }

        private void btnSearch_Click_1(object sender, RoutedEventArgs e)
        {
            Search();
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
                Building_Info _Building_Info = (Building_Info)dgrRenter.SelectedItem;
                if (_Building_Info != null)
                {
                    c_Building_Info_Search = _Building_Info;
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

                string _name = txtBuildingName.Text.ToUpper();
                if (_name == "") _name = CommonData.c_All_Value;

                c_lst = c_BuildingController.Building_Search(_name);

                Mouse.OverrideCursor = null;
                dgrRenter.ItemsSource = c_lst;
                DataGridHelper.NVSFocus(dgrRenter, 0, 0);
            }
            catch (Exception ex)
            {
                Mouse.OverrideCursor = null;
                ErrorLog.log.Error(ex.ToString());
            }
        }
    }
}
