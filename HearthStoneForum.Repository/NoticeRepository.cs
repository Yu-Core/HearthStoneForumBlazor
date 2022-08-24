using HearthStoneForum.IRepository;
using HearthStoneForum.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
