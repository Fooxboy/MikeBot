using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace YandexAPI.Translate
{
    public static class Request
    {

        public static string API(string text, string lang)
        {
            WebClient client = new WebClient();

            string token = "trnsl.1.1.20170920T160548Z.c18aab71890aa273.817c05a99b4f32d62bda3e04f3ab886d8c1f84f4";
            var url = $"https://translate.yandex.net/api/v1.5/tr.json/translate?key={token}&text={text}&lang={lang}&format=plain&options=0";
            client.Encoding = Encoding.UTF8;
            string json = client.DownloadString(url);
            //Console.WriteLine(json);
            return json;
        }
    }
}
