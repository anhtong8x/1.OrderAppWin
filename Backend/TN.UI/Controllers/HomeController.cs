using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TN.Domain.Model;
using TN.Domain.Model.Common;
using TN.Infrastructure;
using TN.Infrastructure.Interfaces;
using TN.UI.Extensions;

namespace TN.UI.Controllers
{
    [AuthorizePermission]
    public class HomeController : Controller
    {
        public HomeController()
        {
        }
        [Route("Admin")]
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}