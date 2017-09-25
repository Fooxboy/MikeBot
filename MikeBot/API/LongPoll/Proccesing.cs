using System;
using System.Collections.Generic;
using System.Text;

namespace MikeBot.API.LongPoll
{
    public static class Proccesing
    {

        public static void Start(List<List<object>> obj)
        {
            object[] retrn = new object[1];
            if (obj.Count == 0)
            {
                //Ничего не произошло.
            } else
            {
                for (int i = 0; i < obj.Count; i++)
                {
                    long code = (long)obj[i][0];
                    //Вызываем обработчик кода сообщений.
                     Code(code, i, obj);
                }
            }
        }

        private static void Code(long code, int i, List<List<object>> ObjectLongPoll)
        {
            object[] retrn = new object[1];
            Debug.Waring($"\nКОД: {code}");
            switch (code)
            {
                case 1:
                    //Замена флагов сообщения
                    break;
                case 2:
                    //Установка флагов сообщения
                    break;
                case 3:
                    //Сброс флагов сообщения
                    break;
                case 4:
                    //Добавлние нового сообщения
                    Console.WriteLine("Новое сообщение");
                    ProccesingCode.Code4.Start(ObjectLongPoll, i);
                    break;
                case 6:
                    //Прочтение всех входящих сообщений

                    break;
                case 7:
                    //Прочтение всех исходящих сообщений
                    break;
                case 8:
                    //друг стан онлайн
                    break;
                case 9:
                    //друг стал офлайн
                    break;
                case 10:
                    //Сброс флагов диалога
                    break;
                case 11:
                    //Замена флагов диалога
                    break;
                case 12:
                    //Установка флагов диалога
                    break;
                case 13:
                    //Удаление всех входящих сообщений
                    break;
                case 14:
                    //Востановление удалённых сообщений
                    break;
                case 51:
                    //Один из параметров беседы были изменены
                    break;
                case 61:
                    //Пользователь набирает текст в диалоге
                    break;
                case 62:
                    //Пользователь набирает текст в беседе
                    break;
                case 70:
                    //Пользователь совершил звонок.
                    break;
                case 80:
                    //Счётчик слева изменился
                    break;
                case 114:
                    //Измеидись настройки приватности
                    break;
                default:
                    //Что-то не то
                    break;
            }
        }

    }
}
