using TN.Domain.Model;
using TN.Infrastructure;
using System.Threading.Tasks;
using TN.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace TN.Infrastructure.Repositories
{
    public class RoleAreaRepository : EntityBaseRepository<RoleArea>, IRoleAreaRepository
    {
        public RoleAreaRepository(ApplicationContext context) : base(context)
        {
        }
    }
}

