using System;
using System.Threading;
using System.Linq;

namespace MikeBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.Waring("Старт бота...");

            /* Debug.Waring("Запуск потока 1");
             Thread ThreadLongPoll = new Thread(new ThreadStart(StartLongPoll));
             ThreadLongPoll.Name = "LongPoll";
             ThreadLongPoll.Start();

             Debug.Waring("Запуск потока 2");
             Thread ThreadSendMessage = new Thread(new ThreadStart(SendMessage));
             ThreadSendMessage.Name = "Console";
             ThreadSendMessage.Start(); */



        }

        private static void SendMessage()
        {
            while(true)
            {
                Console.WriteLine("Написать сообщение..");

                Console.Write("Назначение: ");
                string peer_id = Console.ReadLine();
                Console.WriteLine();
                Console.Write("Сообщение: ");
                string message = Console.ReadLine();

                var resp = API.Method.Messages.Send.Start("",peer_id, message);
                if(resp.error_code == 0)
                {
                    //Console.WriteLine("Сообщение отправлено!");
                } else
                {

                }
            }
        }

        private static void StartLongPoll()
        {
            while(true)
            {
                var response_longpoll = API.LongPoll.Starter.Start();
                API.LongPoll.Proccesing.Start(response_longpoll.obj);
            }
           
        }
    }
}
