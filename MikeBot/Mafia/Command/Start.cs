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

                    if (game_info.IdPlayers.Count < 5)
                    {
                        Bot.API.Message.Send("Наберите необходимое количество участников, чтобы начать игру! Минимум: 5", dialog_id);
                    }
                    else
                    {
                        if (game_info.IsStart == "1")
                        {
                            Bot.API.Message.Send("Игра уже начата! Возможно, Вы не успели присоединиться.", dialog_id);
                        }
                        else
                        {
                            int count_players = game_info.CountPlayers;

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

                            Bot.API.Message.Send("Роли разданы. Для того, чтобы начать первую ночь, напишите: Майк, мафия ночь.", dialog_id);
                        }
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
