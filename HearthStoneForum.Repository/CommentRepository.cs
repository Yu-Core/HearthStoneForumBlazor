using HearthStoneForum.IRepository;
using HearthStoneForum.Model;
using HearthStoneForum.Model.DTOView;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneForum.Repository
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public override Task<List<DTO>> QueryDTOAsync<DTO>(int page, int size, RefAsync<int> total)
        {
            return base.Context.Queryable<Comment>()
                .LeftJoin<UserInfo>((c, u) => u.Id == c.UserId)
                .OrderByDescending(c=>c.CreatedTime)
                .Select((c,u)=>new CommentDTOView
                {
                    Id=c.Id,
                    Content=c.Content,
                    CreatedTime = c.CreatedTime,
                    InvitationId = c.InvitationId,
                    UserId = c.UserId,
                    UserName = u.Name
                } as DTO)
                .ToPageListAsync(page, size, total);
        }
        public override Task<List<DTO>> QueryDTOAsync<DTO>(Expression<Func<DTO, bool>> func, int page, int size, RefAsync<int> total)
        {
            return base.Context.Queryable<Comment>()
                .LeftJoin<UserInfo>((c, u) => u.Id == c.UserId)
                .OrderByDescending(c => c.CreatedTime)
                .Select((c, u) => new CommentDTOView
                {
                    Id = c.Id,
                    Content = c.Content,
                    CreatedTime = c.CreatedTime,
                    InvitationId = c.InvitationId,
                    UserId = c.UserId,
                    UserName = u.Name
                } as DTO)
                .Where(func)
                .ToPageListAsync(page, size, total);
        }

    }
}
