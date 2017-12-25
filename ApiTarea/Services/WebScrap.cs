using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using ApiTarea.Models;
using static ApiTarea.Services.LinkFinder;

namespace ApiTarea.Services
{
    /// <summary>
    /// Descripción breve de WebScrap
    /// </summary>
    /// 
    public class WebScrap 
    {
        public List<string> MainURL { get; private set; } = new List<string>();

        public List<string> nextUrls { get; private set; } = new List<string>();

        private WebClient _Client { get; set; } = new WebClient();

        private string _Buffer = "";

        protected WebScrap() { }

        public WebScrap(string url)
        {
            MainURL.Add(url);
        }

        public WebScrap(List<string> url)
        {
            MainURL.AddRange(url);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        protected Page scrapPage( string url )
        {
            _Buffer = _Client.DownloadString(url);

            foreach (LinkItem link in LinkFinder.Find(_Buffer)) 
                nextUrls.Add(link.Href);

            Page row = new Page();
            row.Id = Guid.NewGuid();
            row.Title = ""; //buscar expresion regular de TITLE
            row.Content = _Buffer; // convertir html to text
            row.Url = url;

            return row;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Page> scrapPages()
        {
            List<Page> _result = new List<Page>();

            foreach (string url in MainURL)
                _result.Add( this.scrapPage(url) );

            return _result;
        }

 
    }
}