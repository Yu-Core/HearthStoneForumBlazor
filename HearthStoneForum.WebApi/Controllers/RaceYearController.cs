using HearthStoneForum.IService;
using HearthStoneForum.Model;
using HearthStoneForum.WebApi.Utility.ApiResult;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HearthStoneForum.WebApi.Controllers
{
    [Route("api/raceYears")]
    [ApiController]
    public class RaceYearController : ControllerBase
    {
        private readonly IRaceYearService _iRaceYearService;
        public RaceYearController(IRaceYearService iRaceYearService)
        {
            _iRaceYearService = iRaceYearService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResult>> GetRaceYear()
        {
            var data = await _iRaceYearService.QueryAsync();
            data = data.OrderBy(data => data.Id).ToList();
            if (data.Count == 0) return ApiResultHelper.Error("没有更多的值");
            return ApiResultHelper.Success(data);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResult>> GetRaceYear(int id)
        {
            var raceYear = await _iRaceYearService.FindAsync(id);
            if (raceYear == null) return ApiResultHelper.Error("没有更多的值");

            return ApiResultHelper.Success(raceYear);
        }
        [HttpPost]
        public async Task<ActionResult<ApiResult>> Create(RaceYear raceYear)
        {
            bool b = await _iRaceYearService.CreateAsync(raceYear);
            if (!b) return ApiResultHelper.Error("添加失败");

            return ApiResultHelper.Success(raceYear);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResult>> Delete(int id)
        {
            bool b = await _iRaceYearService.DeleteAsync(id);
            if (!b) return ApiResultHelper.Error("删除失败");
            return ApiResultHelper.Success(b);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResult>> Edit(int id, RaceYear raceYear)
        {
            var oldRaceYear = await _iRaceYearService.FindAsync(id);
            if (oldRaceYear == null) return ApiResultHelper.Error("没有找到该记录");

            bool b = await _iRaceYearService.EditAsync(raceYear);
            if (!b) return ApiResultHelper.Error("修改失败");
            return ApiResultHelper.Success(raceYear);
        }
    }
}
