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
    public partial class Update_Estate_Object : Window
    {
        public Update_Estate_Object()
        {
            InitializeComponent();
        }

        public Estate_Object_Info c_Estate_Object_Info;
        Estate_Object_Controller c_Estate_Object_Controller = new Estate_Object_Controller();

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
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
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

                if (c_Estate_Object_Controller.Estate_Object_Update(c_Estate_Object_Info.Estate_Id, _Estate_Object_Info) == false)
                {
                    NoteBox.Show("Lỗi sửa đối tượng bất động sản", "", NoteBoxLevel.Error);
                    return;
                }

                NoteBox.Show("Cập nhật dữ liệu thành công", "");
                this.Close();
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }
    }
}
