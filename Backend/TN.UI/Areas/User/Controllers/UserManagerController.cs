﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using TN.Domain.Model;
using TN.Infrastructure.Interfaces;
using System.Linq;
using System.IO;
using System.Net.Http.Headers;
using TN.UI.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using static TN.UI.Extensions.DataUserInfo;

namespace TN.UI.Areas.User.Controllers
{
    [Area("User")]
 
    public class UserManagerController : Base.Controllers.BaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IHostingEnvironment _iHostingEnvironment;
        private readonly ILogger _logger;
        private readonly LogSettings _logSettings;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IOptions<BaseSettings> _baseSettings;
        private readonly IUserRepository _aspNetUsers;
        private readonly ILogRepository _iLogRepository;
        private readonly IFileRepository _iFileRepository;
        private readonly IEmailSenderRepository _iEmailSenderRepository;
        private readonly IOptions<EmailSettings> _emailSettings;

        public UserManagerController(
            ILogger<UserManagerController> logger,
            IHostingEnvironment hostingEnvironment,
            IOptions<BaseSettings> baseSettings,
            UserManager<ApplicationUser> userManager,
            IUserRepository aspNetUsers,
            RoleManager<ApplicationRole> roleManager,
            IHostingEnvironment iHostingEnvironment,
            ILogRepository iLogRepository,
            IOptions<LogSettings> logSettings,
            IFileRepository iFileRepository,
            IEmailSenderRepository iEmailSenderRepository,
            IOptions<EmailSettings> emailSettings
        )
        {
            controllerName = "UserManager";
            tableName = "User";
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
            _baseSettings = baseSettings;
            _userManager = userManager;
            _aspNetUsers = aspNetUsers;
            _roleManager = roleManager;
            _iHostingEnvironment = iHostingEnvironment;
            _iLogRepository = iLogRepository;
            _logSettings = logSettings.Value;
            _iFileRepository = iFileRepository;
            _iEmailSenderRepository = iEmailSenderRepository;
            _emailSettings = emailSettings;
        }
        #region [Index]
        [AuthorizePermission]
        public IActionResult Index()
        {
            ViewData["RoleSelectListItem"] = new SelectList(
                _roleManager.Roles.ToList(), "Id", "Name");
            ViewData["LockSelectListItem"] = new SelectList(
                new List<SelectListItem>() {
                    new SelectListItem {Text="Tất cả",Value="" },
                    new SelectListItem {Text="Tài khoản bị khóa",Value="true" },
                    new SelectListItem {Text="Tài khoản bị khóa",Value="false" }
                }
                , "Value", "Text");
            return View();
        }
        [HttpPost, ActionName("Index")]
        [AuthorizePermission]
        public async Task<IActionResult> IndexPost(int? page, int? limit, string key, int? roleId, bool? isLock, int? isRole, string ordertype = "asc", string orderby = "username")
        {
            page = page < 0 ? 1 : page;
            limit = (limit > 100 || limit < 10) ? 10 : limit;
           
            var data = await _aspNetUsers.SearchPagedList(
                page ?? 1,
                limit ?? 10,
                roleId,
                m => (m.UserName.Contains(key) || key == null || m.DisplayName.Contains(key) || m.PhoneNumber.Contains(key))
                && (m.IsLock == isLock || isLock == null) && m.IsSuperAdmin == false,
                OrderByExtention(ordertype, orderby));
                data.ReturnUrl =  Url.Action("Index", 
                    new {
                        page,
                        limit,
                        key,
                        roleId,
                        isLock,
                        isRole,
                        ordertype,
                        orderby
                    });
            return View("IndexAjax", data);
        }
        private Func<IQueryable<ApplicationUser>, IOrderedQueryable<ApplicationUser>> OrderByExtention(string ordertype, string orderby)
        {
            Func<IQueryable<ApplicationUser>, IOrderedQueryable<ApplicationUser>> functionOrder = null;
            switch (orderby)
            {
                case "displayname":
                    functionOrder = ordertype == "asc" ? EntityExtention<ApplicationUser>.OrderBy(m => m.OrderBy(x => x.DisplayName)) : EntityExtention<ApplicationUser>.OrderBy(m => m.OrderByDescending(x => x.DisplayName));
                    break;
                case "createddate":
                    functionOrder = ordertype == "asc" ? EntityExtention<ApplicationUser>.OrderBy(m => m.OrderBy(x => x.CreatedDate)): EntityExtention<ApplicationUser>.OrderBy(m => m.OrderByDescending(x => x.CreatedDate));
                    break;
                default:
                    functionOrder = ordertype == "asc" ? EntityExtention<ApplicationUser>.OrderBy(m => m.OrderBy(x => x.UserName)) : EntityExtention<ApplicationUser>.OrderBy(m => m.OrderByDescending(x => x.UserName));
                    break;
            }
            return functionOrder;
        }
        #endregion

        #region [Create]
        [HttpGet]
        [AuthorizePermission]
        public IActionResult Create()
        {
            var model = new ManagerRegisterModel
            {
                RoleSelectListItem = new MultiSelectList(_roleManager.Roles.ToList(), "Id", "Name")
            };
            return View(model);
        }
        [HttpPost, ActionName("Create")]
        [AuthorizePermission]
        public async Task<ResponseModel> CreatePost(ManagerRegisterModel use, string returnurl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var ktUsername = await _userManager.FindByNameAsync(use.Username);
                    if (ktUsername != null)
                    {
                        return new ResponseModel() { Output = 2, Message = "Tài khoản này đã có người sử dụng, vui lòng thử lại", Type = ResponseTypeMessage.Warning };
                    }
                    var ktEmail = await _userManager.FindByEmailAsync(use.Email);
                    if (ktEmail != null)
                    {
                        return new ResponseModel() { Output = 3, Message = "Email này đã có người sử dụng, vui lòng thử lại", Type = ResponseTypeMessage.Warning };
                    }
                    var user = new ApplicationUser {
                        UserName = use.Username,
                        Email =use.Email,
                        EmailConfirmed =true,
                        DisplayName = use.DisplayName,
                        PhoneNumber = use.PhoneNumber,
                        Note = use.Note,
                        IsLock=use.IsLock,
                        NoteLock = use.NoteLock,
                        CreatedDate =DateTime.Now,
                        CreatedUserId = UserId,
                        RoleTransportCompany = use.TransportCompanyIds != null ? string.Join(",", use.TransportCompanyIds) : "",
                        RoleSchool = use.SchoolIds != null ? string.Join(",", use.SchoolIds) : "",
                        RoleParents = use.StudentCode
                };
                    var result = await _userManager.CreateAsync(user, "Matkhau@168168");
                    if (result.Succeeded)
                    {
                        // Gửi email đến để đổi tài khoản
                        var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                        var callbackUrl = Url.ResetPasswordCallbackLink(user.Id.ToString(), code, Request.Scheme);
                        await Task.Run(() => SendEmail(user.Email, callbackUrl)).ConfigureAwait(false);
                        // Log
                        await AddLog(new LogModel { Action = $"Thêm mới tài khoản quản trị '{user.UserName}'", ObjectId = user.Id, Type = LogType.Normal, ValueAfter = user });
                        var listRole = new List<int>();
                        // Cập nhật quyền tài khoản
                        if (use.RoleId != null)
                        {
                            listRole = new List<int>() { use.RoleId??0 };
                        }
                        var output = await _aspNetUsers.UpdateRolesAsync(user.Id, listRole);
                        return new ResponseModel() { Output = 1, Message = "Tạo mới tài khoản quản trị thành công", Type = ResponseTypeMessage.Success, IsClosePopup=true };
                    }
                }
                return new ResponseModel() { Output = 0, Message = "Bạn chưa nhập đầy đủ thông tin", Type = ResponseTypeMessage.Warning };
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.GENERATE_ITEMS, "#Trong-[Log]{0}", ex);
            }
            return new ResponseModel() { Output = -1 };
        }
        #endregion

        #region [Edit]
        [HttpGet]
        [AuthorizePermission]
        public async Task<IActionResult> Edit(string id)
        {
            var dl = await _userManager.FindByIdAsync(id);
            if (dl == null || dl.IsSuperAdmin)
            {
                return View("404");
            }
            var model = new UserEditManagerModel
            {
                Id = dl.Id,
                Avatar = dl.Avatar,
                DisplayName = dl.DisplayName,
                IsLock = dl.IsLock,
                Note = dl.Note,
                NoteLock = dl.NoteLock,
                PhoneNumber = dl.PhoneNumber,
                Username = dl.UserName,
                Email = dl.Email
            };
            model.RoleSelectListItem = new SelectList(_roleManager.Roles.ToList(), "Id", "Name");
            model.RoleId = (await _aspNetUsers.GetRolesAsync(dl.Id)).FirstOrDefault();
            return View(model);
        }
        [AuthorizePermission]
        [HttpPost, ActionName("Edit")]
        public async Task<ResponseModel> EditPost(UserEditManagerModel use, int id,bool isChange, string returnurl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dl = await _userManager.FindByIdAsync(id.ToString());
                    if (dl == null)
                    {
                        return new ResponseModel() { Output = 0, Message = "Dữ liệu không tồn tại, vui lòng thử lại", Type = ResponseTypeMessage.Warning };
                    }
                    // Kiểm tra email đã có người sử dụng chưa
                    var ktEmail = await _aspNetUsers.AnyAsync(x => x.Email == use.Email && x.Id != id);
                    if (ktEmail)
                    {
                        return new ResponseModel() { Output = 3, Message = "Email này đã có người sử dụng, vui lòng chọn email khác và thử lại", Type = ResponseTypeMessage.Warning };
                    }
                    //Model log
                    var dlLog = new LogModel
                    {
                        ObjectId = id,
                        Action = $"Cập nhật tài khoản quản trị '{dl.UserName}'",
                        ValueBefore = dl
                    };
                    
                    dl.DisplayName = use.DisplayName;
                    dl.PhoneNumber = use.PhoneNumber;
                    dl.Note = use.Note;
                    dl.IsLock = use.IsLock;
                    dl.IsReLogin = true;
                    dl.Email = use.Email;

                    dl.RoleTransportCompany = use.TransportCompanyIds!=null? string.Join(",", use.TransportCompanyIds):"";
                    dl.RoleSchool = use.SchoolIds!=null?string.Join(",", use.SchoolIds):"";
                    dl.RoleParents = use.StudentCode;

                    if (dl.IsLock == false)
                    {
                        dl.NoteLock = "";
                    }
                    else
                    {
                        dl.NoteLock = use.NoteLock;
                    }
                    var kt = await _userManager.UpdateAsync(dl);
                    if (kt.Succeeded)
                    {
                        // Log
                        dlLog.ValueAfter = dl;
                        await AddLog(dlLog);
                        // Update quyền cho tài khoản
                        if(isChange)
                        {
                            var listRole = new List<int>();
                            if (use.RoleId != null)
                            {
                                listRole = new List<int> { use.RoleId??0 };
                            }
                            var output=  await _aspNetUsers.UpdateRolesAsync(id, listRole);
                            // Log
                            await AddLog(new LogModel
                            {
                                ObjectId = id,
                                Action = $"Cập nhật quyền cho tài khoản '{dl.UserName}'",
                                TableName = "UserRole",
                                StrValueAfter = output.DataAfter,
                                StrValueBefore = output.DataBefore,
                                Type = LogType.Danger
                            });
                        }
                        return new ResponseModel() { Output = 1, Message = "Cập nhật tài khoản quản trị thành công", Type = ResponseTypeMessage.Success, IsClosePopup = true };
                    }
                }
                return new ResponseModel() { Output = -2, Message = "Bạn chưa nhập đầy đủ thông tin", Type = ResponseTypeMessage.Warning };
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.GENERATE_ITEMS, "#Trong-[Log]{0}", ex);
            }
            return new ResponseModel() { Output = -1, Message = "Đã xảy ra lỗi, vui lòng F5 trình duyệt và thử lại", Type = ResponseTypeMessage.Danger, Status = false };
        }
        #endregion

        #region [UploadAvatar]
        [HttpPost, ActionName("UploadAvatar"), ValidateAntiForgeryToken]
        [AuthorizePermission("Edit")]
        public async Task<ResponseModel> UploadAvatarPost(int id)
        {
            try
            {
                string[] allowedExtensions = _baseSettings.Value.ImagesType.Split(',');
                string pathAvatar = $"{_iHostingEnvironment.WebRootPath}/Data/Avatar/";
                string pathServer = "/Data/Avatar/";
                if (!Directory.Exists(pathAvatar))
                {
                    Directory.CreateDirectory(pathAvatar);
                }
                var files = Request.Form.Files;
                foreach (var file in files)
                {
                    if (!allowedExtensions.Contains(Path.GetExtension(file.FileName)))
                    {
                        return new ResponseModel() { Output = 2, Message = "Ảnh đại diện tải lên không đúng định dạng.", Type = ResponseTypeMessage.Warning, Data = "" };
                    }
                    else if (_baseSettings.Value.ImagesMaxSize < file.Length)
                    {
                        return new ResponseModel() { Output = 3, Message = "Ảnh đại diện tải lên vượt quá kích thước cho phép.", Type = ResponseTypeMessage.Warning, Data = "" };
                    }
                    else
                    {
                        var newFilename = Guid.NewGuid();

                        string fileName = ContentDispositionHeaderValue
                        .Parse(file.ContentDisposition)
                        .FileName
                        .Trim('"');
                        fileName = $"{pathAvatar}{newFilename}.jpeg";
                        pathServer = $"{pathServer}{newFilename}.jpeg";
                       // await _iFileRepository.ResizeImageAsync(file, fileName, System.Drawing.Imaging.ImageFormat.Jpeg, zipWidth);
                        // Update data
                        var ktUser = await _aspNetUsers.SearchOneAsync(m => m.Id == id);
                        if (ktUser == null)
                        {
                            return new ResponseModel() { Output = 4, Message = "Dữ liệu không tồn tại vui lòng thử lại.", Type = ResponseTypeMessage.Success };
                        }
                        // Xóa file cũ
                        if (ktUser.Avatar != null)
                        {
                            string oldFile = $"{_iHostingEnvironment.WebRootPath}{ktUser.Avatar}";
                            if (System.IO.File.Exists(oldFile))
                            {
                                System.IO.File.Delete(oldFile);
                            }
                        }
                        ktUser.Avatar = pathServer;
                        ktUser.IsReLogin = true;
                        await _aspNetUsers.Commit();
                        //Log 
                        await AddLog(new LogModel
                        {
                            ObjectId = id,
                            Action = $"Thay đổi ảnh đại diện '{ktUser.UserName}'",
                            Type = LogType.Normal,
                            Status = LogStatus.Default
                        });
                        return new ResponseModel() { Output = 1, Message = "Thay đổi ảnh đại diện thành công.", Type = ResponseTypeMessage.Success, Data = pathServer, IsClosePopup = false };
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.GENERATE_ITEMS, "#Trong-[Log]{0}", ex);
            }
            return new ResponseModel() { Output = -1, Message = "Đã xảy ra lỗi, vui lòng F5 trình duyệt và thử lại.", Type = ResponseTypeMessage.Danger, Status = false };
        }
        #endregion

        #region [Delete]
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        [AuthorizePermission]
        public async Task<ResponseModel> DeletePost(int id)
        {
            try
            {
                var kt = await _userManager.FindByIdAsync(id.ToString());
                if (kt == null)
                {
                    return new ResponseModel() { Output = 0, Message = "Tài khoản này không tồn tại, vui lòng thử lại.", Type = ResponseTypeMessage.Warning };
                }
                // xóa bảng chi tiết quyền
                _aspNetUsers.DeleteRoles(id);
                await _aspNetUsers.Commit();
                var rs = await _userManager.DeleteAsync(kt);
                if (!rs.Succeeded)
                {
                    return new ResponseModel() { IsUse = true, Output = 2, Message = "Dữ liệu đang được sử dụng, xóa tài khoản thất bại.", Type = ResponseTypeMessage.Warning };
                }
                //Log
                await AddLog(new LogModel
                {
                    ObjectId = id,
                    Action = $"Xóa tài khoản quản trị '{kt.UserName}'",
                    ValueBefore = kt,
                    Type = LogType.Danger
                });
                return new ResponseModel() { Output = 1, Message = "Xóa tài khoản thành công, click vào đóng để quay lại trang danh sách.", Type = ResponseTypeMessage.Success,IsClosePopup=true };
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.GENERATE_ITEMS, "#Trong-[Log]{0}", ex);
            }
            return new ResponseModel() { Output = -1, Message = "Đã xảy ra lỗi, vui lòng F5 trình duyệt và thử lại.", Type = ResponseTypeMessage.Danger, Status = false };
        }
        #endregion

        #region [Get Type role]
        [HttpGet]
        [AuthorizePermission("Edit")]
        public async Task<IActionResult> TypeRole(int? id=0,int? userId=0)
        {
            var dl = await _userManager.FindByIdAsync(userId.ToString());
            var role =  _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            if(role==null)
            {
                return Content("");
            }
            var model = new RoleTypeModel {
                Id = role.Id,
                Type = role.Type
            };
            return View(model);
        }
        #endregion

        #region [Change password]
        [HttpPost, ActionName("ChangePassword"), ValidateAntiForgeryToken]
        [AuthorizePermission("Edit")]
        public async Task<ResponseModel> ChangePasswordPost(int id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id.ToString());
                if (user == null)
                {
                    return new ResponseModel() { Output = 1, Message = "Tài khoản này không tồn tại vui lòng thực hiện lại.", Type = ResponseTypeMessage.Warning };
                }
                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = Url.ResetPasswordCallbackLink(user.Id.ToString(), code, Request.Scheme);
                await Task.Run(() => SendEmail(user.Email, callbackUrl)).ConfigureAwait(false);
                return new ResponseModel() { Output = 1, Message = "Gửi email yêu cầu đổi mật khẩu thành công, vui lòng kiểm tra hòm thư email đã đăng ký để thay đổi mật khẩu.", Type = ResponseTypeMessage.Success };
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.GENERATE_ITEMS, "#Trong-[Log]{0}", ex);
            }
            return new ResponseModel() { Output = 2, Message = "Lỗi hệ thống.", Type = ResponseTypeMessage.Error };
        }
        #endregion

        [NonAction]
        private async void SendEmail(string Email, string callbackUrl) => await _iEmailSenderRepository.SendEmailAsync(_emailSettings.Value, Email, "[" + _emailSettings.Value.From + "] Phục hồi mật khẩu", $"Để thay đổi mật khẩu vui lòng nhấp vào <a href='{callbackUrl}'>đây</a>");
    }
}