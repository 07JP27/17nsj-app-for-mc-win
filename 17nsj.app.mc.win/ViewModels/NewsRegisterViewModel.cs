//----------------------------------------------------------------------
// <copyright file="NewsRegisterViewModel.cs" company="17NSJ PR Dept">
// Copyright (c) 17NSJ PR Dept. All rights reserved.
// </copyright>
// <summary>NewsRegisterViewModelクラス</summary>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _17nsj.app.mc.win.Models;

namespace _17nsj.app.mc.win.ViewModels
{
    /// <summary>
    /// NewsRegisterViewModelクラス
    /// </summary>
    public class NewsRegisterViewModel : ViewModelBase
    {
        /// <summary>
        /// ニュースカテゴリーリスト
        /// </summary>
        private ObservableCollection<NewsCategoryModel> categoryList = new ObservableCollection<NewsCategoryModel>();

        /// <summary>
        /// ニュースカテゴリーリストを取得または設定します。
        /// </summary>
        /// <value>ニュースカテゴリーリスト</value>
        public ObservableCollection<NewsCategoryModel> CategoryList
        {
            get
            {
                return this.categoryList;
            }

            set
            {
                if (this.categoryList != value)
                {
                    this.categoryList = value;
                    this.RaisePropertyChanged();
                }
            }
        }
    }
}
