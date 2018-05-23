using MemoryData;
using ObjInfo;
using Starts_Controller;
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

namespace StartsInternational.Building
{
    /// <summary>
    /// Interaction logic for Create_Building.xaml
    /// </summary>
    public partial class Update_Building : Window
    {
        public Update_Building()
        {
            InitializeComponent();
        }

        public Building_Info c_Building_Info;
        BuildingController c_BuildingController = new BuildingController();
        public decimal c_id_insert = 0;

        private void frmUpdate_Building_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
            txt_Building_Code.Focus();
        }

        private void frmUpdate_Building_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
            else if (e.Key == Key.Enter)
            {
                Accept();
            }
        }

        private void btnChapNhan_Click(object sender, RoutedEventArgs e)
        {
            Accept();
        }

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        bool Building_Checkvalidate()
        {
            try
            {
                if (txt_Building_Code.Text == "")
                {
                    NoteBox.Show("Mã tòa nhà không được để trống", "", NoteBoxLevel.Error);
                    txt_Building_Code.Focus();
                    return false;
                }

                //if (txt_Building_Name.Text == "")
                //{
                //    NoteBox.Show("Tên tòa nhà không được để trống", "", NoteBoxLevel.Error);
                //    txt_Building_Name.Focus();
                //    return false;
                //}

                return true;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        void Accept()
        {
            try
            {
                if (Building_Checkvalidate() == false)
                {
                    return;
                }

                MessageBoxResult result = NoteBox.Show("Bạn chắc chắn muốn sửa thông tin tòa nhà hay không?", "Thông báo", NoteBoxLevel.Question);
                if (MessageBoxResult.Yes != result)
                {
                    return;
                }

                Building_Info _Building_Info = new Building_Info();
                _Building_Info.Building_Code = txt_Building_Code.Text;
                _Building_Info.Building_Name = txt_Building_Code.Text;
                _Building_Info.Address = txtAddress.Text;
                _Building_Info.Notes = txtNote.Text;
                decimal _building_id = c_BuildingController.Building_Update(c_Building_Info.Building_Id, _Building_Info);

                if (_building_id == -1)
                {
                    NoteBox.Show("Lỗi sửa thông tin tòa nhà", "", NoteBoxLevel.Error);
                    return;
                }

                c_id_insert = c_Building_Info.Building_Id;

                NoteBox.Show("Sửa dữ liệu thành công", "");
                this.Close();
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
                txt_Building_Code.Text = c_Building_Info.Building_Code;
                //txt_Building_Name.Text = c_Building_Info.Building_Name;
                txtAddress.Text = c_Building_Info.Address;
                txtNote.Text = c_Building_Info.Notes;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }
    }
}
