using System;
using System.Collections.Generic;
using System.Text;

namespace RoyaleWrapper.Models {
    public class Battle {
        public string Type { get; set; }
        public string BattleTime { get; set; }
        public Arena Arena { get; set; }
        public GameMode GameMode { get; set; }
        public string DeckSelection { get; set; }
        public List<Team> Team { get; set; }
        public List<Team> Opponent { get; set; }
    }

    public class GameMode {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Team: IPlayer {
        public string Name { get; set; }
        public string Tag { get; set; }
        public int StartingTrophies { get; set; }
        public int TrophyChange { get; set; }
        public int Crowns { get; set; }
        public ClanBase Clan { get; set; }
        public List<PlayerCard> Cards { get; set; }
    }
}
