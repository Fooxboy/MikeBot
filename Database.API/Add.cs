using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace Database.API
{
    /// <summary>
    /// Класс для работы с Добавлением в БД.
    /// </summary>
    public static class Add
    {
        /// <summary>
        /// Добавить новую строку.
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="values"></param>
        public static void String(string fields, string values)
        {
            var conn = new MySqlConnection(MySQL.Connect.connection_string);
            conn.Open();
            string new_sql = $@"INSERT INTO {MySQL.Connect.table} ({fields}) VALUES ({values});";
            Console.WriteLine(new_sql);
            MySqlCommand command = new MySqlCommand(new_sql, conn);
            command.ExecuteScalar();
            conn.Close();
        }
    }
}
