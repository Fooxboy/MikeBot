using System;
using System.Collections.Generic;
using System.Text;

namespace MikeBot.SDK.Command
{
    public class Proccesing
    {
        public void Run(ResponseSDKCommand response)
        {
            //Получаем команду
            string[] array = response.arg;
            string comand = array[1].ToLower();

            int count = array.Length;

            int count_argument = count - 2;

            string[] arguments_array = new string[count_argument];

            if (arguments_array.Length == 0)
            {
                //Ничего не делаем, аргуметов нет
            }
            else
            {
                for (int i = 0, index = 2; i < count_argument; i++, index++)
                {

                    arguments_array[i] = array[index];
                }
            }

            //В итоге мы получам массив набитый аргументами.
            switch (comand.ToLower())
            {
                case "test":
                    MikeBot.Command.Test.Start(arguments_array);
                    break;
                case "переведи":
                    MikeBot.Command.Translate.Start(arguments_array);
                    break;
                case "мафия":
                    MikeBot.Command.Mafia.Start(arguments_array, response.peer_id, response.id);
                    break;
                case "оботе":
                    MikeBot.Command.About.Start(response.peer_id);
                    break;
                default:          
                    //Нет команды
                    Bot.API.Message.Send("Неизвестная команда.", response.peer_id);
                    break;
            }
        }
    }
}
