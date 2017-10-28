using System;
using System.Collections.Generic;
using System.Text;

namespace Database.API
{
    public class User
    {
        public string Id;
        static Database database = new Database()
        {
            value = "mike"
        };
        static Table table = new Table()
        {
            value = "users"
        };

        Methods method = new Methods(database, table);

        public string Name
        {
            get
            {
                return method.GetFromId(Id, "Name");
            }set
            {
                method.EditField(Id, "Name", Name);
            }
        }
        public bool Ban
        {
            get
            {
                var value = method.GetFromId(Id, "Ban");

                if(value == "1")
                {
                    return true;
                } else
                {
                    return false;
                }
            }set
            {
                var values = "0";
                if(Ban == true)
                {
                    values = "1";
                }

                method.EditField(Id, "Ban", values);
            }
        }
        public bool IsUser
        {
            get
            {
                return method.CheckUser(Id);
            }
        }
        public string Privileges
        {
            get
            {
               return method.GetFromId(Id, "Privileges");
            }set
            {
                method.EditField(Id, "Privileges", Privileges);
            }
        }
        public string PrivegesTime
        {
            get
            {
                return method.GetFromId(Id, "PrivegesTime");

            } set
            {
                method.EditField(Id, "PrivegesTime", PrivegesTime);
            }
        }
    }
}
