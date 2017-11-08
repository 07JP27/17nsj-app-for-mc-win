//----------------------------------------------------------------------
// <copyright file="NewsCategoryDto.cs" company="17NSJ PR Dept">
// Copyright (c) 17NSJ PR Dept. All rights reserved.
// </copyright>
// <summary>NewsCategoryDtoクラス</summary>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace _17nsj.app.dto
{
    /// <summary>
    /// NewsCategoryDtoクラス
    /// </summary>
    public class NewsCategoryDto
    {
        /// <summary>
        /// カテゴリーを取得または設定します。
        /// </summary>
        /// <value>カテゴリー</value>
        [JsonProperty("Category", NullValueHandling = NullValueHandling.Ignore)]
        public string Category { get; set; }

        /// <summary>
        /// カテゴリー名を取得または設定します。
        /// </summary>
        /// <value>カテゴリー名</value>
        [JsonProperty("CategoryName", NullValueHandling = NullValueHandling.Ignore)]
        public string CategoryName { get; set; }

        /// <summary>
        /// ラベルカラーを取得または設定します。
        /// </summary>
        /// <value>ラベルカラー</value>
        [JsonProperty("Color", NullValueHandling = NullValueHandling.Ignore)]
        public string Color { get; set; }
    }
}
