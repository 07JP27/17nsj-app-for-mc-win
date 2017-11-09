//----------------------------------------------------------------------
// <copyright file="NoticesViewerViewModel.cs" company="17NSJ PR Dept">
// Copyright (c) 17NSJ PR Dept. All rights reserved.
// </copyright>
// <summary>NoticesViewerViewModelクラス</summary>
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
using Livet.EventListeners;

namespace _17nsj.app.mc.win.ViewModels
{
    /// <summary>
    /// NoticesViewerViewModelクラス
    /// </summary>
    public class NoticesViewerViewModel : ViewModelBase
    {
        /// <summary>
        /// お知らせリスト
        /// </summary>
        private ObservableCollection<NoticeModel> noticeList = new ObservableCollection<NoticeModel>();

        /// <summary>
        /// 選択中のお知らせ
        /// </summary>
        private NoticeModel selectedNotice = new NoticeModel();

        /// <summary>
        /// お知らせリストを取得または設定します。
        /// </summary>
        /// <value>お知らせリスト</value>
        public ObservableCollection<NoticeModel> NoticeList
        {
            get
            {
                return this.noticeList;
            }

            set
            {
                if (this.noticeList != value)
                {
                    this.noticeList = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// 選択中のお知らせを取得または設定します。
        /// </summary>
        /// <value>選択中のお知らせ</value>
        public NoticeModel SelectedNotice
        {
            get
            {
                return this.selectedNotice;
            }

            set
            {
                if (this.selectedNotice != value)
                {
                    var oldnotice = this.selectedNotice;
                    this.selectedNotice = value;
                    this.RaisePropertyChanged();

                    if (oldnotice.Id != value.Id)
                    {
                        this.RaisePropertyChanged(nameof(this.SelectedId));
                    }

                    if (oldnotice.Author != value.Author)
                    {
                        this.RaisePropertyChanged(nameof(this.SelectedAuthor));
                    }

                    if (oldnotice.Title != value.Title)
                    {
                        this.RaisePropertyChanged(nameof(this.SelectedTitle));
                    }

                    if (oldnotice.Outline != value.Outline)
                    {
                        this.RaisePropertyChanged(nameof(this.SelectedOutline));
                    }

                    if (oldnotice.MediaURL != value.MediaURL)
                    {
                        this.RaisePropertyChanged(nameof(this.SelectedMediaURL));
                    }

                    if (oldnotice.CreatedAt != value.CreatedAt)
                    {
                        this.RaisePropertyChanged(nameof(this.SelectedCreatedAt));
                    }
                }
            }
        }

        /// <summary>
        /// 選択中のお知らせ情報のIDを取得します。
        /// </summary>
        /// <value>選択中のお知らせ情報のID</value>
        public string SelectedId
        {
            get
            {
                return this.selectedNotice.Id;
            }
        }

        /// <summary>
        /// 選択中のお知らせ情報の発信者を取得します。
        /// </summary>
        /// <value>選択中のお知らせ情報の発信者</value>
        public string SelectedAuthor
        {
            get
            {
                return this.selectedNotice.Author;
            }
        }

        /// <summary>
        /// 選択中のお知らせ情報のタイトルを取得します。
        /// </summary>
        /// <value>選択中のお知らせ情報のタイトル</value>
        public string SelectedTitle
        {
            get
            {
                return this.selectedNotice.Title;
            }
        }

        /// <summary>
        /// 選択中のお知らせ情報の概要を取得します。
        /// </summary>
        /// <value>選択中のお知らせ情報の概要</value>
        public string SelectedOutline
        {
            get
            {
                return this.selectedNotice.Outline;
            }
        }

        /// <summary>
        /// 選択中のお知らせ情報のメディアURLを取得します。
        /// </summary>
        /// <value>選択中のお知らせ情報のメディアURL</value>
        public string SelectedMediaURL
        {
            get
            {
                return this.selectedNotice.MediaURL;
            }
        }

        /// <summary>
        /// 選択中のお知らせ情報の配信日時を取得します。
        /// </summary>
        /// <value>選択中のお知らせ情報の配信日時</value>
        public DateTime SelectedCreatedAt
        {
            get
            {
                return this.selectedNotice.CreatedAt;
            }
        }
    }
}
