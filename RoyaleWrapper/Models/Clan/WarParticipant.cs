using System;
using System.Collections.Generic;
using System.Text;

namespace RoyaleWrapper.Models {
    public class WarParticipant: IPlayer {
        public string Tag { get; set; }
        public string Name { get; set; }
        public int CardsEarned { get; set; }
        public int BattlesPlayed { get; set; }
        public int Wins { get; set; }
    }
}
