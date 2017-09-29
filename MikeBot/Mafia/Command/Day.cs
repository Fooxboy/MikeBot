using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace MikeBot.Mafia.Command
{
    public static class Day
    {
        public static void Start(string dialog_id)
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

        private static void EndDay(object obj)
        {
            var object_day = (ResponseDay)obj;
            string dialog_id = object_day.dialog_id;

            var info_game = new InfoGame(dialog_id);
            var info_dialog = new InfoDialog(dialog_id);

            int game = info_dialog.CoutGames + 1;
            int night = info_game.night;

            string json_choise = Methods.ReadFile.Start($@"MafiaGames\{dialog_id}\{game}_choise_day{night}.txt");
            var obj_choise = JsonConvert.DeserializeObject<Models.Mafia.DayChoiseFile>(json_choise);

            List<string> kill = obj_choise.users_id;

            Dictionary<string, string> users = null;

            for(int i=0; kill.Count < i; i++)
            {
                string user = kill[i];

                for(i=0; kill.Count<i; i++)
                {
                    
                }
            }
            
        }

    }

    public class ResponseDay
    {
        public string dialog_id { get; set; }
    }
}
