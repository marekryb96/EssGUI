﻿#pragma checksum "..\..\Device.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "861B15A80D22AABDA0499F1296050D8EB88CB0F1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using EssGUI;
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


namespace EssGUI {
    
    
    /// <summary>
    /// Device
    /// </summary>
    public partial class Device : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\Device.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox filter;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\Device.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox filterBox;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\Device.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid deviceinfo;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\Device.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button editBt;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\Device.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox1;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\Device.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox2;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\Device.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox3;
        
        #line default
        #line hidden
        
        
        #line 119 "..\..\Device.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox4;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\Device.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox5;
        
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
            System.Uri resourceLocater = new System.Uri("/EssGUI;component/device.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Device.xaml"
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
            
            #line 11 "..\..\Device.xaml"
            ((System.Windows.Controls.TabControl)(target)).SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.TabControl_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.filter = ((System.Windows.Controls.TextBox)(target));
            
            #line 31 "..\..\Device.xaml"
            this.filter.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.filter_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.filterBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.deviceinfo = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 5:
            this.editBt = ((System.Windows.Controls.Button)(target));
            
            #line 69 "..\..\Device.xaml"
            this.editBt.Click += new System.Windows.RoutedEventHandler(this.editBt_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 72 "..\..\Device.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.selectBt_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 75 "..\..\Device.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Refersh_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.TextBox1 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.TextBox2 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.TextBox3 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.TextBox4 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            this.TextBox5 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 13:
            
            #line 121 "..\..\Device.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

