//----------------------------------------------------------------------
// <copyright file="LoginView.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// <summary>LoginViewクラス</summary>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
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
using _17nsj.app.mc.win.Utils;
using _17nsj.app.mc.win.ViewModels;
using Newtonsoft.Json;

namespace _17nsj.app.mc.win.Views
{
    /// <summary>
    /// LoginView.xaml の相互作用ロジック
    /// </summary>
    public partial class LoginView : Window
    {
        /// <summary>
        /// ViewModel
        /// </summary>
        private LoginViewModel viewModel;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public LoginView()
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
            this.viewModel = this.DataContext as LoginViewModel;
        }

        /// <summary>
        /// ログインボタンが押されたときに呼ばれます。
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private async void LoginButtonClick(object sender, RoutedEventArgs e)
        {
            this.btnLogin.IsEnabled = false;

            if (!this.ValidateLogin())
            {
                return;
            }

            try
            {
                var passwordHash = new HashCreater().CreateSHA256Hash(this.txtPassword.Password);
                this.viewModel.AccessToken = await this.Login(this.viewModel.UserId, passwordHash);

                if (string.IsNullOrEmpty(this.viewModel.AccessToken))
                {
                    MessageBox.Show("ID、パスワードもしくは両方が間違っています。");
                    return;
                }

                UserDto user = await this.GetUser(this.viewModel.UserId, this.viewModel.AccessToken);

                Window childView = null;

                // 管理者か否かによってメニューを分岐
                if (user.IsAdmin)
                {
                    var childViewModel = new AdminMenuViewModel();

                    childView = new AdminMenuView();
                    childViewModel.UserId = this.viewModel.UserId;
                    childViewModel.DisplayName = this.viewModel.DisplayName;
                    childViewModel.AccessToken = this.viewModel.AccessToken;
                    childView.DataContext = childViewModel;
                }
                else
                {
                    var childViewModel = new UserMenuViewModel();

                    childView = new UserMenuView();
                    childViewModel.UserId = this.viewModel.UserId;
                    childViewModel.DisplayName = this.viewModel.DisplayName;
                    childViewModel.AccessToken = this.viewModel.AccessToken;
                    childView.DataContext = childViewModel;
                }

                childView.Owner = this;
                this.Hide();
                childView.ShowDialog();
            }
            catch (Exception ex)
            {
                ex.ToString();

                // todo
            }
            finally
            {
                this.viewModel.UserId = string.Empty;
                this.txtPassword.Password = string.Empty;
                this.btnLogin.IsEnabled = true;
                this.Show();
            }
        }

        /// <summary>
        /// ログイン処理前の入力チェックを行います。
        /// </summary>
        /// <returns>チェックにパスすればtrueそれ以外はMsgBoxを表示してfalse</returns>
        private bool ValidateLogin()
        {
            if (string.IsNullOrEmpty(this.viewModel.UserId))
            {
                MessageBox.Show("ユーザーIDを入力してください。", "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (string.IsNullOrEmpty(this.txtPassword.Password))
            {
                MessageBox.Show("パスワードを入力してください。", "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        /// <summary>
        /// ログイン処理を行います。
        /// </summary>
        /// <param name="userId">ユーザーID</param>
        /// <param name="password">ハッシュ化されたパスワード</param>
        /// <returns>ログインに成功したらアクセストークン</returns>
        private async Task<string> Login(string userId, string password)
        {
            // ユーザ、パスワードを用いてトークン取得
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate };
            var client = new HttpClient(handler);

            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var authContent = new StringContent($"grant_type=password&username={userId}&password={password}");
            HttpResponseMessage response;

            authContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            response = await client.PostAsync(App.WebServerTokenUrl, authContent);

            if ((response.StatusCode == HttpStatusCode.BadRequest) ||
                (response.StatusCode == HttpStatusCode.Unauthorized))
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            var responseText = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<AuthResultDto>(responseText).Token;
        }

        /// <summary>
        /// ユーザー情報を取得します。
        /// </summary>
        /// <param name="userId">ユーザーID</param>
        /// <param name="token">トークン</param>
        /// <returns>ユーザー情報</returns>
        private async Task<UserDto> GetUser(string userId, string token)
        {
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate };
            var client = new HttpClient(handler);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var tokenSource = new CancellationTokenSource();

            // 企業内のユーザ一覧を取得
            var url = new Uri($"{App.WebServerApiUrl}users/{userId}");
            var response = await client.GetAsync(url, tokenSource.Token);

            response.EnsureSuccessStatusCode();

            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return null;
            }

            var responseText = await response.Content.ReadAsStringAsync();
            var responseDto = JsonConvert.DeserializeObject<UserDto>(responseText);

            return responseDto;
        }
    }
}
