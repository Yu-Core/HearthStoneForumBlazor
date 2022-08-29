using HearthStoneForum.IRepository;
using HearthStoneForum.Model;
using HearthStoneForum.Model.Dto;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneForum.Repository
{
    public class InvitationRepository : BaseRepository<Invitation>, IInvitationRepository
    {
        public async Task<List<InvitationDTORecommend>> GetRecommendInvitations()
        {
            var data = await base.Context.Queryable<Invitation>()
                .Select(it => new InvitationDTORecommend()
                {
                    Title = it.Title,
                    Id = it.Id
                })
                .Mapper(it=>it.LikesCount = Context.Queryable<Likes>().Where(l=>l.InvitationId == it.Id).Count())
                .Mapper(it=>it.CommentCount = Context.Queryable<Comment>().Where(c1=>c1.InvitationId == it.Id).Count())
                .Mapper(it=>it.CollectionCount = Context.Queryable<Collection>().Where(c2=>c2.InvitationId == it.Id).Count())
                .Mapper(it=>it.Recommend = it.LikesCount + it.CommentCount + it.CollectionCount )

                .ToListAsync();
            return data.OrderByDescending(it => it.Recommend).ToList();
        }


        public async Task<List<InvitationDTORecommend>> GetNewInvitations()
        {
            return await base.Context.Queryable<Invitation>()
                .OrderByDescending(it => it.CreatedTime)
                .Select(it => new InvitationDTORecommend()
                {
                    Id = it.Id,
                    Title = it.Title
                })
                .Take(50)
                .ToListAsync();
        }
        public override Task<List<DTO>> QueryDTOAsync<DTO>()
        {
            return base.Context.Queryable<Invitation, Area>((i, a) => new JoinQueryInfos(
                JoinType.Left, i.AreaId == a.Id
                ))
                .Select((i, a) => new InvitationDTO()
                {
                    Id = i.Id,
                    AreaId = i.AreaId,
                    AreaName = a.Name,
                    Title = i.Title,
                    Content = i.Content,
                    UserId = i.UserId,
                    Views = i.Views,
                    ImagePaths = i.ImagePaths
                })
                .MergeTable()
                .Mapper(it => it.Likes = Context.Queryable<Likes>().Where(l => l.InvitationId == it.Id).ToList())
                .Mapper(it => it.Comments = Context.Queryable<Comment>().Where(l => l.InvitationId == it.Id).ToList())
                .Mapper(it => it.Collections = Context.Queryable<Collection>().Where(l => l.InvitationId == it.Id).ToList())

                .Mapper(it => it.LikeCount = (it.Likes ?? new List<Likes>()).Count)
                .Mapper(it => it.CommentCount = (it.Comments ?? new List<Comment>()).Count)
                .Mapper(it => it.CollectionCount = (it.Collections ?? new List<Collection>()).Count)
                .Mapper(it => it.Recommend = it.Views + it.LikeCount + it.CollectionCount + it.CommentCount)
                .ToListAsync(it => new DTO());
        }
        public override Task<List<DTO>> QueryDTOAsync<DTO>(Expression<Func<DTO, bool>> func)
        {
            return base.Context.Queryable<Invitation, Area>((i, a) => new JoinQueryInfos(
                JoinType.Left, i.AreaId == a.Id
                ))
                .Select((i, a) => new InvitationDTO()
                {
                    Id = i.Id,
                    AreaId = i.AreaId,
                    AreaName = a.Name,
                    Title = i.Title,
                    Content = i.Content,
                    UserId = i.UserId,
                    Views = i.Views,
                    ImagePaths = i.ImagePaths
                })
                .MergeTable()
                .Mapper(it => it.Likes = Context.Queryable<Likes>().Where(l => l.InvitationId == it.Id).ToList())
                .Mapper(it => it.Comments = Context.Queryable<Comment>().Where(l => l.InvitationId == it.Id).ToList())
                .Mapper(it => it.Collections = Context.Queryable<Collection>().Where(l => l.InvitationId == it.Id).ToList())

                .Mapper(it => it.LikeCount = (it.Likes ?? new List<Likes>()).Count)
                .Mapper(it => it.CommentCount = (it.Comments ?? new List<Comment>()).Count)
                .Mapper(it => it.CollectionCount = (it.Collections ?? new List<Collection>()).Count)
                .Mapper(it => it.Recommend = it.Views + it.LikeCount + it.CollectionCount + it.CommentCount)

                .Where(func as Expression<Func<InvitationDTO, bool>>)
                .ToListAsync(it => new DTO());
        }
    }
}
