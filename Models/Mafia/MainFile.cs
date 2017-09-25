using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Mafia
{
    public class MainFile
    {
        public int count_games { get; set; }

        public string first_game { get; set; }

        public string last_game { get; set; }

        public string best_player { get; set; }

        public int max_players { get; set; }

        public int max_night { get; set; }
    }
}
