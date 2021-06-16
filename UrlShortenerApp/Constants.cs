using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortenerApp
{
    /// <summary>
    /// The Constants
    /// </summary>
    public class Constants
    {

        /// <summary>
        /// The CleanUriBaseUrl
        /// </summary>
        public const string CleanUriBaseUrl = "https://cleanuri.com/api/v1/shorten";

        /// <summary>
        /// The CleanUriContentTypeHeader
        /// </summary>
        public const string CleanUriContentTypeHeader = "application/x-www-form-urlencoded";

        /// <summary>
        /// The CleanUriParameter
        /// </summary>
        public const string CleanUriParameter = "url={0}";
    }
}
