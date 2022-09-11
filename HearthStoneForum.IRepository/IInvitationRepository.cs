using HearthStoneForum.Model;
using HearthStoneForum.Model.DTOView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneForum.IRepository
{
    public interface IInvitationRepository : IBaseRepository<Invitation>
    {
        Task<List<InvitationDTOViewRecommend>> GetRecommendInvitations();
        Task<List<InvitationDTOViewRecommend>> GetNewInvitations();
    }
}
