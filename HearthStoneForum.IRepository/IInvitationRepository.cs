using HearthStoneForum.Model;
using HearthStoneForum.Model.DTOView;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneForum.IRepository
{
    public interface IInvitationRepository : IBaseRepository<Invitation>
    {
        Task<List<InvitationDTOViewRecommend>> GetRecommendInvitations(int count);
        Task<List<InvitationDTOViewRecommend>> GetNewInvitations(int count);
        Task<List<Invitation>> GetLikeInvitations(Expression<Func<Likes, bool>> func, int page, int size, RefAsync<int> total);
        Task<List<Invitation>> GetCollectionInvitations(Expression<Func<Collection, bool>> func, int page, int size, RefAsync<int> total);
        Task<List<Invitation>> GetViewRecordInvitations(Expression<Func<ViewRecord, bool>> func, int page, int size, RefAsync<int> total);
    }
}
