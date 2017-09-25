using System;
using System.Collections.Generic;
using System.Text;

namespace MikeBot.Bot.API
{
    /// <summary>
    /// Класс для редактирования информации страницы ВКонтакте бота.
    /// </summary>
    public static class Mike
    {
        /// <summary>
        /// Помечает как "В сети".
        /// </summary>
        public static void SetOnline()
        {
            MikeBot.API.Method.Account.SetOnline.Start();
        }
        /// <summary>
        /// Помечает как "был в сети".
        /// </summary>
        public static void SetOffline()
        {
            MikeBot.API.Method.Account.SetOffline.Start();
        }
        /// <summary>
        /// Получение и изменение статуса.
        /// </summary>
        public static string Status
        {
            get
            {
                return MikeBot.API.Method.Status.Get.Start("");
            }
            set
            {
                MikeBot.API.Method.Status.Set.Start(Status);
            }
        }
    }
}
