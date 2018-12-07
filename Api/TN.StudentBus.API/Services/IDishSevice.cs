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
    public interface IDishSevice : IService<Dish>
    {
		Task<ApiResponseData<object>> GetAll();
		Task<ApiResponseData<object>> Get(int id);
		Task<ApiResponseData<object>> Create(DishModel obj);
		Task<ApiResponseData<object>> Edit(DishModel obj);
		Task<ApiResponseData<object>> Delete(int id);
		Task<ApiResponseData<object>> Search(int page = 1, int limit = 10, string key = null);
	}
    public class DishSevice : IDishSevice
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
		private readonly IDishRepository _iDishRepository;

		public DishSevice
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
				IDishRepository iDishRepository

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
			_iDishRepository = iDishRepository;

		}
        public async Task<ApiResponseData<object>> GetAll()
        {
			var data = await _iDishRepository.Search(x => x.Status);
			return new ApiResponseData<object> { Output = 1, Data = data };
		}
		public async Task<ApiResponseData<object>> Get(int id)
		{
			var data = await _iDishRepository.SearchOneAsync(x => x.Id== id && x.Status);
			return new ApiResponseData<object> { Data = data };
		}
		public async Task<ApiResponseData<object>> Search(int page = 1, int limit= 10,string key =null)
		{
			limit = limit > 100 ? 10 : limit;
			var data = await _iDishRepository.SearchPagedList(page, limit, x => (x.Name.Contains(key) || key==null) && (x.Note.Contains(key) || key == null));
			return new ApiResponseData<object> { Data = data };
		}

		public async Task<ApiResponseData<object>> Create(DishModel obj)
		{
			var add = new Dish
			{
				Name = obj.Name,
				Note = obj.Note,
				Status = obj.Status
			};
			await _iDishRepository.AddAsync(add);
			await _iDishRepository.Commit();
			return new ApiResponseData<object> { Output = 1, Data = add };
		}
		public async Task<ApiResponseData<object>> Edit(DishModel obj)
		{
			var data = await _iDishRepository.SearchOneAsync(x => x.Id == obj.Id);
			if (data != null)
			{
				data.Name = obj.Name;
				data.Note = obj.Note;
				data.Status = obj.Status;
				await _iDishRepository.Commit();
			}
			return new ApiResponseData<object> { Output = 1, Data = data };
		}
		public async Task<ApiResponseData<object>> Delete(int id)
		{
			var data = await _iDishRepository.SearchOneAsync(x => x.Id == id);
			if (data != null)
			{
				_iDishRepository.Delete(data);
				await _iDishRepository.Commit();
			}
			return new ApiResponseData<object> { Output = 1, Data = data };
		}
	}
}
