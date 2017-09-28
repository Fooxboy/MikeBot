using System;
using System.Collections.Generic;
using System.Text;

namespace MikeBot.Mafia.Command
{
    public static class Treat
    {
        public static void Start(string from, string id, string dialog_id)
        {
            string character = Methods.GetCharactersFromId.Start(id, dialog_id);
            if(character.ToLower() == "доктор")
            {
                Logic.Characters.Doctor.Start(from, id, dialog_id);
            } else
            {
                Bot.API.Message.Send("Извините, Вам не доступна эта команда. Узнайте подробнее о вашей роли: Майк, мафия помощь <роль>.", id);
            }
        }
    }
}
