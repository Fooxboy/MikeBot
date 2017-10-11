using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Database.API;
using MikeBot.SDK.Command;

namespace MikeBot.Command
{
    public static class SaveNameDialog
    {
        public static void Start(ResponseSDKCommand response)
        {
            var user = new UserInfo(response.attach.from);

            //Проверяем права пользователя.


            var vk = API.Vk.Auth();

            long dialog_id = Convert.ToInt64(response.peer_id);

            var oldName = vk.Messages.GetChat(chatId: dialog_id).Title;

            string name_dialog = "";

            foreach(string s in response.arg)
            {
                name_dialog += s;
            }

        }
    }
}
