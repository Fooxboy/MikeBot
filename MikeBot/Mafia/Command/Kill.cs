using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MikeBot.Mafia.Command
{
    /// <summary>
    /// Убить.
    /// </summary>
    public static class Kill
    {
        public static void Start(string id, string dialog_id, string killed)
        {
            //Убить игрока.

            //Узнаём роль игрока.
            string character = Methods.GetCharactersFromId.Start(id, dialog_id);

            if (character.ToLower() == "бандит")
            {
                //Логика бандита.
                Logic.Characters.Bandit.Kill(id, killed, dialog_id);

            } else if(character.ToLower() == "начинающий бандит")
            {
                //Логика начинающего бандита.
            } else if (character.ToLower() == "заказной киллер")
            {
                //Логика заказного киллера.
            } else
            {
                Bot.API.Message.Send("Вам не доступна эта команда. Узнайте подробнее о вашей роли: Майк, мафия помощь <роль>.", id);
            }
        }
    }
}
