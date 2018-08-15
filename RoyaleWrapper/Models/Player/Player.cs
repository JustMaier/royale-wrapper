using System;
using System.Collections.Generic;
using System.Text;

namespace RoyaleWrapper.Models {
    public class Player : PlayerBase{
        public int BestTrophies { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int BattleCount { get; set; }
        public int ThreeCrownWins { get; set; }
        public int ChallengeCardsWon { get; set; }
        public int ChallengeMaxWins { get; set; }
        public int TournamentCardsWon { get; set; }
        public int TournamentBattleCount { get; set; }
        public int TotalDonations { get; set; }
        public int WarDayWins { get; set; }
        public int ClanCardsCollected { get; set; }
        public ClanBase Clan { get; set; }
        public LeagueStats LeagueStatistics { get; set; }
        public List<Achievement> Achievements { get; set; }
        public List<PlayerCard> Cards { get; set; }
        public Card CurrentFavoriteCard { get; set; }
    }
}
