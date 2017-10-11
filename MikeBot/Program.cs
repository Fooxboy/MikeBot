using System.Threading;

namespace MikeBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.Waring("Старт бота...");

            Debug.Waring("Запуск потока 1");
            Thread ThreadLongPoll = new Thread(new ThreadStart(StartLongPoll));
            ThreadLongPoll.Name = "LongPoll";
            ThreadLongPoll.Start();
        }

        private static void StartLongPoll()
        {
            while (true)
            {
                Debug.Waring("Код потока 1");
                var response_longpoll = API.LongPoll.Starter.Start();

                if (response_longpoll.obj == null)
                {
                    Debug.Error("Ошибка. obj == null");
                    Global.key = "";
                    Global.server = "";
                    //Debug.Error(response_longpoll.error.error.error_msg);
                } else
                {
                    API.LongPoll.Proccesing.Start(response_longpoll.obj);
                }
               
            }
           
        }
    }
}
