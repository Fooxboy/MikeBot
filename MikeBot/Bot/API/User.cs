using System;
using System.Collections.Generic;
using System.Text;

namespace MikeBot.Bot.API
{
    /// <summary>
    /// Класс для работы с Пользователями.
    /// </summary>
    public static class User
    {
        /// <summary>
        /// Получение и изменение имени.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="new_name"></param>
        /// <returns></returns>
        public static string Name(string id, string new_name="")
        {
            var usr = new Database.API.UserInfo(id);

            if(new_name == "")
            {
                return usr.Name;
            } else
            {
                //Редактировать поле usr.Name.
                usr.Name = new_name;
                return $"Имя изменено на {new_name}";
            }       
        }

        /// <summary>
        /// Получение и изменение времени бана пользователя.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string Ban(string id, string time="")
        {
            var usr = new Database.API.UserInfo(id);
            if(time == "")
            {
                string time_ban = usr.Ban;

                if(time_ban == "")
                {
                    return "Пользователь не забанен.";
                } else
                {
                    return $"Пользователь в бане ещё на {time_ban} минут.";
                }
            } else
            {
                //Редактировать поле usr.Ban.
                usr.Ban = time;
                return $"Пользователь забанен на {time} минут.";
            }
        }

        /// <summary>
        /// Проверка пользователя в базе.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string IsUser(string id)
        {
            var usr = new Database.API.UserInfo(id);

            bool resp = usr.IsUser;

            if (resp)
            {
                string name = usr.Name;
                return $"{name} является пользователем бота.";
            } else
            {
                return "Этот пользователь не использовал бота.";
            }
        }


        /// <summary>
        /// Добавление нового пользователя в базу.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string NewUser(string id)
        {
            string fields = @"`id`, `name`, `isYou`";
            string first_name = MikeBot.API.Method.Users.Get.Start(id).obj.response[0].first_name;
            string values = $@"'{id}', '{first_name}', '1'";
            Database.API.Add.String(fields, values);
            string name = Name(id);
            return $"Пользователь {name} добавлен в базу данных пользователей!";
        }
    }
}
