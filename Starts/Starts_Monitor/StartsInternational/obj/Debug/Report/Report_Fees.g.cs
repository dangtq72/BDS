﻿#pragma checksum "..\..\..\Report\Report_Fees.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D0C222EA794EE772A0D6838C58DE7A05"
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


namespace StartsInternational.Report {
    
    
    /// <summary>
    /// Report_Fees
    /// </summary>
    public partial class Report_Fees : AvalonDock.DockableContent, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 6 "..\..\..\Report\Report_Fees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal StartsInternational.Report.Report_Fees frmReport_Fees;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Report\Report_Fees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpFromDate;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Report\Report_Fees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpToDate;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Report\Report_Fees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCustomer;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Report\Report_Fees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cboCreatedBy;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Report\Report_Fees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cboEsateCode;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Report\Report_Fees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtUser;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\Report\Report_Fees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSearch;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\Report\Report_Fees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnExport;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\Report\Report_Fees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgrContract;
        
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
            System.Uri resourceLocater = new System.Uri("/StartsInternational;component/report/report_fees.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Report\Report_Fees.xaml"
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
            this.frmReport_Fees = ((StartsInternational.Report.Report_Fees)(target));
            
            #line 7 "..\..\..\Report\Report_Fees.xaml"
            this.frmReport_Fees.Loaded += new System.Windows.RoutedEventHandler(this.frmReport_Fees_Loaded);
            
            #line default
            #line hidden
            
            #line 7 "..\..\..\Report\Report_Fees.xaml"
            this.frmReport_Fees.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.frmReport_Fees_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 11 "..\..\..\Report\Report_Fees.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.btnView_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 12 "..\..\..\Report\Report_Fees.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.btnExport_Click_1);
            
            #line default
            #line hidden
            return;
            case 4:
            this.dpFromDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.dpToDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            this.txtCustomer = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.cboCreatedBy = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.cboEsateCode = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.txtUser = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.btnSearch = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\..\Report\Report_Fees.xaml"
            this.btnSearch.Click += new System.Windows.RoutedEventHandler(this.btnSearch_Click_1);
            
            #line default
            #line hidden
            return;
            case 11:
            this.btnExport = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\Report\Report_Fees.xaml"
            this.btnExport.Click += new System.Windows.RoutedEventHandler(this.btnExport_Click_1);
            
            #line default
            #line hidden
            return;
            case 12:
            this.dgrContract = ((System.Windows.Controls.DataGrid)(target));
            
            #line 50 "..\..\..\Report\Report_Fees.xaml"
            this.dgrContract.LoadingRow += new System.EventHandler<System.Windows.Controls.DataGridRowEventArgs>(this.dgrContract_LoadingRow);
            
            #line default
            #line hidden
            
            #line 50 "..\..\..\Report\Report_Fees.xaml"
            this.dgrContract.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.dgrContract_PreviewKeyDown);
            
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
            case 13:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.Controls.Control.PreviewMouseDoubleClickEvent;
            
            #line 54 "..\..\..\Report\Report_Fees.xaml"
            eventSetter.Handler = new System.Windows.Input.MouseButtonEventHandler(this.DoubleClick);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            }
        }
    }
}

