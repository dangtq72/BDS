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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace StartsInternational.CustomUserControl
{
    /// <summary>
    /// Interaction logic for CustomPasswordBox.xaml
    /// </summary>
    public partial class CustomPasswordBox : UserControl
    {
        public CustomPasswordBox()
        {
            InitializeComponent();
            FocusManager.SetFocusedElement(this, UctlPassword); 
            FocusManager.SetFocusedElement(UctlPassword, passwordbox); 

            //this.IsVisibleChanged += new DependencyPropertyChangedEventHandler(LoginControl_IsVisibleChanged); 
        }

        //private void LoginControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        //{
        //    if ((bool)e.NewValue == true)
        //    {
        //        Dispatcher.BeginInvoke(
        //        DispatcherPriority.ContextIdle,
        //        new Action(delegate()
        //        {
        //            passwordbox.Focus();
        //        }));
        //    }
        //}  

        #region Constructure and Param
        //BrushConverter bc = new BrushConverter();
        #endregion

        #region Text

        public static DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(CustomPasswordBox), new UIPropertyMetadata());

        public string Text
        {
            get { return (string)passwordbox.Password; }
            set
            {
                passwordbox.Password = value;

                if (passwordbox.Password.Length == 0)
                {
                    Grid.SetZIndex(textbox, 100);
                    Grid.SetZIndex(passwordbox, 98);
                    btnEYE.Visibility = Visibility.Hidden;
                }
                else
                {
                    Grid.SetZIndex(textbox, 98);
                    Grid.SetZIndex(passwordbox, 100);
                }
            }
            //get { return (string)GetValue(TextProperty); }
            //set { SetValue(TextProperty, value); }
        }
        #endregion

        #region MaxLength
        public static DependencyProperty MaxLengthProperty = DependencyProperty.Register("MaxLength", typeof(int), typeof(CustomPasswordBox), new UIPropertyMetadata());

        public int MaxLength
        {
            get { return (int)GetValue(MaxLengthProperty); }
            set { SetValue(MaxLengthProperty, value); }
        }
        #endregion

        #region Tag
        public static readonly DependencyProperty TagProperty = DependencyProperty.Register("Tag", typeof(object), typeof(CustomPasswordBox), new UIPropertyMetadata());

        public object Tag
        {
            get { return (object)GetValue(TagProperty); }
            set { SetValue(TagProperty, value); }
        }
        #endregion

        #region Events
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            CustomSetZIndex();
        }

        private void Button_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            //show pass
            Grid.SetZIndex(textbox, 100);
            Grid.SetZIndex(passwordbox, 98);
            textbox.Text = passwordbox.Password;
        }

        private void Button_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            //hide pass
            Grid.SetZIndex(passwordbox, 100);
            Grid.SetZIndex(textbox, 98);
            textbox.Text = "";
            passwordbox.Focus();
        }

        #region PasswordChanged
        public event RoutedEventHandler PasswordChanged;

        #endregion

        private void CustomSetZIndex()
        {

            try
            {
                if (passwordbox.Password == "")
                {
                    btnEYE.Visibility = Visibility.Hidden;
                    Grid.SetZIndex(textbox, 98);
                    Grid.SetZIndex(passwordbox, 100);
                    //
                    //textbox.Focusable = true;
                    //textbox.Focus();
                }
                else
                {
                    textbox.Focusable = false;
                    btnEYE.Visibility = Visibility.Visible;
                    Grid.SetZIndex(textbox, 98);
                    Grid.SetZIndex(passwordbox, 100);
                }
            }
            catch
            {
            }
        }

        private void UctlPassword_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Tab)
                passwordbox.Focus();
        }

        private void UctlPassword_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            CustomSetZIndex();
        }

        private void UctlPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            this.passwordbox.Focus();
        }
        #endregion
    }
}
