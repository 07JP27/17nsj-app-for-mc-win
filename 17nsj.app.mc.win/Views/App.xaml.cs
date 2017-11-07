//----------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="17NSJ PR Dept">
// Copyright (c) 17NSJ PR Dept. All rights reserved.
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
        /// Webサーバートークンurl
        /// </summary>
        private static string webServerTokenUrl;

        /// <summary>
        /// WebAPIサーバーurl
        /// </summary>
        private static string webServerApiUrl;

        /// <summary>
        /// WebサーバートークンURLを取得します。
        /// </summary>
        /// <value>WebサーバートークンURL</value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Justification ="文字列のままでよい")]
        public static string WebServerTokenUrl
        {
            get
            {
                return webServerTokenUrl;
            }
        }

        /// <summary>
        /// WebAPIサーバーURLを取得します。
        /// </summary>
        /// <value>WebAPIサーバーURL</value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Justification = "文字列のままでよい")]
        public static string WebServerApiUrl
        {
            get
            {
                return webServerApiUrl;
            }
        }

        /// <summary>
        /// スタートアップ時に呼ばれます。
        /// </summary>
        /// <param name="e">e</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            webServerApiUrl = ConfigurationManager.AppSettings["WebServerUrl"] + "api/";
            webServerTokenUrl = ConfigurationManager.AppSettings["WebServerUrl"] + "token";

            var loginView = new LoginView();
            loginView.DataContext = new LoginViewModel();

            loginView.Show();
        }
    }
}
