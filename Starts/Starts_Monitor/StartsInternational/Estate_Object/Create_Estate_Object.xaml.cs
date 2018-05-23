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

namespace StartsInternational.Estate_Object
{
    /// <summary>
    /// Interaction logic for Create_Estate_Object.xaml
    /// </summary>
    public partial class Create_Estate_Object : Window
    {
        public Create_Estate_Object()
        {
            InitializeComponent();
        }

        public decimal c_id_insert = 0;
        Estate_Object_Controller c_Estate_Object_Controller = new Estate_Object_Controller();
        Building_Info c_Building_Info_Search = new Building_Info();

        private void frmCreate_Estate_Object_Loaded_1(object sender, RoutedEventArgs e)
        {
            LoadCombobox();
            txt_Estate_Code.Focus();
        }

        private void frmCreate_Estate_Object_KeyDown_1(object sender, KeyEventArgs e)
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

        private void btnChapNhan_Click_1(object sender, RoutedEventArgs e)
        {
            Accept();
        }

        private void btnHuy_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnChose_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SearchBuilding _SearchBuilding = new SearchBuilding();
                _SearchBuilding.Owner = Window.GetWindow(this);
                _SearchBuilding.ShowDialog();

                if (_SearchBuilding.c_ok == 1)
                {
                    Building_Info _Building_Info = _SearchBuilding.c_Building_Info_Search;

                    txtBuilding.Text = _Building_Info.Building_Code;

                    c_Building_Info_Search = _SearchBuilding.c_Building_Info_Search;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
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
                if (txt_Estate_Code.Text == "")
                {
                    NoteBox.Show("Mã đối tượng bất động sản không được để trống", "", NoteBoxLevel.Error);
                    txt_Estate_Code.Focus();
                    return false;
                }

                if (txt_Estate_Name.Text == "")
                {
                    NoteBox.Show("Tên đối tượng bất động sản không được để trống", "", NoteBoxLevel.Error);
                    txt_Estate_Name.Focus();
                    return false;
                }

                if (txtBuilding.Text == "")
                {
                    NoteBox.Show("Tòa nhà không được để trống", "", NoteBoxLevel.Error);
                    txtBuilding.Focus();
                    return false;
                }

                //if (txt_Estate_Area.Text == "")
                //{
                //    NoteBox.Show("Diện tích đối tượng bất động sản không được để trống", "", NoteBoxLevel.Error);
                //    txt_Estate_Area.Focus();
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
                if (Estate_Checkvalidate() == false)
                {
                    return;
                }

                Estate_Object_Info _Estate_Object_Info = new Estate_Object_Info();
                _Estate_Object_Info.Estate_Name = txt_Estate_Name.Text;
                _Estate_Object_Info.Note = txtNote.Text;
                _Estate_Object_Info.Area = txt_Estate_Area.Text;
                _Estate_Object_Info.Estate_Type = Convert.ToDecimal(cboType.SelectedValue);
                _Estate_Object_Info.Status = Convert.ToDecimal(cboStatus.SelectedValue);
                _Estate_Object_Info.Building_Id = c_Building_Info_Search.Building_Id;
                _Estate_Object_Info.Estate_Code = txt_Estate_Code.Text;
                decimal _estate_id = c_Estate_Object_Controller.Estate_Object_Insert(_Estate_Object_Info);

                if (_estate_id == -1)
                {
                    NoteBox.Show("Lỗi thêm mới đối tượng bất động sản", "", NoteBoxLevel.Error);
                    return;
                }

                c_id_insert = _estate_id;

                NoteBox.Show("Thêm mới dữ liệu thành công", "");
                this.Close();
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

    }
}
