//----------------------------------------------------------------------
// <copyright file="NewsViewerViewModel.cs" company="17NSJ PR Dept">
// Copyright (c) 17NSJ PR Dept. All rights reserved.
// </copyright>
// <summary>NewsViewerViewModelクラス</summary>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _17nsj.app.dto;

namespace _17nsj.app.mc.win.ViewModels
{
    /// <summary>
    /// NewsViewerViewModelクラス
    /// </summary>
    public class NewsViewerViewModel : ViewModelBase
    {
        /// <summary>
        /// ニュースリスト
        /// </summary>
        private List<NewsDto> newsList = new List<NewsDto>();

        /// <summary>
        /// 選択中のニュース
        /// </summary>
        private NewsDto selectedNews;

        /// <summary>
        /// ニュースリストを取得または設定します。
        /// </summary>
        /// <value>ニュースリスト</value>
        public List<NewsDto> NewsList
        {
            get
            {
                return this.newsList;
            }

            set
            {
                if (this.newsList != value)
                {
                    this.newsList = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// 選択中のニュースを取得または設定します。
        /// </summary>
        /// <value>選択中のニュース</value>
        public NewsDto SelectedNews
        {
            get
            {
                return this.selectedNews;
            }

            set
            {
                if (this.selectedNews != value)
                {
                    this.selectedNews = value;
                    this.RaisePropertyChanged();
                }
            }
        }
    }
}
