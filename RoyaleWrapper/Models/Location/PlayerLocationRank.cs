using System;
using System.Collections.Generic;
using System.Text;

namespace RoyaleWrapper.Models {
    public class PlayerLocationRank : LocationRank, IPlayer {
        public int ExpLevel { get; set; }
        public int Trophies { get; set; }
        public ClanBase Clan { get; set; }
        public Arena Arena { get; set; }
    }
}
