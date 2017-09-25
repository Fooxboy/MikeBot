
using System;
using System.Net;
using System.Collections.Generic;
using System.Text;

namespace MikeBot
{
    public static class Request
    {
        /// <summary>
        /// Запрос к API вконтакте 
        /// </summary>
        /// <param name="method"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static string Api(string method, string param)
        {

            WebClient client = new WebClient();

            string token = "bfa9879d97d107fad8968a8ec0e521ee1981be66a3f3c82c13976a9a6ebedf7fa18bc7f1d16f40a346b56";
            Debug.Waring($"\nЗапрос к методу {method}...");
            var url = $"https://api.vk.com/method/{method}?{param}&access_token={token}&v=5.68";
            client.Encoding = Encoding.UTF8;
            string json = client.DownloadString(url);
            //Console.WriteLine(json);
            return json;
        }

        /// <summary>
        /// Запрос к LongPoll Вконтакте.
        /// </summary>
        /// <param name="server"></param>
        /// <param name="key"></param>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static string LongPoll(string server, string key, string ts)
        {
            WebClient client = new WebClient();

            string url = $"https://{server}?act=a_check&key={key}&ts={ts}&wait=25&mode=2&version=2";
            client.Encoding = Encoding.UTF8;
            string json = client.DownloadString(url);
            return json;
        }
    }
}
