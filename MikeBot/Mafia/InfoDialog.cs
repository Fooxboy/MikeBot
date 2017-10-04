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
        Models.Mafia.MainFile obj = null;
        public InfoDialog(string id_dialog)
        {
            id = id_dialog;
            string path = $@"MafiaGames\{id}\Main.json";
            string json = Methods.ReadFile.Start(path);
            obj = Methods.DeserializeMain.Start(json);
        }

        /// <summary>
        /// Количество игр
        /// </summary>
        public int CoutGames
        {
            get
            {
                
                return obj.count_games;
            }
            set
            {
                string path = $@"MafiaGames\{id}\Main.json";
                var info = new InfoDialog(id);
                var model = new Models.Mafia.MainFile();
                model.count_games = CoutGames;
                model.best_player = info.BestPlayer;
                model.first_game = info.FirstGame;
                model.last_game = info.LastGame;
                model.max_night = info.MaxNight;
                model.max_players = info.MaxPlayers;
                model.play = info.Play;
                string json = JsonConvert.SerializeObject(model);
                Methods.WriteFile.Start(json, path);
            }
        }

        /// <summary>
        /// Дата первой игры
        /// </summary>
        public string FirstGame
        {
            get
            {
               
                return obj.first_game;
            }
            set
            {
                string path = $@"MafiaGames\{id}\Main.json";
                var info = new InfoDialog(id);
                var model = new Models.Mafia.MainFile();
                model.count_games = info.CoutGames;
                model.best_player = info.BestPlayer;
                model.first_game = FirstGame;
                model.last_game = info.LastGame;
                model.max_night = info.MaxNight;
                model.max_players = info.MaxPlayers;
                model.play = info.Play;
                string json = JsonConvert.SerializeObject(model);
                Methods.WriteFile.Start(json, path);
            }
        }

        /// <summary>
        /// Дата последней игры
        /// </summary>
        public string LastGame
        {
            get
            {
               
                return obj.last_game;
            }
            set
            {
                string path = $@"MafiaGames\{id}\Main.json";
                var info = new InfoDialog(id);
                var model = new Models.Mafia.MainFile();
                model.count_games = info.CoutGames;
                model.best_player = info.BestPlayer;
                model.first_game = info.FirstGame;
                model.last_game = LastGame;
                model.max_night = info.MaxNight;
                model.max_players = info.MaxPlayers;
                model.play = info.Play;
                string json = JsonConvert.SerializeObject(model);
                Methods.WriteFile.Start(json, path);
            }
        }

        /// <summary>
        /// Лучший игрок
        /// </summary>
        public string BestPlayer
        {
            get
            {
               
                return obj.best_player;
            }
            set
            {
                string path = $@"MafiaGames\{id}\Main.json";
                var info = new InfoDialog(id);
                var model = new Models.Mafia.MainFile();
                model.count_games = info.CoutGames;
                model.best_player = info.BestPlayer;
                model.first_game = info.FirstGame;
                model.last_game = LastGame;
                model.max_night = info.MaxNight;
                model.max_players = info.MaxPlayers;
                model.play = info.Play;
                string json = JsonConvert.SerializeObject(model);
                Methods.WriteFile.Start(json, path);
            }
        }

        /// <summary>
        /// Максимальное кол-во игроков за всё время
        /// </summary>
        public int MaxPlayers
        {
            get
            {
               
                return obj.max_players;
            }
            set
            {
                string path = $@"MafiaGames\{id}\Main.json";
                var info = new InfoDialog(id);
                var model = new Models.Mafia.MainFile();
                model.count_games = info.CoutGames;
                model.best_player = info.BestPlayer;
                model.first_game = info.FirstGame;
                model.last_game = info.LastGame;
                model.max_night = info.MaxNight;
                model.max_players = MaxPlayers;
                model.play = info.Play;
                string json = JsonConvert.SerializeObject(model);
                Methods.WriteFile.Start(json, path);
            }
        }

        /// <summary>
        /// Максимальное кол-во пережитых ночей.
        /// </summary>
        public int MaxNight
        {
            get
            {
                
                return obj.max_night;
            }
            set
            {
                string path = $@"MafiaGames\{id}\Main.json";
                var info = new InfoDialog(id);
                var model = new Models.Mafia.MainFile();
                model.count_games = info.CoutGames;
                model.best_player = info.BestPlayer;
                model.first_game = info.FirstGame;
                model.last_game = info.LastGame;
                model.max_night = MaxNight;
                model.max_players = info.MaxPlayers;
                model.play = info.Play;
                string json = JsonConvert.SerializeObject(model);
                Methods.WriteFile.Start(json, path);
            }
        }

        public bool Play
        {
            get
            {
               
                return obj.play;
            }
            set
            {
                string path = $@"MafiaGames\{id}\Main.json";
                var info = new InfoDialog(id);
                var model = new Models.Mafia.MainFile();
                model.count_games = info.CoutGames;
                model.best_player = info.BestPlayer;
                model.first_game = info.FirstGame;
                model.last_game = info.LastGame;
                model.max_night = info.MaxNight;
                model.max_players = info.MaxPlayers;
                model.play = Play;
                string json = JsonConvert.SerializeObject(model);
                Methods.WriteFile.Start(json, path);
            }
        }
    }
}
