//----------------------------------------------------------------------
// <copyright file="UserModel.cs" company="17NSJ PR Dept">
// Copyright (c) 17NSJ PR Dept. All rights reserved.
// </copyright>
// <summary>UserModelクラス</summary>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17nsj.app.mc.win.Models
{
    /// <summary>
    /// UserModelクラス
    /// </summary>
    public class UserModel : NotificationObject
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
        /// 管理者フラグ
        /// </summary>
        private bool isAdmin;

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
        /// 管理者フラグを取得または設定します。
        /// </summary>
        /// <value>管理者フラグ</value>
        public bool IsAdmin
        {
            get
            {
                return this.isAdmin;
            }

            set
            {
                if (this.isAdmin != value)
                {
                    this.isAdmin = value;
                    this.RaisePropertyChanged();
                }
            }
        }
    }
}
