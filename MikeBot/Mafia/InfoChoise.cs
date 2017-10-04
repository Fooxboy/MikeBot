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

        string path = "";
        string id = "";
        string n = "";

        public InfoChoise(string dialog_id, string night)
        {

            id = dialog_id;
            n = night;

            var info_dialog = new InfoDialog(dialog_id);

            int game = info_dialog.CoutGames + 1;

            path = $@"MafiaGames\{dialog_id}\{game}_choise_night{night}.json";

            string json = Methods.ReadFile.Start(path);

            info = JsonConvert.DeserializeObject<ChoiseFile>(json);
        }

        public List<string> UsersId { get { return info.users_id; }
            set
            {
                var info = new InfoChoise(id, n);
                var model = new ChoiseFile();
                model.choise_id = info.ChoiseId;
                model.killed = info.Killed;
                model.users_id = UsersId;
                string json = JsonConvert.SerializeObject(model);
                Methods.WriteFile.Start(json, path);
            }
        }
        public List<string> ChoiseId { get { return info.choise_id; }
            set
            {
                var info = new InfoChoise(id, n);
                var model = new ChoiseFile();
                model.choise_id = ChoiseId;
                model.killed = info.Killed;
                model.users_id = info.UsersId;
                string json = JsonConvert.SerializeObject(model);
                Methods.WriteFile.Start(json, path);
            }
        }
        public List<string> Killed { get { return info.killed; }
            set
            {
                var info = new InfoChoise(id, n);
                var model = new ChoiseFile();
                model.choise_id = info.ChoiseId;
                model.killed = Killed;
                model.users_id = info.UsersId;
                string json = JsonConvert.SerializeObject(model);
                Methods.WriteFile.Start(json, path);
            }
        }
    }
}
