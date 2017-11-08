//----------------------------------------------------------------------
// <copyright file="NewsViewerView.xaml.cs" company="17NSJ PR Dept">
// Copyright (c) 17NSJ PR Dept. All rights reserved.
// </copyright>
// <summary>NewsViewerView.xaml の相互作用ロジック</summary>
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
        private void ViewLoaded(object sender, RoutedEventArgs e)
        {
            this.viewModel = this.DataContext as NewsViewerViewModel;

            this.GetNewsList();
        }

        /// <summary>
        /// ニュースリストを取得します。
        /// </summary>
        private async void GetNewsList()
        {
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate };
            var client = new HttpClient(handler);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.viewModel.AccessToken);

            var tokenSource = new CancellationTokenSource();

            // 企業内のユーザ一覧を取得
            var url = new Uri($"{App.WebServerApiUrl}news");
            var response = await client.GetAsync(url, tokenSource.Token);

            response.EnsureSuccessStatusCode();

            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return;
            }

            var responseText = await response.Content.ReadAsStringAsync();
            var responseDto = JsonConvert.DeserializeObject<ObservableCollection<Models.NewsModel>>(responseText);

            this.viewModel.NewsList = responseDto;
            return;
        }

        /// <summary>
        /// リスト内のアイテムが選択されたときに呼ばれます。
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void ItemSelected(object sender, SelectionChangedEventArgs e)
        {
            // todo
        }
    }
}
