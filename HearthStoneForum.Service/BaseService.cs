using HearthStoneForum.IRepository;
using HearthStoneForum.IService;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneForum.Service
{
    public class BaseService<T> : IBaseService<T> where T : class, new()
    {
        protected IBaseRepository<T> _iBaseRepository;
        public virtual Task<bool> CreateAsync(T entity)
        {
            return _iBaseRepository.CreateAsync(entity);
        }

        public int CreateAsync(List<T> entities)
        {
            return _iBaseRepository.CreateAsync(entities);
        }

        public Task<bool> DeleteAsync(int id)
        {
            return _iBaseRepository.DeleteAsync(id);
        }

        public Task<bool> EditAsync(T entity)
        {
            return _iBaseRepository.EditAsync(entity);
        }

        public Task<T> FindAsync(int id)
        {
            return _iBaseRepository.FindAsync(id);
        }

        public Task<T> FindAsync(Expression<Func<T, bool>> func)
        {
            return _iBaseRepository.FindAsync(func);
        }

        public Task<List<T>> QueryAsync()
        {
            return _iBaseRepository.QueryAsync();
        }

        public Task<List<T>> QueryAsync(Expression<Func<T, bool>> func)
        {
            return _iBaseRepository.QueryAsync(func);
        }

        public Task<List<T>> QueryAsync(int page, int size, RefAsync<int> total)
        {
            return _iBaseRepository.QueryAsync(page,size, total);
        }

        public Task<List<T>> QueryAsync(Expression<Func<T, bool>> func, int page, int size, RefAsync<int> total)
        {
            return _iBaseRepository.QueryAsync(func,page,size,total);
        }

        public Task<List<DTO>> QueryDTOAsync<DTO>() where DTO : class,new()
        {
            return _iBaseRepository.QueryDTOAsync<DTO>();
        }

        public Task<List<DTO>> QueryDTOAsync<DTO>(Expression<Func<DTO, bool>> func) where DTO : class, new()
        {
            return _iBaseRepository.QueryDTOAsync(func);
        }

        public Task<List<DTO>> QueryDTOAsync<DTO>(int page, int size, RefAsync<int> total) where DTO : class, new()
        {
            return _iBaseRepository.QueryDTOAsync<DTO>(page, size, total);
        }

        public Task<List<DTO>> QueryDTOAsync<DTO>(Expression<Func<DTO, bool>> func, int page, int size, RefAsync<int> total) where DTO : class, new()
        {
            return _iBaseRepository.QueryDTOAsync<DTO>(func, page, size, total);
        }
    }
}
