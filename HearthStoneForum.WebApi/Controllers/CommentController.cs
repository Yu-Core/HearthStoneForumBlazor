using HearthStoneForum.IService;
using HearthStoneForum.Model;
using HearthStoneForum.Model.DTOView;
using HearthStoneForum.Service;
using HearthStoneForum.WebApi.Utility.ApiResult;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;

namespace HearthStoneForum.WebApi.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _iCommentService;
        public CommentController(ICommentService iCommentService)
        {
            _iCommentService = iCommentService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResult>> GetComment()
        {
            var data = await _iCommentService.QueryAsync();
            if (data.Count == 0) return ApiResultHelper.Error("没有更多的值");
            return ApiResultHelper.Success(data);
        }
        [HttpGet("page")]
        public async Task<ActionResult<ApiResult>> GetComment(int page, int size)
        {
            RefAsync<int> total = 0;
            var data = await _iCommentService.QueryDTOAsync<CommentDTOView>(page,size,total);
            if (data.Count == 0) return ApiResultHelper.Error("没有更多的值");
            return ApiResultHelper.Success(data);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResult>> GetComment(int id)
        {
            var comment = await _iCommentService.FindAsync(id);
            if (comment == null) return ApiResultHelper.Error("没有更多的值");

            return ApiResultHelper.Success(comment);
        }
        [HttpGet("search")]
        public async Task<ActionResult<ApiResult>> GetCommentByName(string content)
        {
            var data = await _iCommentService.QueryAsync(it => it.Content.ToLower().Contains(content.ToLower()));
            if (data.Count == 0) return ApiResultHelper.Error("未找到想要搜索的数据");
            return ApiResultHelper.Success(data);
        }
        [HttpPost]
        public async Task<ActionResult<ApiResult>> Create(Comment comment)
        {
            bool b = await _iCommentService.CreateAsync(comment);
            if (!b) return ApiResultHelper.Error("添加失败");

            return ApiResultHelper.Success(comment);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResult>> Delete(int id)
        {
            bool b = await _iCommentService.DeleteAsync(id);
            if (!b) return ApiResultHelper.Error("删除失败");
            return ApiResultHelper.Success(b);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResult>> Edit(int id, Comment comment)
        {
            var oldComment = await _iCommentService.FindAsync(id);
            if (oldComment == null) return ApiResultHelper.Error("没有找到该记录");

            bool b = await _iCommentService.EditAsync(comment);
            if (!b) return ApiResultHelper.Error("修改失败");
            return ApiResultHelper.Success(comment);
        }
    }
}
