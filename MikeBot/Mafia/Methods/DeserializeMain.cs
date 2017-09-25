using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MikeBot.Mafia.Methods
{
    public static class DeserializeMain
    {
        public static Models.Mafia.MainFile Start(string json)
        {
            var obj = JsonConvert.DeserializeObject<Models.Mafia.MainFile>(json);
            return obj;
        }
    }
}
