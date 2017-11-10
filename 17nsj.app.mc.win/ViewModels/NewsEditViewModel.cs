//----------------------------------------------------------------------
// <copyright file="NewsEditViewModel.cs" company="17NSJ PR Dept">
// Copyright (c) 17NSJ PR Dept. All rights reserved.
// </copyright>
// <summary>NewsEditViewModelクラス</summary>
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
    /// NewsEditViewModelクラス
    /// </summary>
    public class NewsEditViewModel : ViewModelBase
    {
        /// <summary>
        /// 更新結果
        /// </summary>
        private string result;

        /// <summary>
        /// ラベルカラー
        /// </summary>
        private string color;

        /// <summary>
        /// カテゴリ
        /// </summary>
        private string category;

        /// <summary>
        /// ID
        /// </summary>
        private int id;

        /// <summary>
        /// 著者
        /// </summary>
        private string author;

        /// <summary>
        /// タイトル
        /// </summary>
        private string title;

        /// <summary>
        /// 概要
        /// </summary>
        private string outline;

        /// <summary>
        /// メディアURL
        /// </summary>
        private string medhiaUrl;

        /// <summary>
        /// 更新結果を取得または設定します。
        /// </summary>
        /// <value>更新結果</value>
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

        /// <summary>
        /// ラベルカラーを取得または設定します。
        /// </summary>
        /// <value>ラベルカラー</value>
        public string Color
        {
            get
            {
                return this.color;
            }

            set
            {
                if (this.color != value)
                {
                    this.color = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// カテゴリーを取得または設定します。
        /// </summary>
        /// <value>カテゴリー</value>
        public string Category
        {
            get
            {
                return this.category;
            }

            set
            {
                if (this.category != value)
                {
                    this.category = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// IDを取得または設定します。
        /// </summary>
        /// <value>ID</value>
        public int Id
        {
            get
            {
                return this.id;
            }

            set
            {
                if (this.id != value)
                {
                    this.id = value;
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
                return this.medhiaUrl;
            }

            set
            {
                if (this.medhiaUrl != value)
                {
                    this.medhiaUrl = value;
                    this.RaisePropertyChanged();
                }
            }
        }
    }
}
