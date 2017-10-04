﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace MikeBot.Mafia.Command
{
    /// <summary>
    /// Присоедениться к игре.
    /// </summary>
    public static class Join
    {
        public static void Start(string id, string dialog_id)
        {
           
            if(Directory.Exists("MafiaGames"))
            {
                if (Directory.Exists($@"MafiaGames\{dialog_id}"))
                {
                    var info = new InfoDialog(dialog_id);
                    int count_game = info.CoutGames;
                    int game = count_game + 1;

                    if (File.Exists($@"MafiaGames\{dialog_id}\{game}.json"))
                    {
                        //Игра существует, присоедениться можно.

                        //Проверяем, есть ли уже игроки, которые присоеденились.

                        var infoGame = new InfoGame(dialog_id);

                        int count_players = infoGame.CountPlayers;
                        List<string> players = infoGame.IdPlayers;

                        /*УСТАРЕВШИЙ КОД
                         * 
                        string json = Methods.ReadFile.Start($@"MafiaGames\{dialog_id}\{game}.json");
                        var obj = JsonConvert.DeserializeObject<Models.Mafia.GameFile>(json);
                        int count_players = obj.count_players;
                        List<string> players = obj.id_players; */

                        

                        if((count_players < 10)||(count_players == 10))
                        {
                            //Добавляем нового игрока.
                            if (players == null)
                            {
                                players = new List<string>();

                                players.Add(id);
                            } else
                            {
                                players.Add(id);
                            }


                            var database = new Database.API.MafiaProfile(id);

                            if (database.IsUser)
                            {
                                
                            } else
                            {
                                var method = new Database.API.Methods("mafia_profile");
                                string fields = @"`id`, `play_id`, `count_game`, `count_win`";
                                string values2 = $@"'{id}', '0', '0', '0'";
                                method.Add(fields,values2);
                            }

                            database.PlayId = dialog_id;

                            infoGame.IdPlayers = players;
                            infoGame.CountPlayers = count_players + 1;

                            /*УСТАРЕВШИЙ КОД 
                             * 
                            var gamemodel = new Models.Mafia.GameFile();
                            gamemodel.id_players = players;
                            gamemodel.count_players = count_players + 1;
                            //Сериализуем в json строку.
                            string new_json = JsonConvert.SerializeObject(gamemodel);
                            //Записываем в файл.
                            Methods.WriteFile.Start(new_json, $@"MafiaGames\{dialog_id}\{game}.txt");*/

                            int count_new_players = count_players + 1;
                            Bot.API.Message.Send($"Вы присоединились к игре! Количество игроков, которые присоеденились: {count_new_players}. Чтобы начать игру напишите Майк, мафия старт.", dialog_id);
                            //Отправить в лс то же самое сообщение.
                            Bot.API.Message.Send($"Вы успешно присоеденились к игре!", id);
                        } else
                        {
                            Bot.API.Message.Send("Максимальное количество игроков достигнуто. Пожалуйста, начните игру. Для этого напишите: Майк, мафия старт.", dialog_id);
                        }
                        
                    } else
                    {
                        Bot.API.Message.Send("Игра ещё не создана. Напишите Майк, мафия создать.",dialog_id);
                    }
                } else
                {
                    Bot.API.Message.Send("Папка с игрой этого диалога не найдена. Чтобы создать новую игру, напишите: Майк, мафия создать.", dialog_id);
                }
            } else
            {
                Bot.API.Message.Send("Не найдена глобальная папка проекта. Чтобы создать игру, напишите: Майк, мафия создать.", dialog_id);
            }
        }
    }
}
