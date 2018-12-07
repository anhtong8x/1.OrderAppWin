using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using TN.API.Services;
using TN.Domain.Model;
using TN.Domain.Seedwork;
using TN.Infrastructure.Interfaces;
using TN.UI.Extensions;

namespace TN.API.Controllers
{
    public abstract class BaseController<TModel, TService> : Controller
            where TService : IService<TModel>
    {
        protected readonly TService Service;
        protected BaseController(TService service)
        {
            Service = service;
        }
        public int UserId
        {
            get
            {
                return Convert.ToInt32(User.FindFirst(JwtRegisteredClaimNames.Sid)?.Value);
            }
        }
        //protected string controllerName = "";
        //protected string tableName = "";
        //public async Task AddLog(LogModel input)
        //{
        //    var iLogRepository = (ILogRepository)AppHttpContext.Current.RequestServices.GetService(typeof(ILogRepository));
        //    var baseSettings = (IOptions<LogSettings>)AppHttpContext.Current.RequestServices.GetService(typeof(IOptions<LogSettings>));
        //    if (baseSettings.Value.Is)
        //    {
        //        var data = new TN.Domain.Model.Log
        //        {
        //            ObjectId = input.ObjectId,
        //            Action = input.Action,
        //           // SystemUser = Newtonsoft.Json.JsonConvert.SerializeObject(new { DataUserInfo.UserId, DataUserInfo.DisplayName, DataUserInfo.UserName, DataUserInfo.Email }),
        //            Object = input.TableName ?? tableName,
        //            ObjectType = controllerName,
        //            SystemUserId = 0,
        //            Timestamp = DateTime.Now.Ticks,
        //            CreatedDate = DateTime.Now,
        //            Note = 0,
        //            ValueAfter = input.StrValueAfter,
        //            ValueBefore = input.StrValueBefore,
        //            Type = input.Type,
        //            CustomObject = input.CustomObject
        //        };
        //        if (baseSettings.Value.IsUseMongo)
        //        {
        //            // Code mongo
        //        }
        //        else
        //        {
        //            await iLogRepository.AddAsync(data);
        //            await iLogRepository.Commit();
        //        }
        //    }
        //}
    }
}
