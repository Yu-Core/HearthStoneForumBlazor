using AutoMapper;
using HearthStoneForum.IService;
using HearthStoneForum.Model;
using HearthStoneForum.Model.DTOAdd;
using HearthStoneForum.Model.DTOView;
using HearthStoneForum.Service;
using HearthStoneForum.WebApi.Utility.ApiResult;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;

namespace HearthStoneForum.WebApi.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _iCommentService;
        private readonly IMapper _iMapper;
        public CommentController(ICommentService iCommentService,IMapper iMapper)
        {
            _iCommentService = iCommentService;
            _iMapper = iMapper;
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
            var data = await _iCommentService.QueryDTOAsync<CommentDTOView>(page, size, total);
            if (data.Count == 0) return ApiResultHelper.Error("没有更多的值");
            return ApiResultHelper.Success(data);
        }
        [HttpGet("invitation")]
        public async Task<ActionResult<ApiResult>> GetComment(int id, int page, int size)
        {
            RefAsync<int> total = 0;
            var data = await _iCommentService.QueryDTOAsync<CommentDTOView>(it => it.InvitationId == id, page, size, total);
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
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ApiResult>> Create(CommentDTOAdd dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Content))
                return ApiResultHelper.Error("添加失败");

            int userId = Convert.ToInt32(this.User.FindFirst("UserId").Value);

            dto.UserId = userId;

            var invitation = _iMapper.Map<CommentDTOAdd, Comment>(dto);

            bool b = await _iCommentService.CreateAsync(invitation);
            if (!b) return ApiResultHelper.Error("添加失败");

            return ApiResultHelper.Success(invitation);
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResult>> Delete(int id)
        {
            int userId = Convert.ToInt32(this.User.FindFirst("UserId").Value);
            var data = await _iCommentService.FindAsync(it => it.Id == id && it.UserId == userId);
            if (data == null) return ApiResultHelper.Error("没有找到该记录");

            bool b = await _iCommentService.DeleteAsync(id);
            if (!b) return ApiResultHelper.Error("删除失败");
            return ApiResultHelper.Success(null);
        }
    }
}
