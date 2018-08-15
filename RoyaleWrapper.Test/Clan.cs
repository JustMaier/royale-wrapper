using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace RoyaleWrapper.Test {
    public class Clan : TestBase{
        [Fact]
        public async Task GetClansByName() {
            var clans = await client.GetClansAsync("b kindom");
            Assert.NotEmpty(clans);
            Assert.Contains(clans, x => x.Name == "b kindom");
        }

        [Fact]
        public async Task GetClansByQuery() {
            var clans = await client.GetClansAsync(new QueryClan { Name = "b kindom", MinScore = 40000 });
            Assert.NotEmpty(clans);
            Assert.Contains(clans, x => x.Name == "b kindom");
        }

        [Fact]
        public async Task GetClan() {
            var clan = await client.GetClanAsync(config.ClanTag);
            Assert.Equal(config.ClanTag, clan.Tag);
        }

        [Fact]
        public async Task GetClanMembers() {
            var members = await client.GetClanMembersAsync(config.ClanTag);
            Assert.NotEmpty(members);
        }

        [Fact]
        public async Task GetClanWarLog() {
            var wars = await client.GetClanWarLogAsync(config.ClanTag);
            Assert.NotEmpty(wars);
        }

        [Fact]
        public async Task GetClanCurrentWar() {
            var war = await client.GetClanCurrentWarAsync(config.ClanTag);
            Assert.Equal(config.ClanTag, war.Clan.Tag);
        }
    }
}
