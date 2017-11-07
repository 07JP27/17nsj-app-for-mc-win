using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace _17nsj.app.dto
{
    public class AuthResultDto
    {
        [JsonProperty("access_token", NullValueHandling = NullValueHandling.Ignore)]
        public string Token { get; set; }
    }
}
