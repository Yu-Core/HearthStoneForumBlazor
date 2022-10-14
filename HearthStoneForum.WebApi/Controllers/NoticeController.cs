using HearthStoneForum.IService;
using HearthStoneForum.Model;
using HearthStoneForum.Service;
using HearthStoneForum.WebApi.Utility.ApiResult;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SqlSugar;
using System.Drawing;

namespace HearthStoneForum.WebApi.Controllers
{
    [Route("api/notices")]
    [ApiController]
    public class NoticeController : ControllerBase
    {
        private readonly INoticeService _iNoticeService;
        public NoticeController(INoticeService iNoticeService)
        {
            _iNoticeService = iNoticeService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResult>> GetNotice()
        {
            var data = await _iNoticeService.QueryAsync();
            if (data.Count == 0) return ApiResultHelper.Error("没有更多的值");
            return ApiResultHelper.Success(data);
        }
        [HttpGet("page")]
        public async Task<ActionResult<ApiResult>> GetNoticePage(int page, int size)
        {
            RefAsync<int> total = 0;
            var data = await _iNoticeService.QueryAsync(page, size, total);
            if (data.Count == 0) return ApiResultHelper.Error("没有更多的值");
            return ApiResultHelper.Success(data,total);
        }
        [HttpGet("new_notices")]
        public async Task<ActionResult<ApiResult>> GetNewNotices()
        {
            var data = await _iNoticeService.GetNewNotices();
            if (data.Count == 0) return ApiResultHelper.Error("没有更多的值");
            return ApiResultHelper.Success(data);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResult>> GetNotice(int id)
        {
            var notice = await _iNoticeService.FindAsync(id);
            if (notice == null) return ApiResultHelper.Error("没有更多的值");

            return ApiResultHelper.Success(notice);
        }
        [HttpGet("search")]
        public async Task<ActionResult<ApiResult>> GetNoticeByName(string searchText, int page, int size)
        {
            RefAsync<int> total = 0;
            var data = await _iNoticeService.QueryAsync(
                it => it.Title.ToLower().Contains(searchText.ToLower())||it.Description.ToLower().Contains(searchText.ToLower()) ,
                page, size, total);

            if (data.Count == 0) return ApiResultHelper.Error("未找到想要搜索的数据");
            return ApiResultHelper.Success(data,total);
        }
        [HttpPost]
        public async Task<ActionResult<ApiResult>> Create(Notice notice)
        {
            bool b = await _iNoticeService.CreateAsync(notice);
            if (!b) return ApiResultHelper.Error("用户添加失败，服务器发生错误");

            return ApiResultHelper.Success(notice);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResult>> Delete(int id)
        {
            bool b = await _iNoticeService.DeleteAsync(id);
            if (!b) return ApiResultHelper.Error("删除失败");
            return ApiResultHelper.Success(b);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResult>> Edit(int id, Notice notice)
        {
            var oldNotice = await _iNoticeService.FindAsync(id);
            if (oldNotice == null) return ApiResultHelper.Error("没有找到该用户");

            bool b = await _iNoticeService.EditAsync(notice);
            if (!b) return ApiResultHelper.Error("修改失败");
            return ApiResultHelper.Success(notice);
        }
    }
}
