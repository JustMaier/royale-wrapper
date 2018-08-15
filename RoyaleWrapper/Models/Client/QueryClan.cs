using System;
using System.Collections.Generic;
using System.Text;

namespace RoyaleWrapper {
    public class QueryClan : QueryBase {
        public string Name { get; set; }
        public int? LocationId { get; set; }
        public int? MinMembers { get; set; }
        public int? MaxMembers { get; set; }
        public int? MinScore { get; set; }
    }
}
