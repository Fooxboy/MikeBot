using System;
using System.Collections.Generic;
using System.Text;

namespace Database.API
{
    public class Ban
    {
        public string Id;
        static Database database = new Database()
        {
            value = "mike"
        };
        static Table table = new Table()
        {
            value = "bans"
        };

        Methods method = new Methods(database, table);

        public string Time
        {
            get
            {
                return method.GetFromId(Id, "Time");
            }set
            {
                method.EditField(Id, "Time", Time);
            }
        }
        public string From
        {
            get
            {
                return method.GetFromId(Id, "From");
            }set
            {
                method.EditField(Id, "From", From);
            }
        }
        public string Count
        {
            get
            {
                return method.GetFromId(Id, "Count");
            }set
            {
                method.EditField(Id, "Count", Count);
            }
        }
    }
}
