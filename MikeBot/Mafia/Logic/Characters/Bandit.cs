using System;
using System.Collections.Generic;
using System.Text;
using Models.Mafia;
using Newtonsoft.Json;

namespace MikeBot.Mafia.Logic.Characters
{
    public static class Bandit
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="from">Кто убивает</param>
        /// <param name="id">Кого убивают</param>
        /// <param name="dialog_id">Диалог в котором происходит действие</param>
        public static void Kill(string from, string id, string dialog_id)
        {
            //Логика убивания бандита. 
            //Бандит убьёт в том случае, если большенство бандитов проголосовало за них.

            var info_game = new InfoGame(dialog_id);

            var info_choise = new InfoChoise(dialog_id, info_game.night.ToString());

            var model_choise = new ChoiseFile();

            List<string> users_id = info_choise.users_id;
            List<string> choise_id = info_choise.choise_id;

            users_id.Add(from);
            choise_id.Add(id);

            model_choise.choise_id = choise_id;
            model_choise.users_id = users_id;

            string json_model_choise = JsonConvert.SerializeObject(model_choise);


        }
    }
}
