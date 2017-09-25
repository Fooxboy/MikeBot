using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace MikeBot.Mafia
{
    /// <summary>
    /// Класс для получения и редактирования информации о играх беседы.
    /// </summary>
    public class InfoDialog
    {
        string id;
        public InfoDialog(string id_dialog)
        {
            id = id_dialog;
        }

        /// <summary>
        /// Количество игр
        /// </summary>
        public int CoutGames
        {
            get
            {
                return GetCountGames(id);
            }
        }

        /// <summary>
        /// Дата первой игры
        /// </summary>
        public string FirstGame
        {
            get
            {
                return GetFirstGame(id);
            }
        }

        /// <summary>
        /// Дата последней игры
        /// </summary>
        public string LastGame
        {
            get
            {
                return GetLastGame(id);
            }
        }

        /// <summary>
        /// Лучший игрок
        /// </summary>
        public string BestPlayer
        {
            get
            {
                return GetBestPlayer(id);
            }
        }

        /// <summary>
        /// Максимальное кол-во игроков за всё время
        /// </summary>
        public int MaxPlayers
        {
            get
            {
                return GetMaxPlayers(id);
            }
        }

        /// <summary>
        /// Максимальное кол-во пережитых ночей.
        /// </summary>
        public int MaxNight
        {
            get
            {
                return GetMaxNight(id);
            }
        }

        private string GetFirstGame(string id)
        {
            string path = $@"MafiaGames\{id}\Main.txt";
            string json = Methods.ReadFile.Start(path);
            var obj = Methods.DeserializeMain.Start(json);
            return obj.first_game;

        }

        private string GetBestPlayer(string id)
        {
            string path = $@"MafiaGames\{id}\Main.txt";
            string json = Methods.ReadFile.Start(path);
            var obj = Methods.DeserializeMain.Start(json);
            return obj.best_player;
        }

        private int GetMaxPlayers(string id)
        {
            string path = $@"MafiaGames\{id}\Main.txt";
            string json = Methods.ReadFile.Start(path);
            var obj = Methods.DeserializeMain.Start(json);
            return obj.max_players;
        }

        private int GetMaxNight(string id)
        {
            string path = $@"MafiaGames\{id}\Main.txt";
            string json = Methods.ReadFile.Start(path);
            var obj = Methods.DeserializeMain.Start(json);
            return obj.max_night;
        }

        private string GetLastGame(string id)
        {
            string path = $@"MafiaGames\{id}\Main.txt";
            string json = Methods.ReadFile.Start(path);
            var obj = Methods.DeserializeMain.Start(json);
            return obj.last_game;
        }

        private int GetCountGames(string id_dialog)
        {
            //Читаем данные с файла.
            string path = $@"MafiaGames\{id_dialog}\Main.txt";
            string json = Methods.ReadFile.Start(path);
            var obj = Methods.DeserializeMain.Start(json);
            return obj.count_games;
        }

    }
}
