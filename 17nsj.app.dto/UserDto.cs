//----------------------------------------------------------------------
// <copyright file="UserDto.cs" company="17NSJ PR Dept">
// Copyright (c) 17NSJ PR Dept. All rights reserved.
// </copyright>
// <summary>UserDtoクラス</summary>
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
    /// UserDtoクラス
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// ユーザーIDを取得または設定します。
        /// </summary>
        /// <value>ユーザーID</value>
        [JsonProperty("UserId", NullValueHandling = NullValueHandling.Ignore)]
        public string UserId { get; set; }

        /// <summary>
        /// 表示名を取得または設定します。
        /// </summary>
        /// <value>表示名</value>
        [JsonProperty("DisplayName", NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayName { get; set; }

        /// <summary>
        /// パスワードを取得または設定します。
        /// </summary>
        /// <value>パスワード</value>
        [JsonProperty("Password", NullValueHandling = NullValueHandling.Ignore)]
        public string Password { get; set; }

        /// <summary>
        /// 管理者フラグを取得または設定します。
        /// </summary>
        /// <value>管理者フラグ</value>
        [JsonProperty("IsAdmin", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsAdmin { get; set; }

        /// <summary>
        /// 読み取り権限フラグを取得または設定します。
        /// </summary>
        /// <value>読み取り権限フラグ</value>
        [JsonProperty("CanRead", NullValueHandling = NullValueHandling.Ignore)]
        public bool CanRead { get; set; }

        /// <summary>
        /// 書き込み権限フラグを取得または設定します。
        /// </summary>
        /// <value>書き込み権限フラグ</value>
        [JsonProperty("CanWrite", NullValueHandling = NullValueHandling.Ignore)]
        public bool CanWrite { get; set; }

        /// <summary>
        /// 有効フラグを取得または設定します。
        /// </summary>
        /// <value>有効フラグ</value>
        [JsonProperty("IsAvailable", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsAvailable { get; set; }
    }
}
