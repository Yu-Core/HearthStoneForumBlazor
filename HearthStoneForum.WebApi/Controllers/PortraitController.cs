using HearthStoneForum.IService;
using HearthStoneForum.Model;
using HearthStoneForum.WebApi.Utility.ApiResult;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HearthStoneForum.WebApi.Controllers
{
    [Route("api/portraits")]
    [ApiController]
    public class PortraitController : ControllerBase
    {
        private readonly IPortraitService _iPortraitService;
        public PortraitController(IPortraitService iPortraitService)
        {
            _iPortraitService = iPortraitService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResult>> GetPortrait()
        {
            var data = await _iPortraitService.QueryAsync();
            if (data.Count == 0) return ApiResultHelper.Error("没有更多的值");
            return ApiResultHelper.Success(data);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResult>> GetPortrait(int id)
        {
            var portrait = await _iPortraitService.FindAsync(id);
            if (portrait == null) return ApiResultHelper.Error("没有更多的值");

            return ApiResultHelper.Success(portrait);
        }
        
        [HttpPost]
        public async Task<ActionResult<ApiResult>> Create(Portrait portrait)
        {
            bool b = await _iPortraitService.CreateAsync(portrait);
            if (!b) return ApiResultHelper.Error("添加失败");

            return ApiResultHelper.Success(portrait);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResult>> Delete(int id)
        {
            bool b = await _iPortraitService.DeleteAsync(id);
            if (!b) return ApiResultHelper.Error("删除失败");
            return ApiResultHelper.Success(b);
        }
        
    }
}
