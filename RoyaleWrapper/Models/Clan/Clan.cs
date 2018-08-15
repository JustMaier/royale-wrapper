using System;
using System.Collections.Generic;
using System.Text;

namespace RoyaleWrapper.Models {
    public class Clan : ClanBase {
        public string Type { get; set; }
        public int ClanScore { get; set; }
        public int RequiredTrophies { get; set; }
        public int DonationsPerWeek { get; set; }
        public int ClanChestLevel { get; set; }
        public int ClanChestMaxLevel { get; set; }
        public int Members { get; set; }
        public Location Location { get; set; }
    }
}
