using HearthStoneForum.IService;
using HearthStoneForum.Model;
using HearthStoneForum.Model.DTOView;
using HearthStoneForum.WebApi.Utility.ApiResult;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
            //读取json文件，并反序列化
            string jsonString = System.IO.File.ReadAllText(json);
            DataObj? obj = JsonConvert.DeserializeObject<DataObj>(jsonString);

            //查询数据，如果数据为空，将json中的数据插入数据库
            var areas = await _iAreaService.QueryAsync();
            if(areas.Count == 0)
            {
                var row = _iAreaService.CreateAsync(obj.Areas);
                if (row == 0) return ApiResultHelper.Error("Areas插入失败");
            }
            var carousels = await _iCarouselService.QueryAsync();
            if(carousels.Count == 0)
            {
                var row = _iCarouselService.CreateAsync(obj.Carousels);
                if (row == 0) return ApiResultHelper.Error("Carousels插入失败");
            }
            var expansions = await _iExpansionService.QueryAsync();
            if(expansions.Count == 0)
            {
                var row = _iExpansionService.CreateAsync(obj.Expansions);
                if (row == 0) return ApiResultHelper.Error("Expansions插入失败");
            }
            var portaits = await _iPortraitService.QueryAsync();
            if(portaits.Count == 0)
            {
                var row = _iPortraitService.CreateAsync(obj.Portraits);
                if (row == 0) return ApiResultHelper.Error("Portraits插入失败");
            }
            var raceYears = await _iRaceYearService.QueryAsync();
            if(raceYears.Count == 0)
            {
                var row = _iRaceYearService.CreateAsync(obj.RaceYears);
                if (row == 0) return ApiResultHelper.Error("RaceYears插入失败");
            }
            

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
