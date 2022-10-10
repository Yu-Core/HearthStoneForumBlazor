using HearthStoneForum.IService;
using HearthStoneForum.Model;
using HearthStoneForum.Model.DTOView;
using HearthStoneForum.WebApi.Utility.ApiResult;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HearthStoneForum.Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IAreaService _iAreaService;
        private readonly ICarouselService _iCarouselService;
        private readonly IRaceYearService _iRaceYearService;
        private readonly IExpansionService _iExpansionService;
        private readonly IPortraitService _iPortraitService;

        private string json = "testdata.json";

        public TestController(
            IAreaService iAreaService,
            ICarouselService iCarouselService,
            IRaceYearService iRaceYearService,
            IExpansionService iExpansionService,
            IPortraitService iPortraitService)
        {
            _iAreaService = iAreaService;
            _iCarouselService = iCarouselService;
            _iRaceYearService = iRaceYearService;
            _iExpansionService = iExpansionService;
            _iPortraitService = iPortraitService;
        }



        [HttpPost]
        public async Task<ActionResult<ApiResult>> AddTestData()
        {
            using FileStream openStream = System.IO.File.OpenRead(json);
            DataObj? obj = await JsonSerializer.DeserializeAsync<DataObj>(openStream);

            var num = _iAreaService.CreateAsync(obj.Areas);
            if (num == 0) return ApiResultHelper.Error("Areas创建失败");
            var num2 = _iCarouselService.CreateAsync(obj.Carousels);
            if (num2 == 0) return ApiResultHelper.Error("Carousels创建失败");
            var num3 = _iExpansionService.CreateAsync(obj.Expansions);
            if (num3 == 0) return ApiResultHelper.Error("Expansions创建失败");
            var num4 = _iPortraitService.CreateAsync(obj.Portraits);
            if (num4 == 0) return ApiResultHelper.Error("Portraits创建失败");
            var num5 = _iRaceYearService.CreateAsync(obj.RaceYears);
            if (num5 == 0) return ApiResultHelper.Error("RaceYears创建失败");

            return ApiResultHelper.Success(null);
        }

        public class DataObj
        {
            public List<Area>? Areas;
            public List<Carousel>? Carousels;
            public List<RaceYear>? RaceYears;
            public List<Portrait>? Portraits;
            public List<Expansion>? Expansions;
        }
    }
}
