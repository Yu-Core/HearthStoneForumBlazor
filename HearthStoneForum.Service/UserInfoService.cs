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
    public class UserInfoService : BaseService<UserInfo>,IUserInfoService
    {
        private readonly IUserInfoRepository _iUserInfoRepository;
        public UserInfoService(IUserInfoRepository iUserInfoRepository)
        {
            base._iBaseRepository = iUserInfoRepository;
            _iUserInfoRepository = iUserInfoRepository;
        }
    }
}
