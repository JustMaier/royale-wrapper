using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RoyaleWrapper.Models {
    public class ResultSet<T> : List<T> {
        public Func<Task<ResultSet<T>>> NextAsync { get; set; }
        public Func<Task<ResultSet<T>>> PreviousAsync { get; set; }
    }
}
