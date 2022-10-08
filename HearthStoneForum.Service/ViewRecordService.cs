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
            base._iBaseRepository = iViewRecordRepository;
            _iViewRecordRepository = iViewRecordRepository;
        }
        public async Task<bool> CreateAsync(int invitationId, int userId)
        {
            var viewRecord = new ViewRecord()
            {
                InvitationId = invitationId,
                UserId = userId,
                CreatedTime = DateTime.Now
            };
            return await base.CreateAsync(viewRecord);
        }
    }

}
