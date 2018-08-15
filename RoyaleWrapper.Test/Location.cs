using System;
using System.Threading.Tasks;
using Xunit;

namespace RoyaleWrapper.Test {
    public class Location : TestBase{
        [Fact]
        public async Task GetLocations() {
            var locations = await client.GetLocationsAsync(limit: 2);
            Assert.NotEmpty(locations);
            Assert.Equal(2, locations.Count);
        }

        [Fact]
        public async Task GetLocation() {
            var location = await client.GetLocationAsync(config.LocationId);
            Assert.Equal("United States", location.Name);
        }

        [Fact]
        public async Task GetLocationRankingsClans() {
            var clans = await client.GetLocationRankingsClansAsync(config.LocationId, limit: 2);
            Assert.NotEmpty(clans);
            Assert.Equal(2, clans.Count);
        }

        [Fact]
        public async Task GetLocationRankingsClanWars() {
            var clans = await client.GetLocationRankingsClanWarsAsync(config.LocationId, limit: 2);
            Assert.NotEmpty(clans);
            Assert.Equal(2, clans.Count);
        }

        [Fact]
        public async Task GetLocationRankingsPlayers() {
            var players = await client.GetLocationRankingsPlayersAsync(config.LocationId, limit: 2);
            Assert.NotEmpty(players);
            Assert.Equal(2, players.Count);
        }
    }
}
