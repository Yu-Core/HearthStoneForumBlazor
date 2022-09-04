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
    public class DownloadService : BaseService<Download> , IDownloadService
    {
        private readonly IDownloadRepository _iDownloadRepository;
        public DownloadService(IDownloadRepository iDownloadRepository)
        {
            base._iBaseRepository = iDownloadRepository;
            _iDownloadRepository = iDownloadRepository;
        }
    }
}
