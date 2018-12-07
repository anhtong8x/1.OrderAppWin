using System.Collections.Generic;
using System.Threading.Tasks;
using TN.Infrastructure.Interfaces;
using TN.Domain.Model;

namespace TN.Infrastructure.Interfaces
{
    public interface IRoleControllerRepository : IEntityBaseRepository<RoleController>
    {
        Task<List<TreeRoleModel>> GetTreeRoleAsync(int roleId);
        Task<BaseLogDataModel<string>> UpdateRoleAsync(int roleId, List<int> ids);
        Task ReLoginUsersAsync(int roleId);
    }
}
