﻿#pragma checksum "..\..\..\..\Contract\Create\Auto_StatusContract.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "91F2D21C001F25A5B1DB3AC28CCC415E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace StartsInternational.Contract.Create {
    
    
    /// <summary>
    /// Auto_StatusContract
    /// </summary>
    public partial class Auto_StatusContract : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\..\..\Contract\Create\Auto_StatusContract.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal StartsInternational.Contract.Create.Auto_StatusContract frmReceiveVsd;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\Contract\Create\Auto_StatusContract.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock lblMes;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\Contract\Create\Auto_StatusContract.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar prgTTLK;
        
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
            System.Uri resourceLocater = new System.Uri("/StartsInternational;component/contract/create/auto_statuscontract.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Contract\Create\Auto_StatusContract.xaml"
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
            this.frmReceiveVsd = ((StartsInternational.Contract.Create.Auto_StatusContract)(target));
            
            #line 5 "..\..\..\..\Contract\Create\Auto_StatusContract.xaml"
            this.frmReceiveVsd.KeyDown += new System.Windows.Input.KeyEventHandler(this.frmReceiveVsd_KeyDown);
            
            #line default
            #line hidden
            
            #line 7 "..\..\..\..\Contract\Create\Auto_StatusContract.xaml"
            this.frmReceiveVsd.Loaded += new System.Windows.RoutedEventHandler(this.frmReceiveVsd_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lblMes = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.prgTTLK = ((System.Windows.Controls.ProgressBar)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

