using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace Database.API.MySQL
{
    public class Connect
    {
        public static string connection_string = "server=localhost;SslMode=none;user=root;database=users;port=3306;password=0000";

        public static string table = "users.test";

        MySqlConnection connect = new MySqlConnection(connection_string);

        public string Get_From_id(string field, string id)
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
            string sql = $"UPDATE {table}  SET `{field}`='{value}' WHERE `id`='{id}';";
            MySqlCommand command = new MySqlCommand(sql, connect);
            command.ExecuteScalar();
            connect.Close();
        }

        public bool CheckUser(string id)
        {
            connect.Open();

            string sql = $"SELECT isYou FROM {table} WHERE id={id}";


            MySqlCommand command = new MySqlCommand(sql, connect);

            MySqlDataReader reader = command.ExecuteReader();

            bool retrn = false;
            if (reader.Read())
            {
                retrn = true;
            }
            else
            {

            }
            reader.Close();
            connect.Close();
            return retrn;
        }

    }
}
