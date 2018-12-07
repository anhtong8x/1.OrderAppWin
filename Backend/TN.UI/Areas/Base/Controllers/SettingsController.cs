using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TN.Domain.Model;
using TN.Infrastructure.Interfaces;
using TN.UI.Areas.Base.Controllers;
using TN.UI.Extensions;

namespace TN.UI.Areas.Setting.Controllers
{
    [Area("Base")]
    public class SettingsController : BaseController
    {
        private readonly ILogger _logger;
        private readonly IFileRepository _iFileRepository;
        private readonly IOptions<BaseSettings> _baseSettings;
        private readonly IOptions<EmailSettings> _emailSettings;
        private readonly IHostingEnvironment _iHostingEnvironment;
        private readonly IEmailSenderRepository _iEmailSenderRepository;
        public SettingsController(
            ILogger<BaseController> logger, 
            IOptions<BaseSettings> baseSettings, 
            IFileRepository iFileRepository, 
            IHostingEnvironment iHostingEnvironment, 
            IOptions<EmailSettings> emailSettings,
            IEmailSenderRepository iEmailSenderRepository
            )
        {
            controllerName = "SettingsController";
            tableName = "User";

            _logger = logger;
            _baseSettings = baseSettings;
            _iFileRepository = iFileRepository;
            _iHostingEnvironment = iHostingEnvironment;
            _emailSettings = emailSettings;
            _iEmailSenderRepository = iEmailSenderRepository;
        }
        [HttpGet]
        [AuthorizePermission("Index")]
        public IActionResult Index()
        {
            return View(_baseSettings.Value);
        }
        [AuthorizePermission("Index")]
        [HttpPost,ValidateAntiForgeryToken,ActionName("Index")]
        public async Task<ResponseModel> IndexPost(BaseSettings model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string valueBeffo = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                    _iFileRepository.SettingsUpdate(_iHostingEnvironment.ContentRootPath + "/appsettings.Base.json", new { BaseSettings = model });
                    var data = _baseSettings.Value;
                    data.DocumentsMaxSize = model.DocumentsMaxSize;
                    data.ImagesType = model.ImagesType;
                    data.ImagesMaxSize = model.ImagesMaxSize;
                    data.DocumentsType = model.DocumentsType;
                    data.IsCapCha = model.IsCapCha;
                    data.CapChaDataSitekey = model.CapChaDataSitekey;
                    data.CapChaSecret = model.CapChaSecret;
                    data.GoogleMapKey = model.GoogleMapKey;
                    await AddLog(new LogModel { Action = $"Cập nhật cấu hình chung", ObjectId = 0, Type = LogType.Danger, ValueAfter = model, StrValueBefore= valueBeffo });
                    return new ResponseModel() { Output = 1, Message = "Cập nhật cấu hình thành công.", Type = ResponseTypeMessage.Success };
                }
                else
                {
                    return new ResponseModel() { Output = 2, Message = "Bạn chưa nhập đầy đủ thông tin, hoặc tên quyền này đã tồn tại.", Type = ResponseTypeMessage.Warning };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.GENERATE_ITEMS, "#Trong-[Log]{0}", ex);
            }
            return new ResponseModel() { Output = -1, Message = "Đã xảy ra lỗi, vui lòng F5 trình duyệt và thử lại.", Type = ResponseTypeMessage.Danger, Status = false };
        }
        [HttpGet]
        [AuthorizePermission("Email")]
        public IActionResult Email()
        {
            return View(_emailSettings.Value);
        }
        [AuthorizePermission("Index")]
        [HttpPost, ValidateAntiForgeryToken, ActionName("Email")]
        public async Task<ResponseModel> EmailPost(EmailSettings model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string valueBeffo = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                    _iFileRepository.SettingsUpdate(_iHostingEnvironment.ContentRootPath + "/appsettings.Email.json", new { EmailSettings = model });

                    var data = _emailSettings.Value;
                    data.Email = model.Email;
                    data.From = model.From;
                    data.Host = model.Host;
                    data.Password = model.Password;
                    data.Port = model.Port;

                    await AddLog(new LogModel { Action = $"Cập nhật cấu hình email.", ObjectId = 0, Type = LogType.Danger, ValueAfter = model, StrValueBefore = valueBeffo });
                    return new ResponseModel() { Output = 1, Message = "Cập nhật cấu hình thành công.", Type = ResponseTypeMessage.Success };
                }
                else
                {
                    return new ResponseModel() { Output = 2, Message = "Bạn chưa nhập đầy đủ thông tin, hoặc tên quyền này đã tồn tại", Type = ResponseTypeMessage.Warning };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.GENERATE_ITEMS, "#Trong-[Log]{0}", ex);
            }
            return new ResponseModel() { Output = -1, Message = "Đã xảy ra lỗi, vui lòng F5 trình duyệt và thử lại", Type = ResponseTypeMessage.Danger, Status = false };
        }
        [AuthorizePermission("Email")]
        [HttpPost, ValidateAntiForgeryToken, ActionName("SendEmail")]
        public async Task<ResponseModel> SendEmailPost(string email)
        {
            try
            {
                var output = await _iEmailSenderRepository.SendAsync(_emailSettings.Value,email,"Email test success.", "Email test success.");
                if(output)
                {
                    return new ResponseModel() { Output = 1, Message = "Gửi email thành công.", Type = ResponseTypeMessage.Success };
                }
                else
                {
                    return new ResponseModel() { Output = 1, Message = "Gửi email thất bại.", Type = ResponseTypeMessage.Warning };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.GENERATE_ITEMS, "#Trong-[Log]{0}", ex);
            }
            return new ResponseModel() { Output = -1, Message = "Đã xảy ra lỗi, vui lòng F5 trình duyệt và thử lại", Type = ResponseTypeMessage.Danger, Status = false };
        }
    }
}