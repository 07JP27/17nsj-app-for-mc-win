//----------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// <summary>Appクラス</summary>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using _17nsj.app.mc.win.ViewModels;
using _17nsj.app.mc.win.Views;

namespace _17nsj.app.mc.win.Views
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// スタートアップ時に呼ばれます。
        /// </summary>
        /// <param name="e">e</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var loginView = new LoginView();
            loginView.DataContext = new LoginViewModel();

            loginView.Show();
        }
    }
}
