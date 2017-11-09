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
    }
}
