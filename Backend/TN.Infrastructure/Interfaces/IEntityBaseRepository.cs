using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using TN.Domain.Seedwork;
using TN.Domain.Model;

namespace TN.Infrastructure
{
    public interface IEntityBaseRepository<T>: IRepository<T> where T : class, IAggregateRoot, new ()
    {
        Task<BaseSearchModel<List<T>>> SearchPagedList(int page, int limit, Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Expression<Func<T, T>> select = null, params Expression<Func<T, object>>[] includeProperties);
        Task<List<T>> Search(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
        Task<List<T>> Search(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includeProperties);
        Task<List<T>> SearchAdvanced(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Expression<Func<T, T>> select = null, params Expression<Func<T, object>>[] includeProperties);
        Task<IEnumerable<T>> GetAll();
        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includeProperties);
        int Count();
        Task<T> GetOne(int id);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        //Task<T> GetOneIncluding(int id, params Expression<Func<T, object>>[] includeProperties);
        Task<T> SearchOneAsync(Expression<Func<T, bool>> predicate);
        Task<T> SearchOneAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        T Add(T entity);
        Task AddAsync(T entity);
        Task AddRangeAsync(List<T> entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteWhere(Expression<Func<T, bool>> predicate);
        bool Any(Expression<Func<T, bool>> predicate);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task Commit();
        Task<int> CountAsync(Expression<Func<T, bool>> predicate = null);
    }
}
