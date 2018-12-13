﻿using Microsoft.AspNetCore.Hosting;
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
    public interface IDishPriceService : IService<DishPrice>
    {
        Task<ApiResponseData<object>> GetAll();
		Task<ApiResponseData<object>> Get(int id);
		Task<ApiResponseData<object>> Create(DishPriceModel obj);
        Task<ApiResponseData<object>> Edit(DishPriceModel obj);
        Task<ApiResponseData<object>> Delete(int id);
        Task<ApiResponseData<object>> Search(int page = 1, int limit = 10, string key = null);
    }
    public class DishPriceService : IDishPriceService
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
        private readonly IDishPriceRepository _iIDishPriceRepository;

        public DishPriceService
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
				IDishPriceRepository iIDishPriceRepository

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
			_iIDishPriceRepository = iIDishPriceRepository;

        }
        public async Task<ApiResponseData<object>> GetAll()
        {
            var data = await _iIDishPriceRepository.Search();
            return new ApiResponseData<object> { Output = 1, Data = data };
        }
        public async Task<ApiResponseData<object>> Get(int id)
        {
            var data = await _iIDishPriceRepository.SearchOneAsync(x => x.Id == id);
            return new ApiResponseData<object> { Output = 1, Data = data };
        }

		public async Task<ApiResponseData<object>> Search(int page = 1, int limit = 10, string key = null)
        {
            limit = limit > 100 ? 10 : limit;
            var data = await _iIDishPriceRepository.SearchPagedList(page, limit, x => (x.Name.Contains(key) || key == null) && (x.Note.Contains(key) || key == null));
            return new ApiResponseData<object> { Data = data };
        }

        public async Task<ApiResponseData<object>> Create(DishPriceModel obj)
        {
			var add = new DishPrice
			{
				DishId = obj.DishId,				
				Name = obj.Name,
				Price = obj.Price,
				Date = DateTime.Now,
				Note = obj.Note,
				Status = obj.Status
            };
            await _iIDishPriceRepository.AddAsync(add);
            await _iIDishPriceRepository.Commit();
            return new ApiResponseData<object> { Output = 1, Data = add };
        }
        public async Task<ApiResponseData<object>> Edit(DishPriceModel obj)
        {
            var data = await _iIDishPriceRepository.SearchOneAsync(x => x.Id == obj.Id);
            if (data != null)
            {
				data.DishId = obj.DishId;
				data.Name = obj.Name;
				data.Price = obj.Price;
				data.Date = DateTime.Now;
				data.Note = obj.Note;
				data.Status = obj.Status;

				await _iIDishPriceRepository.Commit();
            }
            return new ApiResponseData<object> { Output = 1, Data = data };
        }
        public async Task<ApiResponseData<object>> Delete(int id)
        {
            var data = await _iIDishPriceRepository.SearchOneAsync(x => x.Id == id);
            if (data != null)
            {
				_iIDishPriceRepository.Delete(data);
                await _iIDishPriceRepository.Commit();
            }
            return new ApiResponseData<object> { Output = 1, Data = data };
        }
    }

}