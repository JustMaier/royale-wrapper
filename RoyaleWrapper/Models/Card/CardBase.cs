using System;
using System.Collections.Generic;
using System.Text;

namespace RoyaleWrapper.Models {
    public class CardBase {
        public string Name { get; set; }
        public int MaxLevel { get; set; }
        public IconUrl IconUrls { get; set; }

        public class IconUrl {
            public string Medium { get; set; }
        }
    }
}
