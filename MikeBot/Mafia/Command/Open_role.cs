using System;
using System.Collections.Generic;
using System.Text;

namespace MikeBot.Mafia.Command
{
    public static class Open_role
    {
        public static void Start(string from, string id, string  dialog_id)
        {
            var rand = new Random();

            int value = rand.Next(1, 10);

            bool ifOpen = false;

            if(value == 3)
            {
                ifOpen = true;
            }

            if(ifOpen)
            {
                string character = Methods.GetCharactersFromId.Start(from,dialog_id);
                Bot.API.Message.Send($"Скорее всего он - {character}", id);
            } else
            {
                string text = "Ваших способностей не хватило! :( Вы не смогли узнать роль.";
                Bot.API.Message.Send(text, id);
            }
        }
    }
}
