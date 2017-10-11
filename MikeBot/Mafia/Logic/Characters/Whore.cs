using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Models.Mafia;

namespace MikeBot.Mafia.Logic.Characters
{
    public static class Whore
    {
        public static void Visit(string from, string id, string dialog_id)
        {
            string character = Methods.GetCharactersFromId.Start(from, dialog_id);

            var info_game = new InfoGame(dialog_id);
            var info_choise = new InfoChoise(dialog_id, info_game.Night.ToString());
            var info_dialog = new InfoDialog(dialog_id);
            var model_choise = new ChoiseFile();

            List<string> users_id = info_choise.UsersId;
            List<string> choise_id = info_choise.ChoiseId;

            if ((character.ToLower() == "бандит")||(character.ToLower() == "киллер"))
            {
                info_choise.Killed.Add(id);

                string text = "Увы, Вам не повезло. :( Вы сходили на чаёк неудачно. Вы мертвы.";
                Bot.API.Message.Send(text, id);
            } else
            {
                users_id.Add(id);
                choise_id.Add(from);
            }
     
            users_id.Add(from);
            choise_id.Add(id);
            model_choise.choise_id = choise_id;
            model_choise.users_id = users_id;
            model_choise.killed = info_choise.Killed;
            string json_model_choise = JsonConvert.SerializeObject(model_choise);
            int game = info_dialog.CoutGames + 1;
            int night = info_game.Night;
            Methods.WriteFile.Start(json_model_choise, $@"MafiaGames\{dialog_id}\{game}_choise_night{night}.json");
        
        }
    }
}
