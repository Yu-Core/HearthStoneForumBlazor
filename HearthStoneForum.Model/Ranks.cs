using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneForum.Model
{
    public class Ranks
    {
        public int Rating { get; set; }
        public string? BattleTag { get; set; }
        public int Rank { get; set; }
    }

    public class RankData
    {
        public string? Type { get; set; }
        public int SeasonId { get; set; }
        public int DateKey { get; set; }
        public int Status { get; set; }
        public long UpdateTime { get; set; }
        public List<Ranks>? Ranks { get; set; }
    }

    public class RankResult
    {
        public RankData? Data { get; set; }
        public string? Msg { get; set; }
        public string? Status { get; set; }
    }

    public class RankRequest
    {
        public int seasonId { get; set; }
        public string type { get; set; }
        public string t { get; set; }
        public RankRequest(int _seasonId, string _type, string _t)
        {
            seasonId = _seasonId;
            type = _type;
            t = _t;
        }
    }
    public enum RankType
    {
        STD,WLD,BG,CLS,MRC
    }
}
