using AutoMapper;
using HearthStoneForum.IService;
using HearthStoneForum.Model;
using HearthStoneForum.Model.DTOAdd;
using HearthStoneForum.Model.DTOView;
using HearthStoneForum.WebApi.Utility.ApiResult;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SqlSugar;
using System.Drawing;
using System.Security.Policy;
using System.Xml.Linq;

namespace HearthStoneForum.WebApi.Controllers
{
    [Route("api/invitations")]
    [ApiController]
    public class InvitationController : ControllerBase
    {
        private readonly IInvitationService _iInvitationService;
        private readonly IMapper _iMapper;
        public InvitationController(IInvitationService iInvitationService,IMapper iMapper)
        {
            _iInvitationService = iInvitationService;
            _iMapper = iMapper;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResult>> GetInvitation()
        {
            var data = await _iInvitationService.QueryDTOAsync<InvitationDTOView>();
            if (data.Count == 0) return ApiResultHelper.Error("没有更多的值");
            return ApiResultHelper.Success(data);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResult>> GetInvitation(int id)
        {
            var invitation = (await _iInvitationService.QueryDTOAsync<InvitationDTOView>(it => it.Id == id)).FirstOrDefault();
            if (invitation == null) return ApiResultHelper.Error("没有更多的值");

            return ApiResultHelper.Success(invitation);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ApiResult>> Create(InvitationDTOAdd dto)
        {
            if(string.IsNullOrWhiteSpace(dto.Title)||string.IsNullOrWhiteSpace(dto.Content))
                return ApiResultHelper.Error("添加失败");

            int userId = Convert.ToInt32(this.User.FindFirst("UserId").Value);

            dto.UserId = userId;

            var invitation =  _iMapper.Map<InvitationDTOAdd,Invitation>(dto);

            bool b = await _iInvitationService.CreateAsync(invitation);
            if (!b) return ApiResultHelper.Error("添加失败");

            return ApiResultHelper.Success(invitation);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResult>> Delete(int id)
        {
            int userId = Convert.ToInt32(this.User.FindFirst("UserId").Value);
            var data = await _iInvitationService.FindAsync(it => it.Id == id && it.UserId == userId);
            if (data == null) return ApiResultHelper.Error("没有找到该记录");

            bool b = await _iInvitationService.DeleteAsync(id);
            if (!b) return ApiResultHelper.Error("删除失败");
            return ApiResultHelper.Success(null);
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

        [HttpGet("search")]
        public async Task<ActionResult<ApiResult>> GetInvitationByName(string name)
        {
            var data = await _iInvitationService.QueryDTOAsync<InvitationDTOView>(it => it.Title.ToLower().Contains(name.ToLower()));
            if (data.Count == 0) return ApiResultHelper.Error("未找到想要搜索的数据");
            return ApiResultHelper.Success(data);
        }

        [HttpGet("new")]
        public async Task<ActionResult<ApiResult>> GetNewInvitation(int count)
        {
            var data = await _iInvitationService.GetNewInvitations(count);
            if (data.Count == 0) return ApiResultHelper.Error("没有更多的值");
            return ApiResultHelper.Success(data);
        }

        [HttpGet("recommend")]
        public async Task<ActionResult<ApiResult>> GetRecommendInvitation(int count)
        {
            var data = await _iInvitationService.GetRecommendInvitations(count);
            if (data.Count == 0) return ApiResultHelper.Error("没有更多的值");
            return ApiResultHelper.Success(data);
        }

        [Authorize]
        [HttpGet("like")]
        public async Task<ActionResult<ApiResult>> GetLikeInvitation(int userId, int page, int size)
        {
            RefAsync<int> total = 0;
            var data = await _iInvitationService.GetLikeInvitations(it => it.UserId == userId, page, size, total);
            if (data.Count == 0) return ApiResultHelper.Error("没有更多的值");
            return ApiResultHelper.Success(data, total);
        }

        [Authorize]
        [HttpGet("collection")]
        public async Task<ActionResult<ApiResult>> GetCollectionInvitation(int userId, int page, int size)
        {
            RefAsync<int> total = 0;
            var data = await _iInvitationService.GetCollectionInvitations(it => it.UserId == userId, page, size, total);
            if (data.Count == 0) return ApiResultHelper.Error("没有更多的值");
            return ApiResultHelper.Success(data, total);
        }

        [HttpGet("viewRecord")]
        public async Task<ActionResult<ApiResult>> GetViewRecordInvitation(int userId, int page, int size)
        {
            RefAsync<int> total = 0;
            var data = await _iInvitationService.GetViewRecordInvitations(it => it.UserId == userId, page, size, total);
            if (data.Count == 0) return ApiResultHelper.Error("没有更多的值");
            return ApiResultHelper.Success(data, total);
        }

        [HttpGet("area")]
        public async Task<ActionResult<ApiResult>> GetInvitationByAreaId(int id, int page, int size)
        {
            RefAsync<int> total = 0;
            var data = await _iInvitationService.QueryDTOAsync<InvitationDTOView>(it => it.AreaId == id, page, size, total);
            if (data.Count == 0) return ApiResultHelper.Error("没有更多的值");
            return ApiResultHelper.Success(data, total);
        }

        [HttpGet("user")]
        public async Task<ActionResult<ApiResult>> GetInvitationByUserId(int userId, int page, int size)
        {
            RefAsync<int> total = 0;
            var data = await _iInvitationService.QueryAsync(it => it.UserId == userId, page, size, total);
            if (data.Count == 0) return ApiResultHelper.Error("没有更多的值");
            return ApiResultHelper.Success(data, total);
        }

        [Authorize]
        [HttpPut("view")]
        public async Task<ActionResult<ApiResult>> AddView(int id)
        {
            var invitation = await _iInvitationService.FindAsync(id);
            if (invitation == null) return ApiResultHelper.Error("没有找到该记录");

            
            invitation.Views += 1;

            bool b = await _iInvitationService.EditAsync(invitation);
            if (!b) return ApiResultHelper.Error("修改失败");
            return ApiResultHelper.Success(null);
        }
    }
}
