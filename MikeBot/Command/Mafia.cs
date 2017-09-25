using System;
using System.Collections.Generic;
using System.Text;

namespace MikeBot.Command
{
    public static class Mafia
    {
        public static void Start(string[] arg)
        {
            string command = arg[0];

            switch(command.ToLower())
            {
                case "создать":
                    break;
                case "присоедениться":
                    break;
                case "покинуть":
                    break;
                case "помощь":
                    break;

                default:
                    //Ошибка.
                    break;
            }
        }
    }
}
