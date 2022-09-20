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
    public class SignService : BaseService<Sign>, ISignService
    {
        private readonly ISignRepository _iSignRepository;
        public SignService(ISignRepository iSignRepository)
        {
            base._iBaseRepository = iSignRepository;
            _iSignRepository = iSignRepository;
        }
        public int GetTodaySignCount()
        {
            return _iSignRepository.GetTodaySignCount();
        }

        public async Task<bool> SignAsync(int id)
        {
            
            var data = await _iSignRepository.FindAsync(it => it.UserId == id && it.CreatedTime.ToString("d") == DateTime.Now.ToString("d"));
            if (data != null) return false;
            
            Sign sign = new()
            {
                UserId = id,
                CreatedTime = DateTime.Now
            };
            return await base.CreateAsync(sign);
           
        }
    }
}
