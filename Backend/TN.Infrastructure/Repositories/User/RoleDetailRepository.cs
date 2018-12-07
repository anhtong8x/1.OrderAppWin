using TN.Infrastructure.Interfaces;
using TN.Domain.Model;

namespace TN.Infrastructure.Repositories
{
    public class RoleDetailRepository : EntityBaseRepository<RoleDetail>, IRoleDetailRepository
    {
        public RoleDetailRepository(ApplicationContext context) : base(context)
        {
        }

    }
}
