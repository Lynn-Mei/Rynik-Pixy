﻿#pragma checksum "..\..\..\LayerColorSelector.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A5871D9AC80DB173213DA72CD9221EC9963A2DB0"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using CustomCharacterGenerator;
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


namespace CustomCharacterGenerator {
    
    
    /// <summary>
    /// LayerColorSelector
    /// </summary>
    public partial class LayerColorSelector : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\LayerColorSelector.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider Red;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\LayerColorSelector.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider Green;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\LayerColorSelector.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider Blue;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.9.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CustomCharacterGenerator;component/layercolorselector.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\LayerColorSelector.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.9.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Red = ((System.Windows.Controls.Slider)(target));
            
            #line 26 "..\..\..\LayerColorSelector.xaml"
            this.Red.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.ColorSlider_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Green = ((System.Windows.Controls.Slider)(target));
            
            #line 32 "..\..\..\LayerColorSelector.xaml"
            this.Green.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.ColorSlider_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Blue = ((System.Windows.Controls.Slider)(target));
            
            #line 38 "..\..\..\LayerColorSelector.xaml"
            this.Blue.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.ColorSlider_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 40 "..\..\..\LayerColorSelector.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Validate);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

