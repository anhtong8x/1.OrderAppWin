using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TN.UI.Extensions;

namespace TN.UI.Areas.Base.Controllers
{
    [Area("Base")]
    public class FunctionsController : Controller
    {
        [HttpPost("Admin/ChangerMenuType/{i}")]
        public bool ChangeMenuType(int i)
        {
            //CookieExtensions.Remove("MenuType");
            CookieExtensions.Set("MenuType", i.ToString(), 1440);
            return true;
        }
    }
}