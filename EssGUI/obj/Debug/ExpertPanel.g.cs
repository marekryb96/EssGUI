﻿#pragma checksum "..\..\ExpertPanel.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1F1A57F2F1D81E0D2ECCC6DD7072EE145150EE34"
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
    /// ExpertPanel
    /// </summary>
    public partial class ExpertPanel : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\ExpertPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox filter;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\ExpertPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox filterBox;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\ExpertPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid orderinfo1;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\ExpertPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button noBt;
        
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
            System.Uri resourceLocater = new System.Uri("/EssGUI;component/expertpanel.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ExpertPanel.xaml"
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
            this.filter = ((System.Windows.Controls.TextBox)(target));
            
            #line 31 "..\..\ExpertPanel.xaml"
            this.filter.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.filter_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.filterBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 42 "..\..\ExpertPanel.xaml"
            this.filterBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.orderinfo1 = ((System.Windows.Controls.DataGrid)(target));
            
            #line 50 "..\..\ExpertPanel.xaml"
            this.orderinfo1.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.orderinfo1_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.noBt = ((System.Windows.Controls.Button)(target));
            
            #line 68 "..\..\ExpertPanel.xaml"
            this.noBt.Click += new System.Windows.RoutedEventHandler(this.noBt_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 71 "..\..\ExpertPanel.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 74 "..\..\ExpertPanel.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 106 "..\..\ExpertPanel.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.noBt_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 146 "..\..\ExpertPanel.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.noBt_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

