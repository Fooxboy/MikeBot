using System;
using System.Collections.Generic;
using System.Text;

namespace MikeBot.Mafia.Command
{
    public static class Visit
    {
        public static void Start(string from, string id, string dialog_id)
        {
            string character = Methods.GetCharactersFromId.Start(id, dialog_id);

            if(character.ToLower() == "блудница")
            {
                Logic.Characters.Whore.Visit(from, id, dialog_id);
            } else
            {
                Bot.API.Message.Send("Извините, Вам не доступна эта команда.Узнайте подробнее о вашей роли: Майк, мафия помощь<роль>.", id);
            }
        }
    }
}
