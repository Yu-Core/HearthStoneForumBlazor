using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HearthStoneForum.IRepository;
using HearthStoneForum.Model;
using SqlSugar;
using SqlSugar.IOC;

namespace HearthStoneForum.Repository
{
    public class BaseRepository<T> : SimpleClient<T>, IBaseRepository<T> where T : class,new()
    {
        public BaseRepository(ISqlSugarClient? context = null) : base(context)//注意这里要有默认值等于null
        {

            base.Context=DbScoped.SugarScope;

            //创建数据库及表，第一次运行后注释掉，不然会影响性能
            //base.Context.DbMaintenance.CreateDatabase();

            //Type[] types = new Type[] {
            //    typeof(Area),
            //    typeof(Carousel),
            //    typeof(Collection),
            //    typeof(Comment),
            //    typeof(Download),
            //    typeof(Expansion),
            //    typeof(Invitation),
            //    typeof(Likes),
            //    typeof(Notice),
            //    typeof(Portrait),
            //    typeof(RaceYear),
            //    typeof(Sign),
            //    typeof(UserInfo),
            //    typeof(ViewRecord),
            //    typeof(Report)
            //};
            //base.Context.CodeFirst.InitTables(types);
        }

        public Task<bool> CreateAsync(T entity)
        {
            return base.InsertAsync(entity);
        }

        public Task<bool> DeleteAsync(int id)
        {
            return base.DeleteByIdAsync(id);
        }

        public Task<bool> EditAsync(T entity)
        {
            return base.UpdateAsync(entity);
        }

        public Task<T> FindAsync(int id)
        {
            return base.GetByIdAsync(id);
        }

        public Task<T> FindAsync(Expression<Func<T, bool>> func)
        {
            return base.GetSingleAsync(func);
        }

        public virtual Task<List<T>> QueryAsync()
        {
            return base.GetListAsync();
        }

        public virtual Task<List<T>> QueryAsync(Expression<Func<T, bool>> func)
        {
            return base.GetListAsync(func);
        }

        public virtual Task<List<T>> QueryAsync(int page, int size, RefAsync<int> total)
        {
            return base.Context.Queryable<T>().ToPageListAsync(page, size, total);
        }

        public virtual Task<List<T>> QueryAsync(Expression<Func<T, bool>> func, int page, int size, RefAsync<int> total)
        {
            return base.Context.Queryable<T>().Where(func).ToPageListAsync(page, size, total);
        }

        public virtual Task<List<DTO>> QueryDTOAsync<DTO>() where DTO : class, new()
        {
            throw new NotImplementedException("The Method cannot be used,Please override subclasses");
        }

        public virtual Task<List<DTO>> QueryDTOAsync<DTO>(Expression<Func<DTO, bool>> func) where DTO : class, new()
        {
            throw new NotImplementedException("The Method cannot be used,Please override subclasses");
        }

        public virtual Task<List<DTO>> QueryDTOAsync<DTO>(int page, int size, RefAsync<int> total) where DTO : class, new()
        {
            throw new NotImplementedException("The Method cannot be used,Please override subclasses");
        }

        public virtual Task<List<DTO>> QueryDTOAsync<DTO>(Expression<Func<DTO, bool>> func, int page, int size, RefAsync<int> total) where DTO : class, new()
        {
            throw new NotImplementedException("The Method cannot be used,Please override subclasses");
        }
    }
}
