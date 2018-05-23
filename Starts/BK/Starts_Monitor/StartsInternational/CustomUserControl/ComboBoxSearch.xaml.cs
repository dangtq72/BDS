using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Collections;
using System.Reflection;
using System.Windows.Data;

namespace StartsInternational.CustomUserControl
{
    /// <summary>
    /// Interaction logic for ComboBoxSearch.xaml
    /// </summary>
    public partial class ComboBoxSearch : UserControl
    {
        private Hashtable c_HashDisplayValue = new Hashtable(); //danh sach mang truyen cho combox theo DisplayMemberPath va SelectedValuePath
        private Hashtable c_hashProperties = new Hashtable(); //danh sach cac thuoc tinh cua object truyen cho combox

        #region public property
        public event RoutedEventHandler NVSSelectionChanged;

        /// <summary>
        /// trả về display member khi người dùng chọn 
        /// </summary>
        public string DisplayMemberPath;
        /// <summary>
        /// trả về values member khi ngươi dùng chọn mã ck 
        /// </summary>
        /// 
        public string SelectedValuePath;

        private object _SelectedValue = null;
        public object SelectedValue
        {
            get { return _SelectedValue; }
            set
            {
                _SelectedText = null;
                _SelectedValue = null;
                object _v = value;
                //
                foreach (DictionaryEntry de in c_HashDisplayValue)
                {
                    if (de.Value.ToString().ToLower() == value.ToString().ToLower())
                    {
                        _SelectedText = de.Key;
                        _SelectedValue = de.Value;
                    }
                }
                if (_SelectedText != null)
                    txtSearch.Text = _SelectedText.ToString();
                else
                    txtSearch.Text = "";
            }
        }

        private object _SelectedText = null;
        public object SelectedText
        {
            get { return _SelectedText; }
            set
            {
                _SelectedText = value;
                _SelectedValue = null;
                //
                foreach (DictionaryEntry de in c_HashDisplayValue)
                {
                    if (de.Key.ToString().ToLower() == _SelectedText.ToString().ToLower())
                        _SelectedValue = de.Value;
                }
                if (_SelectedText != null)
                    txtSearch.Text = _SelectedText.ToString();
                else
                    txtSearch.Text = "";
            }
        }

        public ArrayList ItemsSource;//mảng danh sách truyền cho combobox

        /// <summary>
        /// Thực hiện bind dữ liệu vào combox
        /// </summary>
        /// <returns>Mã lỗi trả về</returns>
        public int BindData()
        {
            try
            {
                GetPropertyofItemSource();

                if (DisplayMemberPath == "") return ErrorCode.NULL_DisplayMemberPath;
                if (SelectedValuePath == "") return ErrorCode.NULL_SelectedValuePath;
                if (!c_hashProperties.ContainsKey(DisplayMemberPath)) return ErrorCode.Error_DisplayMemberPath;
                if (!c_hashProperties.ContainsKey(SelectedValuePath)) return ErrorCode.Error_SelectedValuePath;


                foreach (object o in ItemsSource)
                {
                    object DisplayMemberValue;
                    object SelectedMemberValue;
                    DisplayMemberValue = ((PropertyInfo)c_hashProperties[DisplayMemberPath]).GetValue(o, null);
                    SelectedMemberValue = ((PropertyInfo)c_hashProperties[SelectedValuePath]).GetValue(o, null);
                    c_HashDisplayValue[DisplayMemberValue] = SelectedMemberValue;
                }
                BindtoListView("");

                return ErrorCode.OK;
            }
            catch
            {
                return ErrorCode.NOdefine;
            }
        }

        #region SelectedItem
        public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register("SelectedItem", typeof(object), typeof(ComboBoxSearch), new PropertyMetadata(null));

        public object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set 
            { 
                SetValue(SelectedItemProperty, value);
                lviList.SelectedItem = SelectedItem;
            }
        } 

        #endregion

        #endregion

        bool IsTabPress = false;

        #region Events
        public ComboBoxSearch()
        {
            InitializeComponent();
            Binding selectedItemBinding = new Binding("SelectedItem");
            selectedItemBinding.Source = this;
            selectedItemBinding.Mode = BindingMode.TwoWay;
            lviList.SetBinding(ListView.SelectedItemProperty, selectedItemBinding);

            this.grdSearch.PreviewMouseDown += delegate(object sender, MouseButtonEventArgs e)
            {
                //If the mouse clicks anywhere except sub elements of the container aka Grid, 
                //the e.OriginalSource will always be container, so we know we can close popup now.
                if (Mouse.Captured == grdSearch && e.OriginalSource == grdSearch)
                {
                    myPopup.IsOpen = false;
                }
            };

            this.myPopup.Opened += delegate
            {
                // Mouse capture the container aka Grid and its sub tree so any mouse related events 
                // will be routed within this scope.
                Mouse.Capture(grdSearch, CaptureMode.SubTree);
            };


            this.myPopup.Closed += delegate
            {
                // Since popup has been closed, we should release mouse capture.
                if (Mouse.Captured == grdSearch)
                {
                    Mouse.Capture(grdSearch, CaptureMode.None);
                }
                if (!IsTabPress)
                {
                    txtSearch.Focus();
                }
            };

            this.txtSearch.PreviewMouseUp += delegate
            {
                if (this.myPopup.IsOpen)
                {
                    Mouse.Capture(grdSearch, CaptureMode.SubTree);
                }
                else
                {
                    Mouse.Capture(grdSearch, CaptureMode.None);
                }

            };
        }

        private void btnSelectList_Click(object sender, RoutedEventArgs e)
        {
            myPopup.IsOpen = !myPopup.IsOpen;
            txtSearch.Focus();
        }

        //xu ly khi an phim len xuong de tim item trong listview
        private void uscSearch_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                IsTabPress = false;
                switch (e.Key)
                {
                    case Key.Down:
                        #region thay doi lviList
                        myPopup.IsOpen = true;
                        lviList.Focus();

                        if (lviList.SelectedIndex < lviList.Items.Count) lviList.SelectedIndex += 1;
                        else lviList.SelectedIndex = lviList.Items.Count;

                        lviList.ScrollIntoView(lviList.SelectedItem);
                        #endregion
                        break;
                    case Key.Up:
                        #region thay doi lviList
                        myPopup.IsOpen = true;
                        lviList.Focus();

                        if (lviList.SelectedIndex > 0) lviList.SelectedIndex -= 1;
                        else lviList.SelectedIndex = 0;
                        lviList.ScrollIntoView(lviList.SelectedItem);
                        #endregion
                        break;
                    case Key.Tab:
                        IsTabPress = true;
                        FinishCBOSelect();
                        myPopup.IsOpen = false;
                        break;
                    default:
                        break;
                }
                txtSearch.Focus();
            }
            catch
            {
            }
        }

        //xu ly khi an cac fim con lai de search
        private void txtSearch_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Down || e.Key == Key.Up || e.Key == Key.Tab)
                {
                    //đã dùng trong uscSearch_PreviewKeyDown
                }
                else if (e.Key == Key.Escape)
                {
                    myPopup.IsOpen = false;
                }
                else if (e.Key == Key.Enter)
                {
                    FinishCBOSelect();
                    myPopup.IsOpen = false;
                }

                else
                {
                    string _str = txtSearch.Text;

                    if (txtSearch.IsReadOnly == false)
                    {
                        myPopup.IsOpen = true;
                        BindtoListView(_str);
                    }
                    else
                    {
                        myPopup.IsOpen = false;
                    }
                }
            }
            catch
            {
            }
        }

        public event SelectionChangedEventHandler SelectionChanged;
        private void lviList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                SelectionChangedEventHandler cboChanged = SelectionChanged;
                //xu ly khi click chuot.không dùng thuộc tính click vì nó lẫn với this.grdSearch.PreviewMouseDown 
                if (lviList.IsFocused == false)
                {
                    FinishCBOSelect();
                    myPopup.IsOpen = false;
                }
                if (cboChanged != null)
                {
                    cboChanged(this, e);
                }
            }
            catch
            {
            }
        }
        #endregion

        #region Hàm phụ trợ
        //lay danh sach cac thuoc tinh cua doi tuong tuyen vao cho cbo
        private void GetPropertyofItemSource()
        {
            try
            {
                if (ItemsSource.Count > 0)
                {
                    Type objType = ItemsSource[0].GetType();

                    foreach (PropertyInfo objProperty in objType.GetProperties())
                    {
                        c_hashProperties[objProperty.Name] = objProperty;
                    }
                }
            }
            catch
            {
            }
        }

        //find du lieu phu hop voi key xuong listview
        private void BindtoListView(string p_key)
        {
            try
            {
                int k = c_HashDisplayValue.Count;
                string[] sortKey = new string[k];
                int i = 0;
                foreach (DictionaryEntry de in c_HashDisplayValue)
                {
                    sortKey[i] = de.Key.ToString();
                    i++;
                }
                Array.Sort(sortKey);
                lviList.Items.Clear();
                for (int j = 0; j < k; j++)
                {
                    //nếu p_key !="" và p_key khác  Common.CommonData.strAll, dùng khi tìm kiếm trên txtSearch
                    // if (p_key != "" && p_key != Common.CommonData.strAll)
                    if (p_key != "")
                    {
                        foreach (DictionaryEntry de in c_HashDisplayValue)
                        {
                            if ((de.Key.ToString() == sortKey[j]))
                            {
                                if (de.Key.ToString().ToLower().Contains(p_key.ToLower()))
                                    lviList.Items.Add(de.Key);
                            }
                        }
                    }
                    //load dữ liệu lên list view
                    else
                    {
                        foreach (DictionaryEntry de in c_HashDisplayValue)
                        {
                            if ((de.Key.ToString() == sortKey[j]))
                            {
                                lviList.Items.Add(de.Key);
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }

        //hàm này sử lý khi đã chọn được item cho combobox - co thể là mất focus, ấn enter, tag
        private void FinishCBOSelect()
        {
            try
            {
                if (lviList.SelectedIndex >= 0)
                {
                    txtSearch.Text = lviList.SelectedValue.ToString();
                    txtSearch.SelectionStart = txtSearch.Text.Length;
                    //
                    SelectedText = txtSearch.Text;
                    //raise event selected change
                    if (NVSSelectionChanged != null)
                        NVSSelectionChanged(this, new RoutedEventArgs());
                }
            }
            catch
            {
            }
        }
        #endregion

        #region Sự kiện tự tạo
        //public event SelectionChangedEventHandler SelectionChanged;
        //private void cbo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    SelectionChangedEventHandler cboChanged = SelectionChanged;
        //    if (cboChanged != null)
        //    {
        //        cboChanged(this, e);
        //    }
        //}

        //public event EventHandler<SelectionChangedEventArgs> ComboBoxSearch;

        //private void Selector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (ListSelectionChanged != null)
        //    {
        //        ListSelectionChanged(sender, e);
        //    }
        //}

        //public override void OnApplyTemplate()
        //{
        //    base.OnApplyTemplate();
        //    //find or declare your control here, the x:name in xaml should be YourControl
        //    ComboBoxSearch == this.Template.FindName("ComboBoxSearch", this) as ComboBox;
        //    ComboBoxSearch.SelectionChanged += ResultListBox_SelectionChanged;
        //}
        #endregion
    }

    public class ErrorCode
    {
        public const int OK = 0;
        public const int NOdefine = -1;
        public const int NULL_DisplayMemberPath = 1; //giá trị DisplayMemberPath bị null
        public const int NULL_SelectedValuePath = 2;//giá trị SelectedValuePath bị null
        public const int Error_DisplayMemberPath = 11; //giá trị DisplayMemberPath  không có trong thuộc tính
        public const int Error_SelectedValuePath = 21; //giá trị DisplayMemberPath  không có trong thuộc tính

    }
}
