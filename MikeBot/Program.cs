using System.Threading;
using System;
using VkNet;

namespace MikeBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.Waring("Старт бота...");

            Thread ThreadLongPoll = new Thread(new ThreadStart(StartLongPoll));
            ThreadLongPoll.Name = "LongPoll";
            Console.Title = "MikeBot - Работает";
            ThreadLongPoll.Start();
        }

        private static void StartLongPoll()
        {
            while (true)
            {
                var response_longpoll = API.LongPoll.Starter.Start();
                if (response_longpoll.obj == null)
                {
                    Global.key = "";
                    Global.server = "";
                } else
                {
                    API.LongPoll.Proccesing.Start(response_longpoll.obj);
                }
            }  
        }
    }
}
