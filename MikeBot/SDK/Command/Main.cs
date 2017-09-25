using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MikeBot.SDK.Command
{
    public static class Main
    {
        public static void Start(object[] array)
        {
            string message_id = (string)array[0];
            string message_flags = (string)array[1];
            string peer_id = (string)array[2];
            string time = (string)array[3];
            string message = (string)array[4];
            var attach = (Models.Attach)array[5];

            string user_id_from;

           if(attach.from == null)
           {
                //Если сообщение в лс.
                user_id_from = peer_id;
           } else
            {
                //Если сообщение в беседе.
                user_id_from = attach.from;
            }
                     
            Global.array_longPoll = array;


            //Структура команды:
            // Майк, <КОМАНДА> <АРГУМЕНТ1> <АРГУМЕНТ2> <АРГУМЕНТ3> и т.д.

            string[] array_message = Split(message);

            if (CheckName(array_message[0]))
            {
                //Тут точно ник указан

                //Проверка на юзера в бд.
                var user = new Database.API.UserInfo(user_id_from);

                if( user_id_from == null)
                {
                    throw new Exception("вы ахуели, сер!");
                }
                if(user.IsUser)
                {
                    if(user.Ban == "")
                    {
                        //Бана нет.

                        //Запускаем обработку.
                        Thread threadProccesing = new Thread(new ParameterizedThreadStart(Proccesing_message));
                        threadProccesing.Start(array_message);
                        threadProccesing.Name = "Proccesing_message";
                    } else
                    {
                        //Чел в бане. Иди нахуй.
                    }
                }else
                {
                    //Пользователя нет в базе данных.
                    //Создаём строку с пользователем.
                    Bot.API.User.NewUser(user_id_from);

                    //запускаем обработку.
                    Debug.Waring("Поток Proccesing");
                    Thread threadProccesing = new Thread(new ParameterizedThreadStart(Proccesing_message));
                    threadProccesing.Start(array_message);
                    threadProccesing.Name = "Proccesing_message";
                }

            }

        }

        private static void Proccesing_message(object array)
        {
            string[] array_message = (string[])array;
            Proccesing procc = new Proccesing();
            procc.Run(array_message);
        }

        private static string[] Split(string message)
        {
            string[] response = message.Split(' ');
            return response;
        }

        private static bool CheckName(string name)
        {
            if ((name == "Майк") || (name == "майк") || (name== "Майк,") || (name == "майк,"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
