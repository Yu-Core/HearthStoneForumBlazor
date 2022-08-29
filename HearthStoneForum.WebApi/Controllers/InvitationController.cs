using HearthStoneForum.IService;
using HearthStoneForum.Model;
using HearthStoneForum.Model.Dto;
using HearthStoneForum.WebApi.Utility.ApiResult;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HearthStoneForum.WebApi.Controllers
{
    [Route("api/invitations")]
    [ApiController]
    public class InvitationController : ControllerBase
    {
        private readonly IInvitationService _iInvitationService;
        public InvitationController(IInvitationService iInvitationService)
        {
            _iInvitationService = iInvitationService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResult>> GetInvitation()
        {
            var data = await _iInvitationService.QueryDTOAsync<InvitationDTO>();
            if (data.Count == 0) return ApiResultHelper.Error("没有更多的值");
            return ApiResultHelper.Success(data);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResult>> GetInvitation(int id)
        {
            var invitation = await _iInvitationService.QueryDTOAsync<InvitationDTO>(it => it.Id == id);
            if (invitation == null) return ApiResultHelper.Error("没有更多的值");

            return ApiResultHelper.Success(invitation);
        }
        [HttpGet("search")]
        public async Task<ActionResult<ApiResult>> GetInvitationByName(string name)
        {
            var data = await _iInvitationService.QueryDTOAsync<InvitationDTO>(it => it.Title.ToLower().Contains(name.ToLower()));
            if (data.Count == 0) return ApiResultHelper.Error("未找到想要搜索的数据");
            return ApiResultHelper.Success(data);
        }
        [HttpGet("new")]
        public async Task<ActionResult<ApiResult>> GetNewInvitation()
        {
            var data = await _iInvitationService.GetNewInvitations();
            if (data.Count == 0) return ApiResultHelper.Error("没有更多的值");
            return ApiResultHelper.Success(data);
        }
        [HttpGet("recommend")]
        public async Task<ActionResult<ApiResult>> GetRecommendInvitation()
        {
            var data = await _iInvitationService.GetRecommendInvitations();
            if (data.Count == 0) return ApiResultHelper.Error("没有更多的值");
            return ApiResultHelper.Success(data);
        }
        [HttpPost]
        public async Task<ActionResult<ApiResult>> Create(Invitation invitation)
        {
            bool b = await _iInvitationService.CreateAsync(invitation);
            if (!b) return ApiResultHelper.Error("添加失败");

            return ApiResultHelper.Success(invitation);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResult>> Delete(int id)
        {
            bool b = await _iInvitationService.DeleteAsync(id);
            if (!b) return ApiResultHelper.Error("删除失败");
            return ApiResultHelper.Success(b);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResult>> Edit(int id, Invitation invitation)
        {
            var oldInvitation = await _iInvitationService.FindAsync(id);
            if (oldInvitation == null) return ApiResultHelper.Error("没有找到该记录");

            bool b = await _iInvitationService.EditAsync(invitation);
            if (!b) return ApiResultHelper.Error("修改失败");
            return ApiResultHelper.Success(invitation);
        }
    }
}
