using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace RoyaleWrapper.Test {
    public class Tournament : TestBase{
        [Fact]
        public async Task GetTournaments() {
            var tournaments = await client.GetTournamentsAsync("a", limit: 1);
            Assert.NotEmpty(tournaments);
        }

        [Fact]
        public async Task GetTournament() {
            var tournaments = await client.GetTournamentsAsync("a", limit: 1);
            var tournament = await client.GetTournamentAsync(tournaments.FirstOrDefault().Tag);
            Assert.Equal(tournaments.FirstOrDefault().Tag, tournament.Tag);
        }
    }
}
