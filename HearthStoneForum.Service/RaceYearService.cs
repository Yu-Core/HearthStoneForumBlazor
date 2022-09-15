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
    public class RaceYearService : BaseService<RaceYear>, IRaceYearService
    {
        private readonly IRaceYearRepository _iRaceYearRepository;
        public RaceYearService(IRaceYearRepository iRaceYearRepository)
        {
            _iBaseRepository = iRaceYearRepository;
            _iRaceYearRepository = iRaceYearRepository;
        }
    }
}
