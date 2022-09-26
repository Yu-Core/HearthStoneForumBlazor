using HearthStoneForum.IRepository;
using HearthStoneForum.Model;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneForum.Repository
{
    public class NoticeRepository : BaseRepository<Notice>, INoticeRepository
    {
        public async Task<List<Notice>> GetNewNotices()
        {
            return (await base.QueryAsync())
                .OrderByDescending(it => it.CreatedTime)
                .Take(4)
                .ToList();
        }
        public override Task<List<Notice>> QueryAsync(int page, int size, RefAsync<int> total)
        {
            return base.Context.Queryable<Notice>()
                .OrderByDescending(it=>it.CreatedTime)
                .ToPageListAsync(page,size,total);
        }
        public override Task<List<Notice>> QueryAsync(Expression<Func<Notice, bool>> func, int page, int size, RefAsync<int> total)
        {
            return base.Context.Queryable<Notice>()
                .Where(func)
                .OrderByDescending(it => it.CreatedTime)
                .ToPageListAsync(page, size, total);
        }
    }
}
