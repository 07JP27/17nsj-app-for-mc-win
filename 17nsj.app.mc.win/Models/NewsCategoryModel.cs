//----------------------------------------------------------------------
// <copyright file="NewsCategoryModel.cs" company="17NSJ PR Dept">
// Copyright (c) 17NSJ PR Dept. All rights reserved.
// </copyright>
// <summary>NewsCategoryModelクラス</summary>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17nsj.app.mc.win.Models
{
    /// <summary>
    /// NewsCategoryModelクラス
    /// </summary>
    public class NewsCategoryModel : NotificationObject
    {
        /// <summary>
        /// カテゴリー
        /// </summary>
        private string category;

        /// <summary>
        /// カテゴリー名
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
    }
}
