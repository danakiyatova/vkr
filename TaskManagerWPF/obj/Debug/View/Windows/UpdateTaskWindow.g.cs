﻿#pragma checksum "..\..\..\..\View\Windows\UpdateTaskWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "BE66B4B149A38EE896FCFC759EDC200F08B5E65681BA0D8E676F71AE718736BA"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using TaskManagerWPF.View.Windows;
using TaskManagerWPF.ViewModel;


namespace TaskManagerWPF.View.Windows {
    
    
    /// <summary>
    /// UpdateTaskWindow
    /// </summary>
    public partial class UpdateTaskWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        /// <summary>
        /// myGrid Name Field
        /// </summary>
        
        #line 139 "..\..\..\..\View\Windows\UpdateTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.Grid myGrid;
        
        #line default
        #line hidden
        
        
        #line 141 "..\..\..\..\View\Windows\UpdateTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CloseBtn;
        
        #line default
        #line hidden
        
        
        #line 161 "..\..\..\..\View\Windows\UpdateTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox updateTaskName;
        
        #line default
        #line hidden
        
        
        #line 164 "..\..\..\..\View\Windows\UpdateTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox updateTaskExecutorTB;
        
        #line default
        #line hidden
        
        
        #line 167 "..\..\..\..\View\Windows\UpdateTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox updateTaskContext;
        
        #line default
        #line hidden
        
        
        #line 170 "..\..\..\..\View\Windows\UpdateTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker updateTaskStart;
        
        #line default
        #line hidden
        
        
        #line 173 "..\..\..\..\View\Windows\UpdateTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker updateTaskEnd;
        
        #line default
        #line hidden
        
        
        #line 176 "..\..\..\..\View\Windows\UpdateTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox updateTaskStatusCB;
        
        #line default
        #line hidden
        
        
        #line 187 "..\..\..\..\View\Windows\UpdateTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox updateTaskEmployeeCB;
        
        #line default
        #line hidden
        
        
        #line 204 "..\..\..\..\View\Windows\UpdateTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnAddBooking;
        
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
            System.Uri resourceLocater = new System.Uri("/TaskManagerWPF;component/view/windows/updatetaskwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\Windows\UpdateTaskWindow.xaml"
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
            
            #line 12 "..\..\..\..\View\Windows\UpdateTaskWindow.xaml"
            ((TaskManagerWPF.View.Windows.UpdateTaskWindow)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Border_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.myGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.CloseBtn = ((System.Windows.Controls.Button)(target));
            
            #line 144 "..\..\..\..\View\Windows\UpdateTaskWindow.xaml"
            this.CloseBtn.Click += new System.Windows.RoutedEventHandler(this.CloseBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 149 "..\..\..\..\View\Windows\UpdateTaskWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BackBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.updateTaskName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.updateTaskExecutorTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.updateTaskContext = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.updateTaskStart = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 9:
            this.updateTaskEnd = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 10:
            this.updateTaskStatusCB = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 11:
            this.updateTaskEmployeeCB = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 12:
            this.BtnAddBooking = ((System.Windows.Controls.Button)(target));
            
            #line 205 "..\..\..\..\View\Windows\UpdateTaskWindow.xaml"
            this.BtnAddBooking.Click += new System.Windows.RoutedEventHandler(this.UpdateTask_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
