using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UrlShortenerApp.Models
{
    public class Response
    {
        [JsonProperty("result_url")]
        public string Result { get; set; }
    }
}
