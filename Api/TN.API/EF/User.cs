using System;
using System.Collections.Generic;

namespace TN.API.EF
{
    public partial class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public bool IsSuperAdmin { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedUser { get; set; }
    }
}
