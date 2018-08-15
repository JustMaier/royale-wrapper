using System;
using System.Collections.Generic;
using System.Text;

namespace RoyaleWrapper.Models {
    public class TournamentParticipant : IPlayer {
        public string Tag { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public int Rank { get; set; }
        public ClanBase Clan { get; set; }
    }
}
