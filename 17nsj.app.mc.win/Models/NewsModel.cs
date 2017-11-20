//----------------------------------------------------------------------
// <copyright file="NewsModel.cs" company="17NSJ PR Dept">
// Copyright (c) 17NSJ PR Dept. All rights reserved.
// </copyright>
// <summary>NewsModelクラス</summary>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17nsj.app.mc.win.Models
{
    /// <summary>
    /// NewsModelクラス
    /// </summary>
    public class NewsModel : NotificationObject
    {
        /// <summary>
        /// カテゴリー
        /// </summary>
        private char category;

        /// <summary>
        /// 通し番号
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
        private string mediaURL;

        /// <summary>
        /// 配信日
        /// </summary>
        private DateTime createdAt;

        /// <summary>
        /// カテゴリー名1
        /// </summary>
        private string categoryName;

        /// <summary>
        /// ラベルカラー
        /// </summary>
        private string color;

        /// <summary>
        /// カテゴリーを取得または設定します。
        /// </summary>
        /// <value>カテゴリー</value>
        public char Category
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
        /// 通し番号を取得または設定します。
        /// </summary>
        /// <value>通し番号</value>
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
        /// 配信日時を取得または設定します。
        /// </summary>
        /// <value>配信日時</value>
        public DateTime CreatedAt
        {
            get
            {
                return this.createdAt;
            }

            set
            {
                if (this.createdAt != value)
                {
                    this.createdAt = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// カテゴリー名を取得または設定します。
        /// </summary>
        /// <value>カテゴリー名</value>
        public string CategoryName
        {
            get
            {
                return this.categoryName;
            }

            set
            {
                if (this.categoryName != value)
                {
                    this.categoryName = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// ラベルカラーを取得または設定します。
        /// </summary>
        /// <value>カテゴリー名</value>
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
        /// カテゴリと通し番号を結合したシリアルIDを取得します。
        /// </summary>
        /// <value>シリアルID</value>
        public string SerialId
        {
            get
            {
                return this.Category + "-" + this.Id;
            }
        }
    }
}
