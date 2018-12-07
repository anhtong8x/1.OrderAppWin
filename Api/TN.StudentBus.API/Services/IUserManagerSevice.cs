using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TN.API.Models.Command;
using TN.API.Models.Data;
using TN.Domain.Model;
using TN.Infrastructure.Interfaces;

namespace TN.API.Services
{
    public interface IUserManagerSevice : IService<ApplicationUser>
    {
        Task<ApiResponseData<object>> LoginAsync(LoginCommand model);
    }
    public class UserManagerSevice : IUserManagerSevice
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IHostingEnvironment _iHostingEnvironment;
        private readonly ILogger _logger;
        private readonly LogSettings _logSettings;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ApiSettings _apiSettings;
        private readonly IUserRepository _aspNetUsers;
        private readonly ILogRepository _iLogRepository;
        private readonly IFileRepository _iFileRepository;
        private readonly IEmailSenderRepository _iEmailSenderRepository;
        private readonly IOptions<EmailSettings> _emailSettings;
        private readonly IUserRepository _iUserRepository;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public UserManagerSevice
            (
                ILogger<UserManagerSevice> logger,
                IHostingEnvironment hostingEnvironment,
                IOptions<ApiSettings> apiSettings,
                UserManager<ApplicationUser> userManager,
                IUserRepository aspNetUsers,
                RoleManager<ApplicationRole> roleManager,
                IHostingEnvironment iHostingEnvironment,
                ILogRepository iLogRepository,
                IOptions<LogSettings> logSettings,
                IFileRepository iFileRepository,
                IEmailSenderRepository iEmailSenderRepository,
                IOptions<EmailSettings> emailSettings,
                IUserRepository iUserRepository,
                SignInManager<ApplicationUser> signInManager
            )
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
            _apiSettings = apiSettings.Value;
            _userManager = userManager;
            _aspNetUsers = aspNetUsers;
            _roleManager = roleManager;
            _iHostingEnvironment = iHostingEnvironment;
            _iLogRepository = iLogRepository;
            _logSettings = logSettings.Value;
            _iFileRepository = iFileRepository;
            _iEmailSenderRepository = iEmailSenderRepository;
            _emailSettings = emailSettings;
            _iUserRepository = iUserRepository;
            _signInManager = signInManager;
        }
        public async Task<ApiResponseData<object>> LoginAsync(LoginCommand model)
        {
            var kt = await _iUserRepository.SearchOneAsync(m => m.UserName == model.Username);
            if (kt == null)
            {
                return new ApiResponseData<object> { Output = 0, Message = "Tài khoản hoặc mật khẩu không tồn tại." };
            }
            if (kt.IsLock && kt.IsSuperAdmin == false)
            {
                return new ApiResponseData<object> { Output = 2, Message = "Tài khoản này đã bị khóa, vui lòng liên hệ quản trị để biết thêm chi tiết." };
            }
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                if(kt.IsReLogin)
                {
                    // cập nhật trạng thái relogin
                    kt.IsReLogin = false;
                    _iUserRepository.Update(kt);
                    await _iUserRepository.Commit();
                }

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sid,kt.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.UniqueName,kt.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_apiSettings.TokenKey));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    issuer: _apiSettings.TokenIssuer,
                    audience: _apiSettings.TokenAudience,
                    claims: claims,
                    expires: DateTime.Now.AddHours(24),
                    signingCredentials: creds);

                return new ApiResponseData<object> {
                    Output = 1,
                    Message = "Đăng nhập thành công.",
                    Data = new AccountData(kt, new JwtSecurityTokenHandler().WriteToken(token)) 
                };
            }
            else
            {
                return new ApiResponseData<object> { Output = 2, Message = "Tài khoản không tồn tại hoặc mật khẩu sai." };
            }
        }
    }
}
