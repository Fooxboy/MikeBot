using System;
using MySql.Data.MySqlClient;

namespace  Database.API
{
    public class UserInfo
     {
        string id = "";
        Methods method = new Methods();
        public UserInfo(string user_id) 
        {
            id = user_id;
        }

        public string Name 
        {
            get 
            {
                return method.GetFromId("name", id);
            }
            set 
            {
                method.EditField(id, "name", Name);
            }
        }

        public string Ban 
        {
            get 
            {
                return method.GetFromId("ban", id);
            }
            set 
            {
                method.EditField(id, "ban", Ban);
            }
        }

        public bool IsUser 
        {
            get 
            {
                return method.CheckUser(id);
            }
        }

        public string Privileges
        {
            get
            {
                return method.GetFromId("privileges", id);
            }
            set
            {
                method.EditField(id, "privilegies", Privileges);
            }
        }

        public string PrivegesTime
        {
            get
            {
                return method.GetFromId("priveleges_time", id);
            } set
            {
                method.EditField(id, "priveleges_time", PrivegesTime);
            }
        }

        public bool IsAdmin 
        {
            get 
            {
               string value = method.GetFromId("admin", id);
               
               if(value == "1") 
               {
                   return true;
               } else 
               {
                   return false;
               }
            }
            set 
            {
                if(IsAdmin) 
                {
                    method.EditField(id, "admin", "1");
                } else {
                    method.EditField(id, "admin", "0");
                }
            }
        }
    }
}