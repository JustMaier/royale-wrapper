using System;
using System.Collections.Generic;
using System.Text;

namespace RoyaleWrapper.Models {
    public class ClanLocationRank : LocationRank, IClan {
        public int ClanScore { get; set; }
        public int BadgeId { get; set; }
        public int Members { get; set; }
        public Location Location { get; set; }
    }
}
