//----------------------------------------------------------------------
// <copyright file="NewsViewerView.xaml.cs" company="17NSJ PR Dept">
// Copyright (c) 17NSJ PR Dept. All rights reserved.
// </copyright>
// <summary>NewsViewerView.xaml の相互作用ロジック</summary>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
using _17nsj.app.mc.win.Extensions;
using _17nsj.app.mc.win.Models;
using _17nsj.app.mc.win.ViewModels;
using Newtonsoft.Json;

namespace _17nsj.app.mc.win.Views
{
    /// <summary>
    /// NewsViewerView.xaml の相互作用ロジック
    /// </summary>
    public partial class NewsViewerView : Window
    {
        /// <summary>
        /// ViewModel
        /// </summary>
        private NewsViewerViewModel viewModel;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public NewsViewerView()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// 画面が読み込まれた後に呼ばれます
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private async void ViewLoaded(object sender, RoutedEventArgs e)
        {
            this.viewModel = this.DataContext as NewsViewerViewModel;

            this.viewModel.IsBusy = true;
            await this.GetNewsCategoryList();
            await this.GetNewsList();
            this.viewModel.IsBusy = false;
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

            foreach (var dto in responseDto)
            {
                NewsCategoryModel model = new NewsCategoryModel();
                model.Category = dto.Category;
                model.CategoryName = dto.CategoryName;
                model.Color = dto.Color;
                model.ThumbnailURL = dto.ThumbnailURL;
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
                model.RelationalURL = dto.RelationalURL;

                // 固有のサムネが無い場合はカテゴリーデフォルトのサムネ
                if (string.IsNullOrEmpty(dto.ThumbnailURL))
                {
                    model.ThumbnailURL = category.ThumbnailURL;
                }
                else
                {
                    model.ThumbnailURL = dto.ThumbnailURL;
                }

                model.CreatedAt = dto.CreatedAt;
                model.CategoryName = category.CategoryName;
                model.Color = category.Color;
                responseModels.Add(model);
            }

            this.viewModel.NewsList = responseModels;
            this.viewModel.FilteredNewsList = responseModels;
            this.viewModel.SelectedNews = responseModels.FirstOrDefault();
            return;
        }

        /// <summary>
        /// 関連リンクをWebブラウザで開きます。
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        /// <summary>
        /// 検索を行います。
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void NewsSerchClicked(object sender, RoutedEventArgs e)
        {
            this.viewModel.IsBusy = true;

            var serchText = this.viewModel.SerchText;

            if (string.IsNullOrEmpty(serchText))
            {
                this.viewModel.FilteredNewsList = this.viewModel.NewsList;
            }

            var serchTextArr = serchText.Split(' ', '　');
            ObservableCollection<NewsModel> filteredNewsList;

            if (serchTextArr.Count() > 0)
            {
                var list = this.viewModel.NewsList.Where(a => a.Title.ContainsAny(serchTextArr) || a.Outline.ContainsAny(serchTextArr)).ToList();
                filteredNewsList = new ObservableCollection<NewsModel>(list);
            }
            else
            {
                filteredNewsList = this.viewModel.NewsList;
            }

            this.viewModel.FilteredNewsList = filteredNewsList;

            this.viewModel.IsBusy = false;
        }
    }
}
