using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TN.Domain.Model;

namespace TN.API.Models.Data
{
    public class AccountData
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string Token { get; set; }
        public AccountData(ApplicationUser user,string token)
        {
            Id = user.Id;
            Username = user.UserName;
            DisplayName = user.DisplayName;
            Token = token;
        }
    }
}
