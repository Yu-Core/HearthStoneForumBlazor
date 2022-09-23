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
    public class ViewRecordService : BaseService<ViewRecord> , IViewRecordService
    {
        private readonly IViewRecordRepository _iViewRecordRepository;
        public ViewRecordService(IViewRecordRepository iViewRecordRepository)
        {
            _iViewRecordRepository = iViewRecordRepository;
        }
    }
}
