﻿#pragma checksum "..\..\..\Building\Create_Building.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "57BA8A0D5C9ACEB23A727E6FFE9E3E74"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
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


namespace StartsInternational.Building {
    
    
    /// <summary>
    /// Create_Building
    /// </summary>
    public partial class Create_Building : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 5 "..\..\..\Building\Create_Building.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal StartsInternational.Building.Create_Building frmCreate_Building;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Building\Create_Building.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_Building_Code;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Building\Create_Building.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtAddress;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Building\Create_Building.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNote;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Building\Create_Building.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grdButton;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Building\Create_Building.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnChapNhan;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Building\Create_Building.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnHuy;
        
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
            System.Uri resourceLocater = new System.Uri("/StartsInternational;component/building/create_building.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Building\Create_Building.xaml"
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
            this.frmCreate_Building = ((StartsInternational.Building.Create_Building)(target));
            
            #line 5 "..\..\..\Building\Create_Building.xaml"
            this.frmCreate_Building.Loaded += new System.Windows.RoutedEventHandler(this.frmCreate_Building_Loaded);
            
            #line default
            #line hidden
            
            #line 5 "..\..\..\Building\Create_Building.xaml"
            this.frmCreate_Building.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.frmCreate_Building_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txt_Building_Code = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtAddress = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtNote = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.grdButton = ((System.Windows.Controls.Grid)(target));
            return;
            case 6:
            this.btnChapNhan = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\Building\Create_Building.xaml"
            this.btnChapNhan.Click += new System.Windows.RoutedEventHandler(this.btnChapNhan_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnHuy = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\Building\Create_Building.xaml"
            this.btnHuy.Click += new System.Windows.RoutedEventHandler(this.btnHuy_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

