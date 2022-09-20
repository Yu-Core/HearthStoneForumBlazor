using HearthStoneForum.Client.Utility;
using HearthStoneForum.Model.DTOAdd;
using HearthStoneForum.Model.DTORest;
using SqlSugar;
using System.Security.Claims;

namespace HearthStoneForum.Client.Service
{
    public interface IAuthService
    {
        Task<ApiResult<string>> Login(UserInfoDTOLogin loginModel);
        Task Logout();
        Task<ApiResult<string>> Register(UserInfoDTOAdd registerModel);
        Task<bool> IsAuthenticated();
        Task<ClaimsPrincipal> GetUser();
    }
}
