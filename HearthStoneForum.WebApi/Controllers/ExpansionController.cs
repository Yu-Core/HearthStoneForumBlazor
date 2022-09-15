using HearthStoneForum.IService;
using HearthStoneForum.Model;
using HearthStoneForum.WebApi.Utility.ApiResult;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HearthStoneForum.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpansionController : ControllerBase
    {
        private readonly IExpansionService _iExpansionService;
        public ExpansionController(IExpansionService iExpansionService)
        {
            _iExpansionService = iExpansionService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResult>> GetExpansion()
        {
            var data = await _iExpansionService.QueryAsync();
            if (data.Count == 0) return ApiResultHelper.Error("没有更多的值");
            return ApiResultHelper.Success(data);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResult>> GetExpansion(int id)
        {
            var expansion = await _iExpansionService.FindAsync(id);
            if (expansion == null) return ApiResultHelper.Error("没有更多的值");

            return ApiResultHelper.Success(expansion);
        }
        
        [HttpPost]
        public async Task<ActionResult<ApiResult>> Create(Expansion expansion)
        {
            bool b = await _iExpansionService.CreateAsync(expansion);
            if (!b) return ApiResultHelper.Error("添加失败");

            return ApiResultHelper.Success(expansion);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResult>> Delete(int id)
        {
            bool b = await _iExpansionService.DeleteAsync(id);
            if (!b) return ApiResultHelper.Error("删除失败");
            return ApiResultHelper.Success(b);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResult>> Edit(int id, Expansion expansion)
        {
            var oldExpansion = await _iExpansionService.FindAsync(id);
            if (oldExpansion == null) return ApiResultHelper.Error("没有找到该记录");

            bool b = await _iExpansionService.EditAsync(expansion);
            if (!b) return ApiResultHelper.Error("修改失败");
            return ApiResultHelper.Success(expansion);
        }
    }
}
