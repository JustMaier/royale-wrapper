using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace RoyaleWrapper.Test {
    public class Paging : TestBase {
        [Fact]
        public async Task PagingForwardAndBack() {
            var locations = await client.GetLocationsAsync(limit: 2);
            Assert.NotEmpty(locations);
            Assert.Equal(2, locations.Count);
            var nextLocations = await locations.NextAsync();
            Assert.NotEmpty(nextLocations);
            Assert.Equal(2, nextLocations.Count);
            Assert.NotEqual(locations.FirstOrDefault().Id, nextLocations.FirstOrDefault().Id);
            var prevLocations = await nextLocations.PreviousAsync();
            Assert.NotEmpty(prevLocations);
            Assert.Equal(2, prevLocations.Count);
            Assert.Equal(locations.FirstOrDefault().Id, prevLocations.FirstOrDefault().Id);
        }

        [Fact]
        public async Task PagingInLoop() {
            var clans = await client.GetLocationRankingsClansAsync(config.LocationId, limit: 50);
            while (!clans.Any(x => x.Tag == config.ClanTag) && clans.NextAsync != null) {
                clans = await clans.NextAsync();
            }
            Assert.DoesNotContain(clans, x => x.Tag == config.ClanTag);
        }
    }
}
