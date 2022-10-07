using AutoMapper;
using HearthStoneForum.IService;
using HearthStoneForum.Model;
using HearthStoneForum.Model.DTOAdd;
using HearthStoneForum.WebApi.Utility.ApiResult;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HearthStoneForum.WebApi.Controllers
{
    [Route("api/reports")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _iReportService;
        private readonly IMapper _iMapper;
        public ReportController(IReportService iReportService,IMapper iMapper)
        {
            _iReportService = iReportService;
            _iMapper = iMapper;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResult>> GetReport()
        {
            var data = await _iReportService.QueryAsync();
            if (data.Count == 0) return ApiResultHelper.Error("没有更多的值");
            return ApiResultHelper.Success(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResult>> GetReport(int id)
        {
            var like = await _iReportService.FindAsync(id);
            if (like == null) return ApiResultHelper.Error("没有更多的值");

            return ApiResultHelper.Success(like);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ApiResult>> Create(ReportDTOAdd dto)
        {
            int userId = Convert.ToInt32(this.User.FindFirst("UserId").Value);
            var data = await _iReportService.FindAsync(it => it.UserId == userId && it.InvitationId == dto.InvitationId);
            if (data != null) return ApiResultHelper.Error("添加失败");

            dto.UserId = userId;
            var report = _iMapper.Map<ReportDTOAdd,Report>(dto);
            bool b = await _iReportService.CreateAsync(report);
            if (!b) return ApiResultHelper.Error("添加失败");

            
            return ApiResultHelper.Success(report);
        }

        

        [Authorize]
        [HttpGet("search")]
        public async Task<ActionResult<ApiResult>> GetReportByInvitationId(int invitationId)
        {
            int userId = Convert.ToInt32(this.User.FindFirst("UserId").Value);
            var data = await _iReportService.FindAsync(it => it.UserId == userId && it.InvitationId == invitationId);
            if (data == null) return ApiResultHelper.Error("没有找到该记录");

            return ApiResultHelper.Success(data);
        }
    }
}
