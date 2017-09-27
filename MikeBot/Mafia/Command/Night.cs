using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Threading;
using System.Linq;

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
            for(int i=0; info.live_players.Count <i;i++)
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


        //TODO: Переписать в нормальный вид. Вынести в отдельный класс. Вынести в Logic.
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

            List<string> killed = info_choise.choise_id;
            List<string> killer = info_choise.users_id;
            List<string> killeders = info_choise.killed;

            //Убиты бандитом.
            List<string> killed_from_bandit = null;

            //Убиты киллером.
            List<string> killed_from_killer = null;

            //С ним переспали ночь.
            List<string> sleeped_to_night = null;

            //Его обворавали
            List<string> stealed = null;

            //Его роль узнали
            List<string> opened_role = null;

            //Вылечены доктором
            List<string> treated_from_doctor = null;

            //Его спасли
            List<string> helpered = null;



            //Теперь нам нужно проанализировать всех убитых и убийц. Начнём.
            for(int i=0; info_game.live_players.Count < i; i++)
            {
                //Проверяем роль
                string role = Methods.GetCharactersFromId.Start(killer[i], dialog_id);

                //Записываем ид тех, кого выбрали.
                switch(role.ToLower())
                {
                    case "бандит":

                        killed_from_bandit.Add(killed[i]);

                        break;
                    case "начинающий бандит":

                        killed_from_bandit.Add(killed[i]);

                        break;
                    case "заказной киллер":
                        killed_from_killer.Add(killed[i]);

                        break;

                    case "доктор":
                        treated_from_doctor.Add(killed[i]);

                        break;
                    case "блудница":
                        sleeped_to_night.Add(killed[i]);

                        break;
                    case "вор":
                        stealed.Add(killed[i]);

                        break;
                    case "гадалка":
                        opened_role.Add(killed[i]);

                        break;
                    case "спасатель":
                        helpered.Add(killed[i]);
                        break;
                    default:
                        break;


                }
            }

            List<string> kill_bandit_and_killer = null;

            string kill = "";

            //Анализируем убитых бандитами. Выбераем одного.
            if(killed_from_bandit != null )
            {
                //Ищем совпадение между выбром киллера и бандита.

                string[] killedBandit = killed_from_bandit.ToArray();
                string[] killedKiller = killed_from_killer.ToArray();

                var results = killedBandit.Intersect(killedKiller);

                foreach(string s in results)
                {
                    kill_bandit_and_killer.Add(s);
                }

                List<string> killed_to_Bandit = null;

                if (kill_bandit_and_killer == null)
                {
                    var result = killedBandit.Intersect(killedBandit);

                    foreach(string s in result)
                    {
                        killed_to_Bandit.Add(s);
                    }

                    if(killed_to_Bandit.Count > 1)
                    {
                        var rand = new Random();
                        int rt = rand.Next(1, killed_to_Bandit.Count);
                        kill = kill_bandit_and_killer[rt];
                    }

                } else
                {
                    int count_killed = kill_bandit_and_killer.Count;

                    if(count_killed > 1)
                    {
                        var rand = new Random();
                        int result = rand.Next(1, count_killed);
                        kill = kill_bandit_and_killer[result];
                    }
                }
            } else
            {
                //Таких нет.
                //TODO:Доделать.
            }

            //Начинаем проверять  с кем переспала блудница.
            if (sleeped_to_night != null)
            {
                if (sleeped_to_night.Count > 1)
                {
                    for (int i = 0; sleeped_to_night.Count < i; i++)
                    {
                        if (kill == sleeped_to_night[i])
                        {
                            kill = "";
                        }
                    }
                }
                else
                {
                    if (kill == sleeped_to_night[0])
                    {
                        kill = "";
                    }
                }
            } else
            {
                //Любовнец нет или они не проголосовали.
            }

            if(treated_from_doctor != null)
            {
                if (treated_from_doctor.Count > 1)
                {
                    for (int i = 0; treated_from_doctor.Count < i; i++)
                    {
                        if (kill == treated_from_doctor[i])
                        {
                            kill = "";
                        }
                    }
                }
                else
                {
                    if (kill == treated_from_doctor[0])
                    {
                        kill = "";
                    }
                }
            }

            if (helpered != null)
            {
                if (helpered.Count > 1)
                {
                    for (int i = 0; helpered.Count < i; i++)
                    {
                        if (kill == helpered[i])
                        {
                            kill = "";
                        }
                    }
                }
                else
                {
                    if (kill == helpered[0])
                    {
                        kill = "";
                    }
                }
            }

            //Мы получили id игроков, которые будут убиты.
            killeders.Add(kill);

            //Проверяем сколько осталось живых игроков. Если один - Он победил.

            if(info_game.live_players.Count == 1)
            {
                //Пишим в беседу имя победителя. И заканчиваем игру.
            }

            //Сообщаем в беседу имена погибших и их роли.
            string retrn = $"Этой ночью погибли:/n {Logic.GetKillText.Start(killeders, dialog_id)}";

            List<string> live_players = info_game.live_players;


            //Получаем список живых игроков.
            for (int i=0; live_players.Count < i; i++)
            {
                string id_live = live_players[i];
                for (int i2=0; killeders.Count < i2; i2++)
                {
                    if(id_live == killeders[i2])
                    {
                        live_players.RemoveAt(i);
                    }
                }
            }

            string live_players_string = $"Оставшиеся живые игроки:\n {Logic.GetLiveText.Start(live_players)}";

            Bot.API.Message.Send($"{retrn}\n{live_players_string}", dialog_id);
            //Теперь нужно перезаписать файл игры.
            var model_game = new Models.Mafia.GameFile();
            model_game.characters = info_game.characters;
            model_game.count_players = info_game.count_players;
            model_game.creator_game = info_game.creator_game;
            model_game.id_players = info_game.id_players;
            model_game.isStart = info_game.isStart;
            model_game.live_players = live_players;
            model_game.night = info_game.night;
            model_game.players_action = info_game.players_action;
            model_game.time = info_game.time;

            string json = JsonConvert.SerializeObject(model_game);

            var info_dialog = new InfoDialog(dialog_id);

            int game = info_dialog.CoutGames + 1;

            Methods.WriteFile.Start(json, $@"MafiaGames\{dialog_id}\{game}.txt");


        }     
    }

    public class ResponseEndNight
    {
        public InfoGame info_game { get; set; }
        public string dialog_id { get; set; }
    }
}
