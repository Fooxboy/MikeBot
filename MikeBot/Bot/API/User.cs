using System;
using System.Collections.Generic;
using System.Text;
using Database.API;

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
            var usr = new Database.API.User()
            {
                Id = id
            };

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
            var usr = new Database.API.User()
            {
                Id = id
            };

            if(time == "")
            {
                var ban = usr.Ban;

                if(ban)
                {
                    return "Пользователь не забанен.";
                } else
                {
                    var usr1 = new Database.API.Ban()
                    {
                        Id = id
                    };
                    return $"Пользователь в бане ещё на {usr1.Time} минут.";
                }
            } else
            {
                //Редактировать поле usr.Ban.
                var usr1 = new Database.API.Ban()
                {
                    Id = id
                };
                usr1.Time = time;
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
            var usr = new Database.API.User()
            {
                Id = id
            };

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

            Database.API.Database database = new Database.API.Database()
            {
                value = "mike"
            };
            Table table = new Table()
            {
                value = "users"
            };

            Methods method = new Methods(database,table);

            method.Add(fields, values);
            string name = Name(id);
            return $"Пользователь {name} добавлен в базу данных пользователей!";
        }
    }
}
