using System.Collections.Generic;
using System.IO;
using Database.API;

namespace MikeBot.Mafia.Command
{
    /// <summary>
    /// Присоедениться к игре.
    /// </summary>
    public static class Join
    {
        public static void Start(string id, string dialog_id)
        {
            if (Directory.Exists("MafiaGames"))
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
                        MafiaProfile profile = new MafiaProfile(id);

                        if (profile.PlayId != "")
                        {
                            Bot.API.Message.Send("Вы уже находитесь в игре! Вам нельзя присоединиться.", dialog_id);
                        }
                        else
                        {
                            var infoGame = new InfoGame(dialog_id);

                            int count_players = infoGame.CountPlayers;
                            List<string> players = infoGame.IdPlayers;

                            if ((count_players < 10) || (count_players == 10))
                            {
                                //Добавляем нового игрока.
                                if (players == null)
                                {
                                    players = new List<string>();

                                    players.Add(id);
                                }
                                else
                                {
                                    players.Add(id);
                                }

                                var database = new MafiaProfile(id);

                                if (!database.IsUser)
                                {
                                    var method = new Database.API.Methods("mafia");
                                    string fields = @"`id`, `play_id`, `count_game`, `count_win`";
                                    string values2 = $@"'{id}', '0', '0', '0'";
                                    method.Add(fields, values2);
                                }

                                database.PlayId = dialog_id;

                                infoGame.IdPlayers = players;
                                infoGame.CountPlayers = count_players + 1;
                                int count_new_players = count_players + 1;
                                Bot.API.Message.Send($"Вы присоединились к игре! Количество игроков, которые присоеденились: {count_new_players}. Чтобы начать игру напишите Майк, мафия старт.", dialog_id);
                                //Отправить в лс то же самое сообщение.
                                Bot.API.Message.Send($"Вы успешно присоеденились к игре!", id);
                            }
                            else
                            {
                                Bot.API.Message.Send("Максимальное количество игроков достигнуто. Пожалуйста, начните игру. Для этого напишите: Майк, мафия старт.", dialog_id);
                            }
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
