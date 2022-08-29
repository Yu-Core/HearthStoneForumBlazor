using HearthStoneForum.IService;
using HearthStoneForum.Model;
using HearthStoneForum.WebApi.Utility.ApiResult;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HearthStoneForum.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionController : ControllerBase
    {
        private readonly ICollectionService _iCollectionService;
        public CollectionController(ICollectionService iCollectionService)
        {
            _iCollectionService = iCollectionService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResult>> GetCollection()
        {
            var data = await _iCollectionService.QueryAsync();
            if (data.Count == 0) return ApiResultHelper.Error("没有更多的值");
            return ApiResultHelper.Success(data);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResult>> GetCollection(int id)
        {
            var collection = await _iCollectionService.FindAsync(id);
            if (collection == null) return ApiResultHelper.Error("没有更多的值");

            return ApiResultHelper.Success(collection);
        }
        [HttpPost]
        public async Task<ActionResult<ApiResult>> Create(Collection collection)
        {
            bool b = await _iCollectionService.CreateAsync(collection);
            if (!b) return ApiResultHelper.Error("添加失败");

            return ApiResultHelper.Success(collection);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResult>> Delete(int id)
        {
            bool b = await _iCollectionService.DeleteAsync(id);
            if (!b) return ApiResultHelper.Error("删除失败");
            return ApiResultHelper.Success(b);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResult>> Edit(int id, Collection collection)
        {
            var oldCollection = await _iCollectionService.FindAsync(id);
            if (oldCollection == null) return ApiResultHelper.Error("没有找到该记录");

            bool b = await _iCollectionService.EditAsync(collection);
            if (!b) return ApiResultHelper.Error("修改失败");
            return ApiResultHelper.Success(collection);
        }
    }
}
