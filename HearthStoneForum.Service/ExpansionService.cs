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
    public class ExpansionService : BaseService<Expansion>, IExpansionService
    {
        private readonly IExpansionRepository _iExpansionRepository;
        public ExpansionService(IExpansionRepository iExpansionRepository)
        {
            base._iBaseRepository = iExpansionRepository;
            _iExpansionRepository = iExpansionRepository;
        }
    }
}
