using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Threading;

namespace MikeBot.Mafia.Command
{
    public static class Night
    {
        public static void Start(string id, string dialog_id)
        {
            //Ночь.

            //Получаем информацию об игре
            var info = new InfoGame(dialog_id);

            //Получаем список персонажей
            List<string> characters = info.characters;

            //Получаем список игроков
            List<string> users = info.id_players;

            //Получаем текст об игроках.
            string players_game = Logic.StringPlayers.Start(users);

            int count_players_action = 0;


            //Начинаем проверять каждого пользователя.
            for(int i=0; info.count_players <i;i++)
            {
                //if((characters[i] == Characters.get[2])||(characters[i] == Characters.get[10])||(characters[i] == Characters.get[11]))
                //{

                    switch(characters[i].ToLower())
                    {
                        case "бандит":
                            Bot.API.Message.Send($"Выберите кого убить. Если ваш выбор совпадёт с большеством, тогда он будет убит.\n{players_game}\nПример:Майк, мафия убить 2.", users[i]);

                            break;
                        case "начинающий бандит":
                            Bot.API.Message.Send($"Выберите кого хотите убить. Шанс убийства - 50%. \n{players_game}\nПример: Майк, мафия убить 2.", users[i]);

                            break;
                        case "заказной киллер":
                            Bot.API.Message.Send($"Выебрите кого хотите убить. Если вы убьёте кого-либо из мафии - Вы лишаетесь своей роли.\n{players_game}\nПример: Майк, мафия убить 2.", users[i]);

                            break;

                        case "доктор":
                            Bot.API.Message.Send($"Выберите кого хотите вылечить. Если на него сделают атаку - Вы его вылечите.\n{players_game}\nПример: Майк, мафия вылечить 2.", users[i]);

                            break;
                        case "блудница":
                            Bot.API.Message.Send($"Выберите с кем хотите провести ночь. Если Вы проведёте ночь с мафией - Вы мертвы.\n{players_game}\nПример: Майк, мафия навестить 2.", users[i]);

                            break;
                        case "вор":
                            Bot.API.Message.Send($"Выберите кого хотите ограбить. Есть шанс того, что Вас поймают, в удачном случае Вы получаете деньги.\n{players_game}\nПример: Майк, мафия ограбить 2.", users[i]);

                            break;
                        case "гадалка":
                            Bot.API.Message.Send($"Выберите того, чью роль вы хотите узнать. Ваши шансы узнать роль - 50%.\n{players_game}\nПример: Майк, мафия гадать 2.", users[i]);

                            break;
                        case "спасатель":
                            Bot.API.Message.Send($"Выберите кого хотите спасти. Ваши шансы кого-либо спасти - 20%\n{players_game}\nПример: Майк, мафия спасти 2", users[i]);

                            break;
                        default:
                            break;
                    }
                //}
                count_players_action = i;
            }

            Bot.API.Message.Send("Ночь началась. Ночь длится 60с. Кто же будет убит этой ночью?", dialog_id);

            var model = new Models.Mafia.GameFile();

            model.characters = info.characters;

            model.count_players = info.count_players;
            model.creator_game = info.creator_game;
            model.id_players = info.id_players;
            model.isStart = info.isStart;
            model.live_players = info.live_players;
            model.night = info.night + 1;
            model.players_action = count_players_action;
            model.time = info.time;

            var info_dialog = new InfoDialog(dialog_id);
            int game = info_dialog.CoutGames + 1;
            string json = JsonConvert.SerializeObject(model);
            Methods.WriteFile.Start(json, $@"MafiaGames\{dialog_id}\{game}.txt");

            var resp = new ResponseEndNight();
            resp.dialog_id = dialog_id;
            resp.info_game = info;

            TimerCallback timerCallback = new TimerCallback(EndNight);

            Timer timer = new Timer(timerCallback, resp, 60000, -1);
            /** ЕБАНЫЙ КОНЕЦ. УРА БЛЯТЬ. УРА! УРА! УРА!*/
        }

        private static void EndNight(object obj)
        {
            //Ночь закончилась.

            //Получаем класс.
            var info = (ResponseEndNight)obj;

            //Получаем класс для работы с информацией игры
            var info_game = info.info_game;

            //Получаем dialog_id
            string dialog_id = info.dialog_id;

            //Получаем файл с выбором.
            var info_choise = new InfoChoise(dialog_id, info_game.night.ToString());

            //Теперь нам нужно про анализировать всех убитых и убийц. Начнём.
            


        }

       
    }

    public class ResponseEndNight
    {
        public InfoGame info_game { get; set; }
        public string dialog_id { get; set; }
    }
}
