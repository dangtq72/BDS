﻿#pragma checksum "..\..\..\Customer\Customer_Display.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "EDDE36FA44B9AE416B207D2E74480966"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AvalonDock;
using Microsoft.Windows.Controls;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace StartsInternational.Display {
    
    
    /// <summary>
    /// Customer_Display
    /// </summary>
    public partial class Customer_Display : AvalonDock.DockableContent, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 5 "..\..\..\Customer\Customer_Display.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal StartsInternational.Display.Customer_Display frmCustomer_Display;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Customer\Customer_Display.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtRenterName;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Customer\Customer_Display.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPhone;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Customer\Customer_Display.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSearch;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Customer\Customer_Display.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnExport;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Customer\Customer_Display.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgrRenter;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\Customer\Customer_Display.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnInsert;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\Customer\Customer_Display.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnUpdate;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\Customer\Customer_Display.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDelete;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\Customer\Customer_Display.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnView;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/StartsInternational;component/customer/customer_display.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Customer\Customer_Display.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.frmCustomer_Display = ((StartsInternational.Display.Customer_Display)(target));
            
            #line 6 "..\..\..\Customer\Customer_Display.xaml"
            this.frmCustomer_Display.Loaded += new System.Windows.RoutedEventHandler(this.frmCustomer_Display_Loaded);
            
            #line default
            #line hidden
            
            #line 7 "..\..\..\Customer\Customer_Display.xaml"
            this.frmCustomer_Display.KeyDown += new System.Windows.Input.KeyEventHandler(this.frmCustomer_Display_KeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 12 "..\..\..\Customer\Customer_Display.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.btnInsert_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 13 "..\..\..\Customer\Customer_Display.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.btnUpdate_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 14 "..\..\..\Customer\Customer_Display.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.btnDelete_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 15 "..\..\..\Customer\Customer_Display.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.btnView_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.txtRenterName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txtPhone = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.btnSearch = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\Customer\Customer_Display.xaml"
            this.btnSearch.Click += new System.Windows.RoutedEventHandler(this.btnSearch_Click_1);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnExport = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\Customer\Customer_Display.xaml"
            this.btnExport.Click += new System.Windows.RoutedEventHandler(this.btnExport_Click_1);
            
            #line default
            #line hidden
            return;
            case 10:
            this.dgrRenter = ((System.Windows.Controls.DataGrid)(target));
            
            #line 41 "..\..\..\Customer\Customer_Display.xaml"
            this.dgrRenter.LoadingRow += new System.EventHandler<System.Windows.Controls.DataGridRowEventArgs>(this.dgrRenter_LoadingRow_1);
            
            #line default
            #line hidden
            
            #line 41 "..\..\..\Customer\Customer_Display.xaml"
            this.dgrRenter.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.dgrRenter_PreviewKeyDown_1);
            
            #line default
            #line hidden
            return;
            case 12:
            this.btnInsert = ((System.Windows.Controls.Button)(target));
            
            #line 66 "..\..\..\Customer\Customer_Display.xaml"
            this.btnInsert.Click += new System.Windows.RoutedEventHandler(this.btnInsert_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.btnUpdate = ((System.Windows.Controls.Button)(target));
            
            #line 67 "..\..\..\Customer\Customer_Display.xaml"
            this.btnUpdate.Click += new System.Windows.RoutedEventHandler(this.btnUpdate_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.btnDelete = ((System.Windows.Controls.Button)(target));
            
            #line 68 "..\..\..\Customer\Customer_Display.xaml"
            this.btnDelete.Click += new System.Windows.RoutedEventHandler(this.btnDelete_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            this.btnView = ((System.Windows.Controls.Button)(target));
            
            #line 69 "..\..\..\Customer\Customer_Display.xaml"
            this.btnView.Click += new System.Windows.RoutedEventHandler(this.btnView_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            System.Windows.EventSetter eventSetter;
            switch (connectionId)
            {
            case 11:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.Controls.Control.PreviewMouseDoubleClickEvent;
            
            #line 45 "..\..\..\Customer\Customer_Display.xaml"
            eventSetter.Handler = new System.Windows.Input.MouseButtonEventHandler(this.DoubleClick);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            }
        }
    }
}
