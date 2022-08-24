using HearthStoneForum.IRepository;
using HearthStoneForum.IService;
using HearthStoneForum.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneForum.Service
{
    public class NoticeService : BaseService<Notice> , INoticeService
    {
        private readonly INoticeRepository _iNoticeREpository;
        public NoticeService(INoticeRepository iNoticeREpository)
        {
            base._iBaseRepository = iNoticeREpository;
            this._iNoticeREpository = iNoticeREpository;
        }

        public async Task<List<Notice>> GetNewNotices()
        {
            return await _iNoticeREpository.GetNewNotices();
        }
    }
}
