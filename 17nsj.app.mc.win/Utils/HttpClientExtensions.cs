//----------------------------------------------------------------------
// <copyright file="HttpClientExtensions.cs" company="17NSJ PR Dept">
// Copyright (c) 17NSJ PR Dept. All rights reserved.
// </copyright>
// <summary>HttpClientExtensionsクラス</summary>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace _17nsj.app.mc.win.Utils
{
    /// <summary>
    /// HttpClientExtensionsクラス
    /// </summary>
    public static class HttpClientExtensions
    {
        /// <summary>
        /// パッチ処理を行います。
        /// </summary>
        /// <param name="client">client</param>
        /// <param name="requestUri">requestUri</param>
        /// <param name="iContent">iContent</param>
        /// <returns>HttpResponseMessage</returns>
        public static async Task<HttpResponseMessage> PatchAsync(this HttpClient client, Uri requestUri, HttpContent iContent)
        {
            var method = new HttpMethod("PATCH");
            var request = new HttpRequestMessage(method, requestUri)
            {
                Content = iContent
            };
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                response = await client.SendAsync(request);
            }
            catch (TaskCanceledException e)
            {
                throw e;
            }

            return response;
        }
    }
}
