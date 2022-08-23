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
        public override async Task<List<Notice>> QueryAsync()
        {
            return (await base.QueryAsync())
                .OrderBy(it => it.CreatedTime)
                .Take(4)
                .ToList();
        }
    }
}
