//----------------------------------------------------------------------
// <copyright file="NoticesViewerView.xaml.cs" company="17NSJ PR Dept">
// Copyright (c) 17NSJ PR Dept. All rights reserved.
// </copyright>
// <summary>NoticesViewerView.xaml の相互作用ロジック</summary>
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
    /// NoticesViewerView.xaml の相互作用ロジック
    /// </summary>
    public partial class NoticesViewerView : Window
    {
        /// <summary>
        /// ViewModel
        /// </summary>
        private NoticesViewerViewModel viewModel;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public NoticesViewerView()
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
            this.viewModel = this.DataContext as NoticesViewerViewModel;

            await this.GetNoticeList();
        }

        /// <summary>
        /// ニュースリストを取得します。
        /// </summary>
        /// <returns>タスク</returns>
        private async Task GetNoticeList()
        {
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate };
            var client = new HttpClient(handler);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.viewModel.AccessToken);

            var tokenSource = new CancellationTokenSource();
            var url = new Uri($"{App.WebServerApiUrl}notices");
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
            var responseDto = JsonConvert.DeserializeObject<List<NoticeDto>>(responseText);
            ObservableCollection<NoticeModel> responseModels = new ObservableCollection<NoticeModel>();

            foreach (var dto in responseDto)
            {
                NoticeModel model = new NoticeModel();

                model.Id = dto.Id;
                model.Author = dto.Author;
                model.Title = dto.Title;
                model.Outline = dto.Outline;
                model.MediaURL = dto.MediaURL;
                model.CreatedAt = dto.CreatedAt;
                responseModels.Add(model);
            }

            this.viewModel.NoticeList = responseModels;
            return;
        }
    }
}
