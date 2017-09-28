using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Models.Mafia;

namespace MikeBot.Mafia.Logic.Characters
{
    public static class Doctor
    {
        public static void Start(string from, string id, string dialog_id)
        {
            var info_game = new InfoGame(dialog_id);
            var info_choise = new InfoChoise(dialog_id, info_game.night.ToString());
            var info_dialog = new InfoDialog(dialog_id);
            var model_choise = new ChoiseFile();

            var random = new Random();

            int value = random.Next(1, 10);

            bool ifkill = false;

            if ((value == 1) || (value == 2) || (value == 3) || (value == 4))
            {
                ifkill = false;
            }
            else
            {
                ifkill = true;
            }

            if(ifkill)
            {
                List<string> users_id = info_choise.users_id;
                List<string> choise_id = info_choise.choise_id;
                users_id.Add(from);
                choise_id.Add(id);
                model_choise.choise_id = choise_id;
                model_choise.users_id = users_id;
                model_choise.killed = info_choise.killed;
                string json_model_choise = JsonConvert.SerializeObject(model_choise);
                int game = info_dialog.CoutGames + 1;
                int night = info_game.night;
                Methods.WriteFile.Start(json_model_choise, $@"MafiaGames\{dialog_id}\{game}_choise_night{night}.txt");
            } else
            {
                string text = "Увы, доктор, Вы не смогли спасти жизнь. :( Плохой Вы доктор!";
                Bot.API.Message.Send(text, id);
            }
        }
    }
}
