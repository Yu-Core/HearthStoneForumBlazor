using HearthStoneForum.Model;
using HearthStoneForum.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneForum.IService
{
    public interface IInvitationService : IBaseService<Invitation>
    {
        Task<List<InvitationDTORecommend>> GetRecommendInvitations();
        Task<List<InvitationDTORecommend>> GetNewInvitations();
    }
}
