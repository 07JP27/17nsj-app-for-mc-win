//----------------------------------------------------------------------
// <copyright file="AdminMenuView.xaml.cs" company="17NSJ PR Dept">
// Copyright (c) 17NSJ PR Dept. All rights reserved.
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

        /// <summary>
        /// ニュースを見るボタンが押されたときに呼ばれます。
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void ViewNewsButtonClick(object sender, RoutedEventArgs e)
        {
            var childView = new NewsViewerView();
            var childViewModel = new NewsViewerViewModel();

            childViewModel.UserId = this.viewModel.UserId;
            childViewModel.DisplayName = this.viewModel.DisplayName;
            childViewModel.AccessToken = this.viewModel.AccessToken;
            childView.DataContext = childViewModel;
            childView.Owner = this;
            childView.ShowDialog();
        }

        /// <summary>
        /// ニュースを登録ボタンが押されたときに呼ばれます。
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void AddNewsButtonClick(object sender, RoutedEventArgs e)
        {
            var childView = new NewsRegisterView();
            var childViewModel = new NewsRegisterViewModel();

            childViewModel.UserId = this.viewModel.UserId;
            childViewModel.DisplayName = this.viewModel.DisplayName;
            childViewModel.AccessToken = this.viewModel.AccessToken;
            childView.DataContext = childViewModel;
            childView.Owner = this;
            childView.ShowDialog();
        }

        /// <summary>
        /// お知らせを見るボタンが押されたときに呼ばれます。
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void ViewNoticesButtonClick(object sender, RoutedEventArgs e)
        {
            var childView = new NoticesViewerView();
            var childViewModel = new NoticesViewerViewModel();

            childViewModel.UserId = this.viewModel.UserId;
            childViewModel.DisplayName = this.viewModel.DisplayName;
            childViewModel.AccessToken = this.viewModel.AccessToken;
            childView.DataContext = childViewModel;
            childView.Owner = this;
            childView.ShowDialog();
        }

        /// <summary>
        /// お知らせ登録ボタンが押されたときに呼ばれます。
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void AddNoticeButtonClick(object sender, RoutedEventArgs e)
        {
            var childView = new NoticeRegisterView();
            var childViewModel = new NoticeRegisterViewModel();

            childViewModel.UserId = this.viewModel.UserId;
            childViewModel.DisplayName = this.viewModel.DisplayName;
            childViewModel.AccessToken = this.viewModel.AccessToken;
            childView.DataContext = childViewModel;
            childView.Owner = this;
            childView.ShowDialog();
        }

        /// <summary>
        /// お知らせ編集ボタンが押されたときに呼ばれます。
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void EditNoticeButtonClick(object sender, RoutedEventArgs e)
        {
            // todo
        }

        /// <summary>
        /// ニュース編集ボタンが押されたときに呼ばれます。
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void EditNewsButtonClick(object sender, RoutedEventArgs e)
        {
            // todo
        }

        /// <summary>
        /// ユーザー追加ボタンが押されたときに呼ばれます。
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void AddUserButtonClick(object sender, RoutedEventArgs e)
        {
            // todo
        }

        /// <summary>
        /// ユーザー編集ボタンが押されたときに呼ばれます。
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void EditUserButtonClick(object sender, RoutedEventArgs e)
        {
            // todo
        }
    }
}
