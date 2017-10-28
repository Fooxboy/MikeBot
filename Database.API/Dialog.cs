using System;
using System.Collections.Generic;
using System.Text;

namespace Database.API
{
    public class Dialog
    {
        public string Id;
        static Database database = new Database()
        {
            value = "mike"
        };
        static Table table = new Table()
        {
            value = "dialogs"
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
        public string Admin
        {
            get
            {
                return method.GetFromId(Id, "Admin");
            }set
            {
                method.EditField(Id, "Admin", Admin);
            }
        }
        public bool IsDialog
        {
            get
            {
                return method.CheckUser(Id);
            }
        }
    }
}
