using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HearthStoneForum.IRepository;
using SqlSugar;

namespace HearthStoneForum.IService
{
    public interface IBaseService<T> where T : class,new()
    {
        Task<bool> CreateAsync(T entity);
        int CreateAsync(List<T> entities);
        Task<bool> DeleteAsync(int id);
        Task<bool> EditAsync(T entity);
        Task<T> FindAsync(int id);
        Task<T> FindAsync(Expression<Func<T, bool>> func);

        /// <summary>
        /// 查询全部的数据
        /// </summary>
        /// <returns></returns>
        Task<List<T>> QueryAsync();
        /// <summary>
        ///自定义条件查询
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        Task<List<T>> QueryAsync(Expression<Func<T, bool>> func);
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        Task<List<T>> QueryAsync(int page, int size, RefAsync<int> total);
        /// <summary>
        /// 自定义条件分页查询
        /// </summary>
        /// <param name="func"></param>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        Task<List<T>> QueryAsync(Expression<Func<T, bool>> func, int page, int size, RefAsync<int> total);

        Task<List<DTO>> QueryDTOAsync<DTO>() where DTO : class, new();
        Task<List<DTO>> QueryDTOAsync<DTO>(Expression<Func<DTO, bool>> func) where DTO : class, new();
        /// <summary>
        /// DTO分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        Task<List<DTO>> QueryDTOAsync<DTO>(int page, int size, RefAsync<int> total) where DTO : class, new();
        /// <summary>
        /// DTO自定义条件分页查询
        /// </summary>
        /// <param name="func"></param>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        Task<List<DTO>> QueryDTOAsync<DTO>(Expression<Func<DTO, bool>> func, int page, int size, RefAsync<int> total) where DTO : class, new();
    }
}
