﻿#pragma checksum "..\..\..\..\UserControls\OverviewOfTheTeam.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8E7DEFBFD602529BF187FA091E45A73879104139"
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
using TeamTracker.UserControls;


namespace TeamTracker.UserControls {
    
    
    /// <summary>
    /// OverviewOfTheTeam
    /// </summary>
    public partial class OverviewOfTheTeam : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 78 "..\..\..\..\UserControls\OverviewOfTheTeam.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblResult;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\..\..\UserControls\OverviewOfTheTeam.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbFavoriteTeam;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\..\UserControls\OverviewOfTheTeam.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbOppositeTeam;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\..\UserControls\OverviewOfTheTeam.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnViewFavoriteTeamInfo;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\..\..\UserControls\OverviewOfTheTeam.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnViewOppositeTeamInfo;
        
        #line default
        #line hidden
        
        
        #line 121 "..\..\..\..\UserControls\OverviewOfTheTeam.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbFavoriteTeam;
        
        #line default
        #line hidden
        
        
        #line 136 "..\..\..\..\UserControls\OverviewOfTheTeam.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbOppositeTeam;
        
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
            System.Uri resourceLocater = new System.Uri("/TeamTracker;component/usercontrols/overviewoftheteam.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UserControls\OverviewOfTheTeam.xaml"
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
            this.lblResult = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.cbFavoriteTeam = ((System.Windows.Controls.ComboBox)(target));
            
            #line 90 "..\..\..\..\UserControls\OverviewOfTheTeam.xaml"
            this.cbFavoriteTeam.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbFavoriteTeam_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.cbOppositeTeam = ((System.Windows.Controls.ComboBox)(target));
            
            #line 98 "..\..\..\..\UserControls\OverviewOfTheTeam.xaml"
            this.cbOppositeTeam.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbOppositeTeam_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnViewFavoriteTeamInfo = ((System.Windows.Controls.Button)(target));
            
            #line 107 "..\..\..\..\UserControls\OverviewOfTheTeam.xaml"
            this.btnViewFavoriteTeamInfo.Click += new System.Windows.RoutedEventHandler(this.Btn_FavoriteTeamInfo_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnViewOppositeTeamInfo = ((System.Windows.Controls.Button)(target));
            
            #line 115 "..\..\..\..\UserControls\OverviewOfTheTeam.xaml"
            this.btnViewOppositeTeamInfo.Click += new System.Windows.RoutedEventHandler(this.Btn_OppositeTeamInfo_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.lbFavoriteTeam = ((System.Windows.Controls.ListBox)(target));
            return;
            case 7:
            this.lbOppositeTeam = ((System.Windows.Controls.ListBox)(target));
            return;
            case 8:
            
            #line 148 "..\..\..\..\UserControls\OverviewOfTheTeam.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Btn_Next_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

