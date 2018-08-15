using System;
using System.Collections.Generic;
using System.Text;

namespace RoyaleWrapper.Models {
    public class PlayerBase: IPlayer {
        public string Tag { get; set; }
        public string Name { get; set; }
        public int ExpLevel { get; set; }
        public int Trophies { get; set; }
        public Arena Arena { get; set; }
        public string Role { get; set; }
        public int Donations { get; set; }
        public int DonationsReceived { get; set; }
    }
}
