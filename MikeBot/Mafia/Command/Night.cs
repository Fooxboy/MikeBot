using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading;
using System.Linq;
using System.IO;

namespace MikeBot.Mafia.Command
{
    public static class Night
    {
        public static void Start(string dialog_id)
        {

            if(Directory.Exists($@"MafiaGames\{dialog_id}\"))
            {
                var info_dialog = new InfoDialog(dialog_id);
                if(info_dialog.Play)
                {
                    var info = new InfoGame(dialog_id);
                    if (info.IsStart == "1")
                    {
                        //Ночь.

                        //Получаем информацию об игре
                        //Получаем список персонажей
                        List<string> characters = info.Characters;

                        //Получаем список игроков
                        List<string> users = info.LivePlayers;

                        //Получаем текст об игроках.
                        string players_game = Logic.StringPlayers.Start(users);

                        int game = info_dialog.CoutGames + 1;

                        int night = info.Night;

                        //Создаём файл, где сказано о всех выборах игроков.
                        using (System.IO.File.Create($@"MafiaGames\{dialog_id}\{game}_choise_night{night}.json"))
                        {

                        }
                        var model_choise = new Models.Mafia.ChoiseFile();
                        model_choise.users_id = new List<string>();
                        model_choise.choise_id = new List<string>();
                        model_choise.killed = new List<string>();
                        string json_choise = JsonConvert.SerializeObject(model_choise);
                        Methods.WriteFile.Start(json_choise, $@"MafiaGames\{dialog_id}\{game}_choise_night-{night}.json");

                        //Начинаем проверять каждого пользователя.
                        for (int i = 0; info.LivePlayers.Count < i; i++)
                        {
                            switch (characters[i].ToLower())
                            {
                                case "бандит":
                                    Bot.API.Message.Send($"Выберите кого убить. Если Ваш выбор совпадёт с большеством, тогда он будет убит.\n{players_game}\nПример:Майк, мафия убить 2.", users[i]);

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
                        }

                        Bot.API.Message.Send("Ночь началась. Ночь длится 60с. Кто же будет убит этой ночью?", dialog_id);

                        info.Night = info.Night + 1;
                        var resp = new ResponseEndNight();
                        resp.dialog_id = dialog_id;

                        //Запускаем конец ночи.
                        TimerCallback timerCallback = new TimerCallback(EndNight);

                        Timer timer = new Timer(timerCallback, resp, 60000, -1);
                    }
                    else
                    {
                        Bot.API.Message.Send("Игра не началась. Чтобы начать напишите: Майк, мафия старт.", dialog_id);
                    }
                }
                else
                {
                    Bot.API.Message.Send("Игра не была создана. Чтобы создать игру, напишите: Майк, мафия создать.", dialog_id);
                }    
            }else
            {
                Bot.API.Message.Send("Не создана папка игры. Чтобы создать игру, напишите: Майк, мафия создать", dialog_id);
            }
           
        }

        //TODO: Переписать в нормальный вид. Вынести в отдельный класс. Вынести в Logic.
        private static void EndNight(object obj)
        {
            //Ночь закончилась.

            //Получаем класс.
            var info = (ResponseEndNight)obj;
            //Получаем dialog_id
            string dialog_id = info.dialog_id;

            //Получаем класс для работы с информацией игры
            var info_game = new InfoGame(dialog_id);

            //Получаем файл с выбором.
            var info_choise = new InfoChoise(dialog_id, info_game.Night.ToString());

            List<string> killed = info_choise.ChoiseId;//Кого убили
            List<string> killer = info_choise.UsersId; //Кто убил
            List<string> killeders = info_choise.Killed; //Кто уже убит.

            //Убиты бандитом.
            List<string> killed_from_bandit = new List<string>();

            //Убиты киллером.
            List<string> killed_from_killer = new List<string>();

            //С ним переспали ночь.
            List<string> sleeped_to_night = new List<string>();

            //Его обворавали
            List<string> stealed = new List<string>();


            //Вылечены доктором
            List<string> treated_from_doctor = new List<string>();

            //Его спасли
            List<string> helpered = new List<string>();



            //Теперь нам нужно проанализировать всех убитых и убийц. Начнём.
            for(int i=0; info_game.LivePlayers.Count < i; i++)
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
                    case "спасатель":
                        helpered.Add(killed[i]);
                        break;
                    default:
                        break;


                }
            }

            List<string> kill_bandit_and_killer = new List<string>();

            string kill = "";

            //Анализируем убитых бандитами. Выбераем одного.
            if(killed_from_bandit.Count != 0 )
            {
                //Ищем совпадение между выбром киллера и бандита.
                string[] killedBandit = killed_from_bandit.ToArray();
                string[] killedKiller = killed_from_killer.ToArray();

                var results = killedBandit.Intersect(killedKiller);

                foreach(string s in results)
                {
                    kill_bandit_and_killer.Add(s);
                }

                List<string> killed_to_Bandit = new List<string>();

                if (kill_bandit_and_killer.Count == 0)
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

            if(treated_from_doctor.Count != 0)
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

            if (helpered.Count != 0)
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

            string retrn = "";

            if(killeders == null)
            {
                if(kill == "")
                {
                    retrn = $"Этой ночью никто не погиб.";
                }else
                {
                    var user =  API.Method.Users.Get.Start(kill).obj.response[0];
                    retrn = $"Этой ночью погиб: [{kill}|{user.first_name} {user.last_name}] был {Methods.GetCharactersFromId.Start(kill,dialog_id)}";
                }
              
            } else
            {
                killeders.Add(kill);
                retrn = $"Этой ночью погибли:/n {Logic.GetKillText.Start(killeders, dialog_id)}";
            }
            List<string> live_players = info_game.LivePlayers;


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

            if(live_players.Count == 1)
            {
                //Выводим имя победителя и заканчиваем игру
                var obj_user = API.Method.Users.Get.Start(live_players[0]);
                string text = $"ПОБЕДИЛ: [{live_players[0]}|{obj_user.obj.response[0].first_name} {obj_user.obj.response[0].last_name}] - был {Methods.GetCharactersFromId.Start(live_players[0],dialog_id)}";
                End.Start(dialog_id, live_players[0]);
            } else
            {
                string live_players_string = $"Оставшиеся живые игроки:\n {Logic.GetLiveText.Start(live_players)}";
                Bot.API.Message.Send($"{retrn}\n{live_players_string}", dialog_id);

                Day.Start(dialog_id);
            }

            //Теперь нужно перезаписать файл игры.

            info_game.LivePlayers = live_players;
            info_game.Night = info_game.Night + 1;

        }     
    }

    public class ResponseEndNight
    {
        public string dialog_id { get; set; }
    }
}
