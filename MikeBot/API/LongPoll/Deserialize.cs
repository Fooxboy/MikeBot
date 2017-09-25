using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MikeBot.API.LongPoll
{
    public struct Deserialize
    {
        /// <summary>
        /// Десериализация ответа лонг пулла.
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public Response<RootObject> Run(string json)
        {
            try
            {
                var obj = JsonConvert.DeserializeObject<RootObject>(json);
                Global.ts = obj.ts;
                var resp = new Response<RootObject>();
                resp.obj = obj;
                resp.error_code = 0;
                resp.error = null;
                return resp;
            }catch
            {
                var error_obj = JsonConvert.DeserializeObject<LongPoll.Deserialize.ErrorObject>(json);
                var resp = new Response<RootObject>();
                resp.obj = null;
                resp.error_code = 2;
                resp.LongPollError = error_obj;
                LongPoll.Errors ers = new Errors();
                ers.proccesing(error_obj.falied, error_obj);
                return resp;
            }

        }

        public class RootObject
        {
            public string ts { get; set; }
            public List<List<object>> updates { get; set; }
        }

        public ErrorObject Error(string json)
        {
            return JsonConvert.DeserializeObject<ErrorObject>(json);
        }

        public class ErrorObject
        {
            public string falied { get; set; }
            public string ts { get; set; }
            public int min_version { get; set; }
            public int max_version { get; set; }
        }

    }
}
