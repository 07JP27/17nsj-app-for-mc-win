//----------------------------------------------------------------------
// <copyright file="AdminMenuView.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// <summary>AdminMenuView.xaml の相互作用ロジック</summary>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using _17nsj.app.mc.win.ViewModels;

namespace _17nsj.app.mc.win.Views
{
    /// <summary>
    /// AdminMenuView.xaml の相互作用ロジック
    /// </summary>
    public partial class AdminMenuView : Window
    {
        /// <summary>
        /// ViewModel
        /// </summary>
        private AdminMenuViewModel viewModel;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public AdminMenuView()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// 画面が読み込まれた後に呼ばれます。
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void ViewLoaded(object sender, RoutedEventArgs e)
        {
            this.viewModel = this.DataContext as AdminMenuViewModel;
        }
    }
}
