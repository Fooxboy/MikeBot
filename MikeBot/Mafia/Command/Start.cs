using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace MikeBot.Mafia.Command
{
    public static class Start
    {
        public static void Run(string id, string dialog_id)
        {
            //Получаем информации об сыграных играх.
            var info = new InfoDialog(dialog_id);
            int count_game = info.CoutGames;
            int game = count_game++;

            //получаем количество игроков.
            string json = Methods.ReadFile.Start($@"MafiaGames\{dialog_id}\{game}.txt");
            var obj = JsonConvert.DeserializeObject<Models.Mafia.GameFile>(json);
            int count_players = obj.count_players;

            //Получаем список персонажей.
            string[] characters = Logic.Distribution.Start(count_players);

            //Получаем список игроков.
            List<string> players_id = obj.id_players;

            List<string> new_charecters = obj.characters;

            //Заполняем массив персонажей
            for(int i=0; i< count_players; i++)
            {
                new_charecters[i] = characters[i];
            }

            //Отправляем каждому игроку его роль в личные сообщения.
            for(int i=0;i <count_players; i++ )
            {
                string characters_info = "...";
                string text = $"Ваша роль: {characters[i]}. Краткое описание:\n{characters_info}";

                Bot.API.Message.Send(text, players_id[i]);       
            }

            var model_game = new Models.Mafia.GameFile();
            model_game.characters = new_charecters;
            model_game.count_players = count_players;
            model_game.creator_game = obj.creator_game;
            model_game.id_players = obj.id_players;
            model_game.night = obj.night;
            model_game.live_players = obj.id_players;
            model_game.isStart = "1";

            

            string json_new = JsonConvert.SerializeObject(model_game);
            Methods.WriteFile.Start(json_new, $@"MafiaGames\{dialog_id}\{game}.txt");

            //Создаём файл, где сказано о всех выборах игроков(0 ночь).
            File.Create($@"MafiaGames\{dialog_id}\{game}_choise_night{obj.night}.txt");
            var model_choise = new Models.Mafia.ChoiseFile();
            model_choise.users_id = null;
            model_choise.choise_id = null;
            string json_choise = JsonConvert.SerializeObject(model_choise);
            Methods.WriteFile.Start(json_choise, $@"MafiaGames\{dialog_id}\{game}_choise_night{obj.night}.txt");


            Bot.API.Message.Send("Роли разданы. Для того, чтобы начать первую ночь, напишите: Майк, мафия ночь.", dialog_id);

        }
    }
}
