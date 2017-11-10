//----------------------------------------------------------------------
// <copyright file="NewsManageView.xaml.cs" company="17NSJ PR Dept">
// Copyright (c) 17NSJ PR Dept. All rights reserved.
// </copyright>
// <summary>NewsManageView.xaml の相互作用ロジック</summary>
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
    /// NewsManageView.xaml の相互作用ロジック
    /// </summary>
    public partial class NewsManageView : Window
    {
        /// <summary>
        /// ViewModel
        /// </summary>
        private NewsManageViewModel viewModel;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public NewsManageView()
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
            this.viewModel = this.DataContext as NewsManageViewModel;

            await this.GetNewsCategoryList();
            await this.GetNewsList();
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
            ObservableCollection<NewsCategoryModel> responseModels = new ObservableCollection<NewsCategoryModel>();
            responseModels.Add(new NewsCategoryModel() { Category = null, CategoryName = "すべて" });

            foreach (var dto in responseDto)
            {
                NewsCategoryModel model = new NewsCategoryModel();
                model.Category = dto.Category;
                model.CategoryName = dto.CategoryName;
                model.Color = dto.Color;
                responseModels.Add(model);
            }

            this.viewModel.NewsCategoryList = responseModels;
            return;
        }

        /// <summary>
        /// ニュースリストを取得します。
        /// </summary>
        /// <returns>タスク</returns>
        private async Task GetNewsList()
        {
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate };
            var client = new HttpClient(handler);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.viewModel.AccessToken);

            var tokenSource = new CancellationTokenSource();
            var url = new Uri($"{App.WebServerApiUrl}news");
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
            var responseDto = JsonConvert.DeserializeObject<List<NewsDto>>(responseText);
            ObservableCollection<NewsModel> responseModels = new ObservableCollection<NewsModel>();

            foreach (var dto in responseDto)
            {
                NewsModel model = new NewsModel();
                NewsCategoryModel category = this.viewModel.NewsCategoryList.Where(e => e.Category == dto.Category).Single();

                model.Category = dto.Category;
                model.Id = dto.Id;
                model.Author = dto.Author;
                model.Title = dto.Title;
                model.Outline = dto.Outline;
                model.MediaURL = dto.MediaURL;
                model.CreatedAt = dto.CreatedAt;
                model.CategoryName = category.CategoryName;
                model.Color = category.Color;
                responseModels.Add(model);
            }

            this.viewModel.NewsList = responseModels;
            this.FilterNewsList(null);
            return;
        }

        /// <summary>
        /// 選択中のニュースカテゴリが変更されたときに呼ばれます。
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void SelectedNewsCategoryChanged(object sender, SelectionChangedEventArgs e)
        {
            this.FilterNewsList(this.viewModel.SelectedNewsCategory.Category);
        }

        /// <summary>
        /// ニュースがダブルクリックされたときに呼ばれます。
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void NewsDoubleClicked(object sender, MouseButtonEventArgs e)
        {
            this.OpenEditView();
        }

        /// <summary>
        /// 編集ボタンが押されたときに呼ばれます。
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void NewsEditButtonClicked(object sender, RoutedEventArgs e)
        {
            if (this.viewModel.SelectedNews == null)
            {
                MessageBox.Show("編集するニュースを選択してください。");
                return;
            }

            this.OpenEditView();
        }

        /// <summary>
        /// 編集画面を開きます。
        /// </summary>
        private void OpenEditView()
        {
            var childView = new NewsEditView();
            var childViewModel = new NewsEditViewModel();

            childViewModel.UserId = this.viewModel.UserId;
            childViewModel.DisplayName = this.viewModel.DisplayName;
            childViewModel.AccessToken = this.viewModel.AccessToken;
            childViewModel.Color = this.viewModel.SelectedNews.Color;
            childViewModel.Category = this.viewModel.SelectedNews.Category;
            childViewModel.Id = this.viewModel.SelectedNews.Id;
            childViewModel.Title = this.viewModel.SelectedNews.Title;
            childViewModel.Author = this.viewModel.SelectedNews.Author;
            childViewModel.Outline = this.viewModel.SelectedNews.Outline;
            childViewModel.MediaURL = this.viewModel.SelectedNews.MediaURL;
            childView.DataContext = childViewModel;
            childView.Owner = this;
            var dialogResult = childView.ShowDialog();

            if (dialogResult == true)
            {
                if (this.viewModel.SelectedNewsCategory.Category == null)
                {
                    this.RefreshNewsList(null);
                }
                else
                {
                    this.RefreshNewsList(this.viewModel.SelectedNewsCategory.Category);
                }
            }
        }

        /// <summary>
        /// リストを更新して検索条件を適用します。
        /// </summary>
        /// <param name="category">カテゴリー</param>
        private async void RefreshNewsList(string category)
        {
            await this.GetNewsList();
            this.FilterNewsList(category);
        }

        /// <summary>
        /// NewsListを指定された引数のカテゴリのニュースを抽出し、FilteredNewsListに格納します。
        /// 引数がnullの場合はFilteredNewsList = NewsListになります。
        /// </summary>
        /// <param name="category">カテゴリ</param>
        private void FilterNewsList(string category)
        {
            if (string.IsNullOrEmpty(category))
            {
                this.viewModel.FilteredNewsList = this.viewModel.NewsList;
            }
            else
            {
                var list = this.viewModel.NewsList.Where(e => e.Category == category).ToList();
                this.viewModel.FilteredNewsList = new ObservableCollection<NewsModel>(list);
            }
        }
    }
}
