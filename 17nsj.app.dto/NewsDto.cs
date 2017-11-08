//----------------------------------------------------------------------
// <copyright file="NewsDto.cs" company="17NSJ PR Dept">
// Copyright (c) 17NSJ PR Dept. All rights reserved.
// </copyright>
// <summary>NewsDtoクラス</summary>
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
    /// NewsDtoクラス
    /// </summary>
    public class NewsDto
    {
        /// <summary>
        /// カテゴリーを取得または設定します。
        /// </summary>
        /// <value>ユーザーID</value>
        [JsonProperty("Category", NullValueHandling = NullValueHandling.Ignore)]
        public string Category { get; set; }

        /// <summary>
        /// 通し番号を取得または設定します。
        /// </summary>
        /// <value>通し番号</value>
        [JsonProperty("Id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>
        /// 著者を取得または設定します。
        /// </summary>
        /// <value>著者</value>
        [JsonProperty("Author", NullValueHandling = NullValueHandling.Ignore)]
        public string Author { get; set; }

        /// <summary>
        /// タイトルを取得または設定します。
        /// </summary>
        /// <value>タイトル</value>
        [JsonProperty("Title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        /// <summary>
        /// 概要を取得または設定します。
        /// </summary>
        /// <value>概要</value>
        [JsonProperty("Outline", NullValueHandling = NullValueHandling.Ignore)]
        public string Outline { get; set; }

        /// <summary>
        /// メディアURLを取得または設定します。
        /// </summary>
        /// <value>メディアURL</value>
        [JsonProperty("MediaURL", NullValueHandling = NullValueHandling.Ignore)]
        public string MediaURL { get; set; }

        /// <summary>
        /// 配信日時を取得または設定します。
        /// </summary>
        /// <value>配信日時</value>
        [JsonProperty("CreatedAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime CreatedAt { get; set; }
    }
}
