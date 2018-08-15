using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace RoyaleWrapper.Test {
    public class Player : TestBase{
        [Fact]
        public async Task GetPlayer() {
            var player = await client.GetPlayerAsync(config.PlayerTag);
            Assert.Equal(config.PlayerTag, player.Tag);
        }

        [Fact]
        public async Task GetUpcomingChests() {
            var chests = await client.GetUpcomingChestsAsync(config.PlayerTag);
            Assert.NotEmpty(chests);
        }

        [Fact]
        public async Task GetBattleLog() {
            var battles = await client.GetBattleLogAsync(config.PlayerTag);
            Assert.NotEmpty(battles);
        }
    }
}
