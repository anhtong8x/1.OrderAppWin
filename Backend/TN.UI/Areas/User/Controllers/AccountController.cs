using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.Net.Http.Headers;
using System;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using TN.UI.Controllers;
using TN.Domain.Model;
using TN.Infrastructure.Interfaces;
using static TN.UI.Extensions.DataUserInfo;
namespace TN.UI.Areas.User.Controllers
{
    [Area("User"),Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
    
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSenderRepository _iEmailSenderRepository;
        private readonly ILogger _logger;
        private readonly IUserRepository _iAspNetUsers;
        private readonly IOptions<BaseSettings> _baseSettings;
        private readonly IOptions<EmailSettings> _emailSettings;
        private readonly IFileRepository _iFileRepository;
        private readonly IUserRepository _iUserRepository;

        private readonly IHostingEnvironment _iHostingEnvironment;
        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSenderRepository iEmailSenderRepository,
            IOptions<BaseSettings> baseSettings,
            ILogger<AccountController> logger, 
            IUserRepository iAspNetUsers,
            IHostingEnvironment iHostingEnvironment,
            IOptions<EmailSettings> emailSettings,
            IFileRepository iFileRepository,
            IUserRepository iUserRepository
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _iEmailSenderRepository = iEmailSenderRepository;
            _logger = logger;
            _iAspNetUsers = iAspNetUsers;
            _baseSettings = baseSettings;
            _iHostingEnvironment = iHostingEnvironment;
            _emailSettings = emailSettings;
            _iFileRepository = iFileRepository;
            _iUserRepository = iUserRepository;
        }

        #region [Login]
        [HttpGet,Route("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnurl = null)
        {
            //System.Drawing.Color;
        
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            ViewData["returnurl"] = returnurl;
            return View();
        }

        [HttpPost, Route("Login")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnurl = null)
        {
            ViewData["returnurl"] = returnurl;
			if (ModelState.IsValid)
			{
				// Kiểm tra xem tài khoản bị khóa hay không
				var kt = await _iAspNetUsers.SearchOneAsync(m => m.UserName == model.Username);
				if (kt == null)
				{
					ModelState.AddModelError("UserName", "Tài khoản hoặc mật khẩu không tồn tại");
					// Tài khoản hoặc mật khẩu không tồn tại
					return View(model);
				}
				if (kt.IsLock && kt.IsSuperAdmin == false)
				{
					ModelState.AddModelError("UserName", "Tài khoản này đã bị khóa, vui lòng liên hệ quản trị để biết thêm chi tiết");
					// Tài khoản bị khóa vì lý do nào đó
					return View(model);
				}
				// This doesn't count login failures towards account lockout
				// To enable password failures to trigger account lockout, set lockoutOnFailure: true
				var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, lockoutOnFailure: false);
				if (result.Succeeded)
				{
					// cập nhật trạng thái relogin
					kt.IsReLogin = false;
					_iAspNetUsers.Update(kt);
					await _iAspNetUsers.Commit();
					return RedirectToLocal(returnurl);
				}
				else
				{
					ModelState.AddModelError("UserName", "Tài khoản hoặc mật khẩu không tồn tại");
					await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
				}
                if (result.IsLockedOut)
                {
                    return RedirectToAction(nameof(LockoutAsync));
                }
                else
                {
                    return View(model);
                }
            }
            return View(model);
        }
        #endregion

        #region [LogOut]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> LockoutAsync()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new { area = "" });
            //return View();
        }

        [HttpPost,Route("Logout")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home",new {area="" });
        }
        #endregion

        #region [Reset pass]
        [AllowAnonymous]
        public IActionResult ResetPassword(string code = null,int userId=0)
        {
            if (code == null)
            {
                throw new ApplicationException("A code must be supplied for password reset.");
            }
            var model = new ResetPasswordViewModel { Code = code ,Id=userId};
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(int userId, ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                return RedirectToAction(nameof(ResetPasswordConfirmation));
            }
            var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
            if (result.Succeeded)
            {
                //Yêu cầu đăng nhập lại
                user.IsReLogin = true;
                await _userManager.UpdateAsync(user);
                return RedirectToAction(nameof(ResetPasswordConfirmation));
            }
            ModelState.AddModelError("Password", "Mã xác nhận không chính xác hoặc đã quá hạn, vui lòng thử lại.");
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }
        #endregion

        #region [ForgotPassword]
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            var a = _baseSettings.Value;
            var b = _emailSettings.Value;
            return View(new ForgotPasswordViewModel());
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                {
                    return RedirectToAction(nameof(ForgotPasswordConfirmation));
                }
                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = Url.ResetPasswordCallbackLink(user.Id.ToString(), code, Request.Scheme);
                await Task.Run(() => SendEmail(model.Email, callbackUrl)).ConfigureAwait(false);
                return RedirectToAction(nameof(ForgotPasswordConfirmation));
            }
            return View(model);
        }
        private async void SendEmail(string Email, string callbackUrl) => await _iEmailSenderRepository.SendEmailAsync(_emailSettings.Value, Email, "[" + _emailSettings.Value.From + "]Phục hồi mật khẩu", $"Để thay đổi mật khẩu vui lòng nhấp vào <a href='{callbackUrl}'>đây</a>");
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }
        #endregion

        #region Helpers
        private IActionResult RedirectToLocal(string returnurl)
        {
            if(returnurl==null)
            {
                return Redirect("/Admin");
            }
            if (Url.IsLocalUrl(returnurl))
            {
                return Redirect(returnurl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home",new { area =""});
            }
        }

        #endregion

        #region [Profile]
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var dl = await _userManager.FindByIdAsync(UserId.ToString());
            if (dl == null)
            {
                return View("404");
            }
            var model = new UserProfileModel
            {
                Id = dl.Id,
                Avatar = dl.Avatar,
                DisplayName = dl.DisplayName,
                Note = dl.Note,
                PhoneNumber = dl.PhoneNumber,
                UserName = dl.UserName,
                Email = dl.Email
            };
            return View(model);
        }
        [HttpPost, ActionName("Profile")]
        public async Task<ResponseModel> ProfilePost(UserProfileModel use)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dl = await _userManager.FindByIdAsync(UserId.ToString());
                    if (dl == null)
                    {
                        return new ResponseModel() { Output = 0, Message = "Vui lòng đăng nhập lại và thử lại", Type = ResponseTypeMessage.Warning };
                    }
                    // Kiểm tra email đã có người sử dụng chưa
                    var ktEmail = await _iUserRepository.AnyAsync(x => x.Email == use.Email && x.Id != dl.Id);
                    if (ktEmail)
                    {
                        return new ResponseModel() { Output = 2, Message = "Email này đã có người sử dụng, vui lòng chọn email khác và thử lại", Type = ResponseTypeMessage.Warning };
                    }
                    dl.DisplayName = use.DisplayName;
                    dl.PhoneNumber = use.PhoneNumber;
                    dl.Note = use.Note;
                    dl.Email = use.Email;
                    var kt = await _userManager.UpdateAsync(dl);
                    if (kt.Succeeded)
                    {
                        await _signInManager.RefreshSignInAsync(dl);
                        return new ResponseModel() { Output = 1, Message = "Cập nhật thông tin tài khoản thành công", Type = ResponseTypeMessage.Success };
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
                        return new ResponseModel() { Output = 2, Message = "Ảnh đại diện tải lên không đúng định dạng", Type = ResponseTypeMessage.Warning, Data = "" };
                    }
                    else if (_baseSettings.Value.ImagesMaxSize < file.Length)
                    {
                        return new ResponseModel() { Output = 3, Message = "Ảnh đại diện tải lên vượt quá kích thước cho phép", Type = ResponseTypeMessage.Warning, Data = "" };
                    }
                    else
                    {
                        var newFilename = Guid.NewGuid();
                        string fileName = ContentDispositionHeaderValue
                        .Parse(file.ContentDisposition)
                        .FileName.Value
                        .Trim('"');
                        fileName = $"{pathAvatar}{newFilename}.jpeg";
                        pathServer = $"{pathServer}{newFilename}.jpeg";
                       // await _iFileRepository.ResizeImageAsync(file, fileName, System.Drawing.Imaging.ImageFormat.Jpeg, zipWidth);
                     
                        // Update data
                        var ktUser = await _iAspNetUsers.SearchOneAsync(m => m.Id == id);
                        if (ktUser == null)
                        {
                            return new ResponseModel() { Output = 4, Message = "Vui lòng đăng nhập và thử lại", Type = ResponseTypeMessage.Success };
                        }
                        // Xóa file cũ
                        if(ktUser.Avatar!=null)
                        {
                            string oldFile = $"{_iHostingEnvironment.WebRootPath}{ktUser.Avatar}";
                            if (System.IO.File.Exists(oldFile))
                            {
                                System.IO.File.Delete(oldFile);
                            }
                        }
                        //Cập nhật
                        ktUser.Avatar = pathServer;
                        await _iAspNetUsers.Commit();

                        await _signInManager.RefreshSignInAsync(ktUser);

                        return new ResponseModel() { Output = 1, Message = "Thay đổi ảnh đại diện thành công", Type = ResponseTypeMessage.Success, Data = pathServer };
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.GENERATE_ITEMS, "#Trong-[Log]{0}", ex);
            }
            return new ResponseModel() { Output = -1, Message = "Đã xảy ra lỗi, vui lòng F5 trình duyệt và thử lại", Type = ResponseTypeMessage.Danger, Status = false };
        }
        #endregion

        #region [ChangePassword]
        [HttpGet]
        public async Task<IActionResult> ChangePassword()
        {
            var dl = await _userManager.FindByIdAsync(UserId.ToString());
            if (dl == null)
            {
                return View("404");
            }
            var model = new ChangePasswordViewModel
            {
            };
            return View(model);
        }
        [HttpPost, ActionName("ChangePassword"),ValidateAntiForgeryToken]
        public async Task<ResponseModel> ChangePasswordPost(ChangePasswordViewModel use)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return new ResponseModel() { Output = -2, Message = "Bạn chưa nhập đầy đủ thông tin", Type = ResponseTypeMessage.Warning };
                }
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return new ResponseModel() { Output = 2, Message = "Vui lòng đăng nhập và thử lại", Type = ResponseTypeMessage.Success };
                }
                var changePasswordResult = await _userManager.ChangePasswordAsync(user, use.OldPassword, use.NewPassword);
                if (changePasswordResult.Succeeded)
                {
                    await _signInManager.RefreshSignInAsync(user);
                    return new ResponseModel() { Output = 1, Message = "Thay đổi mật khẩu thành công", Type = ResponseTypeMessage.Success };
                }
                else
                {
                    return new ResponseModel() { Output =3, Message = "Thay đổi mật khẩu thất bại do sai mật khẩu cũ, vui lòng nhập lại", Type = ResponseTypeMessage.Warning };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.GENERATE_ITEMS, "#Trong-[Log]{0}", ex);
            }
            return new ResponseModel() { Output = -1, Message = "Đã xảy ra lỗi, vui lòng F5 trình duyệt và thử lại", Type = ResponseTypeMessage.Danger, Status = false };
        }
        #endregion
    }
}