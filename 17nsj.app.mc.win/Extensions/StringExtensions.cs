//----------------------------------------------------------------------
// <copyright file="StringExtensions.cs" company="17NSJ PR Dept">
// Copyright (c) 17NSJ PR Dept. All rights reserved.
// </copyright>
// <summary>StringExtensionsクラス</summary>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17nsj.app.mc.win.Extensions
{
    /// <summary>
    /// StringExtensionsクラス
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// AND検索
        /// </summary>
        /// <param name="str">検索対象文字</param>
        /// <param name="needles">検索文字</param>
        /// <returns>含まれていればtrue</returns>
        public static bool ContainsAll(this string str, string[] needles)
        {
            foreach (string needle in needles)
            {
                if (!str.Contains(needle))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// OR検索
        /// </summary>
        /// <param name="str">検索対象文字</param>
        /// <param name="needles">検索文字</param>
        /// <returns>含まれていればtrue</returns>
        public static bool ContainsAny(this string str, string[] needles)
        {
            foreach (string needle in needles)
            {
                if (str.Contains(needle))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
