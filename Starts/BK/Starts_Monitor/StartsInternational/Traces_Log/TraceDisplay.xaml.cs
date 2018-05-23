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
using System.Collections;

using AvalonDock;
using ObjInfo;
using Starts_Controller;
using MemoryData;

namespace StartsInternational
{
    public partial class TraceDisplay : DockableContent
    {

        #region Contructor & para

        public TraceDisplay()
        {
            InitializeComponent();
        }

        private ArrayList arResult = new ArrayList();
        private int index_page_SearchEx = 0;//Chi so trang hien tai!
        private int Number_Msg_SearchEx = 0;//So ban ghi con thua lai!
        private int TotalPage = 0;

        Traces_Log_Controllers _TraceControler = new Traces_Log_Controllers();

        #endregion

        #region Event

        private void frmtracedisplay_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (IsFistLoad)
                {
                    IsFistLoad = false; //đã load 1 lần rồi.
                    loadCombobox();
                    if (gridtrace.Items.Count > 0)
                        gridtrace.SelectedIndex = 0;

                    dtTungay.Text = Common.ConvertData.ConvertDate2String(DateTime.Now.AddDays(-7));
                    dtDenngay.Text = Common.ConvertData.ConvertDate2String(DateTime.Now);
                    //SearchTT();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        private void gridtrace_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            grid_selectedRow();
        }

        private void gridtrace_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                e.Handled = true;
            }
        }

        private void btnRe_Click(object sender, RoutedEventArgs e)
        {
            SearchTT();
        }

        private void gridtrace_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            int row_total = CommonData.RowTotalDock;
            e.Row.Header = (((index_page_SearchEx - 1) * row_total) + (e.Row.GetIndex() + 1)).ToString();

        }

        private void btnTim_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SearchTT();
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        private void frmtracedisplay_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    FrameworkElement fesuorce = (FrameworkElement)e.Source;
                    if (fesuorce.Name == "gridtrace")
                    {
                        grid_selectedRow();
                        return;
                    }
                    else
                    {
                        SearchTT();
                    }
                }
                if (e.Key == Key.F5)
                {
                    SearchTT();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        private void PrivewPage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CommonFunction.Paging_Previous_ListData(arResult, gridtrace, ref index_page_SearchEx, ref txtPageOut, ref Number_Msg_SearchEx);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool check_Thread = true;
                CommonFunction.Paging_Next_ListData(arResult, gridtrace, ref check_Thread, ref index_page_SearchEx, ref txtPageOut, ref Number_Msg_SearchEx);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        private void btnRefreshMsgOut_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CboTotalRow_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                index_page_SearchEx = 0;
                bool check_Thread = false;
                CommonData.RowTotalDock = int.Parse(cboTotalRow.SelectedValue.ToString());
                TotalPage = arResult.Count % CommonData.RowTotalDock == 0 ? arResult.Count / CommonData.RowTotalDock : arResult.Count / CommonData.RowTotalDock + 1;
                lblTotalPage.Content = "Tổng số trang: " + TotalPage;
                CommonFunction.Paging_Next_ListData(arResult, gridtrace, ref check_Thread, ref index_page_SearchEx, ref txtPageOut, ref Number_Msg_SearchEx);
            }
            catch (Exception)
            {
                CommonData.RowTotalDock = 10;
            }
        }

        #endregion

        #region private method

        void loadCombobox()
        {
            try
            {
                User_Controller _UserControler = new User_Controller();
                List<User_Info> _arr = _UserControler.User_Get_All();

                User_Info _objshort = new User_Info();
                _objshort.User_Id = -1;
                _objshort.User_Name = CommonData.c_All_Content;
                _arr.Insert(0, _objshort);
                cboNguoidung.ItemsSource = _arr;
                cboNguoidung.DisplayMemberPath = "User_name";
                cboNguoidung.SelectedValuePath = "User_id";
                cboNguoidung.SelectedIndex = 0;

                //Add tinh thong tin vao Combobox!
                ArrayList _arrTable = new ArrayList();

                TableInfo _TableInfo1 = new TableInfo();
                _TableInfo1.ID = 1;
                _TableInfo1.Name = "CONTRACT";
                _arrTable.Add(_TableInfo1);

                TableInfo _TableInfo7 = new TableInfo();
                _TableInfo7.ID = 1;
                _TableInfo7.Name = "CUSTOMER";
                _arrTable.Add(_TableInfo7);


                TableInfo _TableInfo0 = new TableInfo();
                _TableInfo0.ID = -1;
                _TableInfo0.Name = CommonData.c_All_Content;
                _arrTable.Insert(0, _TableInfo0);

                cboTenbang.ItemsSource = _arrTable;
                cboTenbang.SelectedValuePath = "ID";
                cboTenbang.DisplayMemberPath = "Name";
                cboTenbang.SelectedIndex = 0;

                List<int> lstTotalRow = new List<int>() { 10, 20, 50, 100, 200 };
                cboTotalRow.ItemsSource = lstTotalRow;
                cboTotalRow.SelectedIndex = 0;
                CommonData.RowTotalDock = int.Parse(cboTotalRow.SelectedValue.ToString());
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        void grid_selectedRow()
        {
            try
            {
                TraceDetail _TraceDetail = new TraceDetail();
                int row = gridtrace.SelectedIndex;
                TraceInfo _cInfo = (TraceInfo)gridtrace.SelectedItem;
                _TraceDetail.trace_value = _cInfo.Trace_Value;
                _TraceDetail.Owner = Window.GetWindow(this);
                _TraceDetail.ShowDialog();
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        void SearchTT()
        {
            try
            {
                if (checkValid())
                {
                    arResult = new ArrayList();
                    //
                    string _tablename = "", _username = "";
                    TableInfo _TableInfo = (TableInfo)cboTenbang.SelectedItem;
                    User_Info _UsersInfo = (User_Info)cboNguoidung.SelectedItem;

                    //
                    string _dtFrom = "", _dtTo = "";
                    _dtFrom = dtTungay.Text.Trim();
                    _dtTo = dtDenngay.Text.Trim();//Gtri nay luon phai nhap.
                    
                    if (_TableInfo != null)
                        _tablename = _TableInfo.Name;
                    if (_UsersInfo != null)
                        _username = _UsersInfo.User_Name;

                    //Tim kiem Bang theo cac dk
                    arResult = _TraceControler.Trace_Search(_tablename, _username, _dtFrom, _dtTo);
                    //Phan trang arResult cho no dep!
                    bool check_Thread = true;
                    index_page_SearchEx = 0;
                    CommonFunction.Paging_Next_ListData(arResult, gridtrace, ref check_Thread, ref index_page_SearchEx, ref txtPageOut, ref Number_Msg_SearchEx);
                    TotalPage = arResult.Count % CommonData.RowTotalDock == 0 ? arResult.Count / CommonData.RowTotalDock : arResult.Count / CommonData.RowTotalDock + 1;
                    lblTotalPage.Content = "Tổng số trang: " + TotalPage;
                    if (arResult != null)
                        gridtrace.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        bool checkValid()
        {
            try
            {
                string p_dtFrom = dtTungay.Text.Trim();
                string p_dtTo = dtDenngay.Text.Trim();

                if (p_dtFrom.Equals(""))
                {
                    NoteBox.Show("Giá trị từ ngày không được để trống!", "", NoteBoxLevel.Error);
                    dtTungay.Focus();
                    return false;
                }
                else if (p_dtTo.Equals(""))
                {
                    NoteBox.Show("Giá trị đến ngày không được để trống!", "", NoteBoxLevel.Error);
                    dtDenngay.Focus();
                    return false;
                }
                else if (!p_dtFrom.Equals("") && !CheckValidate.CheckValidDate(p_dtFrom))
                {
                    NoteBox.Show("Giá trị ngày tháng không đúng định dạng dd/MM/yyyy", "", NoteBoxLevel.Error);
                    dtTungay.Focus();
                    return false;

                }
                else if (!p_dtTo.Equals("") && !CheckValidate.CheckValidDate(p_dtTo))
                {
                    NoteBox.Show("Giá trị ngày tháng không đúng định dạng dd/MM/yyyy", "", NoteBoxLevel.Error);
                    dtDenngay.Focus();
                    return false;
                }
                else if (Common.ConvertData.ConvertString2Date(p_dtTo) < Common.ConvertData.ConvertString2Date(p_dtFrom))
                {
                    NoteBox.Show("Giá trị từ ngày phải nhỏ hơn đến ngày", "", NoteBoxLevel.Error);
                    dtTungay.Focus();
                    return false;
                }
                else
                    return true;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        #endregion

    }

    public class TableInfo
    {
        private string _name;
        private decimal _id;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public decimal ID
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}
