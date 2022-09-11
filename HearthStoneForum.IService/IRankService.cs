using HearthStoneForum.Model;
using HearthStoneForum.Model.DTOView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneForum.IService
{
    public interface IRankService
    {
        Task<RankData> GetRanks();
        Task<RankData> GetRanks(string type,int seasonId);
    }
}
