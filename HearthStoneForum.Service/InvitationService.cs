using HearthStoneForum.IRepository;
using HearthStoneForum.IService;
using HearthStoneForum.Model;
using HearthStoneForum.Model.DTOView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneForum.Service
{
    public class InvitationService : BaseService<Invitation>, IInvitationService
    {
        private readonly IInvitationRepository _iInvitationRepository;
        public InvitationService(IInvitationRepository iInvitationRepository)
        {
            base._iBaseRepository = iInvitationRepository;
            _iInvitationRepository = iInvitationRepository;
        }

        public async Task<List<InvitationDTOViewRecommend>> GetNewInvitations()
        {
            return await _iInvitationRepository.GetNewInvitations();
        }

        public async Task<List<InvitationDTOViewRecommend>> GetRecommendInvitations()
        {
            return await _iInvitationRepository.GetRecommendInvitations();
        }
    }

}
