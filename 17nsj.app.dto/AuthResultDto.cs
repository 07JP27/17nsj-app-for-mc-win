//----------------------------------------------------------------------
// <copyright file="AuthResultDto.cs" company="17NSJ PR Dept">
// Copyright (c) 17NSJ PR Dept. All rights reserved.
// </copyright>
// <summary>AuthResultDtoクラス</summary>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace _17nsj.app.dto
{
    /// <summary>
    /// AuthResultDtoクラス
    /// </summary>
    public class AuthResultDto
    {
        /// <summary>
        /// アクセストークンを取得または設定します。
        /// </summary>
        /// <value>アクセストークン</value>
        [JsonProperty("access_token", NullValueHandling = NullValueHandling.Ignore)]
        public string Token { get; set; }
    }
}
