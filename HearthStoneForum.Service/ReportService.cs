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
    public class ReportService : BaseService<Report>, IReportService
    {
        private readonly IReportRepository _iReportRepository;
        public ReportService(IReportRepository iReportRepository)
        {
            _iBaseRepository = iReportRepository;
            _iReportRepository = iReportRepository;
        }
    }
}
