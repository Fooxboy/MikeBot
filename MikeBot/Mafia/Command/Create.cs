using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace MikeBot.Mafia.Command
{
    public static class Create
    {
        public static void Start(string id, string dialog_id)
        {
            //Проверка папки MafiaGames
            if(Directory.Exists("MafiaGames"))
            {
                //Существует. Всё хорошо.
            } else
            {
                //Не существет. Создаём его.
                Directory.CreateDirectory("MafiaGames");
            }

            //Проверяем, есть ли папка этой беседы 
            if(Directory.Exists($@"MafiaGames\{dialog_id}"))
            {
                //Существует. 
            } else
            {
                //Не существует. Создаём её.
                Directory.CreateDirectory($@"MafiaGames\{dialog_id}");
                //Создаём главный файл этой беседы со всей статистикой
                using (File.Create($@"MafiaGames\{dialog_id}\Main.txt"))
                {

                }
                //Заполняем данными файл.
                var model = new Models.Mafia.MainFile();
                model.count_games = 0;
                model.first_game = DateTime.Now.ToString();
                model.last_game = DateTime.Now.ToString();
                model.best_player = "None";
                model.max_players = 0;
                model.max_night = 0;
                //получаем json
                string json = Methods.SerializeMain.Start(model);
                //Записываем в файл.
                Methods.WriteFile.Start(json, $@"MafiaGames\{dialog_id}\Main.txt");
            }

            //Нужно получить инфрмацию о беседе и играх.
            var info = new InfoDialog(dialog_id);
            int count_games = info.CoutGames;
            //Создаём файл игры.
            int name_game = count_games++;

            using (File.Create($@"MafiaGames\{dialog_id}\{name_game}.txt"))
            {

            }

            var model_game = new Models.Mafia.GameFile();     
            model_game.creator_game = id;
            model_game.count_players = 0;
            model_game.night = 0; 
            string json_game = JsonConvert.SerializeObject(model_game);
            Methods.WriteFile.Start(json_game, $@"MafiaGames\{dialog_id}\{name_game}.txt");

            Bot.API.Message.Send("Игра создана. Чтобы присоединиться напишите Майк, мафия присоединиться.", dialog_id);
        }
    }
}
