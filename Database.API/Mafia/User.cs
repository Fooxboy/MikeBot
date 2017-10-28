using System;
using System.Collections.Generic;
using System.Text;

namespace Database.API.Mafia
{
    public class User
    {
        public string Id;
        static Database database = new Database()
        {
            value = "mafia"
        };
        static Table table = new Table()
        {
            value = "users"
        };
        Methods method = new Methods(database, table);

        public string PlayId
        {
            get
            {
                return method.GetFromId(Id, "PlayId");
            } set
            {
                method.EditField(Id, "PlayId", PlayId);
            }
        }
        public string CountGames
        {
            get
            {
                return method.GetFromId(Id, "CountGames");
            }set
            {
                method.EditField(Id, "CountGames", CountGames);
            }
        }
        public string CountWins
        {
            get
            {
                return method.GetFromId(Id, "CountWins");
            }set
            {
                method.EditField(Id, "CountWins", CountWins);
            }
        }
        public bool IsUser
        {
            get
            {
                return method.CheckUser(Id);
            }
        }
    }
}
