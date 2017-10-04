using System;
using MySql.Data.MySqlClient;

namespace Database.API
{
    public class Methods 
    {
        string connection_string = "";

        string table = "";

        public Methods(string connection, string Table) 
        {
            connection_string = connection;
            table = Table;
        }

        public Methods(string Table) 
        {
            connection_string = "server=localhost;SslMode=none;user=root;database=users;port=3306;password=0000";
            table = Table;
        }

        public Methods()
        {
            connection_string = "server=localhost;SslMode=none;user=root;database=users;port=3306;password=0000";
            table = "users.test";
        }

        MySqlConnection connect = new MySqlConnection(connection_string);

        public string GetFromId(string field, string id) 
        {
            connect.Open();

            string sql = $"SELECT {field} FROM {table} WHERE id={id}";
            MySqlCommand command = new MySqlCommand(sql, connect);

            string response = command.ExecuteScalar().ToString();
            connect.Close();
            return response;
        }

        public void EditField(string id, string field, string value) 
        {
            connect.Open();
            string sql  = $"UPDATE {table}  SET `{field}`='{value}' WHERE `id`='{id}';";
            MySqlCommand command = new MySqlCommand(sql, connect);
            command.ExecuteScalar();
            connect.Close;
        }

        public bool CheckUser(string id)
        {
            connect.Open();

            string sql = $"SELECT isYou FROM {table} WHERE id={id}";
            MySqlCommand command = new MySqlCommand(sql, connect);
            MySqlDataReader reader = command.ExecuteReader();

            bool response = false;

            if(reader.Read()) 
            {
                response  = true;
            }

            reader.Close();
            connect.Close();
            return response;
        }

        public void Add(string fields, string values) 
        {
            connect.Open();

            string sql = $@"INSERT INTO {table} ({fields}) VALUES ({values});";
            MySqlCommand command = new MySqlCommand(sql, connect);
            command.ExecuteScalar();
            connect.Close();
        }
    }
}