using HearthStoneForum.IService;
using HearthStoneForum.WebApi.Utility.ApiResult;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HearthStoneForum.WebApi.Controllers
{
    [Route("api/viewRecords")]
    [ApiController]
    public class ViewRecordController : ControllerBase
    {
        private readonly IViewRecordService _iViewRecordService;
        private readonly IInvitationService _iInvitationService;
        public ViewRecordController(IViewRecordService iViewRecordService,IInvitationService iInvitationService)
        {
            _iViewRecordService = iViewRecordService;
            _iInvitationService = iInvitationService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResult>> GetViewRecord()
        {
            var data = await _iViewRecordService.QueryAsync();
            if (data.Count == 0) return ApiResultHelper.Error("没有更多的值");
            return ApiResultHelper.Success(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResult>> GetViewRecord(int id)
        {
            var like = await _iViewRecordService.FindAsync(id);
            if (like == null) return ApiResultHelper.Error("没有更多的值");

            return ApiResultHelper.Success(like);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ApiResult>> Create(int invitationId)
        {
            int userId = Convert.ToInt32(this.User.FindFirst("UserId").Value);
            var data = await _iViewRecordService.FindAsync(it => it.UserId == userId && it.InvitationId == invitationId);
            if (data != null) return ApiResultHelper.Error("添加失败，重复添加");

            bool b = await _iViewRecordService.CreateAsync(invitationId, userId);
            if (!b) return ApiResultHelper.Error("添加失败");

            var like = await _iViewRecordService.FindAsync(it => it.UserId == userId && it.InvitationId == invitationId);

            var invitation = await _iInvitationService.FindAsync(invitationId);
            invitation.Views++;
            bool b2 = await _iInvitationService.EditAsync(invitation);
            if (!b2) return ApiResultHelper.Error("修改失败");

            return ApiResultHelper.Success(like);
        }

        [Authorize]
        [HttpDelete("{invitationId}")]
        public async Task<ActionResult<ApiResult>> Delete(int invitationId)
        {
            int userId = Convert.ToInt32(this.User.FindFirst("UserId").Value);
            var data = await _iViewRecordService.FindAsync(it => it.InvitationId == invitationId && it.UserId == userId);
            if (data == null) return ApiResultHelper.Error("没有找到该记录");

            bool b = await _iViewRecordService.DeleteAsync(data.Id);
            if (!b) return ApiResultHelper.Error("删除失败");
            return ApiResultHelper.Success(null);
        }

        [Authorize]
        [HttpGet("search")]
        public async Task<ActionResult<ApiResult>> GetViewRecordByInvitationId(int invitationId)
        {
            int userId = Convert.ToInt32(this.User.FindFirst("UserId").Value);
            var data = await _iViewRecordService.FindAsync(it => it.UserId == userId && it.InvitationId == invitationId);
            if (data == null) return ApiResultHelper.Error("没有找到该记录");

            return ApiResultHelper.Success(data);
        }
    }
}
