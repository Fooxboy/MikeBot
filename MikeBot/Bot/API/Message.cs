using System;
using System.Collections.Generic;
using System.Text;

namespace MikeBot.Bot.API
{
    public static class Message
    {
        public static bool Send(string message, string fors, string message_id="")
        {
            var obj = MikeBot.API.Method.Messages.Send.Start(fors, "", message, message_id);

            if(obj.error_code == 0)
            {
                return true;
            } else
            {
                return false;
            }
            
        }
    }
}
