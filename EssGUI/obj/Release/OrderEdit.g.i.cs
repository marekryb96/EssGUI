﻿#pragma checksum "..\..\OrderEdit.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7202691107811ECC88C8FEA375F515ACB2F05243"
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
    /// OrderEdit
    /// </summary>
    public partial class OrderEdit : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 50 "..\..\OrderEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nameLabel;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\OrderEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox phoneTb;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\OrderEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox statusBox;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\OrderEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox problemTb;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\OrderEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox modelLabel;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\OrderEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox serialLabel;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\OrderEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox repairLabel;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\OrderEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox cost1Tb;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\OrderEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox cost2Tb;
        
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
            System.Uri resourceLocater = new System.Uri("/EssGUI;component/orderedit.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\OrderEdit.xaml"
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
            this.nameLabel = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.phoneTb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.statusBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.problemTb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.modelLabel = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.serialLabel = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.repairLabel = ((System.Windows.Controls.TextBox)(target));
            
            #line 66 "..\..\OrderEdit.xaml"
            this.repairLabel.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.repairLabel_TextChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.cost1Tb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.cost2Tb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            
            #line 70 "..\..\OrderEdit.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

