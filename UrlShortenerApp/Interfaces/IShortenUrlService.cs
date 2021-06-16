using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortenerApp.Interfaces
{
    /// <summary>
    /// ShortenUrl Interface
    /// </summary>
    public interface IShortenUrlService
    {
        /// <summary>
        /// GetShorternUrl
        /// </summary>
        /// <param name="longUrl">string</param>    
        /// <returns>string</returns>
        Task<string> GetShorternUrl(string longUrl);
    }
}
