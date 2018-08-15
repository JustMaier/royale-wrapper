using System;
using System.Collections.Generic;
using System.Text;

namespace RoyaleWrapper.Models {
    public class LeagueStats {
        public SeasonStats CurrentSeason { get; set; }
        public SeasonStats PreviousSeason { get; set; }
        public SeasonStats BestSeason { get; set; }
    }
}
