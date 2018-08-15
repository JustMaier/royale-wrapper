using System;
using System.Collections.Generic;
using System.Text;

namespace RoyaleWrapper.Models {
    public class ClanDetail : Clan {
        public string Description { get; set; }
        public string ClanChestStatus { get; set; }
        public int ClanChestPoints { get; set; }
        public List<ClanMember> MemberList { get; set; }
    }
}
