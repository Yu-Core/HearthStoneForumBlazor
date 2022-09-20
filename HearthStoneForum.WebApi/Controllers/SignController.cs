using HearthStoneForum.IService;
using HearthStoneForum.Model;
using HearthStoneForum.WebApi.Utility.ApiResult;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;

namespace HearthStoneForum.WebApi.Controllers
{
    [Route("api/signs")]
    [ApiController]
    public class SignController : ControllerBase
    {
        private readonly ISignService _iSignService;
        public SignController(ISignService iSignService)
        {
            _iSignService = iSignService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResult>> GetSign()
        {
            var data = await _iSignService.QueryAsync();
            if (data.Count == 0) return ApiResultHelper.Error("没有更多的值");
            return ApiResultHelper.Success(data);
        }
        [HttpGet("todayCount")]
        public ActionResult<ApiResult> GetTodaySignCount()
        {
            var count = _iSignService.GetTodaySignCount();
            return ApiResultHelper.Success(count);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResult>> GetSign(int id)
        {
            var sign = await _iSignService.FindAsync(id);
            if (sign == null) return ApiResultHelper.Error("没有更多的值");

            return ApiResultHelper.Success(sign);
        }
        [Authorize]
        [HttpGet("today")]
        public async Task<ActionResult<ApiResult>> GetTodaySign()
        {
            int id = Convert.ToInt32(this.User.FindFirst("UserId").Value);

            var data = await _iSignService.FindAsync(it=>it.UserId == id && it.CreatedTime.ToString("d") == DateTime.Now.ToString("d"));
            if(data != null) return ApiResultHelper.Success(data);
            return ApiResultHelper.Error("今日尚未签到");
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ApiResult>> Create()
        {
            int id = Convert.ToInt32(this.User.FindFirst("UserId").Value);

            bool b = await _iSignService.SignAsync(id);
            if (!b) return ApiResultHelper.Error("签到失败");

            return ApiResultHelper.Success(null);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResult>> Delete(int id)
        {
            bool b = await _iSignService.DeleteAsync(id);
            if (!b) return ApiResultHelper.Error("删除失败");
            return ApiResultHelper.Success(b);
        }
        
    }
}
