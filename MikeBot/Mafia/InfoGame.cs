using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MikeBot.Mafia
{
    public class InfoGame
    {
        Models.Mafia.GameFile model = null;
        string id = "";
        string path = "";
        public InfoGame(string dialog_id)
        {
            var info = new InfoDialog(dialog_id);
            int count_game = info.CoutGames;
            int game = count_game++;
            path = $@"MafiaGames\{dialog_id}\{game}.txt";
            string json = Methods.ReadFile.Start(path);
            model = JsonConvert.DeserializeObject<Models.Mafia.GameFile>(json);
            id = dialog_id;
        }

        public List<string> IdPlayers { get { return model.id_players; }
            set
            {
                var info = new InfoGame(id);
                var model = new Models.Mafia.GameFile();
                model.characters = info.Characters;
                model.count_players = info.CountPlayers;
                model.creator_game = info.CreatorGame;
                model.id_players = IdPlayers;
                model.isStart = info.IsStart;
                model.live_players = info.LivePlayers;
                model.night = info.Night;
                model.players_action = info.PlayersAction;
                model.time = info.Time;
                string json = JsonConvert.SerializeObject(model);
                Methods.WriteFile.Start(json, path);

            }
        }
        public List<string> Characters { get { return model.characters; }
            set
            {
                var info = new InfoGame(id);
                var model = new Models.Mafia.GameFile();
                model.characters = Characters;
                model.count_players = info.CountPlayers;
                model.creator_game = info.CreatorGame;
                model.id_players = info.IdPlayers;
                model.isStart = info.IsStart;
                model.live_players = info.LivePlayers;
                model.night = info.Night;
                model.players_action = info.PlayersAction;
                model.time = info.Time;
                string json = JsonConvert.SerializeObject(model);
                Methods.WriteFile.Start(json, path);
            }
        }
        public List<string> LivePlayers { get { return model.live_players; }
            set
            {
                var info = new InfoGame(id);
                var model = new Models.Mafia.GameFile();
                model.characters = info.Characters;
                model.count_players = info.CountPlayers;
                model.creator_game = info.CreatorGame;
                model.id_players = info.IdPlayers;
                model.isStart = info.IsStart;
                model.live_players = LivePlayers;
                model.night = info.Night;
                model.players_action = info.PlayersAction;
                model.time = info.Time;
                string json = JsonConvert.SerializeObject(model);
                Methods.WriteFile.Start(json, path);
            }
        }
        public int CountPlayers { get { return model.count_players; }
            set
            {
                var info = new InfoGame(id);
                var model = new Models.Mafia.GameFile();
                model.characters = info.Characters;
                model.count_players = CountPlayers;
                model.creator_game = info.CreatorGame;
                model.id_players = info.IdPlayers;
                model.isStart = info.IsStart;
                model.live_players = info.LivePlayers;
                model.night = info.Night;
                model.players_action = info.PlayersAction;
                model.time = info.Time;
                string json = JsonConvert.SerializeObject(model);
                Methods.WriteFile.Start(json, path);
            }
        }
        public string CreatorGame { get { return model.creator_game; }
            set
            {
                var info = new InfoGame(id);
                var model = new Models.Mafia.GameFile();
                model.characters = info.Characters;
                model.count_players = info.CountPlayers;
                model.creator_game = CreatorGame;
                model.id_players = info.IdPlayers;
                model.isStart = info.IsStart;
                model.live_players = info.LivePlayers;
                model.night = info.Night;
                model.players_action = info.PlayersAction;
                model.time = info.Time;
                string json = JsonConvert.SerializeObject(model);
                Methods.WriteFile.Start(json, path);
            }
        }
        public int Night { get { return model.night; }
            set
            {
                var info = new InfoGame(id);
                var model = new Models.Mafia.GameFile();
                model.characters = info.Characters;
                model.count_players = info.CountPlayers;
                model.creator_game = info.CreatorGame;
                model.id_players = info.IdPlayers;
                model.isStart = info.IsStart;
                model.live_players = info.LivePlayers;
                model.night = Night;
                model.players_action = info.PlayersAction;
                model.time = info.Time;
                string json = JsonConvert.SerializeObject(model);
                Methods.WriteFile.Start(json, path);
            }
        }
        public string Time { get { return model.time; }
            set
            {
                var info = new InfoGame(id);
                var model = new Models.Mafia.GameFile();
                model.characters = info.Characters;
                model.count_players = info.CountPlayers;
                model.creator_game = info.CreatorGame;
                model.id_players = info.IdPlayers;
                model.isStart = info.IsStart;
                model.live_players = info.LivePlayers;
                model.night = info.Night;
                model.players_action = info.PlayersAction;
                model.time = Time;
                string json = JsonConvert.SerializeObject(model);
                Methods.WriteFile.Start(json, path);
            }
        }
        public string IsStart { get { return model.isStart; }
            set
            {
                var info = new InfoGame(id);
                var model = new Models.Mafia.GameFile();
                model.characters = info.Characters;
                model.count_players = info.CountPlayers;
                model.creator_game = info.CreatorGame;
                model.id_players = info.IdPlayers;
                model.isStart = IsStart;
                model.live_players = info.LivePlayers;
                model.night = info.Night;
                model.players_action = info.PlayersAction;
                model.time = info.Time;
                string json = JsonConvert.SerializeObject(model);
                Methods.WriteFile.Start(json, path);
            }
        }
        public int PlayersAction { get { return model.players_action; }
            set
            {
                var info = new InfoGame(id);
                var model = new Models.Mafia.GameFile();
                model.characters = info.Characters;
                model.count_players = info.CountPlayers;
                model.creator_game = info.CreatorGame;
                model.id_players = info.IdPlayers;
                model.isStart = info.IsStart;
                model.live_players = info.LivePlayers;
                model.night = info.Night;
                model.players_action = PlayersAction;
                model.time = info.Time;
                string json = JsonConvert.SerializeObject(model);
                Methods.WriteFile.Start(json, path);
            }
        }
    }
}
