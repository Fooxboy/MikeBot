using System;
using System.Collections.Generic;
using System.Text;

namespace MikeBot.Mafia.Methods
{
    public static class GetIdsFromCharacter
    {
        public static List<string> Start(string character, string dialog_id)
        {
            var info_game = new InfoGame(dialog_id);

            List<string> players = info_game.id_players;

            List<string> characters = info_game.characters;

            List<string> response_id = null;

            for(int i=0; info_game.count_players < i; i++)
            {
                if(characters[i] == character)
                {
                    response_id.Add(players[i]);
                }
            }

            return response_id;
        }
    }
}
