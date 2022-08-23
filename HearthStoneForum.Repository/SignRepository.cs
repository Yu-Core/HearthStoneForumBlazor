using HearthStoneForum.IRepository;
using HearthStoneForum.Model;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneForum.Repository
{
    public class SignRepository : BaseRepository<Sign>, ISignRepository
    {
        public int GetTodaySignCount()
        {
            return Context.Queryable<Sign>()
                .Where(it => SqlFunc.DateIsSame(it.CreatedTime, DateTime.Now))
                .Count();
        }
    }
}
