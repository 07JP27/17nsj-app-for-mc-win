//----------------------------------------------------------------------
// <copyright file="UserEditViewModel.cs" company="17NSJ PR Dept">
// Copyright (c) 17NSJ PR Dept. All rights reserved.
// </copyright>
// <summary>UserEditViewModelクラス</summary>
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
    /// UserEditViewModelクラス
    /// </summary>
    public class UserEditViewModel : ViewModelBase
    {
        /// <summary>
        /// ユーザーID
        /// </summary>
        private string targetUserId;

        /// <summary>
        /// 表示名
        /// </summary>
        private string targetDisplayName;

        /// <summary>
        /// 読み取り権限フラグ
        /// </summary>
        private bool targetCanRead;

        /// <summary>
        /// 書き込み権限フラグ
        /// </summary>
        private bool targetCanWrite;

        /// <summary>
        /// 管理者フラグ
        /// </summary>
        private bool targetIsAdmin;

        /// <summary>
        /// ユーザーIDを取得または設定します。
        /// </summary>
        /// <value>ユーザーID</value>
        public string TargetUserId
        {
            get
            {
                return this.targetUserId;
            }

            set
            {
                if (this.targetUserId != value)
                {
                    this.targetUserId = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// 表示名を取得または設定します。
        /// </summary>
        /// <value>表示名</value>
        public string TargetDisplayName
        {
            get
            {
                return this.targetDisplayName;
            }

            set
            {
                if (this.targetDisplayName != value)
                {
                    this.targetDisplayName = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// 読み取り権限フラグを取得または設定します。
        /// </summary>
        /// <value>読み取り権限フラグ</value>
        public bool TargetCanRead
        {
            get
            {
                return this.targetCanRead;
            }

            set
            {
                if (this.targetCanRead != value)
                {
                    this.targetCanRead = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// 書き込み権限フラグを取得または設定します。
        /// </summary>
        /// <value>書き込み権限フラグ</value>
        public bool TargetCanWrite
        {
            get
            {
                return this.targetCanWrite;
            }

            set
            {
                if (this.targetCanWrite != value)
                {
                    this.targetCanWrite = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// 管理者フラグを取得または設定します。
        /// </summary>
        /// <value>管理者フラグ</value>
        public bool TargetIsAdmin
        {
            get
            {
                return this.targetIsAdmin;
            }

            set
            {
                if (this.targetIsAdmin != value)
                {
                    this.targetIsAdmin = value;
                    this.RaisePropertyChanged();
                }
            }
        }
    }
}
