using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace StartsInternational
{
    /// <summary>
    /// Interaction logic for TraceDetail.xaml
    /// </summary>
    public partial class TraceDetail : Window
    {
        #region Contructor & para

        public TraceDetail()
        {
            InitializeComponent();
        }

        public string trace_value;

        public class trace_change
        {
            private string _fieldname;
            private string _change;
            public string FieldName
            {
                get { return _fieldname; }
                set { _fieldname = value; }
            }
            public string Change
            {
                get { return _change; }
                set { _change = value; }
            }
        } 

        #endregion

        #region Event

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                List<trace_change> list_change = new List<trace_change>();
                trace_change _trace_change;

                char[] strtrace_value = new char[trace_value.Length];
                char[] change;
                strtrace_value = trace_value.ToCharArray();
                int startindex = 0;
                for (int i = 0; i < trace_value.Length; i++)
                {
                    if (strtrace_value[i].ToString() == ConstParam.Field.ToString())
                    {
                        string strchange = trace_value.Substring(startindex, i - startindex);
                        startindex = i + 1;
                        change = new char[strchange.Length];
                        change = strchange.ToCharArray();
                        for (int j = 0; j < strchange.Length; j++)
                        {
                            if (change[j].ToString() == ConstParam.FieldValue.ToString())
                            {
                                _trace_change = new trace_change();
                                _trace_change.FieldName = (strchange.Substring(0, j)).ToString();
                                _trace_change.Change = (strchange.Substring(j + 1, strchange.Length - j - 1)).ToString();
                                list_change.Add(_trace_change);
                            }
                        }
                    }
                }

                string str = trace_value.Substring(startindex, trace_value.Length - startindex);
                change = new char[str.Length];
                change = str.ToCharArray();
                for (int j = 0; j < str.Length; j++)
                {
                    if (change[j].ToString() == ConstParam.FieldValue.ToString())
                    {
                        _trace_change = new trace_change();
                        _trace_change.FieldName = (str.Substring(0, j)).ToString();
                        _trace_change.Change = (str.Substring(j + 1, str.Length - j - 1)).ToString();
                        list_change.Add(_trace_change);
                    }
                }
                grTraceDetail.ItemsSource = list_change;
            }
            catch  
            {
                //err .log.Error(ex.ToString());
            }
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                MessageBoxResult result = NoteBox.Show("Bạn chắc chắn muốn thoát form không?", "Thông báo", NoteBoxLevel.Question);
                if (MessageBoxResult.Yes == result)
                this.Close();
            }
            if (e.Key == Key.Delete)
            {
                e.Handled = true;
            }
        }

        private void grTraceDetail_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void grTraceDetail_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                e.Handled = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
