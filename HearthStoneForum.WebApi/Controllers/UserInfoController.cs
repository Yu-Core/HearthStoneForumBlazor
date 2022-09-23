using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HearthStoneForum.IService;
using HearthStoneForum.WebApi.Utility.ApiResult;
using HearthStoneForum.Model;
using AutoMapper;
using HearthStoneForum.Model.DTOView;
using HearthStoneForum.Model.DTOAdd;
using Microsoft.AspNetCore.Authorization;
using HearthStoneForum.Model.DTOEdit;

namespace HearthStoneForum.WebApi.Controllers
{
    [Route("api/userInfos")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly IUserInfoService _iUserInfoService;
        private IMapper _iMapper;
        public UserInfoController(IUserInfoService iUserInfoService,IMapper iMapper)
        {
            _iUserInfoService = iUserInfoService;
            _iMapper = iMapper;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResult>> GetUserInfo()
        {
            var data = await _iUserInfoService.QueryDTOAsync<UserInfoDTOView>();
            if (data.Count == 0) return ApiResultHelper.Error("没有更多的值");
            return ApiResultHelper.Success(data);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResult>> GetUserInfo(int id)
        {
            var userInfo = await _iUserInfoService.FindAsync(id);
            if (userInfo == null) return ApiResultHelper.Error("没有更多的值");
            
            var userInfoDTOView = _iMapper.Map<UserInfo,UserInfoDTOView>(userInfo);
            return ApiResultHelper.Success(userInfoDTOView);
        }
        [HttpGet("search")]
        public async Task<ActionResult<ApiResult>> GetUserInfoByName(string name)
        {
            var data = await _iUserInfoService.QueryDTOAsync<UserInfoDTOView>(it => it.Name.ToLower().Contains(name.ToLower()));
            if (data.Count == 0) return ApiResultHelper.Error("未找到想要搜索的用户");
            return ApiResultHelper.Success(data);
        }
        [HttpPost]
        public async Task<ActionResult<ApiResult>> Create(UserInfoDTOAdd dto)
        {
            #region 数据验证
            if (String.IsNullOrWhiteSpace(dto.UserName) || String.IsNullOrWhiteSpace(dto.Password)) return ApiResultHelper.Error("用户名和密码不能为空");
            #endregion
            #region 检测用户名是否存在
            var data = await _iUserInfoService.QueryAsync(it => it.UserName == dto.UserName);
            if (data.Count > 0) return ApiResultHelper.Error("该用户名已存在");
            #endregion

            UserInfo userInfo = _iMapper.Map<UserInfoDTOAdd,UserInfo>(dto);
            bool b = await _iUserInfoService.CreateAsync(userInfo);
            if (!b) return ApiResultHelper.Error("用户添加失败");

            var UserInfoDTOView = _iMapper.Map<UserInfoDTOView>(userInfo);
            return ApiResultHelper.Success(UserInfoDTOView);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResult>> Delete(int id)
        {
            bool b = await _iUserInfoService.DeleteAsync(id);
            if (!b) return ApiResultHelper.Error("删除失败");
            return ApiResultHelper.Success(b);
        }
        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResult>> Edit(UserInfoDTOEdit dto)
        {
            int id = Convert.ToInt32(User.FindFirst("UserId").Value);

            if(id != dto.Id) return ApiResultHelper.Error("修改失败，身份认证失败");

            var userInfo = await _iUserInfoService.FindAsync(id);
            if (userInfo == null) return ApiResultHelper.Error("没有找到该用户");

            userInfo = _iMapper.Map<UserInfoDTOEdit,UserInfo>(dto, userInfo);

            bool b = await _iUserInfoService.EditAsync(userInfo);
            if (!b) return ApiResultHelper.Error("修改失败");
            return ApiResultHelper.Success(dto);
        }
        [HttpGet("portrait")]
        public async Task<ActionResult<ApiResult>> GetUserPortrait(int userId)
        {
            var data = await _iUserInfoService.FindAsync(it=>it.Id == userId);
            if (data == null) return ApiResultHelper.Error("没有找到该用户");
            return ApiResultHelper.Success(data.Portrait);
        }
    }
}
