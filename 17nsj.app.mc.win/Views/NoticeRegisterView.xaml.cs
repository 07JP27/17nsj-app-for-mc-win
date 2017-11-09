﻿//----------------------------------------------------------------------
// <copyright file="NoticeRegisterView.xaml.cs" company="17NSJ PR Dept">
// Copyright (c) 17NSJ PR Dept. All rights reserved.
// </copyright>
// <summary>NoticeRegisterView.xaml の相互作用ロジック</summary>
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
    /// NoticeRegisterView.xaml の相互作用ロジック
    /// </summary>
    public partial class NoticeRegisterView : Window
    {
        /// <summary>
        /// ViewModel
        /// </summary>
        private NoticeRegisterViewModel viewModel;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public NoticeRegisterView()
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
            this.viewModel = this.DataContext as NoticeRegisterViewModel;
            this.viewModel.Author = this.viewModel.DisplayName;
        }

        /// <summary>
        /// 登録ボタンが押されたときに呼ばれます。
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private async void SubmitButtonClick(object sender, RoutedEventArgs e)
        {
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate };
            var client = new HttpClient(handler);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.viewModel.AccessToken);

            var tokenSource = new CancellationTokenSource();
            var url = new Uri($"{App.WebServerApiUrl}notices");
            var dto = new NoticeDto();
            dto.Author = this.viewModel.Author;
            dto.Title = this.viewModel.Title;
            dto.Outline = this.viewModel.Outline;
            dto.MediaURL = this.viewModel.MediaURL;
            dto.IsAvailable = true;

            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, content);

            if (response.StatusCode == HttpStatusCode.Created)
            {
                string location = response.Headers.Location.ToString();
                string[] locationArr = location.Split('/');
                string id = locationArr[locationArr.Length - 1];
                this.viewModel.Result = $"ID{id}でお知らせを登録しました。。";

                this.viewModel.Title = string.Empty;
                this.viewModel.Outline = string.Empty;
                this.viewModel.MediaURL = string.Empty;
            }
            else
            {
                MessageBox.Show(await response.Content.ReadAsStringAsync());
            }
        }
    }
}
