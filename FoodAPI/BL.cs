using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FoodAPI
{
    public class BL
    {
        public const string APIKeyParam = "q1OCvAlrk1RtsmKlktt0vljQWKW0tymiOiZqPNAV";
        private const string URL = "http://api.nal.usda.gov/ndb/list?format={0}&lt=f&max={1}&offset={2}&sort=n&api_key={3}";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="format">format type</param>
        /// <param name="max">max value</param>
        /// <param name="offset">offset value</param>
        /// <returns></returns>
        public static string Search(string format = "json", int max = 500 ,int offset = 0)
        {
            string strResponse = String.Empty;
            bool getItems = true;
           
            while (getItems)
            {
                string urlWithParams = string.Format(URL, format, max, offset, APIKeyParam);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlWithParams);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream resStream = response.GetResponseStream();
                
                using (StreamReader sr = new StreamReader(resStream))
                {
                    strResponse = sr.ReadToEnd();
                }

                offset += max;
                RootObject ro = JsonConvert.DeserializeObject<RootObject>(strResponse);

                foreach (Item item in ro.list.item)
                {                    
                    // CALL BL TO INSERT INTO SQL
                }

                getItems = ro.list.total != 0;
            }

            return strResponse;
        }

    }
}
