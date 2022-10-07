using HearthStoneForum.IRepository;
using HearthStoneForum.IService;
using HearthStoneForum.Model;
using HearthStoneForum.Model.DTOView;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task<List<Invitation>> GetCollectionInvitations(Expression<Func<Collection, bool>> func, int page, int size, RefAsync<int> total)
        {
            return await _iInvitationRepository.GetCollectionInvitations(func, page, size, total);
        }

        public async Task<List<Invitation>> GetLikeInvitations(Expression<Func<Likes, bool>> func, int page, int size, RefAsync<int> total)
        {
            return await _iInvitationRepository.GetLikeInvitations(func,page,size,total);
        }

        public async Task<List<InvitationDTOViewRecommend>> GetNewInvitations(int count)
        {
            return await _iInvitationRepository.GetNewInvitations(count);
        }

        public async Task<List<InvitationDTOViewRecommend>> GetRecommendInvitations(int count)
        {
            return await _iInvitationRepository.GetRecommendInvitations(count);
        }

        public async Task<List<Invitation>> GetViewRecordInvitations(Expression<Func<ViewRecord, bool>> func, int page, int size, RefAsync<int> total)
        {
            return await _iInvitationRepository.GetViewRecordInvitations(func,page,size,total);
        }
    }

}
