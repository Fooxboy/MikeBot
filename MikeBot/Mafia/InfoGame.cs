using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MikeBot.Mafia
{
    public class InfoGame
    {
        Models.Mafia.GameFile model = null;
        public InfoGame(string dialog_id)
        {
            var info = new InfoDialog(dialog_id);
            int count_game = info.CoutGames;
            int game = count_game++;
            string json = Methods.ReadFile.Start($@"MafiaGames\{dialog_id}\{game}.txt");
            model = JsonConvert.DeserializeObject<Models.Mafia.GameFile>(json);
        }

        public List<string> id_players { get { return model.id_players; } }
        public List<string> characters { get { return model.characters; }  }
        public List<string> live_players { get { return model.live_players; } }
        public int count_players { get { return model.count_players; } }
        public string creator_game { get { return model.creator_game; } }
        public int night { get { return model.night; }  }
        public string time { get { return model.time; } }
        public string isStart { get { return model.isStart; } }
        public int players_action { get { return model.players_action; } }
    }
}
