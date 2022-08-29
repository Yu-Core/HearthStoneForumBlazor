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
    public class LikesService : BaseService<Likes> , ILikesService
    {
        private readonly ILikesRepository _iLikesRepository;
        public LikesService(ILikesRepository iLikesRepository)
        {
            base._iBaseRepository = iLikesRepository;
            _iLikesRepository = iLikesRepository;
        }
    }
}
