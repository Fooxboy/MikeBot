using System;
using MySql.Data.MySqlClient;

namespace Database.API
{
    /// <summary>
    /// Класс для работы с Добавлением в БД.
    /// </summary>
    public static class Add
    {
        error
        /// <summary>
        /// Добавить новую строку.
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="values"></param>
        public static void String(string fields, string values)
        {
            var conn = new MySqlConnection("server=localhost;SslMode=none;user=root;database=users;port=3306;password=0000");
            conn.Open();
            string new_sql = $@"INSERT INTO users.test ({fields}) VALUES ({values});";
            Console.WriteLine(new_sql);
            MySqlCommand command = new MySqlCommand(new_sql, conn);
            command.ExecuteScalar();
            conn.Close();
        }
    }
}
