using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HearthStoneForum.IService;
using HearthStoneForum.JWT;
using HearthStoneForum.JWT.Utility._MD5;
using HearthStoneForum.JWT.Utility.ApiResult;
using HearthStoneForum.Model.DTORest;
using HearthStoneForum.JWT.Utility;
using HearthStoneForum.Model.DTOView;

namespace HearthStoneForum.JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthoizeController : ControllerBase
    {
        private readonly IUserInfoService _UserInfoService;
        
        public AuthoizeController(IUserInfoService iUserInfoService)
        {
            _UserInfoService = iUserInfoService;
        }

        
        [HttpPost("login")]
        public async Task<ApiResult> Login(UserInfoDTOLogin dto)
        {
            //加密密码
            string pwd = MD5Helper.MD5Encrytp32(dto.Password);
            //数据校验
            var userInfo = await _UserInfoService.FindAsync(it=>it.UserName==dto.UserName&&it.Password == pwd);
            if (userInfo == null)
            {
                return ApiResultHelper.Error("账号或密码错误");
            }
            else
            {
                var jwtToken = JWTHelper.CreateToken(userInfo);
                return ApiResultHelper.Success(jwtToken);
            }
        }
    }
}
