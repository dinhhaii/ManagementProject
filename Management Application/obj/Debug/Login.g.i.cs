﻿#pragma checksum "..\..\Login.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B882BA71211CB8F646FD07AAF9B3252AAC785781"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Dragablz;
using Management_Application;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace Management_Application {
    
    
    /// <summary>
    /// Login
    /// </summary>
    public partial class Login : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Management_Application.Login login;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtbox;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox passwordBox;
        
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
            System.Uri resourceLocater = new System.Uri("/Management Application;component/login.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Login.xaml"
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
            this.login = ((Management_Application.Login)(target));
            return;
            case 2:
            this.txtbox = ((System.Windows.Controls.TextBox)(target));
            
            #line 40 "..\..\Login.xaml"
            this.txtbox.GotMouseCapture += new System.Windows.Input.MouseEventHandler(this.txtbox_GotMouseCapture);
            
            #line default
            #line hidden
            
            #line 41 "..\..\Login.xaml"
            this.txtbox.GotKeyboardFocus += new System.Windows.Input.KeyboardFocusChangedEventHandler(this.txtbox_GotKeyboardFocus);
            
            #line default
            #line hidden
            
            #line 42 "..\..\Login.xaml"
            this.txtbox.KeyDown += new System.Windows.Input.KeyEventHandler(this.txtbox_KeyDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.passwordBox = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 62 "..\..\Login.xaml"
            this.passwordBox.GotKeyboardFocus += new System.Windows.Input.KeyboardFocusChangedEventHandler(this.passwordBox_GotKeyboardFocus);
            
            #line default
            #line hidden
            
            #line 63 "..\..\Login.xaml"
            this.passwordBox.GotMouseCapture += new System.Windows.Input.MouseEventHandler(this.passwordBox_GotMouseCapture);
            
            #line default
            #line hidden
            
            #line 64 "..\..\Login.xaml"
            this.passwordBox.KeyDown += new System.Windows.Input.KeyEventHandler(this.passwordBox_KeyDown);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 74 "..\..\Login.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

