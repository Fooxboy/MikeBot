using System;
using System.Collections.Generic;
using System.Text;

namespace Database.API
{
    public class DialogInfo
    {
        string id;

        Methods method = new Methods("dialog");

        public DialogInfo(string dialog_id)
        {
            id = dialog_id;
        }

        public string Name
        {
            get
            {
               return method.GetFromId("name", id);
            } set
            {
                method.EditField(id, "name", Name);
            }
        }
        public string Admin
        {
            get
            {
                return method.GetFromId("admin", id);
            } set
            {
                method.EditField(id, "admin", Admin);
            }
        }
        public bool IsDialog
        {
            get
            {
                return method.CheckUser(id);
            }
        }
    }
}
