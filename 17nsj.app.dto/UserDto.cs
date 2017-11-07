﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace _17nsj.app.dto
{
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
        /// 管理者フラグを取得または設定します。
        /// </summary>
        /// <value>管理者フラグ</value>
        [JsonProperty("IsAdmin", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsAdmin { get; set; }
    }
}
