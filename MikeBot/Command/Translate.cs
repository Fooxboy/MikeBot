using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MikeBot.Command
{
    public static class Translate
    {
        public static void Start(string[] arg)
        {
            string peer_id = Global.array_longPoll[2].ToString();

            int count = arg.Length;

            var regex = "[a-z]{2}-[a-z]{2}";

            if (Regex.IsMatch(arg[0], regex, RegexOptions.IgnoreCase))
            {
                //Здесь указан язык.
                string text = "";

                for (int i = 1; i < count; i++)
                {
                    text = String.Concat(text, $"{arg[i]} ");
                }

                //Обработка текста.
                string resp = YandexAPI.Translate.Main.Start(text, arg[0]);

                Bot.API.Message.Send(resp, peer_id);
            }
            else
            {
                //Здесь не текст
                switch (arg[0].ToLower())
                {
                    case "помощь":
                        //обработка помощь
                        Bot.API.Message.Send(text_help, peer_id);
                        break;
                    default:
                        //Неизвестный аргумент
                        Bot.API.Message.Send("Неизвесные аргументы.", peer_id);
                        break;
                }
            }
        }

        public static string text_help = "СТРУКУРА КОМАНДЫ:\n  Майк, переведи <Языки> <Текст>";
    }
}
