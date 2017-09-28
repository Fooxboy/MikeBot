using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MikeBot.Mafia.Command
{
    public static class Day
    {
        public static void Start(string id, string dialog_id)
        {
            Bot.API.Message.Send("Начался день! В это время все жители решают кого посадить в тюрьму. У вас 120 секунд!", dialog_id);

            var info_game = new InfoGame(dialog_id);

            var info_dialog = new InfoDialog(dialog_id);

            int game = info_dialog.CoutGames + 1;
            int night = info_game.night;

            File.Create($@"MafiaGames\{dialog_id}\{game}_choise_day{night}.txt");

            string list_players = Logic.StringPlayers.Start(info_game.live_players);

            Bot.API.Message.Send($"Список игроков:\n{list_players}\nПроголосовать можно, написав в беседу или мне в ЛС.\nПример: Майк, проголосовать 2", dialog_id);

           

        }
    }
}
