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
    public class AreaService : BaseService<Area>, IAreaService
    {
        private readonly IAreaRepository _iAreaRepository;
        public AreaService(IAreaRepository iAreaRepository)
        {
            base._iBaseRepository = iAreaRepository;
            _iAreaRepository = iAreaRepository;
        }
    }
}
