using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MikeBot.API.LongPoll.ProccesingCode
{
    public static class Code4
    {
        public static void Start(List<List<object>> ObjectLongPoll, int i)
        {
            string message_id = ObjectLongPoll[i][1].ToString();
            string message_flags = (string)ObjectLongPoll[i][2].ToString();
            string peer_id = (string)ObjectLongPoll[i][3].ToString();
            string time = (string)ObjectLongPoll[i][4].ToString();
            string text = (string)ObjectLongPoll[i][5].ToString();
            var type_attach = (Newtonsoft.Json.Linq.JObject)ObjectLongPoll[i][6];

            var attach = type_attach.ToObject<Models.Attach>();

            object[] response = new object[6];
            response[0] = message_id;
            response[1] = message_flags;
            response[2] = peer_id;
            response[3] = time;
            response[4] = text;
            response[5] = attach;

            //Отправляем сдк обработки команд
            getParametr get = new getParametr();
            get.array = response;
            Thread threadSDK = new Thread(new ParameterizedThreadStart(runSDK));
            threadSDK.Name = "Обработка сообщений";
            Debug.Waring("\nПоток 2");
            threadSDK.Start(get);
        }

        private static void runSDK(object resp)
        {
            var obj = (getParametr)resp;
            object[] response = obj.array;
            SDK.Command.Main.Start(response);
        }

        public class getParametr
        {
            public object[] array;
        }
    }

}
