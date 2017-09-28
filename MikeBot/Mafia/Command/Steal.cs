using System;
using System.Collections.Generic;
using System.Text;

namespace MikeBot.Mafia.Command
{
    public static class Steal
    {
        public static void Start(string from, string id, string dialog_id)
        {
            Bot.API.Message.Send("Вор сможет функционировать только после того, как добавят валюту.", id);
        }
    }
}
