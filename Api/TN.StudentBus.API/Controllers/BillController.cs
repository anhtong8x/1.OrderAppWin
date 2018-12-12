using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TN.API.Models.Data;
using TN.API.Services;
using TN.Domain.Model.Manager;

namespace TN.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : BaseController<Bill, IBillService>
    {
        public BillController(IBillService service)
          : base(service)
        {
        }

        [AllowAnonymous]
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
                return Ok(await Service.Search(page, limit, key));
            }
            catch (Exception)
            {
                return BadRequest(new ApiResponseData<object>() { Status = false, ErrorCode = ApiResponseErrorCode.ServerError });
            }
        }

        [AllowAnonymous]
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
                return BadRequest(new ApiResponseData<object>() { Status = false, ErrorCode = ApiResponseErrorCode.ServerError });
            }
        }

        [AllowAnonymous]
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

		[AllowAnonymous]
		[HttpGet("GetTable/{id}")]
		public async Task<IActionResult> GetTable(int id)
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
				return Ok(await Service.GetTable(id));
			}
			catch (Exception)
			{
				return BadRequest(new ApiResponseData<object>() { Status = false, ErrorCode = ApiResponseErrorCode.ServerError });
			}
		}

		[HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] BillModel obj)
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
        public async Task<IActionResult> Edit([FromBody] BillModel obj)
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