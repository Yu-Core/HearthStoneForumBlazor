using HearthStoneForum.IRepository;
using HearthStoneForum.Model;
using HearthStoneForum.Model.DTOView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneForum.Repository
{
#pragma warning disable CS8619 // 值中的引用类型的为 Null 性与目标类型不匹配。
#pragma warning disable CS8620 // 由于引用类型的可为 null 性差异，实参不能用于形参。
    public class UserInfoRepository : BaseRepository<UserInfo>,IUserInfoRepository
    {
        public override async Task<List<DTO>> QueryDTOAsync<DTO>()
        {


            return await Context.Queryable<UserInfo>()
                .Select(u => new UserInfoDTOView()
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    Name = u.Name,
                    CreatedTime = u.CreatedTime,
                    Email = u.Email,
                    Portrait = u.Portrait,
                    LastLogin = u.LastLogin,
                    Phone = u.Phone,
                    Sex = u.Sex
                } as DTO)
                .ToListAsync();

        }
        public override async Task<List<DTO>> QueryDTOAsync<DTO>(Expression<Func<DTO, bool>> func)
        {
                return await Context.Queryable<UserInfo>()
                .Select(u => new UserInfoDTOView()
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    Name = u.Name,
                    CreatedTime = u.CreatedTime,
                    Email = u.Email,
                    Portrait = u.Portrait,
                    LastLogin = u.LastLogin,
                    Phone = u.Phone,
                    Sex = u.Sex
                } as DTO)
                .Where(func)
                .ToListAsync();
        }
    }
}
