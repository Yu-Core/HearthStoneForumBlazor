using HearthStoneForum.IService;
using HearthStoneForum.Model;
using HearthStoneForum.WebApi.Utility.ApiResult;
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
        [HttpGet("today_count")]
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
        [HttpPost]
        public async Task<ActionResult<ApiResult>> Create(Sign sign)
        {
            bool b = await _iSignService.CreateAsync(sign);
            if (!b) return ApiResultHelper.Error("添加失败");

            return ApiResultHelper.Success(sign);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResult>> Delete(int id)
        {
            bool b = await _iSignService.DeleteAsync(id);
            if (!b) return ApiResultHelper.Error("删除失败");
            return ApiResultHelper.Success(b);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResult>> Edit(int id, Sign sign)
        {
            var oldSign = await _iSignService.FindAsync(id);
            if (oldSign == null) return ApiResultHelper.Error("没有找到该记录");

            bool b = await _iSignService.EditAsync(sign);
            if (!b) return ApiResultHelper.Error("修改失败");
            return ApiResultHelper.Success(sign);
        }
    }
}
