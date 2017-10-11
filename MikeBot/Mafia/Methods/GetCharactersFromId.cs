using System;
using System.Collections.Generic;
using System.Text;

namespace MikeBot.Mafia.Methods
{
    public static class GetCharactersFromId
    {
        public static string Start(string id, string dialog_id)
        { 
            var info_game = new InfoGame(dialog_id);

            List<string> users_id = info_game.IdPlayers;

            List<string> characters = info_game.Characters;

            string response = "";

            for(int i=0; info_game.CountPlayers < i; i++)
            {
                if(users_id[i] == id)
                {
                    response = characters[i];
                }
            }

            return response;
        }
    }
}
