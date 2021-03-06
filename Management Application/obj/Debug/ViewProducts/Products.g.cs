﻿#pragma checksum "..\..\..\ViewProducts\Products.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3D4BEFEDCBBC11620D9D162146B948FBCCA52B6D"
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
using Management_Application.ViewProducts;
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


namespace Management_Application.ViewProducts {
    
    
    /// <summary>
    /// Products
    /// </summary>
    public partial class Products : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 8 "..\..\..\ViewProducts\Products.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Management_Application.ViewProducts.Products ProductUserControl;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\ViewProducts\Products.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtboxSearch;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\ViewProducts\Products.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonSearch;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\ViewProducts\Products.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.PackIcon iconSearch;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\ViewProducts\Products.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonFilter;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\ViewProducts\Products.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonCloseFilter;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\ViewProducts\Products.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonReload;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\ViewProducts\Products.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonAdd;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\..\ViewProducts\Products.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonDelete;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\..\ViewProducts\Products.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.PackIcon iconDelete;
        
        #line default
        #line hidden
        
        
        #line 119 "..\..\..\ViewProducts\Products.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button closeDelete;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\..\ViewProducts\Products.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGridProduct;
        
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
            System.Uri resourceLocater = new System.Uri("/Management Application;component/viewproducts/products.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ViewProducts\Products.xaml"
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
            this.ProductUserControl = ((Management_Application.ViewProducts.Products)(target));
            return;
            case 3:
            this.txtboxSearch = ((System.Windows.Controls.TextBox)(target));
            
            #line 37 "..\..\..\ViewProducts\Products.xaml"
            this.txtboxSearch.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtboxSearch_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.buttonSearch = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\ViewProducts\Products.xaml"
            this.buttonSearch.Click += new System.Windows.RoutedEventHandler(this.buttonSearch_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.iconSearch = ((MaterialDesignThemes.Wpf.PackIcon)(target));
            return;
            case 6:
            this.buttonFilter = ((System.Windows.Controls.Button)(target));
            
            #line 66 "..\..\..\ViewProducts\Products.xaml"
            this.buttonFilter.Click += new System.Windows.RoutedEventHandler(this.buttonFilter_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.buttonCloseFilter = ((System.Windows.Controls.Button)(target));
            
            #line 77 "..\..\..\ViewProducts\Products.xaml"
            this.buttonCloseFilter.Click += new System.Windows.RoutedEventHandler(this.buttonCloseFilter_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.buttonReload = ((System.Windows.Controls.Button)(target));
            
            #line 89 "..\..\..\ViewProducts\Products.xaml"
            this.buttonReload.Click += new System.Windows.RoutedEventHandler(this.buttonReload_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.buttonAdd = ((System.Windows.Controls.Button)(target));
            
            #line 99 "..\..\..\ViewProducts\Products.xaml"
            this.buttonAdd.Click += new System.Windows.RoutedEventHandler(this.buttonAdd_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.buttonDelete = ((System.Windows.Controls.Button)(target));
            
            #line 109 "..\..\..\ViewProducts\Products.xaml"
            this.buttonDelete.Click += new System.Windows.RoutedEventHandler(this.buttonDelete_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.iconDelete = ((MaterialDesignThemes.Wpf.PackIcon)(target));
            return;
            case 12:
            this.closeDelete = ((System.Windows.Controls.Button)(target));
            
            #line 120 "..\..\..\ViewProducts\Products.xaml"
            this.closeDelete.Click += new System.Windows.RoutedEventHandler(this.buttoncloseDelete_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.dataGridProduct = ((System.Windows.Controls.DataGrid)(target));
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
            case 2:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.UIElement.PreviewMouseLeftButtonDownEvent;
            
            #line 27 "..\..\..\ViewProducts\Products.xaml"
            eventSetter.Handler = new System.Windows.Input.MouseButtonEventHandler(this.DataGridCell_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            case 14:
            
            #line 160 "..\..\..\ViewProducts\Products.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Checked += new System.Windows.RoutedEventHandler(this.checkBoxDeleteAll_CheckedUnChecked);
            
            #line default
            #line hidden
            
            #line 161 "..\..\..\ViewProducts\Products.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Unchecked += new System.Windows.RoutedEventHandler(this.checkBoxDeleteAll_CheckedUnChecked);
            
            #line default
            #line hidden
            break;
            case 15:
            
            #line 171 "..\..\..\ViewProducts\Products.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Checked += new System.Windows.RoutedEventHandler(this.checkBoxDelete_CheckedUnChecked);
            
            #line default
            #line hidden
            
            #line 172 "..\..\..\ViewProducts\Products.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Unchecked += new System.Windows.RoutedEventHandler(this.checkBoxDelete_CheckedUnChecked);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

