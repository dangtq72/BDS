﻿#pragma checksum "..\..\..\..\Control\Update\Group_User_Update.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "13A26C8DE4BCE6DB4B59358F8F90EFAB"
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


namespace StartsInternational.Update {
    
    
    /// <summary>
    /// Group_User_Update
    /// </summary>
    public partial class Group_User_Update : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 4 "..\..\..\..\Control\Update\Group_User_Update.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal StartsInternational.Update.Group_User_Update frmGroupUserUpdate;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\..\Control\Update\Group_User_Update.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GroupBox grbStatus;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\Control\Update\Group_User_Update.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtName;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Control\Update\Group_User_Update.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNotes;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\Control\Update\Group_User_Update.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancel;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\Control\Update\Group_User_Update.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAccept;
        
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
            System.Uri resourceLocater = new System.Uri("/StartsInternational;component/control/update/group_user_update.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Control\Update\Group_User_Update.xaml"
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
            this.frmGroupUserUpdate = ((StartsInternational.Update.Group_User_Update)(target));
            
            #line 5 "..\..\..\..\Control\Update\Group_User_Update.xaml"
            this.frmGroupUserUpdate.Loaded += new System.Windows.RoutedEventHandler(this.frmGroupUserUpdate_Loaded);
            
            #line default
            #line hidden
            
            #line 5 "..\..\..\..\Control\Update\Group_User_Update.xaml"
            this.frmGroupUserUpdate.KeyDown += new System.Windows.Input.KeyEventHandler(this.frmGroupUserUpdate_KeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.grbStatus = ((System.Windows.Controls.GroupBox)(target));
            return;
            case 3:
            this.txtName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtNotes = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.btnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\..\Control\Update\Group_User_Update.xaml"
            this.btnCancel.Click += new System.Windows.RoutedEventHandler(this.btnCancel_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnAccept = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\..\Control\Update\Group_User_Update.xaml"
            this.btnAccept.Click += new System.Windows.RoutedEventHandler(this.btnAccept_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

