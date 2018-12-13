using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TN.Domain.Model.Manager;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TN.API.Models.Command;
using TN.API.Models.Data;
using TN.Domain.Model;
using TN.Infrastructure.Interfaces;
using TN.Infrastructure.Interfaces.Manager;

namespace TN.API.Services
{
    public interface IBillService : IService<Bill>
    {
        Task<ApiResponseData<object>> GetAll();
        Task<ApiResponseData<object>> GetByIdTable(int id);
		Task<ApiResponseData<object>> Get(int id);
		Task<ApiResponseData<object>> Create(BillModel obj);
        Task<ApiResponseData<object>> Edit(BillModel obj);
        Task<ApiResponseData<object>> Delete(int id);
        Task<ApiResponseData<object>> Search(int page = 1, int limit = 10, string key = null);
    }
    public class BillService : IBillService
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
        private readonly IBillRepository _iBillRepository;

        public BillService
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
                IBillRepository iBillRepository

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
			_iBillRepository = iBillRepository;

        }
        public async Task<ApiResponseData<object>> GetAll()
        {
            var data = await _iBillRepository.Search();
            return new ApiResponseData<object> { Output = 1, Data = data };
        }
        public async Task<ApiResponseData<object>> Get(int id)
        {
            var data = await _iBillRepository.SearchOneAsync(x => x.Id == id);
            return new ApiResponseData<object> { Output = 1, Data = data };
        }

		public async Task<ApiResponseData<object>> GetByIdTable(int id)
		{
			var data = await _iBillRepository.SearchOneAsync(x => x.TableId == id && x.Paid == false);
			return new ApiResponseData<object> { Output = 1, Data = data };
		}

		public async Task<ApiResponseData<object>> Search(int page = 1, int limit = 10, string key = null)
        {
            limit = limit > 100 ? 10 : limit;
            var data = await _iBillRepository.SearchPagedList(page, limit, x => (x.CashierName.Contains(key) || key == null) && (x.Note.Contains(key) || key == null));
            return new ApiResponseData<object> { Data = data };
        }

        public async Task<ApiResponseData<object>> Create(BillModel obj)
        {
			var add = new Bill
			{
				CashierId = obj.Id,
				CashierName = obj.CashierName,
				WaitersId = obj.Id,
				WaiterName = obj.WaiterName,
				Paid = obj.Paid,
				Money = obj.Money,
				CreateDate = DateTime.Now,
				Note = obj.Note,
				TableId = obj.TableId
            };
            await _iBillRepository.AddAsync(add);
            await _iBillRepository.Commit();
            return new ApiResponseData<object> { Output = 1, Data = add };
        }
        public async Task<ApiResponseData<object>> Edit(BillModel obj)
        {
            var data = await _iBillRepository.SearchOneAsync(x => x.Id == obj.Id);
            if (data != null)
            {
				data.CashierId = obj.Id;
				data.CashierName = obj.CashierName;
				data.WaitersId = obj.Id;
				data.WaiterName = obj.WaiterName;
				data.Paid = obj.Paid;
				data.Money = obj.Money;
				data.CreateDate = DateTime.Now;
				data.Note = obj.Note;
				data.TableId = obj.TableId;

				await _iBillRepository.Commit();
            }
            return new ApiResponseData<object> { Output = 1, Data = data };
        }
        public async Task<ApiResponseData<object>> Delete(int id)
        {
            var data = await _iBillRepository.SearchOneAsync(x => x.Id == id);
            if (data != null)
            {
				_iBillRepository.Delete(data);
                await _iBillRepository.Commit();
            }
            return new ApiResponseData<object> { Output = 1, Data = data };
        }
    }

}
