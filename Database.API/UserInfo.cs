 using System;
using MySql.Data.MySqlClient;

namespace Database.API
{
    /// <summary>
    /// Класс для получения информации о пользователе с базы данных.
    /// </summary>
    public class UserInfo
    {
        string _user_id;

        /// <summary>
        /// При создании объекта указываем id.
        /// </summary>
        /// <param name="id"></param>
        public UserInfo(string id)
        {
            _user_id = id;
        }

        /// <summary>
        /// Имя.
        /// </summary>
        public string Name
        {
            get
            {
                return GetName(_user_id);
            }
            set
            {
                SetName(_user_id, this.Name);
            }
        }

        /// <summary>
        /// Время бана или пустая строка, если человек не в бане.
        /// </summary>
        public string Ban
        {
            get
            {
                return GetBan(_user_id);
            }
            set
            {
                SetBan(_user_id, this.Ban);
            }
        }

        /// <summary>
        /// Проверка пользователя в базе данных.
        /// </summary>
        public bool IsUser
        {
            get
            {
                return GetIsUser(_user_id);
            }
        }

        public bool IsAdmin
        {
            get
            {
                return GetIsAdmin(_user_id);
            }
            set
            {
                SetIsAdmin(_user_id);
            }
        }

        //Классы для упращения записи.
        private string GetName(string id)
        {
            MySQL.Connect connect = new MySQL.Connect();

            return connect.Get_From_id("name", id);
        }

        private  bool GetIsUser(string id)
        {
            MySQL.Connect connect = new MySQL.Connect();
            return connect.CheckUser(id);
        }

        private string GetBan(string id)
        {
            MySQL.Connect connect = new MySQL.Connect();

            return connect.Get_From_id("ban", id);
        }

        private bool GetIsAdmin(string id)
        {
            MySQL.Connect connect = new MySQL.Connect();
            string value = connect.Get_From_id("admin", id);
            if(value == "1")
            {
                return true;
            } else
            {
                return false;
            }
        }

        private void SetName(string id, string value)
        {
            MySQL.Connect connect = new MySQL.Connect();

            connect.EditField(id, "name", value);
        }

        private void SetBan(string id, string value)
        {
            MySQL.Connect connect = new MySQL.Connect();

            connect.EditField(id, "ban", value);
        }

        private void SetIsAdmin(string id)
        {
            MySQL.Connect connect = new MySQL.Connect();

            connect.EditField(id, "admin", "1");
        }
    }
}
