using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Newtonsoft.Json;

namespace MikeBot.API.Method.Utils
{
    public static class ResolveScreenName
    {
        public static string Start(string screen_name)
        {
            string json = Request.Api("resolveScreenName", $"screen_name={screen_name}");

            try
            {
                var obj = JsonConvert.DeserializeObject<RootObject<ResolveScreenNameObject>>(json);
                try
                {
                    return obj.response.object_id;
                }
                catch
                {
                    return screen_name;
                }

            } catch
            {
                return screen_name;
            }
        }

        public class ResolveScreenNameObject
        {
            public string type { get; set; }
            public string object_id { get; set; }
        }

    }
}
