using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MikeBot.API.Method.Messages
{
    public static class Send
    {

        public static Response<string> Start(string id = "", string domain = "", string message = "", string forward_messages = "", string attachment = "", string sticker_id = "")
        {
            string json = Request.Api("messages.send", $"peer_id={id}&domain={domain}&message={message}&forward_messages={forward_messages}&sticker_id={sticker_id}&attachment={attachment}");
            try
            {
                var Obj = JsonConvert.DeserializeObject<RootObject>(json);
                if (Obj.response == 0)
                {
                    throw new Exception("еррор");
                }
                var resp = new Response<string>();
                resp.error_code = 0;
                resp.obj = Obj.response.ToString();
                return resp;
            }
            catch
            {
                var error_object = JsonConvert.DeserializeObject<Models.Error>(json);
                int error_code = error_object.error.error_code;
                Debug.Error(Error.Proccesing.Start(error_code));
                var resp = new Response<string>();
                resp.error_code = 4;
                resp.error = error_object;
                Debug.Error(resp.error_code);
                return resp;
            }
        }

        public class RootObject
        {
            public int response { get; set; }
        }

    }
}
