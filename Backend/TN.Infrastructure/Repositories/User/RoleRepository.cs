﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TN.Domain.Model;
using TN.Infrastructure.Interfaces;

namespace TN.Infrastructure.Repositories
{
   
    public class RoleRepository : EntityBaseRepository<ApplicationRole>, IRoleRepository
    {
        private readonly ApplicationContext db;
        public RoleRepository(ApplicationContext context) : base(context)
        {
            db = context;
        }
        public virtual async Task<bool> IsUse(int roleId)
        {
            return await db.UserRoles.AnyAsync(m => m.RoleId == roleId);
        }
    }
}