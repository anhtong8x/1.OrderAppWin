using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TN.UI.Extensions;
using TN.Domain.Model;
using TN.Infrastructure.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TN.UI.Areas.User.Controllers
{
    [Area("User")]
    [AuthorizePermission]
    public class RoleManagerController : Base.Controllers.BaseController
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IRoleControllerRepository _iroleController;
        private readonly IRoleDetailRepository _iAspNetRoleDetailRepository;
        private readonly ILogger _Logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogRepository _iLogRepository;
        private readonly LogSettings _logSettings;

        private readonly IRoleRepository _iRoleRepository;
        public RoleManagerController(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            IRoleControllerRepository iRoleController,
            IRoleDetailRepository iAspNetRoleDetailRepository,
            ILogger<RoleManagerController> logger,
            ILogRepository iLogRepository,
            IOptions<LogSettings> logSettings,
            IRoleRepository iRoleRepository
            )
        {
            controllerName = "RoleManager";
            tableName = "User";
            _Logger = logger;
            _roleManager = roleManager;
            _iroleController = iRoleController;
            _iAspNetRoleDetailRepository = iAspNetRoleDetailRepository;
            _userManager = userManager;
            _iLogRepository = iLogRepository;
            _logSettings = logSettings.Value;
            _iRoleRepository = iRoleRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost, ActionName("Index")]
        public async Task<IActionResult> IndexPost(int? page, int? limit, string key,string ordertype="asc", string orderby="name")
        {
            if (page <= 0)
            {
                page = 1;
            }
            if (limit >= 100)
            {
                page = 100;
            }
            //Func<IQueryable<ApplicationRole>, IOrderedQueryable<ApplicationRole>> functionOrder = null;
            var list = _roleManager.Roles.Where(m => m.Name.Contains(key) || key == null).AsQueryable();
            if(orderby=="name" && ordertype=="asc")
            {
                list = list.OrderBy(m => m.Name);
            }
            else if (orderby == "name" && ordertype == "desc")
            {
                list = list.OrderByDescending(m => m.Name);
            }
            else if (orderby == "createddate" && ordertype == "asc")
            {
                list = list.OrderBy(m => m.Id);
            }
            else if (orderby == "createddate" && ordertype == "desc")
            {
                list = list.OrderByDescending(m => m.Id);
            }
            int TotalRows = list.Select(m => 1).Count();
            list = list.Skip(((page ?? 1) - 1) * (limit ?? 10)).Take(limit ?? 10).AsQueryable();
            return View("IndexAjax", new BaseSearchModel<List<ApplicationRole>>
            {
                TotalRows = TotalRows,
                Limit = limit ?? 10,
                Data = await list.ToListAsync(),
                Page = page ?? 1,
                ReturnUrl = Url.Action("Index", new { page, limit, key, ordertype, orderby })
            });
        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new RoleManagerModel
            {
                TypeSelectList = ListType()
            };
            return View(model);
        }
        private SelectList ListType()
        {
            return new SelectList(
                new List<SelectListItem> {
                    new SelectListItem() { Value = RoleManagerType.Default.ToString(), Text = RoleManagerType.Default.GetDisplayName() },
                    new SelectListItem() { Value = RoleManagerType.Center.ToString(), Text = RoleManagerType.Center.GetDisplayName() },
                    new SelectListItem() { Value = RoleManagerType.TransportCompany.ToString(), Text = RoleManagerType.TransportCompany.GetDisplayName() },
                    new SelectListItem() { Value = RoleManagerType.Parents.ToString(), Text = RoleManagerType.Parents.GetDisplayName() },
                    new SelectListItem() { Value = RoleManagerType.School.ToString(), Text = RoleManagerType.School.GetDisplayName() }
             }, "Value", "Text");
        }
        [HttpPost, ActionName("Create")]
        public async Task<ResponseModel> CreatePost(RoleManagerModel use)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!await _roleManager.RoleExistsAsync(use.Name))
                    {
                        var dlAdd = new ApplicationRole
                        {
                            Id = use.Id,
                            Name = use.Name,
                            Description = use.Description,
                            Type = use.Type,
                            ConcurrencyStamp = use.Id.ToString()
                        };
                        var create = await _roleManager.CreateAsync(dlAdd);
                        if (create.Succeeded)
                        {
                            // Log
                            await AddLog(new LogModel { Action = $"Thêm mới quyền '{dlAdd.Name}'", ObjectId = dlAdd.Id, Type = LogType.Normal, ValueAfter = dlAdd });
                            return new ResponseModel() { Output = 1, Message = "Tạo mới quyền thành công", Type = ResponseTypeMessage.Success,IsClosePopup=true };
                        }
                    }
                    else
                    {
                        return new ResponseModel() { Output = 2, Message = "Bạn chưa nhập đầy đủ thông tin, hoặc tên quyền này đã tồn tại", Type = ResponseTypeMessage.Warning };
                    }
                }
                return new ResponseModel() { Output = 0, Message = "Bạn chưa nhập đầy đủ thông tin, hoặc tên quyền này đã tồn tại", Type = ResponseTypeMessage.Warning };
            }
            catch (Exception ex)
            {
                _Logger.LogError(LoggingEvents.GENERATE_ITEMS, "#Trong-[Log]{0}", ex);
            }
            return new ResponseModel() { Output = -1, Message = "Đã xảy ra lỗi, vui lòng F5 trình duyệt và thử lại", Type = ResponseTypeMessage.Danger, Status = false };
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id, string returnurl)
        {
            var kt = await _roleManager.FindByIdAsync(id.ToString());
            if (kt == null)
            {
                return View("404");
            }
            return base.View(
                new RoleManagerModel
                {
                    Id = kt.Id,
                    Name = kt.Name,
                    Type = kt.Type,
                    Description = kt.Description,
                    TreeData = Functions.ToJson(await _iroleController.GetTreeRoleAsync(id)),
                    TypeSelectList = ListType()
                });
        }

        [HttpPost, ActionName("Edit"), ValidateAntiForgeryToken]
        public async Task<ResponseModel> EditPost(int id, RoleManagerModel use, string ids, bool isChange)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var kt = await _roleManager.FindByIdAsync(id.ToString());
                    if (kt != null)
                    {
                        //Model log
                        var dlLog = new LogModel{
                            ObjectId = id,
                            Action = $"Cập nhật quyền '{kt.Name}'",
                            ValueBefore = kt,
                            Type = LogType.Warning
                        };
                        kt.Name = use.Name;
                        kt.Description = use.Description;
                        kt.Type = use.Type;
                        var rs = await _roleManager.UpdateAsync(kt);
                        if (rs.Succeeded)
                        {
                            // Log
                            dlLog.ValueAfter = kt;
                            await AddLog(dlLog);

                            if (isChange)
                            {
                                if (ids == null)
                                {
                                    ids = "0";
                                }
                                List<int> listId = ids.Split(',').Where(m => m.StartsWith("A")).Select(m => int.Parse(m.Replace("A", ""))).ToList();
                                var data = await _iroleController.UpdateRoleAsync(id, listId);
                                // Log
                                await AddLog(new LogModel {
                                    ObjectId = id,
                                    Action = $"Cập nhật hành động trong quyền '{kt.Name}'",
                                    TableName = "RoleDetail",
                                    StrValueAfter = data.DataAfter,
                                    StrValueBefore = data.DataBefore,
                                    Type = LogType.Danger
                                });
                            }
                            return new ResponseModel() { Output = 1, Message = "Cập nhật quyền thành công", Type = ResponseTypeMessage.Success };
                        }
                        else
                        {
                            return new ResponseModel() { Output = 0, Message = "Bạn chưa nhập đầy đủ thông tin, vui lòng thử lại", Type = ResponseTypeMessage.Success };
                        }
                    }
                }
                return new ResponseModel() { Output = 0 };
            }
            catch (Exception ex)
            {
                _Logger.LogError(LoggingEvents.GENERATE_ITEMS, "#Trong-[Log]{0}", ex);
            }
            return new ResponseModel() { Output = -1, Message = "Đã xảy ra lỗi, vui lòng F5 trình duyệt và thử lại", Type = ResponseTypeMessage.Danger, Status = false };
        }
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<ResponseModel> DeletePost(int id)
        {
            try
            {
                if (await _iRoleRepository.IsUse(id))
                {
                    return new ResponseModel() { IsUse = true, Output = 3, Message = "Quyền này đang được sử dụng trong quản lý tài khoản quản trị, bỏ quyền liên quan đến bản ghi này rồi thực hiện lại.", Type = ResponseTypeMessage.Warning };
                }
                var kt = await _roleManager.FindByIdAsync(id.ToString());
                if (kt == null)
                {
                    return new ResponseModel() { Output = 0, Message = "Quyền này không tồn tại, vui lòng thử lại.", Type = ResponseTypeMessage.Warning };
                }
                _iAspNetRoleDetailRepository.DeleteWhere(m => m.RoleId == id);
                await _iAspNetRoleDetailRepository.Commit();
                var rs = await _roleManager.DeleteAsync(kt);
                if (!rs.Succeeded)
                {
                    return new ResponseModel() { Output = 2, Message = "Dữ liệu đang được sử dụng, xóa quyền này thất bại.", Type = ResponseTypeMessage.Warning };
                }
                else
                {
                    // Log
                    await AddLog(new LogModel { ObjectId = id, Action = $"Xóa quyền '{kt.Name}'", ValueBefore = kt, Type = LogType.Danger});
                }
                return new ResponseModel() { Output = 1, Message = "Xóa quyền thành công.", Type = ResponseTypeMessage.Success,IsClosePopup=true };
            }
            catch (Exception ex)
            {
                _Logger.LogError(LoggingEvents.GENERATE_ITEMS, "#Trong-[Log]{0}", ex);
            }
            return new ResponseModel() { Output = -1, Message = "Đã xảy ra lỗi, vui lòng F5 trình duyệt và thử lại.", Type = ResponseTypeMessage.Danger, Status = false };
        }
    }
}