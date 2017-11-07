//----------------------------------------------------------------------
// <copyright file="ViewModelBase.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// <summary>LoginViewクラス</summary>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _17nsj.app.mc.win.Models;

namespace _17nsj.app.mc.win.ViewModels
{
    /// <summary>
    /// ViewModelBaseクラス
    /// </summary>
    public class ViewModelBase : NotificationObject
    {
        /// <summary>
        /// ユーザーID
        /// </summary>
        private string userId;

        /// <summary>
        /// 表示名
        /// </summary>
        private string displayName;

        /// <summary>
        /// アクセストークン
        /// </summary>
        private string accessToken;

        /// <summary>
        /// ユーザーIDを取得または設定します。
        /// </summary>
        /// <value>ユーザーID</value>
        public string UserId
        {
            get
            {
                return this.userId;
            }

            set
            {
                if (this.userId != value)
                {
                    this.userId = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// 表示名を取得または設定します。
        /// </summary>
        /// <value>表示名</value>
        public string DisplayName
        {
            get
            {
                return this.displayName;
            }

            set
            {
                if (this.displayName != value)
                {
                    this.displayName = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// アクセストークンを取得または設定します。
        /// </summary>
        /// <value>アクセストークン</value>
        public string AccessToken
        {
            get
            {
                return this.accessToken;
            }

            set
            {
                if (this.accessToken != value)
                {
                    this.accessToken = value;
                    this.RaisePropertyChanged();
                }
            }
        }
    }
}
