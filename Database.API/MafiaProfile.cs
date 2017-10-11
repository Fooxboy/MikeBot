using System;

namespace Database.API
{
    public class MafiaProfile 
    {
        string id = "";

        Methods method = new Methods("mafia");

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
                method.EditField(id, "count_game", CountGames);
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
                method.EditField(id, "count_win", CountWins);
            }
        }

        public bool IsUser
        {
            get
            {
                return method.CheckUser(id);
            }
        }
    }
}