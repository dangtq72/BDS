﻿#pragma checksum "..\..\..\Display\Tenant_Display.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "79903F3A76282CE010461CE1D2505C9E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
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
    /// Tenant_Display
    /// </summary>
    public partial class Tenant_Display : AvalonDock.DockableContent, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 5 "..\..\..\Display\Tenant_Display.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal StartsInternational.Display.Tenant_Display frmTenant_Display;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Display\Tenant_Display.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtRenterName;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Display\Tenant_Display.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSearch;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Display\Tenant_Display.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnExport;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Display\Tenant_Display.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgrRenter;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\Display\Tenant_Display.xaml"
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
            System.Uri resourceLocater = new System.Uri("/StartsInternational;component/display/tenant_display.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Display\Tenant_Display.xaml"
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
            this.frmTenant_Display = ((StartsInternational.Display.Tenant_Display)(target));
            
            #line 6 "..\..\..\Display\Tenant_Display.xaml"
            this.frmTenant_Display.Loaded += new System.Windows.RoutedEventHandler(this.frmRenter_Display_Loaded_1);
            
            #line default
            #line hidden
            
            #line 7 "..\..\..\Display\Tenant_Display.xaml"
            this.frmTenant_Display.KeyDown += new System.Windows.Input.KeyEventHandler(this.frmRenter_Display_KeyDown_1);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtRenterName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.btnSearch = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\Display\Tenant_Display.xaml"
            this.btnSearch.Click += new System.Windows.RoutedEventHandler(this.btnSearch_Click_1);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnExport = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\Display\Tenant_Display.xaml"
            this.btnExport.Click += new System.Windows.RoutedEventHandler(this.btnExport_Click_1);
            
            #line default
            #line hidden
            return;
            case 5:
            this.dgrRenter = ((System.Windows.Controls.DataGrid)(target));
            
            #line 28 "..\..\..\Display\Tenant_Display.xaml"
            this.dgrRenter.LoadingRow += new System.EventHandler<System.Windows.Controls.DataGridRowEventArgs>(this.dgrRenter_LoadingRow_1);
            
            #line default
            #line hidden
            
            #line 28 "..\..\..\Display\Tenant_Display.xaml"
            this.dgrRenter.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.dgrRenter_PreviewKeyDown_1);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnView = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\..\Display\Tenant_Display.xaml"
            this.btnView.Click += new System.Windows.RoutedEventHandler(this.btnView_Click_1);
            
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
            case 6:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.Controls.Control.PreviewMouseDoubleClickEvent;
            
            #line 32 "..\..\..\Display\Tenant_Display.xaml"
            eventSetter.Handler = new System.Windows.Input.MouseButtonEventHandler(this.DoubleClick);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            }
        }
    }
}

