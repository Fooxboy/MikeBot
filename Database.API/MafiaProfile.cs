using System;

namespace Database.API
{
    public class MafiaProfile 
    {
        string id = "";

        var method = new Methods("mafia_profile");

        public MafiaProfile(string user_id) 
        {
            id = user_id;
        }

        public string PlayId 
        {
            get 
            {
                return method.GetFromId("play_id", id);
            }
            set 
            {
                method.EditField(id, "play_id", PlayId);
            }
        }

        public string CountGames 
        {
            get 
            {
                return method.GetFromId("count_game", id);
            }
            set 
            {
                method.EditField(id, "count_game", id);
            }
        }

        public string CountWins 
        {
            get 
            {
                return method.GetFromId("count_win", id);
            }
            set 
            {
                method.EditField(id, "count_win", id);
            }
        }
    }
}