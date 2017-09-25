using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MikeBot.Mafia.Methods
{
    public static class SerializeMain
    {
        public static string Start(Models.Mafia.MainFile obj)
        {
            string resp = JsonConvert.SerializeObject(obj);
            return resp;
        }
    }
}
