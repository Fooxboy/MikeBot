using System;
using System.Collections.Generic;
using System.Text;

namespace MikeBot.API.LongPoll
{

    //TODO: Переписать логику стартера.

    /// <summary>
    /// Стартер лонгпулла, который возвращает объект.
    /// </summary>
    public static class Starter
    {
        /// <summary>
        /// Запусить.
        /// </summary>
        /// <returns></returns>
        public static Response<List<List<object>>> Start()
        {
            Response<List<List<object>>> resp = new Response<List<List<object>>>();
            resp.error_code = 0;
            if ((Global.key == "") && (Global.server == ""))
            {
                var responseMethod = Method.Messages.GetLongPollServer.Start();

                if (responseMethod.error_code == 0)
                {
                    string key = responseMethod.obj.response.key;
                    string server = responseMethod.obj.response.server;
                    string ts = responseMethod.obj.response.ts;

                    Global.key = key;
                    Global.server = server;
                    Global.ts = ts; 
                } else
                {
                    Console.WriteLine(responseMethod.error.error.error_msg);
                    resp.error_code = 3;
                    resp.error = responseMethod.error;
                }
            }
            if(resp.error_code == 0)
            {
                string json = Request.LongPoll(Global.server, Global.key, Global.ts);
                var response = new Deserialize();
                List<List<object>> longpollobject = response.Run(json).obj.updates;
                resp.error_code = 0;
                resp.obj = longpollobject;
            }
            return resp;
        }
    }
}
