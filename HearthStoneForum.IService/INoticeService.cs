using HearthStoneForum.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneForum.IService
{
    public interface INoticeService : IBaseService<Notice>
    {
        Task<List<Notice>> GetNewNotices();
    }
}
