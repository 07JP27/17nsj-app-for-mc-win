//----------------------------------------------------------------------
// <copyright file="NewsEditView.xaml.cs" company="17NSJ PR Dept">
// Copyright (c) 17NSJ PR Dept. All rights reserved.
// </copyright>
// <summary>NewsEditView.xaml の相互作用ロジック</summary>
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
    /// NewsEditView.xaml の相互作用ロジック
    /// </summary>
    public partial class NewsEditView : Window
    {
        /// <summary>
        /// ViewModel
        /// </summary>
        private NewsEditViewModel viewModel;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public NewsEditView()
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
            this.viewModel = this.DataContext as NewsEditViewModel;
        }

        /// <summary>
        /// 更新ボタンが押されたときに呼ばれます。
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private async void SubmitButtonClick(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("変更は即座に反映されます。変更しますか？", "確認", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {
                return;
            }

            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate };
            var client = new HttpClient(handler);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.viewModel.AccessToken);

            var tokenSource = new CancellationTokenSource();
            var url = new Uri($"{App.WebServerApiUrl}news/{this.viewModel.Category}/{this.viewModel.Id}");
            var dto = new NewsDto();
            dto.Title = this.viewModel.Title;
            dto.Author = this.viewModel.Author;
            dto.Outline = this.viewModel.Outline;
            dto.MediaURL = this.viewModel.MediaURL;

            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PatchAsync(url, content);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string location = response.Headers.Location.ToString();
                string[] locationArr = location.Split('/');
                string category = locationArr[locationArr.Length - 2];
                string id = locationArr[locationArr.Length - 1];
                this.viewModel.Result = $"{category}-{id}の記事を変更しました。";
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show(await response.Content.ReadAsStringAsync());
            }
        }
    }
}
