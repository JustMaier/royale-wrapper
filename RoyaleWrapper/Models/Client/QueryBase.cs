using System;
using System.Collections.Generic;
using System.Text;

namespace RoyaleWrapper {
    public class QueryBase {
        public QueryBase(int? limit = null, string after = null, string before = null) {
            Limit = limit;
            After = after;
            Before = before;
        }
        public int? Limit { get; set; }
        public string After { get; set; }
        public string Before { get; set; }
    }
}
