using HearthStoneForum.IService;
using HearthStoneForum.Model;
using HearthStoneForum.Service;
using HearthStoneForum.WebApi.Utility.ApiResult;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HearthStoneForum.WebApi.Controllers
{
    [Route("api/downloads")]
    [ApiController]
    public class DownloadController : ControllerBase
    {
        private readonly IDownloadService _iDownloadService;
        public DownloadController(IDownloadService iDownloadService)
        {
            _iDownloadService = iDownloadService;
        }
        [HttpGet("search")]
        public async Task<ActionResult<ApiResult>> GetDownloadByName(string name)
        {
            var data = (await _iDownloadService.QueryAsync(it => it.Name.ToLower().Contains(name.ToLower()))).FirstOrDefault();
            if (data == null) return ApiResultHelper.Error("未找到想要搜索的数据");
            return ApiResultHelper.Success(data);
        }
        [HttpPost]
        public async Task<ActionResult<ApiResult>> Create(Download download)
        {
            bool b = await _iDownloadService.CreateAsync(download);
            if (!b) return ApiResultHelper.Error("添加失败");

            return ApiResultHelper.Success(download);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResult>> Delete(int id)
        {
            bool b = await _iDownloadService.DeleteAsync(id);
            if (!b) return ApiResultHelper.Error("删除失败");
            return ApiResultHelper.Success(b);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResult>> Edit(int id, Download download)
        {
            var oldDownload = await _iDownloadService.FindAsync(id);
            if (oldDownload == null) return ApiResultHelper.Error("没有找到该记录");

            bool b = await _iDownloadService.EditAsync(download);
            if (!b) return ApiResultHelper.Error("修改失败");
            return ApiResultHelper.Success(download);
        }
    }
}
