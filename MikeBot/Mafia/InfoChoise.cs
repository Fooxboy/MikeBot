using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Models.Mafia;

namespace MikeBot.Mafia
{
    public class InfoChoise
    {
        ChoiseFile info = new ChoiseFile();

        public InfoChoise(string dialog_id, string night)
        {
            var info_dialog = new InfoDialog(dialog_id);

            int game = info_dialog.CoutGames + 1;

            string json = Methods.ReadFile.Start($@"MafiaGames\{dialog_id}\{game}_choise_night{night}.txt");

            info = JsonConvert.DeserializeObject<ChoiseFile>(json);
        }

        public List<string> users_id { get { return info.users_id; } }
        public List<string> choise_id { get { return info.choise_id; } }
    }
}
