using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MikeBot.Mafia.Command
{
    public static class Choise
    {
        public static void Start(string from, string id, string dialog_id)
        {
            //Файл голосования.
            var model_choise = new Models.Mafia.DayChoiseFile();

            var info_dialog = new InfoDialog(dialog_id);
            var info_game = new InfoGame(dialog_id);
            int game = info_dialog.CoutGames + 1;
            int night = info_game.Night;

            string json = Methods.ReadFile.Start($@"MafiaGames\{dialog_id}\{game}_choise_day{night}.json");
            var choise = JsonConvert.DeserializeObject<Models.Mafia.DayChoiseFile>(json);

            List<string> uid = choise.users_id;


            uid.Add(from);

            model_choise.users_id = uid;

            string new_json = JsonConvert.SerializeObject(model_choise);

            Methods.WriteFile.Start(new_json, $@"MafiaGames\{dialog_id}\{game}_choise_day{night}.json");
        }
    }
}
