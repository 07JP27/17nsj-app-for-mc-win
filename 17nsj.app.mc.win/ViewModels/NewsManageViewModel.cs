//----------------------------------------------------------------------
// <copyright file="NewsManageViewModel.cs" company="17NSJ PR Dept">
// Copyright (c) 17NSJ PR Dept. All rights reserved.
// </copyright>
// <summary>NewsManageViewModelクラス</summary>
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

namespace _17nsj.app.mc.win.ViewModels
{
    /// <summary>
    /// NewsManageViewModelクラス
    /// </summary>
    public class NewsManageViewModel : ViewModelBase
    {
        /// <summary>
        /// ニュースカテゴリーリスト
        /// </summary>
        private ObservableCollection<NewsCategoryModel> newsCategoryList = new ObservableCollection<NewsCategoryModel>();

        /// <summary>
        /// 選択中のニュースカテゴリー
        /// </summary>
        private NewsCategoryModel selectedNewsCategory;

        /// <summary>
        /// ニュースリスト
        /// </summary>
        private ObservableCollection<NewsModel> newsList = new ObservableCollection<NewsModel>();

        /// <summary>
        /// フィルタされたニュースリスト
        /// </summary>
        private ObservableCollection<NewsModel> filteredNewsList = new ObservableCollection<NewsModel>();

        /// <summary>
        /// 選択中のニュース
        /// </summary>
        private NewsModel selectedNews;

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
        /// 選択中のニュースカテゴリーを取得または設定します。
        /// </summary>
        /// <value>選択中のニュースカテゴリー</value>
        public NewsCategoryModel SelectedNewsCategory
        {
            get
            {
                return this.selectedNewsCategory;
            }

            set
            {
                if (this.selectedNewsCategory != value)
                {
                    this.selectedNewsCategory = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// ニュースリストを取得または設定します。
        /// </summary>
        /// <value>ニュースリスト</value>
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
        /// フィルターされたニュースリストを取得または設定します。
        /// </summary>
        /// <value>フィルターされたニュースリスト</value>
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
                }
            }
        }
    }
}
