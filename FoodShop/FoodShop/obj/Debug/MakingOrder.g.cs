﻿#pragma checksum "..\..\MakingOrder.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "01DAE2FD5A4724515DD15A560488917187E352F7"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using FoodShop;
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


namespace FoodShop {
    
    
    /// <summary>
    /// MakingOrder
    /// </summary>
    public partial class MakingOrder : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\MakingOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid OrderGrid;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\MakingOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Adress;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\MakingOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Number;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\MakingOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Company;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\MakingOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Dish;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\MakingOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker Date;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\MakingOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox TypeDish;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\MakingOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Count;
        
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
            System.Uri resourceLocater = new System.Uri("/FoodShop;component/makingorder.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MakingOrder.xaml"
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
            
            #line 8 "..\..\MakingOrder.xaml"
            ((FoodShop.MakingOrder)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.window_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 13 "..\..\MakingOrder.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 16 "..\..\MakingOrder.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Exit_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 21 "..\..\MakingOrder.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Menu_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 22 "..\..\MakingOrder.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Main_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.OrderGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 7:
            this.Adress = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.Number = ((System.Windows.Controls.TextBox)(target));
            
            #line 35 "..\..\MakingOrder.xaml"
            this.Number.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.Number_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Company = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.Dish = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 11:
            this.Date = ((System.Windows.Controls.DatePicker)(target));
            
            #line 38 "..\..\MakingOrder.xaml"
            this.Date.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.Date_KeyDown);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 39 "..\..\MakingOrder.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.MakeOrder_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.TypeDish = ((System.Windows.Controls.ComboBox)(target));
            
            #line 40 "..\..\MakingOrder.xaml"
            this.TypeDish.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.TypeDish_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 14:
            this.Count = ((System.Windows.Controls.TextBox)(target));
            
            #line 48 "..\..\MakingOrder.xaml"
            this.Count.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.Number_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 49 "..\..\MakingOrder.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Add_Click);
            
            #line default
            #line hidden
            return;
            case 16:
            
            #line 50 "..\..\MakingOrder.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ShowOrder_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

