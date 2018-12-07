using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TN.Domain.Model;
using TN.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;

namespace TN.Infrastructure.Repositories
{
    public class UserRepository : EntityBaseRepository<ApplicationUser>, IUserRepository
    {
        private readonly ApplicationContext _db;
        public UserRepository(ApplicationContext context) : base(context)
        {
            _db = context;
        }
      
        public async Task<List<DataRoleActionModel>> RoleActionsByUserAsync(int userId)
        {
          
              var listCa = await _db.RoleActions.Where(m =>
                 _db.UserRoles.Any(x => x.UserId == userId && _db.RoleDetails.Any(r => r.RoleId == x.RoleId && r.ActionId == m.Id))
                ).GroupBy(m=>m.Id).Select(m=>m.FirstOrDefault()).Select(x => new DataRoleActionModel
                {
                    ControllerName = x.ControllerId,
                    AreaName = x.RoleController.AreaId,
                    ActionName = x.Name,
                    Id = x.Id
                }).ToListAsync();

            return listCa;
        }
        public async Task<ApplicationRole> GetRoleByUser(int userId)
        {
            return await _db.Roles.FirstOrDefaultAsync(x => _db.UserRoles.Any(m => m.UserId == userId && m.RoleId == x.Id));
        }
        public async Task<int> StatusUserAsync(int userId)
        {
            var dl= await _db.Users
                .Where(m=>m.Id==userId)
                .Select(
                    x=>new ApplicationUser {
                        Id = x.Id,
                        IsLock =x.IsLock,
                        IsReLogin =x.IsReLogin
                    })
                .FirstOrDefaultAsync();
            if (dl == null) return 0;
            else if (dl.IsReLogin) return 3;
            else if (dl.IsLock) return 2;
            return 1;
        }
        public async Task<BaseLogDataModel<string>> UpdateRolesAsync(int userId,List<int> roles)
        {
            var listFirst =await _db.UserRoles.Where(m => m.UserId == userId).ToListAsync();
            var strFirst = Newtonsoft.Json.JsonConvert.SerializeObject(listFirst);
            _db.UserRoles.RemoveRange(listFirst);
            await _db.SaveChangesAsync();
            await _db.UserRoles.AddRangeAsync(roles.Select(m => new IdentityUserRole<int> { RoleId = m, UserId = userId }));
            await _db.SaveChangesAsync();
            var listLast =await _db.UserRoles.Where(m => m.UserId == userId).ToListAsync();
            return new BaseLogDataModel<string>() { DataBefore = strFirst,DataAfter= Newtonsoft.Json.JsonConvert.SerializeObject(listLast) };
        }
        public async Task<List<int>> GetRolesAsync(int userId)
        {
            return await _db.UserRoles.Where(m => m.UserId == userId).Select(x => x.RoleId).ToListAsync();
        }

        public  async Task<BaseSearchModel<List<ApplicationUser>>> SearchPagedList(int page, int limit, int? roleId, Expression<Func<ApplicationUser, bool>> predicate = null, Func<IQueryable<ApplicationUser>, IOrderedQueryable<ApplicationUser>> orderBy = null, Expression<Func<ApplicationUser, ApplicationUser>> select = null, params Expression<Func<ApplicationUser, object>>[] includeProperties)
        {
            IQueryable<ApplicationUser> query = _db.Set<ApplicationUser>();
            if (predicate != null)
            {
                query = _db.Set<ApplicationUser>().Where(predicate).AsQueryable();
            }
            if(roleId != null)
            {
                query= query.Where(m => _db.UserRoles.Any(x => x.UserId == m.Id && x.RoleId == roleId)).AsQueryable();
            }
            if (orderBy != null)
            {
                query = orderBy(query).AsQueryable();
            }
            if (select != null)
            {
                query = query.Select(select).AsQueryable();
            }
            
            var currentData = await query.Skip((page - 1) * limit).Take(limit).ToListAsync();
            var rolesUser = await _db.UserRoles.Where(m => currentData.Any(x => x.Id == m.UserId))
                .Join(_db.Roles,
                entryPoint => entryPoint.RoleId,
                entry => entry.Id,
                (entryPoint, entry) => new { entryPoint, entry }).ToListAsync();
            foreach (var item in currentData)
            {
                item.Roles = rolesUser.Where(m => m.entryPoint.UserId == item.Id)
                                        .Select(x => new IdentityRole<int>
                                        {
                                            Id = x.entry.Id,
                                            Name = x.entry.Name
                                        }).ToList();
            }
            return new BaseSearchModel<List<ApplicationUser>>
            {
                Data = currentData,
                Limit = limit,
                Page = page,
                ReturnUrl = "",
                TotalRows = await query.Select(m => 1).CountAsync()
            };
        }
        public  void DeleteRoles(int userId)
        {
              _db.UserRoles.RemoveRange(_db.UserRoles.Where(m => m.UserId == userId));
        }
        public List<int> SchoolRoles(int userId)
        {
            var data = _db.Users.Where(x => x.Id == userId && _db.UserRoles.Any(y=>y.UserId==userId && _db.Roles.Any(z=>z.Id==y.RoleId && z.Type==RoleManagerType.School))).Select(x => x.RoleSchool).FirstOrDefault();
            if (data == null || data == "") return new List<int>();
            return data.Split(',').Select(x => int.Parse(x)).ToList();
        }
    }
}
