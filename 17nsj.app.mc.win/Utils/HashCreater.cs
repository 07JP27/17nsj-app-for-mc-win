//----------------------------------------------------------------------
// <copyright file="HashCreater.cs" company="17NSJ PR Dept">
// Copyright (c) 17NSJ PR Dept. All rights reserved.
// </copyright>
// <summary>HashCreaterクラス</summary>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _17nsj.app.mc.win.Utils
{
    /// <summary>
    /// HashCreaterクラス
    /// </summary>
    public class HashCreater
    {
        /// <summary>
        /// SHA256アルゴリズムによるハッシュを作成します。
        /// </summary>
        /// <param name="input">ハッシュを作成する対象の文字列。</param>
        /// <returns>16進表記のハッシュ文字列。アルファベットは小文字です。</returns>
        public string CreateSHA256Hash(string input)
        {
            byte[] data = Encoding.UTF8.GetBytes(input);
            byte[] hash = null;

            using (var sha256 = new SHA256CryptoServiceProvider())
            {
                hash = sha256.ComputeHash(data);
            }

            var sb = new StringBuilder();

            for (int index = 0; index < hash.Length; index++)
            {
                sb.Append(hash[index].ToString("x2", Thread.CurrentThread.CurrentCulture));
            }

            string result = sb.ToString();

            return result;
        }
    }
}
