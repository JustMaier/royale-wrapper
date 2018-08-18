using System;
using System.Collections.Generic;
using System.Text;

namespace RoyaleWrapper.Models {
    public class War {
        public string SeasonId { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<WarParticipant> Participants { get; set; }
    }
}
