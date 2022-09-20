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
    public class PortraitService : BaseService<Portrait>, IPortraitService
    {
        private readonly IPortraitRepository _iPortraitRepository;
        public PortraitService(IPortraitRepository iPortraitRepository)
        {
            _iBaseRepository = iPortraitRepository;
            _iPortraitRepository = iPortraitRepository;
        }
    }
}
