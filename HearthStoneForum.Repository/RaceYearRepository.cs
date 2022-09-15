using HearthStoneForum.IRepository;
using HearthStoneForum.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneForum.Repository
{
    public class RaceYearRepository : BaseRepository<RaceYear>, IRaceYearRepository
    {
        public override Task<List<RaceYear>> QueryAsync()
        {
            return base.Context.Queryable<RaceYear>()
                .OrderByDescending(it=>it.Id)
                .Includes(it => it.Expansions.OrderBy(x=>x.DateTime).ToList())
                .ToListAsync();
        }
    }
}
