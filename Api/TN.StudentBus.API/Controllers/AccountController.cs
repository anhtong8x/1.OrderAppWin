using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TN.API.Models.Command;
using TN.API.Models.Data;
using TN.API.Services;
using TN.Domain.Model;

namespace TN.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController<ApplicationUser, IUserManagerSevice>
    {
        public AccountController(IUserManagerSevice service)
          : base(service)
        {
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCommand model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Ok(new ApiResponseData<object>()
                    {
                        ErrorCode = ApiResponseErrorCode.FalseIsValid,
                        Message = Newtonsoft.Json.JsonConvert.SerializeObject(ModelState)
                    });
                }
                return Ok(await Service.LoginAsync(model));
            }
            catch (Exception)
            {
                return BadRequest(new ApiResponseData<object>() { Status=false, ErrorCode =ApiResponseErrorCode.ServerError });
            }
        }
    }
}