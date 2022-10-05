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
                .Select((c,u)=>new CommentDTOView
                {
                    Id=c.Id,
                    Content=c.Content,
                    CreatedTime = c.CreatedTime,
                    InvitationId = c.InvitationId,
                    UserId = c.UserId,
                    UserName = u.Name,
                    UserPortrait = u.Portrait
                })
                .MergeTable()
                .OrderByDescending(it => it.CreatedTime)
                .ToPageListAsync(page, size, total, it => new DTO());
        }
        public override Task<List<DTO>> QueryDTOAsync<DTO>(Expression<Func<DTO, bool>> func, int page, int size, RefAsync<int> total)
        {
            return base.Context.Queryable<Comment>()
                .LeftJoin<UserInfo>((c, u) => u.Id == c.UserId)
                .Select((c, u) => new CommentDTOView
                {
                    Id = c.Id,
                    Content = c.Content,
                    CreatedTime = c.CreatedTime,
                    InvitationId = c.InvitationId,
                    UserId = c.UserId,
                    UserName = u.Name,
                    UserPortrait = u.Portrait
                })
                
                .MergeTable()
                .OrderByDescending(it => it.CreatedTime)
                .Where(func as Expression<Func<CommentDTOView, bool>>)
                .ToPageListAsync(page, size, total, it => new DTO());
        }

    }
}
