using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TN.Infrastructure.Interfaces;
using TN.Domain.Model;
using TN.UI.Extensions;

namespace TN.UI.Areas.Base.Controllers
{
    public class BaseController : Controller
    {
        protected  string controllerName = "";
        protected  string tableName = "";
        public async  Task AddLog(LogModel input)
        {
            var iLogRepository = (ILogRepository)AppHttpContext.Current.RequestServices.GetService(typeof(ILogRepository));
            var baseSettings = (IOptions<LogSettings>)AppHttpContext.Current.RequestServices.GetService(typeof(IOptions<LogSettings>));
            if (baseSettings.Value.Is)
            {
                var data = new TN.Domain.Model.Log
                {
                    ObjectId = input.ObjectId,
                    Action = input.Action,
                    SystemUser = Newtonsoft.Json.JsonConvert.SerializeObject(new { DataUserInfo.UserId, DataUserInfo.DisplayName , DataUserInfo.UserName , DataUserInfo.Email }),
                    Object = input.TableName ?? tableName,
                    ObjectType = controllerName,
                    SystemUserId = DataUserInfo.UserId,
                    Timestamp = DateTime.Now.Ticks,
                    CreatedDate = DateTime.Now,
                    Note = 0,
                    ValueAfter = input.StrValueAfter,
                    ValueBefore = input.StrValueBefore,
                    Type = input.Type,
                    CustomObject = input.CustomObject
                };
                if (baseSettings.Value.IsUseMongo)
                {
                    // Code mongo
                }
                else
                {
                    await iLogRepository.AddAsync(data);
                    await iLogRepository.Commit();
                }
            }
        }
    }
}