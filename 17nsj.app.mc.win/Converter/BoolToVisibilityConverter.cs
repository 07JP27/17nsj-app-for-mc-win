//----------------------------------------------------------------------
// <copyright file="BoolToVisibilityConverter.cs" company="17NSJ PR Dept">
// Copyright (c) 17NSJ PR Dept. All rights reserved.
// </copyright>
// <summary>BoolToVisibilityConverterクラス</summary>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace _17nsj.app.mc.win.Converter
{
    /// <summary>
    /// BoolToVisibilityConverterクラス
    /// </summary>
    public class BoolToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// 変換します。
        /// </summary>
        /// <param name="value">バインディング ソースによって生成された値</param>
        /// <param name="targetType">バインディング ターゲット プロパティの型</param>
        /// <param name="parameter">使用するコンバーター パラメーター</param>
        /// <param name="culture">コンバーターで使用するカルチャ</param>
        /// <returns>変換された値。メソッドが null を返す場合は、有効な null 値が使用されています。</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var v = (bool)value;
                return v ? Visibility.Visible : Visibility.Collapsed;
            }
            catch (InvalidCastException)
            {
                return Visibility.Collapsed;
            }
        }

        /// <summary>
        /// 逆変換します。
        /// </summary>
        /// <param name="value">バインディング ソースによって生成された値</param>
        /// <param name="targetType">バインディング ターゲット プロパティの型</param>
        /// <param name="parameter">使用するコンバーター パラメーター</param>
        /// <param name="culture">コンバーターで使用するカルチャ</param>
        /// <returns>変換された値。メソッドが null を返す場合は、有効な null 値が使用されています。</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
