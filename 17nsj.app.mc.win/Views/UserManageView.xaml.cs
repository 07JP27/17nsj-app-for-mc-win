//----------------------------------------------------------------------
// <copyright file="UserManageView.xaml.cs" company="17NSJ PR Dept">
// Copyright (c) 17NSJ PR Dept. All rights reserved.
// </copyright>
// <summary>UserManageView.xaml の相互作用ロジック</summary>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using _17nsj.app.dto;
using _17nsj.app.mc.win.Models;
using _17nsj.app.mc.win.Utils;
using _17nsj.app.mc.win.ViewModels;
using Newtonsoft.Json;

namespace _17nsj.app.mc.win.Views
{
    /// <summary>
    /// UserManageView.xaml の相互作用ロジック
    /// </summary>
    public partial class UserManageView : Window
    {
        /// <summary>
        /// ViewModel
        /// </summary>
        private UserManageViewModel viewModel;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public UserManageView()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// 画面が読み込まれた後に呼ばれます。
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private async void ViewLoaded(object sender, RoutedEventArgs e)
        {
            this.viewModel = this.DataContext as UserManageViewModel;
            this.viewModel.IsBusy = true;
            await this.GetUserList();
            this.viewModel.IsBusy = false;
        }

        /// <summary>
        /// 編集ボタンが押されたときに呼ばれます。
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void UserEditButtonClicked(object sender, RoutedEventArgs e)
        {
            if (this.viewModel.SelectedUser == null)
            {
                MessageBox.Show("編集するユーザーを選択してください。");
                return;
            }

            this.OpenEditView();
        }

        /// <summary>
        /// Userがダブルクリックされたときに呼ばれます。
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void UserDoubleClicked(object sender, MouseButtonEventArgs e)
        {
            this.OpenEditView();
        }

        /// <summary>
        /// ユーザーリストを取得します。
        /// </summary>
        /// <returns>タスク</returns>
        private async Task GetUserList()
        {
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate };
            var client = new HttpClient(handler);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.viewModel.AccessToken);

            var tokenSource = new CancellationTokenSource();
            var url = new Uri($"{App.WebServerApiUrl}users");
            var response = await client.GetAsync(url, tokenSource.Token);

            if (response.StatusCode == HttpStatusCode.Forbidden)
            {
                MessageBox.Show("現在ログイン中のアカウントではこの操作は許可されていません。");
                this.Close();
                return;
            }

            response.EnsureSuccessStatusCode();

            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return;
            }

            var responseText = await response.Content.ReadAsStringAsync();
            var responseDto = JsonConvert.DeserializeObject<List<UserDto>>(responseText);
            ObservableCollection<UserModel> responseModels = new ObservableCollection<UserModel>();

            foreach (var dto in responseDto)
            {
                UserModel model = new UserModel();

                model.UserId = dto.UserId;
                model.DisplayName = dto.DisplayName;
                model.IsAdmin = dto.IsAdmin;
                model.CanRead = dto.CanRead;
                model.CanWrite = dto.CanWrite;
                responseModels.Add(model);
            }

            this.viewModel.UserList = responseModels;
            this.viewModel.FilteredUserList = responseModels;
            return;
        }

        /// <summary>
        /// 編集画面を開きます。
        /// </summary>
        private void OpenEditView()
        {
            var childView = new UserEditView();
            var childViewModel = new UserEditViewModel();

            childViewModel.UserId = this.viewModel.UserId;
            childViewModel.DisplayName = this.viewModel.DisplayName;
            childViewModel.AccessToken = this.viewModel.AccessToken;
            childViewModel.TargetUserId = this.viewModel.SelectedUser.UserId;
            childViewModel.TargetDisplayName = this.viewModel.SelectedUser.DisplayName;
            childViewModel.TargetCanRead = this.viewModel.SelectedUser.CanRead;
            childViewModel.TargetCanWrite = this.viewModel.SelectedUser.CanWrite;
            childViewModel.TargetIsAdmin = this.viewModel.SelectedUser.IsAdmin;
            childView.DataContext = childViewModel;
            childView.Owner = this;
            var dialogResult = childView.ShowDialog();
        }

        /// <summary>
        /// 登録画面を開きます。
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void UserRegisterButtonClicked(object sender, RoutedEventArgs e)
        {
            var childView = new UserRegisterView();
            var childViewModel = new UserRegisterViewModel();

            childViewModel.UserId = this.viewModel.UserId;
            childViewModel.DisplayName = this.viewModel.DisplayName;
            childViewModel.AccessToken = this.viewModel.AccessToken;
            childView.DataContext = childViewModel;
            childView.Owner = this;
            var dialogResult = childView.ShowDialog();
        }
    }
}
