using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using TN.Domain.Seedwork;

namespace TN.Domain.Model
{
    public class ApplicationRole : IdentityRole<int>, IAggregateRoot
    {
        [Display(Name= "Description")]
        public string Description { get; set; }
        public RoleManagerType Type { get; set; }
    }

}
