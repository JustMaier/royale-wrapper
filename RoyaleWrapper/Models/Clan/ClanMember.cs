using System;
using System.Collections.Generic;
using System.Text;

namespace RoyaleWrapper.Models {
    public class ClanMember : PlayerBase {
        public int ClanRank { get; set; }
        public int PreviousClanRank { get; set; }
        public int ClanChestPoints { get; set; }
    }
}
