﻿//----------------------------------------------------------------------
// <copyright file="NewsViewerViewModel.cs" company="17NSJ PR Dept">
// Copyright (c) 17NSJ PR Dept. All rights reserved.
// </copyright>
// <summary>NewsViewerViewModelクラス</summary>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _17nsj.app.dto;
using _17nsj.app.mc.win.Models;
using Livet.EventListeners;

namespace _17nsj.app.mc.win.ViewModels
{
    /// <summary>
    /// NewsViewerViewModelクラス
    /// </summary>
    public class NewsViewerViewModel : ViewModelBase
    {
        /// <summary>
        /// ニュースカテゴリーリスト
        /// </summary>
        private ObservableCollection<NewsCategoryModel> newsCategoryList = new ObservableCollection<NewsCategoryModel>();

        /// <summary>
        /// オリジナルニュースリスト
        /// </summary>
        private ObservableCollection<NewsModel> newsList = new ObservableCollection<NewsModel>();

        /// <summary>
        /// フィルタされたニュースリスト
        /// </summary>
        private ObservableCollection<NewsModel> filteredNewsList = new ObservableCollection<NewsModel>();

        /// <summary>
        /// 選択中のニュース
        /// </summary>
        private NewsModel selectedNews = new NewsModel();

        /// <summary>
        /// 検索文字
        /// </summary>
        private string serchText;

        /// <summary>
        /// ニュースカテゴリーリストを取得または設定します。
        /// </summary>
        /// <value>ニュースカテゴリーリスト</value>
        public ObservableCollection<NewsCategoryModel> NewsCategoryList
        {
            get
            {
                return this.newsCategoryList;
            }

            set
            {
                if (this.newsCategoryList != value)
                {
                    this.newsCategoryList = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// オリジナルニュースリストを取得または設定します。
        /// </summary>
        /// <value>オリジナルニュースリスト</value>
        public ObservableCollection<NewsModel> NewsList
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
        /// フィルタされたニュースリストを取得または設定します。
        /// </summary>
        /// <value>フィルタされたニュースリスト</value>
        public ObservableCollection<NewsModel> FilteredNewsList
        {
            get
            {
                return this.filteredNewsList;
            }

            set
            {
                if (this.filteredNewsList != value)
                {
                    this.filteredNewsList = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// 選択中のニュースを取得または設定します。
        /// </summary>
        /// <value>選択中のニュース</value>
        public NewsModel SelectedNews
        {
            get
            {
                return this.selectedNews;
            }

            set
            {
                if (this.selectedNews != value)
                {
                    var oldNews = this.selectedNews;
                    this.selectedNews = value;
                    this.RaisePropertyChanged();

                    if (oldNews.SerialId != value.SerialId)
                    {
                        this.RaisePropertyChanged(nameof(this.SelectedSerialId));
                    }

                    if (oldNews.Author != value.Author)
                    {
                        this.RaisePropertyChanged(nameof(this.SelectedAuthor));
                    }

                    if (oldNews.Title != value.Title)
                    {
                        this.RaisePropertyChanged(nameof(this.SelectedTitle));
                    }

                    if (oldNews.Outline != value.Outline)
                    {
                        this.RaisePropertyChanged(nameof(this.SelectedOutline));
                    }

                    if (oldNews.MediaURL != value.MediaURL)
                    {
                        this.RaisePropertyChanged(nameof(this.SelectedMediaURL));
                    }

                    if (oldNews.RelationalURL != value.RelationalURL)
                    {
                        this.RaisePropertyChanged(nameof(this.SelectedRelationalURL));
                    }

                    if (oldNews.ThumbnailURL != value.ThumbnailURL)
                    {
                        this.RaisePropertyChanged(nameof(this.SelectedThumbnailURL));
                    }

                    if (oldNews.CreatedAt != value.CreatedAt)
                    {
                        this.RaisePropertyChanged(nameof(this.SelectedCreatedAt));
                    }

                    if (oldNews.CategoryName != value.CategoryName)
                    {
                        this.RaisePropertyChanged(nameof(this.SelectedCategoryName));
                    }

                    if (oldNews.Color != value.Color)
                    {
                        this.RaisePropertyChanged(nameof(this.SelectedColor));
                    }
                }
            }
        }

        /// <summary>
        /// 検索文字列を取得または設定します。
        /// </summary>
        /// <value>検索文字列</value>
        public string SerchText
        {
            get
            {
                return this.serchText;
            }

            set
            {
                if (this.serchText != value)
                {
                    this.serchText = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// 選択中のニュース情報のシリアルIDを取得します。
        /// </summary>
        /// <value>選択中のニュース情報のシリアルID</value>
        public string SelectedSerialId
        {
            get
            {
                return this.SelectedNews.SerialId;
            }
        }

        /// <summary>
        /// 選択中のニュース情報の著者を取得します。
        /// </summary>
        /// <value>選択中のニュース情報の著者</value>
        public string SelectedAuthor
        {
            get
            {
                return this.SelectedNews.Author;
            }
        }

        /// <summary>
        /// 選択中のニュース情報のタイトルを取得します。
        /// </summary>
        /// <value>選択中のニュース情報のタイトル</value>
        public string SelectedTitle
        {
            get
            {
                return this.SelectedNews.Title;
            }
        }

        /// <summary>
        /// 選択中のニュース情報の概要を取得します。
        /// </summary>
        /// <value>選択中のニュース情報の概要</value>
        public string SelectedOutline
        {
            get
            {
                return this.SelectedNews.Outline;
            }
        }

        /// <summary>
        /// 選択中のニュース情報のメディアURLを取得します。
        /// </summary>
        /// <value>選択中のニュース情報のメディアURL</value>
        public string SelectedMediaURL
        {
            get
            {
                return this.SelectedNews.MediaURL;
            }
        }

        /// <summary>
        /// 選択中のニュース情報の関連URLを取得します。
        /// </summary>
        /// <value>選択中のニュース情報の関連URL</value>
        public string SelectedRelationalURL
        {
            get
            {
                return this.SelectedNews.RelationalURL;
            }
        }

        /// <summary>
        /// 選択中のニュース情報のサムネイルURLを取得します。
        /// </summary>
        /// <value>選択中のニュース情報のサムネイルURL</value>
        public string SelectedThumbnailURL
        {
            get
            {
                return this.SelectedNews.ThumbnailURL;
            }
        }

        /// <summary>
        /// 選択中のニュース情報の配信日時を取得します。
        /// </summary>
        /// <value>選択中のニュース情報の配信日時</value>
        public DateTime SelectedCreatedAt
        {
            get
            {
                return this.SelectedNews.CreatedAt;
            }
        }

        /// <summary>
        /// 選択中のニュース情報のカテゴリー名を取得します。
        /// </summary>
        /// <value>選択中のニュース情報のカテゴリー名</value>
        public string SelectedCategoryName
        {
            get
            {
                return this.SelectedNews.CategoryName;
            }
        }

        /// <summary>
        /// 選択中のニュース情報のラベルカラーを取得します。
        /// </summary>
        /// <value>選択中のニュース情報のラベルカラー</value>
        public string SelectedColor
        {
            get
            {
                return this.SelectedNews.Color;
            }
        }
    }
}
