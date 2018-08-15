using System;
using System.Collections.Generic;
using System.Text;

namespace RoyaleWrapper.Models {
    public class ClanBase : IClan {
        public string Tag { get; set; }
        public string Name { get; set; }
        public int BadgeId { get; set; }
    }
}
