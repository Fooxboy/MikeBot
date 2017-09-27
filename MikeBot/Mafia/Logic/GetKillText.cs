using System;
using System.Collections.Generic;
using System.Text;

namespace MikeBot.Mafia.Logic
{
    public static class GetKillText
    {
        public static string Start(List<string> ids, string dialog_id)
        {
            string response = "";

            //Получаем id всех пользователей.
            string id = "";

            foreach(string s in ids)
            {
                id += $"{s},";
            }

            var obj = API.Method.Users.Get.Start(id).obj;

           
            for(int i=0; ids.Count< i; i++)
            {
                string character = Methods.GetCharactersFromId.Start(ids[i], dialog_id);

                response += $"[{ids[i]}|{obj.response[i].first_name} {obj.response[i].last_name}] - Был {character}\n";
            }

            return response;
        }
    }
}
