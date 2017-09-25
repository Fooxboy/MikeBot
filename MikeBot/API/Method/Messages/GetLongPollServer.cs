using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Newtonsoft.Json;

namespace MikeBot.API.Method.Messages
{
    public static class GetLongPollServer
    {
        public static Response<RootObject<Models.GetLongPollServer>> Start()
        {
            string json = Request.Api("messages.getLongPollServer", "lp_version=2");
            try
            {
                var ok = JsonConvert.DeserializeObject<RootObject<Models.GetLongPollServer>>(json);
                var resp = new Response<RootObject<Models.GetLongPollServer>>();
                resp.obj = ok;
                resp.error_code = 0;
                resp.error = null;
                return resp;
            } catch
            {
                var error_obj = JsonConvert.DeserializeObject<Models.Error>(json);
                var resp = new Response<RootObject<Models.GetLongPollServer>>();
                resp.obj = null;
                resp.error_code = 1;
                resp.error = error_obj;
                API.Error.Proccesing.Start(error_obj.error.error_code);
                return resp;
            }
        }
    }
}
