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
    public class RoleGroupRepository : EntityBaseRepository<RoleGroup>, IRoleGroupRepository
    {
        public RoleGroupRepository(ApplicationContext context) : base(context)
        {
        }
    }
}

