using System;
using System.Collections.Generic;
using System.Text;

namespace MikeBot.API.LongPoll
{
    /// <summary>
    /// Обработка ошибок лонг пулла
    /// </summary>
    public class Errors
    {
        public string proccesing(string error, LongPoll.Deserialize.ErrorObject obj)
        {
            switch (error)
            {
                case "1":
                    Code1(obj);
                    return "История событий устарела или была частично утеряна, приложение может получать события далее, используя новое значение ts из ответа.";
                case "2":
                    Code2();
                    return "Истекло время действия ключа, нужно заново получить key.";
                case "3":
                    Code3();
                    return "Информация о пользователе утрачена, нужно запросить новые key и ts";
                case "4":
                    Code4();
                    return "Передан недопустимый номер версии в параметре version.";
                default:
                    return "Передан неизвесный код ошибки.";
            }
        }

        private void Code1(LongPoll.Deserialize.ErrorObject obj)
        {
            Global.ts = obj.ts;
        }

        private void Code2()
        {
            var obj_getLongPollServer = Method.Messages.GetLongPollServer.Start();
            if(obj_getLongPollServer.error_code==0)
            {
                var ok = obj_getLongPollServer.obj.response;
                Global.key = ok.key;
            }
            else
            {
                Console.WriteLine(obj_getLongPollServer.error_code);
            }
        }

        private void Code3()
        {
            var obj_getLongPollServer = Method.Messages.GetLongPollServer.Start();
            if (obj_getLongPollServer.error_code==0)
            {
                var ok = obj_getLongPollServer.obj.response;
                Global.key = ok.key;
                Global.ts = ok.ts;
            }
            else
            {
                var error = obj_getLongPollServer.error_code;
                System.Console.WriteLine(error);
            }


        }

        private void Code4()
        {
            //Эта ошибка не может появиться.
        }
    }
}
