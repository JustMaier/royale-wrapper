using System;
using System.Collections.Generic;
using System.Text;

namespace RoyaleWrapper.Models {
    public class TournamentDetail : Tournament {
        public List<TournamentParticipant> MemberList { get; set; }
    }
}
