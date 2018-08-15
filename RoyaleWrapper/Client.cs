using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RoyaleWrapper.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;

namespace RoyaleWrapper {
    public class Client {
        private readonly HttpClient client;

        public Client(string key) {
            client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", key);
            client.BaseAddress = new Uri("https://api.clashroyale.com/v1/");
        }

        #region Clans
        private const string CLAN_ENDPOINT = "clans";
        public async Task<ResultSet<Clan>> GetClansAsync(string name) => await GetClansAsync(new QueryClan { Name = name });
        public async Task<ResultSet<Clan>> GetClansAsync(QueryClan query) => await GetPageAsync<Clan>($"{CLAN_ENDPOINT}", query);
        public async Task<ClanDetail> GetClanAsync(string clanTag) => await GetAsync<ClanDetail>($"{CLAN_ENDPOINT}/{CleanTag(clanTag)}");
        public async Task<ResultSet<ClanMember>> GetClanMembersAsync(string clanTag, int? limit = null, string before = null, string after = null) => await GetPageAsync<ClanMember>($"{CLAN_ENDPOINT}/{CleanTag(clanTag)}/members", new QueryBase(limit, after, before));
        public async Task<ResultSet<War>> GetClanWarLogAsync(string clanTag, int? limit = null, string before = null, string after = null) => await GetPageAsync<War>($"{CLAN_ENDPOINT}/{CleanTag(clanTag)}/warlog", new QueryBase(limit, after, before));
        public async Task<CurrentWar> GetClanCurrentWarAsync(string clanTag) => await GetAsync<CurrentWar>($"{CLAN_ENDPOINT}/{CleanTag(clanTag)}/currentwar");
        #endregion Clans

        #region Players
        private const string PLAYER_ENDPOINT = "players";
        public async Task<Player> GetPlayerAsync(string playerTag) => await GetAsync<Player>($"{PLAYER_ENDPOINT}/{CleanTag(playerTag)}");
        public async Task<ResultSet<Chest>> GetUpcomingChestsAsync(string playerTag) => await GetPageAsync<Chest>($"{PLAYER_ENDPOINT}/{CleanTag(playerTag)}/upcomingchests", null);
        public async Task<List<Battle>> GetBattleLogAsync(string playerTag) => await GetAsync<List<Battle>>($"{PLAYER_ENDPOINT}/{CleanTag(playerTag)}/battlelog");
        #endregion Players

        #region Tournaments
        private const string TOURNAMENT_ENDPOINT = "tournaments";
        public async Task<ResultSet<Tournament>> GetTournamentsAsync(string name, int? limit = null, string before = null, string after = null) => await GetPageAsync<Tournament>($"{TOURNAMENT_ENDPOINT}?name={name}", new QueryBase(limit, after, before));
        public async Task<TournamentDetail> GetTournamentAsync(string tournamentTag) => await GetAsync<TournamentDetail>($"{TOURNAMENT_ENDPOINT}/{CleanTag(tournamentTag)}");
        #endregion Tournaments

        #region Locations
        private const string LOCATION_ENDPOINT = "locations";
        public async Task<ResultSet<Location>> GetLocationsAsync(int? limit = null, string before = null, string after = null) => await GetPageAsync<Location>($"{LOCATION_ENDPOINT}", new QueryBase(limit, after, before));
        public async Task<Location> GetLocationAsync(int locationId) => await GetAsync<Location>($"{LOCATION_ENDPOINT}/{locationId}");
        public async Task<ResultSet<PlayerLocationRank>> GetLocationRankingsPlayersAsync(int locationId, int? limit = null, string before = null, string after = null) => await GetPageAsync<PlayerLocationRank>($"{LOCATION_ENDPOINT}/{locationId}/rankings/players", new QueryBase(limit, after, before));
        public async Task<ResultSet<ClanLocationRank>> GetLocationRankingsClansAsync(int locationId, int? limit = null, string before = null, string after = null) => await GetPageAsync<ClanLocationRank>($"{LOCATION_ENDPOINT}/{locationId}/rankings/clans", new QueryBase(limit, after, before));
        public async Task<ResultSet<ClanLocationRank>> GetLocationRankingsClanWarsAsync(int locationId, int? limit = null, string before = null, string after = null) => await GetPageAsync<ClanLocationRank>($"{LOCATION_ENDPOINT}/{locationId}/rankings/clanwars", new QueryBase(limit, after, before));
        #endregion Locations

        #region Helpers
        private string CleanTag(string tag) => $"%23{tag.Replace("#", "").Replace("%23", "")}";
        private static JsonSerializerSettings clientSerializer = new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };
        private string AddQuery(string url, QueryBase query) {
            if (query == null) return url;

            var queryDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(JsonConvert.SerializeObject(query, clientSerializer));
            return url + (url.Contains("?") ? "&" : "?") + string.Join("&",queryDictionary.Select(x => $"{x.Key}={x.Value}"));
        }
        protected async Task<ResultSet<T>> GetPageAsync<T>(string url, QueryBase query) {
            var res = await client.GetStringAsync(AddQuery(url, query));
            var pagedResult = JsonConvert.DeserializeObject<PagedResult<T>>(res, clientSerializer);
            if (pagedResult.Paging?.Before != null)
                pagedResult.Items.PreviousAsync = async () => await GetPageAsync<T>(url, new QueryBase { Limit = query.Limit, Before = pagedResult.Paging.Before });
            if (pagedResult.Paging?.After != null)
                pagedResult.Items.NextAsync = async () => await GetPageAsync<T>(url, new QueryBase { Limit = query.Limit, After = pagedResult.Paging.After });

            return pagedResult.Items;
        }
        protected async Task<T> GetAsync<T>(string url) {
            var res = await client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<T>(res);
        }
        #endregion Helpers
    }
}
