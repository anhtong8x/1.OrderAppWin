using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TN.Domain.Model;

namespace TN.Infrastructure.Interfaces
{
    public interface IRoleRepository : IEntityBaseRepository<ApplicationRole>
    {
        Task<bool> IsUse(int roleId);
    }
}
