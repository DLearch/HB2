﻿#pragma checksum "..\..\..\DialogWindows\UsersWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "00FECD7F93E56B173DBF1233117F21E5CE9CC62B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using WpfApplication1.DialogWindows;


namespace WpfApplication1.DialogWindows {
    
    
    /// <summary>
    /// UsersWindow
    /// </summary>
    public partial class UsersWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\DialogWindows\UsersWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListBoxUsers;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\DialogWindows\UsersWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxAddName;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\DialogWindows\UsersWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxAddEmail;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\DialogWindows\UsersWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxAddPassword;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\DialogWindows\UsersWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxEditName;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\DialogWindows\UsersWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxEditEmail;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\DialogWindows\UsersWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxEditPassword;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\DialogWindows\UsersWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonRemoveUser;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApplication1;component/dialogwindows/userswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\DialogWindows\UsersWindow.xaml"
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
            this.ListBoxUsers = ((System.Windows.Controls.ListBox)(target));
            
            #line 22 "..\..\..\DialogWindows\UsersWindow.xaml"
            this.ListBoxUsers.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListBoxUsers_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TextBoxAddName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.TextBoxAddEmail = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.TextBoxAddPassword = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            
            #line 48 "..\..\..\DialogWindows\UsersWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonAddUser_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.TextBoxEditName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.TextBoxEditEmail = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.TextBoxEditPassword = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            
            #line 75 "..\..\..\DialogWindows\UsersWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonEditUser_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.ButtonRemoveUser = ((System.Windows.Controls.Button)(target));
            
            #line 78 "..\..\..\DialogWindows\UsersWindow.xaml"
            this.ButtonRemoveUser.Click += new System.Windows.RoutedEventHandler(this.ButtonRemoveUser_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
