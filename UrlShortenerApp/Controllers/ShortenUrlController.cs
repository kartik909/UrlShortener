using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UrlShortenerApp.Interfaces;

namespace UrlShortenerApp.Controllers
{
    /// <summary>
    /// The ShortenUrlController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ShortenUrlController : ControllerBase
    {
        /// <summary>
        /// The ShortenUrlService
        /// </summary>
        public IShortenUrlService ShortenUrlService { get; set; }

        /// <summary>
        /// The ShortenUrlController Constructor
        /// </summary>
        public ShortenUrlController(IShortenUrlService shortenUrlService)
        {
            ShortenUrlService = shortenUrlService;
        }

        /// <summary>
        /// Post
        /// </summary>
        /// <param name="url">string</param>    
        /// <returns>string</returns>
        [HttpPost]
        public async Task<string> Post([FromBody] string url)
        {
            try
            {
                return await ShortenUrlService.GetShorternUrl(url).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "ERROR OCCURED- PLEASE CONTACT TECHNICAL TEAM OR TRY AGAIN AFTER SOMETIME";
            }
        }
    }
}