using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TN.API.Code;
using TN.API.Controllers;
using TN.API.Models;

namespace TN.API.Services
{
    public class StudentTripMongoDB
    {
        private  MongoClient _client;
        public StudentTripMongoDB(string serverName)
        {
            _client = new MongoClient(serverName);
        }
        public  async Task<List<StudentTripModel>> FindByDate(string lpn, DateTime date,int GroupId = 31)
        {
            string dataBaseName = $"trip_{date.ToString("MMyyyy")}";
            var collection = _client.GetDatabase(dataBaseName).GetCollection<StudentTripModel>("StudentTrip");
            var list = await collection.FindAsync(x =>x.VehiclePlate== lpn && x.GroupId == GroupId && x.RealTimeStart >= TIT.Core.Utilities.DateTimeToUnixTimestamp(date.Date) && x.RealTimeStart < TIT.Core.Utilities.DateTimeToUnixTimestamp(date.Date.AddDays(1)));
            return await list.ToListAsync();
        }
    }
}
