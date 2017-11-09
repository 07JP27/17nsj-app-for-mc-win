//----------------------------------------------------------------------
// <copyright file="NewsRegisterViewModel.cs" company="17NSJ PR Dept">
// Copyright (c) 17NSJ PR Dept. All rights reserved.
// </copyright>
// <summary>NewsRegisterViewModelクラス</summary>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _17nsj.app.mc.win.Models;

namespace _17nsj.app.mc.win.ViewModels
{
    /// <summary>
    /// NewsRegisterViewModelクラス
    /// </summary>
    public class NewsRegisterViewModel : ViewModelBase
    {
        /// <summary>
        /// ニュースカテゴリーリスト
        /// </summary>
        private ObservableCollection<NewsCategoryModel> categoryList = new ObservableCollection<NewsCategoryModel>();

        /// <summary>
        /// 選択中のカテゴリー
        /// </summary>
        private NewsCategoryModel selectedCategory;

        /// <summary>
        /// タイトル
        /// </summary>
        private string title;

        /// <summary>
        /// 著者
        /// </summary>
        private string author;

        /// <summary>
        /// 概要
        /// </summary>
        private string outline;

        /// <summary>
        /// メディアURL
        /// </summary>
        private string mediaURL;

        /// <summary>
        /// 登録結果
        /// </summary>
        private string result;

        /// <summary>
        /// ニュースカテゴリーリストを取得または設定します。
        /// </summary>
        /// <value>ニュースカテゴリーリスト</value>
        public ObservableCollection<NewsCategoryModel> CategoryList
        {
            get
            {
                return this.categoryList;
            }

            set
            {
                if (this.categoryList != value)
                {
                    this.categoryList = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// カテゴリーを取得または設定します。
        /// </summary>
        /// <value>カテゴリー</value>
        public NewsCategoryModel SelectedCategory
        {
            get
            {
                return this.selectedCategory;
            }

            set
            {
                if (this.selectedCategory != value)
                {
                    this.selectedCategory = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// タイトルを取得または設定します。
        /// </summary>
        /// <value>タイトル</value>
        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                if (this.title != value)
                {
                    this.title = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// 著者を取得または設定します。
        /// </summary>
        /// <value>著者</value>
        public string Author
        {
            get
            {
                return this.author;
            }

            set
            {
                if (this.author != value)
                {
                    this.author = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// 概要を取得または設定します。
        /// </summary>
        /// <value>概要</value>
        public string Outline
        {
            get
            {
                return this.outline;
            }

            set
            {
                if (this.outline != value)
                {
                    this.outline = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// メディアURLを取得または設定します。
        /// </summary>
        /// <value>メディアURL</value>
        public string MediaURL
        {
            get
            {
                return this.mediaURL;
            }

            set
            {
                if (this.mediaURL != value)
                {
                    this.mediaURL = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// 登録結果を取得または設定します。
        /// </summary>
        /// <value>登録結果</value>
        public string Result
        {
            get
            {
                return this.result;
            }

            set
            {
                if (this.result != value)
                {
                    this.result = value;
                    this.RaisePropertyChanged();
                }
            }
        }
    }
}
