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
        public void Scrap(List<string> url, int depth=1)
        {
            IsValidUrl(url);

            WebScrap engine = new WebScrap(url);

            if ( depth == 1 )
            {
                Indexs = 0;
                Words = 0;
            }
            else if (depth <= 3)
            {
                var pages = engine.scrapPages();

                MongoDBInstance.getInstance.Insert(pages);
                    
                Indexs += engine.nextUrls.Count;

                Words += engine.WordCount;

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
            try
            {
                return MongoDBInstance.getInstance.SelectByMatchWord(word);
            }
            catch
            {
                // Action if exception is launch
                return null;
            }
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
                // Action if exception is launch
                
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Url"></param>
        protected void IsValidUrl(List<string> Url )
        {
            List<string> output = new List<string>();

            foreach (string url in Url)
            {
                if (!UrlParser.checkURLFormat(url) || !UrlParser.checkURLStatus(url))
                    continue;
                else
                    output.Add(url);
            }

            Url.Clear();
            Url.AddRange(output);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IndexResult getIndexResult()
        {
            IndexResult indexR = new IndexResult()
            {
                pageIndexTotal = Indexs,
                pageWordsCount = Words
            };

            return indexR;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<Page> removeContent(List<Page> list)
        {
            List<Page> output = new List<Page>();
            foreach (Page p in list)
            {
                p.Content = "";
                output.Add(p);
            }

            return output;
        }

        public static int CountMatchWordIntoResult(string word, List<Page> searchResult)
        {
            foreach(Page site in searchResult)
                foreach(string sentence in site.Content.Split(' '))
                {
                   // site.seWordMatchs(  )
                }

            /*
            content.split(" ").forEach((word) => {
                this.numberOfOccurrences = content.match(new RegExp(word, "g")).length
            });
            */

            return 1;
        }
    }
}
