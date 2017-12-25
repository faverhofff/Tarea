using ApiTarea.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiTarea.Services
{
    public class Aplication
    {
        public int Indexs { get; private set; }

        public int Words { get; private set; }

        public Aplication()
        {            
           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="depth"></param>
        /// <returns></returns>
        public async Task Scrap(List<string> url, int depth=1)
        {
            IsValidUrl(url);

            WebScrap engine = new WebScrap(url);
            if (depth <= 3)
            {
                var pages = engine.scrapPages();

                MongoDBInstance.getInstance.Insert(pages);
                    
                Indexs += engine.nextUrls.Count;

                Scrap(engine.nextUrls, ++depth);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public List<Page> Search(string word)
        {
            return MongoDBInstance.getInstance.SelectByWord(word);
        }

        /// <summary>
        /// 
        /// </summary>
        public void RemoveIndexContent()
        {
            try
            {
                MongoDBInstance.getInstance.Remove();
            }
            catch
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Url"></param>
        protected void IsValidUrl(List<string> Url )
        {
            foreach (string url in Url)
            {
                if (!UrlParser.checkURLFormat(url))
                    throw new Exception("Invalid URL:" + url);

                if (!UrlParser.checkURLStatus(url))
                    throw new Exception("URL no response:" + url);
            }
        }

 
    }
}
