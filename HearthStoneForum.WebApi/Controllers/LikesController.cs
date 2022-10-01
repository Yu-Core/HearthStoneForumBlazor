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
        public async Task<ActionResult<ApiResult>> Create(Likes like)
        {
            bool b = await _iLikesService.CreateAsync(like);
            if (!b) return ApiResultHelper.Error("添加失败");

            return ApiResultHelper.Success(like);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResult>> Delete(int id)
        {
            bool b = await _iLikesService.DeleteAsync(id);
            if (!b) return ApiResultHelper.Error("删除失败");
            return ApiResultHelper.Success(b);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResult>> Edit(int id, Likes like)
        {
            var oldLikes = await _iLikesService.FindAsync(id);
            if (oldLikes == null) return ApiResultHelper.Error("没有找到该记录");

            bool b = await _iLikesService.EditAsync(like);
            if (!b) return ApiResultHelper.Error("修改失败");
            return ApiResultHelper.Success(like);
        }
    }
}
