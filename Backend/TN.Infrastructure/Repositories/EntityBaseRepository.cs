using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TN.Domain.Model;
using TN.Domain.Seedwork;
using TN.Infrastructure;

namespace TN.Infrastructure.Repositories
{
	public class EntityBaseRepository<T> : IEntityBaseRepository<T>
			where T : class, IAggregateRoot, new()
	{
		protected readonly ApplicationContext _context;

		public IUnitOfWork UnitOfWork
		{
			get
			{
				return _context;
			}
		}

		#region Properties
		public EntityBaseRepository(ApplicationContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}
		#endregion

		public virtual async Task<BaseSearchModel<List<T>>> SearchPagedList(int page, int limit, Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Expression<Func<T, T>> select = null, params Expression<Func<T, object>>[] includeProperties)
		{
			IQueryable<T> query = _context.Set<T>();
			
			
            if (predicate != null)
            {
                query = _context.Set<T>().Where(predicate).AsQueryable();
            }
            if (orderBy != null)
            {
                query = orderBy(query).AsQueryable();
            }
            if (select != null)
			{
				query = query.Select(select).AsQueryable();
			}
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            return new BaseSearchModel<List<T>>
			{
				Data = await query.Skip((page - 1) * limit).Take(limit).AsNoTracking().ToListAsync(),
				Limit = limit,
				Page = page,
				TotalRows = await query.CountAsync()
			};
		}

		public virtual async Task<List<T>> Search(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
		{
			IQueryable<T> query = _context.Set<T>();
			if (predicate != null)
			{
				query = _context.Set<T>().Where(predicate).AsQueryable();
			}
			if (orderBy != null)
			{
				query = orderBy(query).AsQueryable();
			}
			return await query.ToListAsync();
		}

		public virtual async Task<List<T>> Search(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includeProperties)
		{
			IQueryable<T> query = _context.Set<T>();
			if (predicate != null)
			{
				query = _context.Set<T>().Where(predicate).AsQueryable();
			}
			if (orderBy != null)
			{
				query = orderBy(query).AsQueryable();
			}

			if (includeProperties != null)
			{
				foreach (var includeProperty in includeProperties)
				{
					query = query.Include(includeProperty);
				}
			}

            return await query.ToListAsync();
		}
        public virtual async Task<List<T>> SearchAdvanced(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Expression<Func<T, T>> select = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            if (predicate != null)
            {
                query = _context.Set<T>().Where(predicate).AsQueryable();
            }
            if (orderBy != null)
            {
                query = orderBy(query).AsQueryable();
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            if (select != null)
            {
                query = query.Select(select).AsQueryable();
            }
            return await query.AsNoTracking().ToListAsync();
        }
        public virtual async Task<IEnumerable<T>> GetAll()
		{
			return await _context.Set<T>().ToListAsync();
		}

		public virtual IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includeProperties)
		{
			IQueryable<T> query = _context.Set<T>();
			if (includeProperties != null)
			{
				foreach (var includeProperty in includeProperties)
				{
					query = query.Include(includeProperty);
				}
			}
			return query.AsEnumerable();
		}

		public virtual int Count()
		{
			return _context.Set<T>().Count();
		}
        public virtual async Task<int> CountAsync(Expression<Func<T, bool>> predicate = null)
        {
            return await _context.Set<T>().CountAsync(predicate);
        }
        public async Task<T> GetOne(int id)
		{
			return await _context.Set<T>().FindAsync(id);
		}

		public async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
		{
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return await query.FirstOrDefaultAsync(predicate);
        }

		public async Task<T> SearchOneAsync(Expression<Func<T, bool>> predicate)
		{
			IQueryable<T> query = _context.Set<T>();
			return await query.Where(predicate).FirstOrDefaultAsync();
		}

		public async Task<T> SearchOneAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
		{
			IQueryable<T> query = _context.Set<T>();
			if (includeProperties != null)
			{
				foreach (var includeProperty in includeProperties)
				{
					query = query.Include(includeProperty);
				}
			}
			return await query.Where(predicate).FirstOrDefaultAsync();
		}

		public bool Any(Expression<Func<T, bool>> predicate)
		{
			return _context.Set<T>().Any(predicate);
		}

		public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
		{
			return await _context.Set<T>().AnyAsync(predicate);
		}

		public T Add(T entity)
		{
			return _context.Set<T>().Add(entity).Entity;

		}

		public virtual async Task AddAsync(T entity)
		{
			EntityEntry dbEntityEntry = _context.Entry<T>(entity);
			await _context.Set<T>().AddAsync(entity);
		}

		public virtual async Task AddRangeAsync(List<T> entity)
		{
			EntityEntry dbEntityEntry = _context.Entry<List<T>>(entity);
			await _context.Set<T>().AddRangeAsync(entity);
		}
		public virtual void Update(T entity)
		{
			_context.Entry(entity).State = EntityState.Modified;
		}
		public virtual void Delete(T entity)
		{
			_context.Entry(entity).State = EntityState.Deleted;
		}
		public virtual void DeleteWhere(Expression<Func<T, bool>> predicate)
		{
			IEnumerable<T> entities = _context.Set<T>().Where(predicate);

			foreach (var entity in entities)
			{
				_context.Entry<T>(entity).State = EntityState.Deleted;
			}
		}
		public virtual async Task Commit()
		{
			await UnitOfWork.SaveEntitiesAsync();
		}
	}
}
