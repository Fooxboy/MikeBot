using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Threading;

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
            int night = info_game.Night;

            using (File.Create($@"MafiaGames\{dialog_id}\{game}_choise_day{night}.json"))
            {

            }

            string list_players = Logic.StringPlayers.Start(info_game.LivePlayers);

            Bot.API.Message.Send($"Список игроков:\n{list_players}\nПроголосовать можно, написав в беседу или мне в ЛС.\nПример: Майк, проголосовать 2", dialog_id);

            TimerCallback timerCallback = new TimerCallback(EndDay);

            var resp = new ResponseDay();
            resp.dialog_id = dialog_id;

            Timer timer = new Timer(timerCallback, resp, 120000, -1);

        }

        private static void EndDay(object obj)
        {

            var object_day = (ResponseDay)obj;
            string dialog_id = object_day.dialog_id;

            Bot.API.Message.Send("Вечереет. Вот и жители выбрали кого посадить за решётку..",dialog_id);

            var info_game = new InfoGame(dialog_id);
            var info_dialog = new InfoDialog(dialog_id);

            int game = info_dialog.CoutGames + 1;
            int night = info_game.Night;

            string json_choise = Methods.ReadFile.Start($@"MafiaGames\{dialog_id}\{game}_choise_day{night}.json");
            var obj_choise = JsonConvert.DeserializeObject<Models.Mafia.DayChoiseFile>(json_choise);

            List<string> kill = obj_choise.users_id;


            string[] kill_array = kill.ToArray();


            string id = kill_array.GroupBy(x => x).OrderByDescending(x => x.Count()).First().Key;

            Bot.API.Message.Send("Вы отправляетесь в тюрьму, где Вы умираете. :(", id);

            List<string> livePlayers = info_game.LivePlayers;

            for (int i = 0; livePlayers.Count < i; i++)
            {
                if (livePlayers[i] == id)
                {
                    livePlayers.RemoveAt(i);
                } 
            }

           var user = API.Method.Users.Get.Start(id).obj.response[0];
            string character = Methods.GetCharactersFromId.Start(id, dialog_id);

            string name = $"[{id}|{user.first_name} {user.last_name}] - был {character}";

            string text = $"И так. Сегодня в тюрьму отправляется {name}.";

            Bot.API.Message.Send(text, dialog_id);

            var model_game = new Models.Mafia.GameFile();
            model_game.characters = info_game.Characters;
            model_game.count_players = info_game.CountPlayers;
            model_game.creator_game = info_game.CreatorGame;
            model_game.id_players = info_game.IdPlayers;
            model_game.isStart = info_game.IsStart;
            model_game.live_players = livePlayers;
            model_game.night = info_game.Night;
            model_game.players_action = info_game.PlayersAction;
            model_game.time = info_game.Time;

            string json_model = JsonConvert.SerializeObject(model_game);

            Methods.WriteFile.Start(json_model, $@"MafiaGames\{dialog_id}\{game}.json");
            
            if(livePlayers.Count == 1)
            {
                //Конец игры.
            } else
            {
                Command.Night.Start(dialog_id);
            }

        }

    }

    public class ResponseDay
    {
        public string dialog_id { get; set; }
    }
}
