using System;
using System.Collections.Generic;
using System.Text;

namespace RoyaleWrapper.Models {
    public class CurrentWar {
        public string State { get; set; }
        public DateTime WarEndTime { get; set; }
        public WarClan Clan { get; set; }
        public List<WarParticipant> Participants { get; set; }
    }

    public class WarClan : ClanBase {
        public int ClanScore { get; set; }
        public int Participants { get; set; }
        public int BattlesPlayed { get; set; }
        public int Wins { get; set; }
        public int Crowns { get; set; }
    }
}
