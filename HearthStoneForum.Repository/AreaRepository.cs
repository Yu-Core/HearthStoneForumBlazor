using HearthStoneForum.IRepository;
using HearthStoneForum.Model;
using HearthStoneForum.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneForum.Repository
{
    public class AreaRepository : BaseRepository<Area> , IAreaRepository
    {
        public override async Task<List<DTO>> QueryDTOAsync<DTO>()
        {
            return await base.Context.Queryable<Area>()
                .Select(it => new AreaDTO()
                {
                    Id = it.Id,
                    Name = it.Name,
                    Description = it.Description
                } as DTO)
                .ToListAsync();
        }
        public override async Task<List<DTO>> QueryDTOAsync<DTO>(Expression<Func<DTO, bool>> func)
        {
            return await base.Context.Queryable<Area>()
                .Select(it => new AreaDTO()
                {
                    Id = it.Id,
                    Name = it.Name,
                    Description = it.Description
                } as DTO)
                .Where(func)
                .ToListAsync();
        }
    }
}
