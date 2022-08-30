using HearthStoneForum.IService;
using HearthStoneForum.WebApi.Utility.ApiResult;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HearthStoneForum.WebApi.Controllers
{
    [Route("api/ranks")]
    [ApiController]
    public class RankController : ControllerBase
    {
        private readonly IRankService _rankService;
        public RankController(IRankService rankService)
        {
            _rankService = rankService;
        }
        [HttpGet]
        public async Task<ActionResult<ApiResult>> GetRanks()
        {
            var data = await _rankService.GetRanks();
            if (data == null) return ApiResultHelper.Error("没有更多的值");
            return ApiResultHelper.Success(data);
        }
        [HttpPost]
        public async Task<ActionResult<ApiResult>> GetRanks(string type, int seasonId)
        {
            var data = await _rankService.GetRanks(type, seasonId);
            if (data == null) return ApiResultHelper.Error("没有更多的值");
            return ApiResultHelper.Success(data);
        }
    }
}
