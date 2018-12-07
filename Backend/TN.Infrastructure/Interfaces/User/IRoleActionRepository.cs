using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TN.Infrastructure;
using TN.Domain.Model;

namespace TN.Infrastructure.Interfaces
{
    public interface IRoleActionRepository : IEntityBaseRepository<RoleAction>
    {
        Task<BaseSearchModel<List<RoleAction>>> SearchPagedListAdvance(int page, int limit, Expression<Func<RoleAction, bool>> predicate = null, Func<IQueryable<RoleAction>, IOrderedQueryable<RoleAction>> orderBy = null, Expression<Func<RoleAction, RoleAction>> select = null);
    }
}

