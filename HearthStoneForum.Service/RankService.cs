using HearthStoneForum.IService;
using HearthStoneForum.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneForum.Service
{
    public class RankService : IRankService
    {
        private HttpClient Http = new HttpClient();
        private readonly DateTime InitialTime = Convert.ToDateTime("2013-10-1");
        private static readonly long ticks = new DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc).Ticks;
        public async Task<RankData> GetRanks()
        {
            int seasonId = GetSeasonId(DateTime.Now);
            var response = await Http.PostAsJsonAsync("https://hs.blizzard.cn/action/hs/leaderboards/season/rank", new RankRequest(seasonId, "STD",ticks.ToString()));
            return response.Content.ReadFromJsonAsync<RankResult>().Result.Data;
        }

        public async Task<RankData> GetRanks(string type, int seasonId)
        {
            var response = await Http.PostAsJsonAsync("https://hs.blizzard.cn/action/hs/leaderboards/season/rank", new RankRequest(seasonId, type, ticks.ToString()));
            return response.Content.ReadFromJsonAsync<RankResult>().Result.Data;
        }
        private int GetSeasonId(DateTime dateTime)
        {
            return (dateTime.Year - InitialTime.Year) * 12 + (dateTime.Month - InitialTime.Month);
        }
    }
}
