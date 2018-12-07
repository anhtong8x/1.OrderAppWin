using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TN.Domain.Model;

namespace TN.Infrastructure.Interfaces
{
    public interface IUserRepository : IEntityBaseRepository<ApplicationUser>
    {
        List<int> SchoolRoles(int userId);
        Task<List<DataRoleActionModel>> RoleActionsByUserAsync(int userId);
        Task<BaseLogDataModel<string>> UpdateRolesAsync(int userId, List<int> roles);
        Task<List<int>> GetRolesAsync(int userId);
        Task<int> StatusUserAsync(int userId);
        void DeleteRoles(int userId);
        Task<ApplicationRole> GetRoleByUser(int userId);
        Task<BaseSearchModel<List<ApplicationUser>>> SearchPagedList(int page, int limit, int? roleId, Expression<Func<ApplicationUser, bool>> predicate = null, Func<IQueryable<ApplicationUser>, IOrderedQueryable<ApplicationUser>> orderBy = null, Expression<Func<ApplicationUser, ApplicationUser>> select = null, params Expression<Func<ApplicationUser, object>>[] includeProperties);
    }
}
