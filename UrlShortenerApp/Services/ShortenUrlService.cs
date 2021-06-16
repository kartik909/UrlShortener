using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using UrlShortenerApp.Interfaces;
using UrlShortenerApp.Models;

namespace UrlShortenerApp.Services
{
    /// <summary>
    /// ShortenUrl Service
    /// </summary>
    public class ShortenUrlService: IShortenUrlService
    {
        /// <summary>
        /// ShortenUrl Service Constructor
        /// </summary>
        public ShortenUrlService()
        {
                
        }

        /// <summary>
        /// GetShorternUrl
        /// </summary>
        /// <param name="longUrl">string</param>    
        /// <returns>string</returns>
        public async Task<string> GetShorternUrl(string longUrl)
        {
            // prepra request - if URL shortening service in the future then this request has to be change (parameter/Body/Url etc) 
            var url = Constants.CleanUriBaseUrl;
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "POST";
            httpRequest.ContentType = Constants.CleanUriContentTypeHeader;
            var data = string.Format(Constants.CleanUriParameter, Uri.EscapeUriString(longUrl));

            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                await streamWriter.WriteAsync(data).ConfigureAwait(false);
            }

            var link = new Response();
            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            if (httpResponse.StatusCode == HttpStatusCode.OK && httpResponse.GetResponseStream() != null)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = await streamReader.ReadToEndAsync().ConfigureAwait(false);
                    link = JsonConvert.DeserializeObject<Response>(
                        result);
                }
            }

            return link.Result;
        }
    }
}
