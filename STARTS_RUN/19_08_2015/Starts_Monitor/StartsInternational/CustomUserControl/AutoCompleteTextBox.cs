using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace StartsInternational.CustomUserControl
{
    /// <summary>
    /// Achieve AutoComplete TextBox or ComboBox
    /// </summary>
    public class AutoCompleteTextBox : ComboBox
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoCompleteTextBox"/> class.
        /// </summary>
        public AutoCompleteTextBox()
        {
            //load and apply style to the ComboBox.
            ResourceDictionary rd = new ResourceDictionary();
            rd.Source = new Uri("/" + this.GetType().Assembly.GetName().Name + ";component/CustomUserControl/AutoCompleteComboBoxStyle.xaml",UriKind.Relative);
            this.Resources = rd;
            //disable default Text Search Function
            this.IsTextSearchEnabled = false;

        }

        /// <summary>
        /// Override OnApplyTemplate method 
        /// Get TextBox control out of Combobox control, and hook up TextChanged event.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            //get the textbox control in the ComboBox control
            TextBox textBox = this.Template.FindName("PART_EditableTextBox", this) as TextBox;
            if (textBox != null)
            {
                //disable Autoword selection of the TextBox
                textBox.AutoWordSelection = false;
                //handle TextChanged event to dynamically add Combobox items.
                textBox.TextChanged += new TextChangedEventHandler(textBox_TextChanged);
                //textBox.KeyDown += new KeyEventHandler(TextBox_KeyDown);
                //MinhND them vao
                textBox.PreviewKeyDown+= new KeyEventHandler(TextBox_KeyDown);
            }
        }

        //The autosuggestionlist source.
        private ObservableCollection<string> autoSuggestionList = new ObservableCollection<string>();

        //The Data source.
        private DataTable dsList = new DataTable();

        /// <summary>
        /// Gets or sets the auto suggestion list.
        /// </summary>
        /// <value>The auto suggestion list.</value>
        public ObservableCollection<string> AutoSuggestionList
        {
            get { return autoSuggestionList; }
            set { autoSuggestionList = value; }
        }

        public DataTable TableList
        {
            get { return dsList; }
            set { dsList = value; }
        }


        /// <summary>
        /// main logic to generate auto suggestion list.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Controls.TextChangedEventArgs"/> 
        /// instance containing the event data.</param>
        private string strTemp = "";
        private int intSelectTemp = 0;
        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                TextBox textBox = sender as TextBox;
                textBox.AutoWordSelection = false;
                // if the word in the textbox is selected, then don't change item collection
                if ((textBox.SelectionStart != 0 || textBox.Text.Length == 0))
                {

                    int i = 0;
                    //add new filtered items according the current TextBox input
                    if (!string.IsNullOrEmpty(textBox.Text) && TableList.Rows.Count > 0)
                    {
                        strTemp = textBox.Text;
                        intSelectTemp = textBox.SelectionStart;
                        this.Items.Clear();
                        textBox.Text = strTemp;
                        textBox.SelectionStart = intSelectTemp;
                        DataRow[] results = TableList.Select("Column1 like '%" + textBox.Text + "%'");

                        foreach (DataRow a in results)
                        {
                            string s = a[0].ToString();
                            int intLengText = textBox.Text.Length;
                            if (s.IndexOf(textBox.Text, StringComparison.InvariantCultureIgnoreCase) >= 0)
                            //if (s.StartsWith(textBox.Text, StringComparison.InvariantCultureIgnoreCase))
                            {

                                string Start = s.Substring(0, s.IndexOf(textBox.Text, StringComparison.InvariantCultureIgnoreCase));
                                string boldpart = s.Substring(Start.Length, intLengText);
                                string End = "";
                                if (Start.Length + intLengText > s.Length)
                                    End = "";
                                else
                                    End = s.Substring(Start.Length + intLengText);

                                AutoCompleteEntry entry = new AutoCompleteEntry(Start, boldpart, End);
                                this.Items.Add(entry);
                                i++;
                            }
                            if (i > 20)
                            {
                                break;
                            }
                        }
                    }
                }
                // open or close dropdown of the ComboBox according to whether there are items in the 
                // fitlered result.
                this.IsDropDownOpen = this.HasItems;

                //avoid auto selection
                textBox.Focus();
                //textBox.SelectionStart = intSelectTemp-1;
                if (intSelectTemp > 0)
                    textBox.CaretIndex = intSelectTemp;
                //textBox.SelectionStart = textBox.Text.Length;
            }
            catch 
            {
                
              
            }           
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.Key == Key.Tab)
            {
                if (this.Items.Count > 0 && this.SelectedIndex < 0)
                {
                    this.SelectedIndex = 0;
                    this.IsDropDownOpen = false;
                    this.Focus();
                }
            }
            if (e.Key == Key.Back)
            {
                //this.Text = string.Empty;
                this.IsDropDownOpen = false;
            }
        }
    }

    /// <summary>
    /// Extended ComboBox Item
    /// </summary>
    public class AutoCompleteEntry : ComboBoxItem
    {
        private TextBlock tbEntry;

        //text of the item
        private string text;

        /// <summary>
        /// Contrutor of AutoCompleteEntry class
        /// </summary>
        /// <param name="text">All the Text of the item </param>
        /// <param name="bold">The already entered part of the Text</param>
        /// <param name="unbold">The remained part of the Text</param>
        public AutoCompleteEntry(string Start, string bold, string End)
        {
            //this.text = text;
            tbEntry = new TextBlock();
            //highlight the current input Text
            tbEntry.Inlines.Add(new Run { Text = Start });
            tbEntry.Inlines.Add(new Run
            {
                Text = bold,
                FontWeight = FontWeights.Bold,
                Foreground = new SolidColorBrush(Colors.RoyalBlue)
            });
            tbEntry.Inlines.Add(new Run { Text = End });
            this.Content = tbEntry;
        }

        /// <summary>
        /// Gets the text.
        /// </summary>
        public string Text
        {
            get { return this.text; }
        }
    }
}
