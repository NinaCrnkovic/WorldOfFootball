﻿#pragma checksum "..\..\..\..\UserControls\InitialSettings.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2A8A77F54F3104DEAD6DD1CA1C6F79F94BD42460"
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
using System.Windows.Controls.Ribbon;
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
using TeamTracker.Properties;
using TeamTracker.UserControls;


namespace TeamTracker.UserControls {
    
    
    /// <summary>
    /// InitialSettings
    /// </summary>
    public partial class InitialSettings : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 44 "..\..\..\..\UserControls\InitialSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbCro;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\UserControls\InitialSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbEn;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\UserControls\InitialSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbF;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\UserControls\InitialSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbM;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\..\UserControls\InitialSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbFull;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\..\UserControls\InitialSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbOriginal;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\..\UserControls\InitialSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbSmall;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TeamTracker;component/usercontrols/initialsettings.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UserControls\InitialSettings.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.rbCro = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 2:
            this.rbEn = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 3:
            this.rbF = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 4:
            this.rbM = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 5:
            this.rbFull = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 6:
            this.rbOriginal = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 7:
            this.rbSmall = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 8:
            
            #line 94 "..\..\..\..\UserControls\InitialSettings.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.InitialSettingsButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

