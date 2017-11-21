//----------------------------------------------------------------------
// <copyright file="NewsRegisterView.xaml.cs" company="17NSJ PR Dept">
// Copyright (c) 17NSJ PR Dept. All rights reserved.
// </copyright>
// <summary>NewsRegisterView.xaml の相互作用ロジック</summary>
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
using _17nsj.app.mc.win.ViewModels;
using Newtonsoft.Json;

namespace _17nsj.app.mc.win.Views
{
    /// <summary>
    /// NewsRegisterView.xaml の相互作用ロジック
    /// </summary>
    public partial class NewsRegisterView : Window
    {
        /// <summary>
        /// ViewModel
        /// </summary>
        private NewsRegisterViewModel viewModel;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public NewsRegisterView()
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
            this.viewModel = this.DataContext as NewsRegisterViewModel;
            this.viewModel.Author = this.viewModel.DisplayName;
            await this.GetNewsCategoryList();
        }

        /// <summary>
        /// ニュースカテゴリーリストを取得します。
        /// </summary>
        /// <returns>タスク</returns>
        private async Task GetNewsCategoryList()
        {
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate };
            var client = new HttpClient(handler);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.viewModel.AccessToken);

            var tokenSource = new CancellationTokenSource();
            var url = new Uri($"{App.WebServerApiUrl}news_categories");
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
            var responseDto = JsonConvert.DeserializeObject<List<NewsCategoryDto>>(responseText);
            ObservableCollection<NewsCategoryModel> responseModel = new ObservableCollection<NewsCategoryModel>();

            foreach (var dto in responseDto)
            {
                NewsCategoryModel model = new NewsCategoryModel();
                model.Category = dto.Category;
                model.CategoryName = dto.CategoryName;
                model.Color = dto.Color;
                responseModel.Add(model);
            }

            this.viewModel.CategoryList = responseModel;
            return;
        }

        /// <summary>
        /// 登録ボタンが押されたときに呼ばれます。
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private async void SubmitButtonClick(object sender, RoutedEventArgs e)
        {
            if (!this.Validate())
            {
                return;
            }

            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate };
            var client = new HttpClient(handler);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.viewModel.AccessToken);

            var tokenSource = new CancellationTokenSource();
            var url = new Uri($"{App.WebServerApiUrl}news");
            var dto = new NewsDto();
            dto.Category = this.viewModel.SelectedCategory.Category;
            dto.Author = this.viewModel.Author;
            dto.Title = this.viewModel.Title;
            dto.Outline = this.viewModel.Outline;
            dto.MediaURL = this.viewModel.MediaURL;
            dto.RelationalURL = this.viewModel.RelationalURL;
            dto.ThumbnailURL = this.viewModel.ThumbnailURL;
            dto.IsAvailable = true;

            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, content);

            if (response.StatusCode == HttpStatusCode.Created)
            {
                string location = response.Headers.Location.ToString();
                string[] locationArr = location.Split('/');
                string category = locationArr[locationArr.Length - 2];
                string id = locationArr[locationArr.Length - 1];
                this.viewModel.Result = $"ニュースを登録しました。共有フォルダ→{category}フォルダ→{id}フォルダに本記事に関する写真・文章等を入れてください。";

                this.viewModel.SelectedCategory = null;
                this.viewModel.Title = string.Empty;
                this.viewModel.Outline = string.Empty;
                this.viewModel.MediaURL = string.Empty;
                this.viewModel.RelationalURL = string.Empty;
                this.viewModel.ThumbnailURL = string.Empty;
            }
            else
            {
                MessageBox.Show(await response.Content.ReadAsStringAsync());
            }
        }

        /// <summary>
        /// 登録前に文字数等のチェックをします。
        /// </summary>
        /// <returns>パスしたらtrue</returns>
        private bool Validate()
        {
            if (this.viewModel.SelectedCategory == null)
            {
                MessageBox.Show("カテゴリーを選択してください。");
                return false;
            }

            if (string.IsNullOrEmpty(this.viewModel.Title) || this.viewModel.Title.Length > 20)
            {
                MessageBox.Show("タイトルは必須かつ２０文字以内で入力してください。");
                return false;
            }

            if (string.IsNullOrEmpty(this.viewModel.Author) || this.viewModel.Author.Length > 30)
            {
                MessageBox.Show("著者は必須かつ3０文字以内で入力してください。");
                return false;
            }

            if (!string.IsNullOrEmpty(this.viewModel.Outline) && this.viewModel.Outline.Length > 300)
            {
                MessageBox.Show("概要は300文字以内で入力してください。");
                return false;
            }

            if (!string.IsNullOrEmpty(this.viewModel.MediaURL) && this.viewModel.MediaURL.Length > 200)
            {
                MessageBox.Show("メディアURLは200文字以内で入力してください。");
                return false;
            }

            if (!string.IsNullOrEmpty(this.viewModel.RelationalURL) && this.viewModel.RelationalURL.Length > 200)
            {
                MessageBox.Show("関連URLは200文字以内で入力してください。");
                return false;
            }

            if (!string.IsNullOrEmpty(this.viewModel.ThumbnailURL) && this.viewModel.ThumbnailURL.Length > 200)
            {
                MessageBox.Show("サムネイルURLは200文字以内で入力してください。");
                return false;
            }

            return true;
        }
    }
}
