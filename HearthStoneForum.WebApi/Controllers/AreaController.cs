using AutoMapper;
using HearthStoneForum.IService;
using HearthStoneForum.Model;
using HearthStoneForum.Model.DTOAdd;
using HearthStoneForum.Model.DTOView;
using HearthStoneForum.WebApi.Utility.ApiResult;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HearthStoneForum.WebApi.Controllers
{
    [Route("api/areas")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly IAreaService _iAreaService;
        private readonly IMapper _iMapper;
        public AreaController(IAreaService iAreaService, IMapper iMapper)
        {
            _iAreaService = iAreaService;
            _iMapper = iMapper;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResult>> GetArea()
        {
            var data = await _iAreaService.QueryDTOAsync<AreaDTOView>();
            if (data.Count == 0) return ApiResultHelper.Error("没有更多的值");
            return ApiResultHelper.Success(data);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResult>> GetArea(int id)
        {
            var area = (await _iAreaService.QueryDTOAsync<AreaDTOView>(it => it.Id == id)).FirstOrDefault();
            if (area == null) return ApiResultHelper.Error("没有更多的值");

            return ApiResultHelper.Success(area);
        }
        [HttpGet("search")]
        public async Task<ActionResult<ApiResult>> GetAreaByName(string name)
        {
            var data = await _iAreaService.QueryDTOAsync<AreaDTOView>(it => it.Name.ToLower().Contains(name.ToLower()));
            if (data.Count == 0) return ApiResultHelper.Error("未找到想要搜索的分区");
            return ApiResultHelper.Success(data);
        }
        [HttpPost]
        public async Task<ActionResult<ApiResult>> Create(AreaDTOAdd dto)
        {
            Area area = _iMapper.Map<AreaDTOAdd, Area>(dto);
            bool b = await _iAreaService.CreateAsync(area);
            if (!b) return ApiResultHelper.Error("添加失败");

            return ApiResultHelper.Success(area);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResult>> Delete(int id)
        {
            bool b = await _iAreaService.DeleteAsync(id);
            if (!b) return ApiResultHelper.Error("删除失败");
            return ApiResultHelper.Success(b);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResult>> Edit(int id, Area area)
        {
            var oldArea = await _iAreaService.FindAsync(id);
            if (oldArea == null) return ApiResultHelper.Error("没有找到该记录");

            bool b = await _iAreaService.EditAsync(area);
            if (!b) return ApiResultHelper.Error("修改失败");
            return ApiResultHelper.Success(area);
        }

        
        [HttpPut("sort/num")]
        public async Task<ActionResult<ApiResult>> SortByNum(int id, int num)
        {
            var area = await _iAreaService.FindAsync(id);
            if (area == null) return ApiResultHelper.Error("没有找到该记录");

            var areas = await _iAreaService.QueryAsync();
            if (areas.Count == 0) return ApiResultHelper.Error("没有找到该记录");

            if (num <= 0 || num > areas.Count) return ApiResultHelper.Error("没有找到该记录");

            area.Sort = (areas[num - 1].Sort + (num == 1 ? 0 : areas[num - 2].Sort)) / 2;

            bool b = await _iAreaService.EditAsync(area);
            if (!b) return ApiResultHelper.Error("修改失败");
            return ApiResultHelper.Success(area);
        }
    }
}
