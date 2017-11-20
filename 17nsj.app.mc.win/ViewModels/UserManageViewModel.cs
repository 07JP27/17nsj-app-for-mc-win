//----------------------------------------------------------------------
// <copyright file="UserManageViewModel.cs" company="17NSJ PR Dept">
// Copyright (c) 17NSJ PR Dept. All rights reserved.
// </copyright>
// <summary>UserManageViewModelクラス</summary>
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
    /// UserManageViewModelクラス
    /// </summary>
    public class UserManageViewModel : ViewModelBase
    {
        /// <summary>
        /// ユーザーリスト
        /// </summary>
        private ObservableCollection<UserModel> userList;

        /// <summary>
        /// フィルタされたユーザー
        /// </summary>
        private ObservableCollection<UserModel> filteredUserList;

        /// <summary>
        /// 選択中のユーザー
        /// </summary>
        private UserModel selectedUser;

        /// <summary>
        /// ユーザーリストを取得または設定します。
        /// </summary>
        /// <value>ユーザーリスト</value>
        public ObservableCollection<UserModel> UserList
        {
            get
            {
                return this.userList;
            }

            set
            {
                if (this.userList != value)
                {
                    this.userList = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// フィルターされたユーザーリストを取得または設定します。
        /// </summary>
        /// <value>フィルターされたユーザーリスト</value>
        public ObservableCollection<UserModel> FilteredUserList
        {
            get
            {
                return this.filteredUserList;
            }

            set
            {
                if (this.filteredUserList != value)
                {
                    this.filteredUserList = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// 選択中のユーザーを取得または設定します。
        /// </summary>
        /// <value>選択中のユーザー</value>
        public UserModel SelectedUser
        {
            get
            {
                return this.selectedUser;
            }

            set
            {
                if (this.selectedUser != value)
                {
                    var oldUser = this.selectedUser;
                    this.selectedUser = value;
                    this.RaisePropertyChanged();
                }
            }
        }
    }
}
