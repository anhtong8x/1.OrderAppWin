using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TN.Domain.Model;
using TN.Domain.Seedwork;

namespace TN.Infrastructure
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser, ApplicationRole,int>, IUnitOfWork
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
             : base(options)
        {
        }

        // System User
        public DbSet<RoleController> RoleControllers { get; set; }
        public DbSet<RoleAction> RoleActions { get; set; }
        public DbSet<RoleDetail> RoleDetails { get; set; }
        public DbSet<RoleGroup> RoleGroups { get; set; }
        public DbSet<RoleArea> RoleAreas { get; set; }
        public DbSet<Log> Logs { get; set; }
		public DbSet<Dish> Dishs { get; set; }
		public DbSet<TableStatus> TableStatuss { get; set; }
		public DbSet<DishPrice> DishPrices { get; set; }


		protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(builder);

            builder.Entity<RoleDetail>().ToTable("RoleDetail", "adm").HasKey(c => new { c.ActionId, c.RoleId });
            builder.Entity<RoleController>().ToTable("RoleController", "adm");
            builder.Entity<RoleAction>().ToTable("RoleAction", "adm");
            builder.Entity<RoleGroup>().ToTable("RoleGroup", "adm");
            builder.Entity<RoleArea>().ToTable("RoleArea", "adm");
            builder.Entity<ApplicationUser>().ToTable("User", "adm");
            builder.Entity<ApplicationRole>().ToTable("Role", "adm");
            builder.Entity<IdentityUserRole<int>>().ToTable("UserRole", "adm");
            builder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaim", "adm");
            builder.Entity<IdentityUserLogin<int>>().ToTable("UserLogin", "adm");
            builder.Entity<IdentityUserToken<int>>().ToTable("UserToken", "adm");
            builder.Entity<IdentityUserClaim<int>>().ToTable("UserClaim", "adm");
            builder.Entity<Log>().ToTable("Log", "adm").HasIndex(x => new { x.CreatedDate, x.Type, x.ObjectType, x.Action, x.SystemUser });

			// khai bao cac bang them
			builder.Entity<Dish>().ToTable("Dish");
			builder.Entity<TableStatus>().ToTable("TableStatus");
			builder.Entity<DishPrice>().ToTable("DishPrice");

		}
		public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await base.SaveChangesAsync();
            return true;
        }
    }
}
