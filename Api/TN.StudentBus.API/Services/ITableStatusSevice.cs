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
    public interface ITableStatusSevice : IService<TableStatus>
    {
		Task<ApiResponseData<object>> GetAll();
		Task<ApiResponseData<object>> Get(int id);
		Task<ApiResponseData<object>> Create(TableStatusModel obj);
		Task<ApiResponseData<object>> Edit(TableStatusModel obj);
		Task<ApiResponseData<object>> Delete(int id);
		Task<ApiResponseData<object>> Search(int page = 1, int limit = 10, string key = null);
	}
    public class TableStatusSevice : ITableStatusSevice
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
		private readonly ITableStatusRespository _iTableStatusRespository;

		public TableStatusSevice
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
                SignInManager<ApplicationUser> signInManager,
				ITableStatusRespository iTableStatusRespository

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
			_iTableStatusRespository = iTableStatusRespository;

		}

		public Task<ApiResponseData<object>> Create(TableStatusModel obj)
		{
			throw new NotImplementedException();
		}

		public Task<ApiResponseData<object>> Delete(int id)
		{
			throw new NotImplementedException();
		}

		public Task<ApiResponseData<object>> Edit(TableStatusModel obj)
		{
			throw new NotImplementedException();
		}

		public Task<ApiResponseData<object>> Get(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<ApiResponseData<object>> GetAll()
		{
			var data = await _iTableStatusRespository.Search();
			return new ApiResponseData<object> { Output = 1, Data = data };
		}

		public Task<ApiResponseData<object>> Search(int page = 1, int limit = 10, string key = null)
		{
			throw new NotImplementedException();
		}
	}
}
