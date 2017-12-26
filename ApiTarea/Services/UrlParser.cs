using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
// using System.Web;

namespace ApiTarea.Services
{
  /// <summary>
  /// Summary description for UrlParser
  /// </summary>
  public class UrlParser
  {
        public UrlParser()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool checkURLFormat(string url)
        {
            Uri UriResult;

            return Uri.TryCreate(url, UriKind.Absolute, out UriResult) && (UriResult.Scheme == Uri.UriSchemeHttp || UriResult.Scheme == Uri.UriSchemeHttps);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool checkURLStatus(string url)
        {
            try
            {
                var client = new WebClient();
                client.OpenRead(url);
                return true;
            } 
            catch
            {
                return false;
            }
        }
  }
}