using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Newtonsoft.Json;
using TN.API.Code;
using TN.API.Models;

namespace TN.API.Controllers
{
    [Produces("application/json")]
    [Route("api/StudentTrip")]
    public class StudentTripController : Controller
    {
        private readonly BaseSettings _baseSettings;
        public  StudentTripController(IOptions<BaseSettings> baseSettings)
        {
            _baseSettings = baseSettings.Value;
        }
        [HttpGet("{lpn}/{date}/{groupId}")]
        public async Task<IActionResult> Get(string lpn,string date,int groupId = 31)
        {
            using (var httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject( new { lpn, date, groupId });
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
                var t = await httpClient.PostAsync(_baseSettings.ServiceStudentTripByDate, stringContent);
                var data = await t.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<ValueTripsModel>(data);
                var strb = new StringBuilder();
                foreach (var item in list.D.Result)
                {
                    strb.Append($"Xe: {item.VehiclePlate} - Thời gian bắt đầu: {Functions.UnixTimeStampToDateTime(item.RealTimeStart)} - Thời gian kết thúc: {Functions.UnixTimeStampToDateTime(item.RealTimeEnd)} /////////////");
                }
                return Content(strb.ToString());
            }
        }

    }
    
}
