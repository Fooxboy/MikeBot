
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

            if (dialog_id == "0")
            {
                Bot.API.Message.Send("Вы не находитесь  в игре. Присоеденитесь! ", id);
            }
            else
            {
                //Узнаём роль игрока.
                string character = Methods.GetCharactersFromId.Start(id, dialog_id);

                if (character.ToLower() == "бандит")
                {
                    //Логика бандита.
                    Logic.Characters.Bandit.Kill(killed, id, dialog_id);

                }
                else if (character.ToLower() == "начинающий бандит")
                {
                    //Логика начинающего бандита.
                    Logic.Characters.New_Bandit.Kill(killed, id, dialog_id);
                }
                else if (character.ToLower() == "заказной киллер")
                {
                    //Логика заказного киллера.
                }
                else
                {
                    Bot.API.Message.Send("Вам не доступна эта команда. Узнайте подробнее о вашей роли: Майк, мафия помощь <роль>.", id);
                }
            }
        }
    }
}
