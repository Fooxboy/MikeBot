using System;
using System.Collections.Generic;
using System.Text;

namespace MikeBot.Command
{
    public static class Test
    {
        public static void Start(string[] arguments)
        {
            string text;
            if (arguments.Length == 0)
            {
                text = "Ты пидор";
            }
            else
            {
                text = $"Ты пидор! Аргумент: {arguments[0]} ";
            }
            string peer_id = Global.array_longPoll[2].ToString();

            Bot.API.Message.Send(text, peer_id);
        }
    }
}
