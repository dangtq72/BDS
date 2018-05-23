using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace StartsInternational.Themes
{
    public partial class MainWindowETF
    {
        private void ButtonOnClick(object sender, RoutedEventArgs args)
        {
            Window w = Window.GetWindow((System.Windows.DependencyObject)sender);
            w.Close();
        }

        private void Title_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window w = Window.GetWindow((System.Windows.DependencyObject)sender);
            w.DragMove();
            if (w.WindowState == WindowState.Maximized)
            {
                w.WindowState = WindowState.Normal;
                w.Height = SystemParameters.MaximizedPrimaryScreenHeight - 13;
                w.Width = SystemParameters.MaximizedPrimaryScreenWidth;
                w.Top = 0;
                w.Left = 0;
            }
        }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            Window w = Window.GetWindow((System.Windows.DependencyObject)sender);
            w.DialogResult = true;
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            Window w = Window.GetWindow((System.Windows.DependencyObject)sender);
            w.DialogResult = false;
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            Window w = Window.GetWindow((System.Windows.DependencyObject)sender);
            w.WindowState = WindowState.Minimized;
        }

        private void Maximize_Click(object sender, RoutedEventArgs e)
        {
            Window w = Window.GetWindow((System.Windows.DependencyObject)sender);
            if (w.ActualHeight == (SystemParameters.MaximizedPrimaryScreenHeight - 13) || w.ActualWidth == SystemParameters.PrimaryScreenWidth)
            {
                w.Width = 1024;
                w.Height = 768;
            }
            else
            {
                w.Height = SystemParameters.MaximizedPrimaryScreenHeight - 13;
                w.Width = SystemParameters.MaximizedPrimaryScreenWidth;
                w.Top = 0;
                w.Left = 0;
            }
        }

        private void DoubleClick(object sender, MouseButtonEventArgs e)
        {
            Window w = Window.GetWindow((System.Windows.DependencyObject)sender);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (w.ActualHeight == (SystemParameters.MaximizedPrimaryScreenHeight - 13) || w.ActualWidth == SystemParameters.PrimaryScreenWidth)
                {
                    w.Width = 1024;
                    w.Height = 768;
                }
                else
                {
                    w.Height = SystemParameters.MaximizedPrimaryScreenHeight - 13;
                    w.Width = SystemParameters.MaximizedPrimaryScreenWidth;
                    w.Top = 0;
                    w.Left = 0;
                }
                //e.Handled = true;
            }
        }
    }
}
