using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeAPI
{
    public class BL
    {
        public const string APIKeyParam = "key=AIzaSyCZZ6WWHLLtKajEpOVZdSyKseGQHgHqIVk";
        private const string URL = "https://www.googleapis.com/youtube/v3/search?part=snippet";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="q">Search value</param>
        /// <param name="maxResults"></param>
        /// <param name="type">Video/Channel etc.</param>
        /// <returns></returns>
        public static string Search(string q, int maxResults = 15, string type = "video")
        {
            string maxResultsParam = "maxResults=" + maxResults.ToString();
            string qParam = "q=" + q;
            string typeParam = "type=" + type;
            string urlWithParams = URL + "&" + maxResultsParam + "&" + qParam + "&" + typeParam + "&" + APIKeyParam;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlWithParams);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resStream = response.GetResponseStream();

            string strResponse;
            using(StreamReader sr = new StreamReader(resStream))
            {
                strResponse = sr.ReadToEnd();
            }

            return strResponse;
        }

    }
}
