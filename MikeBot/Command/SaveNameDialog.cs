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

            var vk = API.Vk.Auth();
            long dialog_id = Convert.ToInt64(response.peer_id);
            var info_dialog = vk.Messages.GetChat(chatId: dialog_id);
            long id = Convert.ToInt64(response.attach.from);
            string pr = user.Privileges.ToLower();

            if(pr != "user")
            {
                var oldName = info_dialog.Title;

                string name_dialog = "";

                if (response.arg.Length == 0)
                {
                    name_dialog = oldName;
                }
                else
                {
                    foreach (string s in response.arg)
                    {
                        name_dialog += s;
                    }
                }

                var dialog = new DialogInfo(dialog_id.ToString());

                if(!dialog.IsDialog)
                {
                    Methods_OLD method = new Methods_OLD("dialog");
                    string fields = @"`id`, `name`, `admin`, `isYou`";
                    string values = $@"'{dialog_id}', '{name_dialog}', '{id}', '1'";
                    method.Add(fields, values);
                }

                if(id.ToString() != dialog.Admin)
                {
                    Bot.API.Message.Send($"Вы не можете изменить название в этой беседе! Изменить может [{id}|этот] пользователь.", dialog_id.ToString());
                } else
                {
                    vk.Messages.EditChat(dialog_id, name_dialog);
                    Bot.API.Message.Send($"Вы успешно сохранили название {name_dialog} ", dialog_id.ToString());
                }      
            } else
            {
                Bot.API.Message.Send("У Вас нет прав! Купите привилегию Vip или выше. Подробнее: Майк, донат.", dialog_id.ToString());
            }

        }

        public static bool Check(string dialog_id, string id)
        {
            long _dialog_id = Convert.ToInt64(dialog_id);
            var dialog = new DialogInfo(dialog_id);

            if(dialog.IsDialog)
            {
                var vk = API.Vk.Auth();

                var id_creator = vk.Messages.GetChat(_dialog_id).AdminId;

                var admin = dialog.Admin;

                if((id == id_creator.ToString()) || (id ==admin))
                {
                    return false;
                } else
                {
                    string name_dialog = dialog.Name;
                    vk.Messages.EditChat(_dialog_id, name_dialog);
                    Bot.API.Message.Send("Для того, чтобы изменить название, обратитесь к [{id_creator}|создателю] диалога  или тому [{admin}|кто сохранил] название.", dialog_id);
                    return true;
                }
            } else
            {
                return false;
            }
        }
    }

}
