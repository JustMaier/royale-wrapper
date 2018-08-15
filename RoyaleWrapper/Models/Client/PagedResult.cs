using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RoyaleWrapper.Helpers;

namespace RoyaleWrapper.Models {
    [JsonConverter(typeof(JsonPathConverter))]
    public class PagedResult<T> {
        public ResultSet<T> Items { get; set; }
        [JsonProperty("paging.cursors")]
        public PagedResultPaging Paging { get; set; }
    }

    public class PagedResultPaging {
        public string Before { get; set; }
        public string After { get; set; }
    }
}
