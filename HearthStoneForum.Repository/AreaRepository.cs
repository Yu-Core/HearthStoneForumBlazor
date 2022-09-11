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
    public class AreaRepository : BaseRepository<Area> , IAreaRepository
    {
        public override async Task<List<DTO>> QueryDTOAsync<DTO>()
        {
            return await base.Context.Queryable<Area>()
                .Select(it => new AreaDTOView()
                {
                    Id = it.Id,
                    Name = it.Name,
                    Description = it.Description,
                    ImagePath = it.ImagePath,
                    Sort = it.Sort
                })
                .OrderBy(it=>it.Sort)
                .ToListAsync(it=>new DTO());
        }
        public override async Task<List<DTO>> QueryDTOAsync<DTO>(Expression<Func<DTO, bool>> func)
        {
            return await base.Context.Queryable<Area>()
                .OrderBy(it => it.Sort)
                .OrderBy(it => it.Id)
                .Select(it => new AreaDTOView()
                {
                    Id = it.Id,
                    Name = it.Name,
                    Description = it.Description,
                    ImagePath= it.ImagePath,
                    Sort = it.Sort
                } as DTO)
                .Where(func) 
                .ToListAsync();
        }
    }
}
