using System;
using System.Collections.Generic;
using System.Text;

namespace MikeBot.Mafia.Logic
{
    public static class StringPlayers
    {
        public static string Start(List<string> array)
        {
            int count_players = array.Count;

            string response = "";

            string ids = "";

            for(int i=0; count_players < i; i++)
            {
                ids += $"{array[i]},";
            }

            var obj = API.Method.Users.Get.Start(ids);

            for(int i=0; count_players < i; i++)
            {
                response += $"{i} - [{array[i]}|{obj.obj.response[i].first_name} {obj.obj.response[i].last_name}]\n"; 
            }

            return response;
        }
    }
}
