using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Mafia
{
    public class GameFile
    {
        public List<string> id_players { get; set; }
        public List<string> characters { get; set; }
        public List<string> live_players { get; set; }
        public int count_players { get; set; }
        public string creator_game { get; set; }
        public int night { get; set; }
        public string time { get; set; }
        public string isStart { get; set; }
        public int players_action { get; set; }
    }
}
