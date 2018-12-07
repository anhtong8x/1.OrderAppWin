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
    public class DishController : BaseController<Dish, IDishSevice>
    {
        public DishController(IDishSevice service)
          : base(service)
        {
        }
		[HttpGet("Search")]
		public async Task<IActionResult> Search(int page, int limit, string key)
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
				return Ok(await Service.Search(page,limit,key));
			}
			catch (Exception)
			{
				return BadRequest(new ApiResponseData<object>() { Status = false, ErrorCode = ApiResponseErrorCode.ServerError });
			}
		}
		[HttpGet("Gets")]
        public async Task<IActionResult> Gets()
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
                return Ok(await Service.GetAll());
            }
            catch (Exception)
            {
                return BadRequest(new ApiResponseData<object>() { Status=false, ErrorCode =ApiResponseErrorCode.ServerError });
            }
        }
		[HttpGet("Get/{id}")]
		public async Task<IActionResult> Get(int id)
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
				return Ok(await Service.Get(id));
			}
			catch (Exception)
			{
				return BadRequest(new ApiResponseData<object>() { Status = false, ErrorCode = ApiResponseErrorCode.ServerError });
			}
		}

		[HttpPost("Create")]
		public async Task<IActionResult> Create([FromBody] DishModel obj)
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
				return Ok(await Service.Create(obj));
			}
			catch (Exception)
			{
				return BadRequest(new ApiResponseData<object>() { Status = false, ErrorCode = ApiResponseErrorCode.ServerError });
			}
		}
		[HttpPut("Edit")]
		public async Task<IActionResult> Edit([FromBody] DishModel obj)
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
				return Ok(await Service.Edit(obj));
			}
			catch (Exception)
			{
				return BadRequest(new ApiResponseData<object>() { Status = false, ErrorCode = ApiResponseErrorCode.ServerError });
			}
		}
		[HttpDelete("Delete/{id}")]
		public async Task<IActionResult> Delete(int id)
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
				return Ok(await Service.Delete(id));
			}
			catch (Exception)
			{
				return BadRequest(new ApiResponseData<object>() { Status = false, ErrorCode = ApiResponseErrorCode.ServerError });
			}
		}
	}
}