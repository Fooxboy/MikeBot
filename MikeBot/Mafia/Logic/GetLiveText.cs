using System;
using System.Collections.Generic;
using System.Text;

namespace MikeBot.Mafia.Logic
{
    public static class GetLiveText
    {
        public static string Start(List<string> users_id)
        {
            string users_ids = "";

            foreach(string s in users_id)
            {
                users_ids += $"{s},";
            }

            var obj = API.Method.Users.Get.Start(users_ids);

            string response = "";
            for(int i = 0; users_id.Count <i; i++)
            {
                response += $"[{users_id[i]}|{obj.obj.response[i].first_name} {obj.obj.response[i].last_name}]\n";
            }
            return response;
        }
    }
}
