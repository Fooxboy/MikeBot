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
            if(Directory.Exists($@"MafiaGames\{dialog_id}\"))
            {
                var info = new InfoDialog(dialog_id);
                if (info.Play)
                {
                    //Получаем информации об сыграных играх.

                    int count_game = info.CoutGames;
                    int game = count_game++;

                    //получаем количество игроков.
                    var game_info = new InfoGame(dialog_id);

                    if (game_info.IsStart == "1")
                    {
                        Bot.API.Message.Send("Игра уже начата! Возможно, Вы не успели присоединиться.", dialog_id);
                    } else
                    {
                        int count_players = game_info.CountPlayers;

                        /* УСТАРЕВШИЙ КОД
                         * 
                        string json = Methods.ReadFile.Start($@"MafiaGames\{dialog_id}\{game}.txt");
                        var obj = JsonConvert.DeserializeObject<Models.Mafia.GameFile>(json);
                        int count_players = obj.count_players;*/

                        //Получаем список персонажей.
                        string[] characters = Logic.Distribution.Start(count_players);

                        //Получаем список игроков.
                        List<string> players_id = game_info.IdPlayers;

                        List<string> new_characters = new List<string>();

                        for (int i = 0; i < count_players; i++)
                        {
                            new_characters.Add(characters[i]);
                        }

                        //Отправляем каждому игроку его роль в личные сообщения.
                        for (int i = 0; i < count_players; i++)
                        {
                            string characters_info = "Информация об роли...";
                            string text = $"Ваша роль: {characters[i]}. Краткое описание:\n{characters_info}";

                            Bot.API.Message.Send(text, players_id[i]);
                        }

                        game_info.Characters = new_characters;
                        game_info.IsStart = "1";

                        /*УСТАРЕВНИЙ КОД
                         * 
                        var model_game = new Models.Mafia.GameFile();
                        model_game.characters = new_charecters;
                        model_game.count_players = count_players;
                        model_game.creator_game = obj.creator_game;
                        model_game.id_players = obj.id_players;
                        model_game.night = 0;
                        model_game.live_players = obj.id_players;
                        model_game.isStart = "1";*/

                        Bot.API.Message.Send("Роли разданы. Для того, чтобы начать первую ночь, напишите: Майк, мафия ночь.", dialog_id);
                    }
                } else
                {
                    Bot.API.Message.Send("В этом диалог нет созданной игры. Исправте это! Напишите: Майк, мафия создать.", dialog_id);
                }
            } else
            {
                Bot.API.Message.Send("Не найдена папка с игрой. Создайте новую игру! Напишите: Майк, мафия создать", dialog_id);
            }

           
        }
    }
}
