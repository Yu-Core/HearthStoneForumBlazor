using HearthStoneForum.IService;
using HearthStoneForum.Model;
using HearthStoneForum.WebApi.Utility.ApiResult;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HearthStoneForum.WebApi.Controllers
{
    [Route("api/likes")]
    [ApiController]
    public class LikesController : ControllerBase
    {
        private readonly ILikesService _iLikesService;
        public LikesController(ILikesService iLikesService)
        {
            _iLikesService = iLikesService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResult>> GetLikes()
        {
            var data = await _iLikesService.QueryAsync();
            if (data.Count == 0) return ApiResultHelper.Error("没有更多的值");
            return ApiResultHelper.Success(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResult>> GetLikes(int id)
        {
            var like = await _iLikesService.FindAsync(id);
            if (like == null) return ApiResultHelper.Error("没有更多的值");

            return ApiResultHelper.Success(like);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ApiResult>> Create(int invitationId)
        {
            int userId = Convert.ToInt32(this.User.FindFirst("UserId").Value);
            //此处为何用FindAsync而不用QueryAsync，因为FindAsync只会返回第一个，QueryAsync会查询所有，浪费时间和性能
            var data = await _iLikesService.FindAsync(it=>it.UserId == userId && it.InvitationId == invitationId);
            if(data != null) return ApiResultHelper.Error("添加失败");

            bool b = await _iLikesService.CreateAsync(invitationId, userId);
            if (!b) return ApiResultHelper.Error("添加失败");

            var like = await _iLikesService.FindAsync(it => it.UserId == userId && it.InvitationId == invitationId);

            return ApiResultHelper.Success(like);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResult>> Delete(int id)
        {
            int userId = Convert.ToInt32(this.User.FindFirst("UserId").Value);
            var data = await _iLikesService.FindAsync(it=>it.Id == id && it.UserId == userId);
            if (data == null) return ApiResultHelper.Error("没有找到该记录");

            bool b = await _iLikesService.DeleteAsync(id);
            if (!b) return ApiResultHelper.Error("删除失败");
            return ApiResultHelper.Success(null);
        }

        [Authorize]
        [HttpGet("search")]
        public async Task<ActionResult<ApiResult>> GetLikesByInvitationId(int invitationId)
        {
            int userId = Convert.ToInt32(this.User.FindFirst("UserId").Value);
            var data = await _iLikesService.FindAsync(it => it.UserId == userId && it.InvitationId == invitationId);
            if (data == null) return ApiResultHelper.Error("没有找到该记录");

            return ApiResultHelper.Success(data);
        }
    }
}
