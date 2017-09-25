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

            List<string> users_id = info_game.id_players;

            List<string> characters = info_game.characters;

            string response = "";

            for(int i=0; info_game.count_players < i; i++)
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
