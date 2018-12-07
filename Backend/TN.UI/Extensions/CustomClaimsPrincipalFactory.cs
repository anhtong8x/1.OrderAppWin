using Microsoft.AspNetCore.Http;
using System;
using TN.Domain.Model;
using static TN.UI.Extensions.AppHttpContext;
using System.Security.Claims;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using TN.Infrastructure.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Text;

namespace TN.UI.Extensions
{
    public class CustomClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser>
    {
        private readonly IUserRepository _iUserRepository;
        public CustomClaimsPrincipalFactory(
        IUserRepository iUserRepository, IMemoryCache iMemoryCache,
        UserManager<ApplicationUser> userManager,
           IOptions<IdentityOptions> optionsAccessor) :
              base(userManager, optionsAccessor)
        {
            _iUserRepository = iUserRepository;
        }

        public async override Task<ClaimsPrincipal>
           CreateAsync(ApplicationUser user)
        {
            var principal = await base.CreateAsync(user);
            var listRoleAction = new List<DataRoleActionModel>();
            if (!user.IsSuperAdmin)
            {
                listRoleAction = await _iUserRepository.RoleActionsByUserAsync(user.Id);
            }
            var DefaultRole = await _iUserRepository.GetRoleByUser(user.Id);
            // Add your claims here
            ((ClaimsIdentity)principal.Identity).AddClaims(new[] { new Claim("DisplayName", user.DisplayName ?? "") });
            ((ClaimsIdentity)principal.Identity).AddClaims(new[] { new Claim("IsSuperAdmin", user.IsSuperAdmin.ToString()) });
            ((ClaimsIdentity)principal.Identity).AddClaims(new[] { new Claim("PhoneNumber", user.PhoneNumber ?? "") });
            ((ClaimsIdentity)principal.Identity).AddClaims(new[] { new Claim("Avatar", user.Avatar ?? "") });
            ((ClaimsIdentity)principal.Identity).AddClaims(new[] { new Claim("RoleActions", listRoleAction.Count()==0? "[]": Newtonsoft.Json.JsonConvert.SerializeObject(listRoleAction))});
            ((ClaimsIdentity)principal.Identity).AddClaims(new[] { new Claim("RoleIds", listRoleAction.Count() == 0 ? "[]" : Newtonsoft.Json.JsonConvert.SerializeObject(listRoleAction.Select(m => m.Id)))});

            ((ClaimsIdentity)principal.Identity).AddClaims(new[] { new Claim("RoleTransportCompany", user.RoleTransportCompany??"")});
            ((ClaimsIdentity)principal.Identity).AddClaims(new[] { new Claim("RoleSchool", user.RoleSchool ?? "") });
            ((ClaimsIdentity)principal.Identity).AddClaims(new[] { new Claim("RoleParents", user.RoleParents ?? "") });

            ((ClaimsIdentity)principal.Identity).AddClaims(new[] { new Claim("RoleManagerType", DefaultRole?.Type.ToString() ?? "") });


            return principal;
        }
        //private  string BindRole(List<RoleActionModel> list)
        //{
        //    var str = new StringBuilder();
        //    str.Append("<style>");
        //    str.Append("[data-checked]{ display: none!important;}");
        //    foreach (var item in list)
        //    {
        //        str.Append("[data-role-" + item.Id + "] {display:initial !important;}");
        //        str.Append("th[data-role-" + item.Id + "],td[data-role-" + item.Id + "] { display:table-cell !important; }");
        //        str.Append("a[data-role-" + item.Id + "] {display:inline-block !important;}");
        //        str.Append(".header[data-role-" + item.Id + "] {display:block !important;}");
        //    }
        //    str.Append("</style>");
        //    return str.ToString();
        //}
    }
}
