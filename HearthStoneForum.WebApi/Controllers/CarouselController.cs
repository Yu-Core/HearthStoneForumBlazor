using HearthStoneForum.IService;
using HearthStoneForum.Model;
using HearthStoneForum.WebApi.Utility.ApiResult;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HearthStoneForum.WebApi.Controllers
{
    [Route("api/carousels")]
    [ApiController]
    public class CarouselController : ControllerBase
    {
        private readonly ICarouselService _iCarouselService;
        public CarouselController(ICarouselService iCarouselService)
        {
            _iCarouselService = iCarouselService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResult>> GetCarousel()
        {
            var data = await _iCarouselService.QueryAsync();
            if (data.Count == 0) return ApiResultHelper.Error("没有更多的值");
            return ApiResultHelper.Success(data);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResult>> GetCarousel(int id)
        {
            var carousel = await _iCarouselService.FindAsync(id);
            if (carousel == null) return ApiResultHelper.Error("没有更多的值");

            return ApiResultHelper.Success(carousel);
        }
        [HttpGet("search")]
        public async Task<ActionResult<ApiResult>> GetCarouselByName(string name)
        {
            var data = await _iCarouselService.QueryAsync(it => it.Title.ToLower().Contains(name.ToLower()));
            if (data.Count == 0) return ApiResultHelper.Error("未找到想要搜索的用户");
            return ApiResultHelper.Success(data);
        }
        [HttpPost]
        public async Task<ActionResult<ApiResult>> Create(Carousel carousel)
        {
            bool b = await _iCarouselService.CreateAsync(carousel);
            if (!b) return ApiResultHelper.Error("添加失败");

            return ApiResultHelper.Success(carousel);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResult>> Delete(int id)
        {
            bool b = await _iCarouselService.DeleteAsync(id);
            if (!b) return ApiResultHelper.Error("删除失败");
            return ApiResultHelper.Success(b);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResult>> Edit(int id,Carousel carousel)
        {
            var oldCarousel = await _iCarouselService.FindAsync(id);
            if (oldCarousel == null) return ApiResultHelper.Error("没有找到该记录");

            bool b = await _iCarouselService.EditAsync(carousel);
            if (!b) return ApiResultHelper.Error("修改失败");
            return ApiResultHelper.Success(carousel);
        }
    }
}
