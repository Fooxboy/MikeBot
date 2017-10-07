using System;
using System.Collections.Generic;
using System.Text;
using Database.API;

namespace MikeBot.Mafia.Command
{
    public static class End
    {
        public static void Start(string dialog_id, string win_players)
        {
            //файл конца игры. Здесь сохраняется вся информация.
            //TODO: доделать класс окончания игры.
            //...

            var info_dialog = new InfoDialog(dialog_id);

            var info_game = new InfoGame(dialog_id);

            info_game.IsStart = "0";

            info_dialog.CoutGames = info_dialog.CoutGames + 1;

            List<string> players = info_game.IdPlayers;

            foreach(string user in players)
            {
                MafiaProfile mafiaProfile = new MafiaProfile(user);
                mafiaProfile.CountGames = mafiaProfile.CountGames + 1;
                mafiaProfile.PlayId = "";
            }

            info_dialog.LastGame = DateTime.Now.ToString();

            MafiaProfile Profile = new MafiaProfile(win_players);
            Profile.CountWins = Profile.CountWins + 1;
            info_dialog.Play = false;

            Bot.API.Message.Send("Игра окончена.", dialog_id);

        }
    }
}
