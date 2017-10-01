using System;
using System.Collections.Generic;
using System.Text;

namespace MikeBot.Command
{
    public static class Mafia
    {
        public static void Start(string[] arg, string dialog_id, string id)
        {
            string command = arg[0];

            int choise = 0;

            if(arg.Length == 1)
            {

            } else
            {
                choise = Convert.ToInt32(arg[1]);
            }

            MikeBot.Mafia.InfoGame info_game = null;
            List<string> players = null;
            try
            {
              info_game = new MikeBot.Mafia.InfoGame(dialog_id);
              players = info_game.live_players;
            }catch
            {
                //TODO: сделать проверку на игру.
            }

            switch(command.ToLower())
            {
                case "создать":
                    MikeBot.Mafia.Command.Create.Start(id, dialog_id);
                    break;
                case "присоединиться":
                    MikeBot.Mafia.Command.Join.Start(id, dialog_id);
                    break;
                case "покинуть":
                   // MikeBot.Mafia.Command.Create.Start(id, dialog_id);
                    break;
                case "помощь":
                    //MikeBot.Mafia.Command.Create.Start(id, dialog_id);
                    break;
                case "голосовать":
                    MikeBot.Mafia.Command.Choise.Start(players[choise],id, dialog_id);
                    break;
                case "убить":
                    MikeBot.Mafia.Command.Kill.Start(id, dialog_id, players[choise]);
                    break;
                case "узнать":
                    MikeBot.Mafia.Command.Open_role.Start(players[choise], id, dialog_id);
                    break;
                case "старт":
                    MikeBot.Mafia.Command.Start.Run(id, dialog_id);
                    break;
                case "ограбить":
                    MikeBot.Mafia.Command.Steal.Start(players[choise], id, dialog_id);
                    break;
                case "вылечить":
                    MikeBot.Mafia.Command.Treat.Start(players[choise], id, dialog_id);
                    break;
                case "посетить":
                    MikeBot.Mafia.Command.Visit.Start(players[choise], id, dialog_id);
                    break;
                case "ночь":
                    MikeBot.Mafia.Command.Night.Start(dialog_id);
                    break;
                default:
                    Bot.API.Message.Send("Такой команды не существует.", id);
                    break;
            }
        }
    }
}
