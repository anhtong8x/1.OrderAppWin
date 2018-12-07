using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TN.API.Models
{
    public class BaseSettings
    {
        public int MTimesMiss { get; set; }
        public string MongoDBServer { get; set; }
        public string ServiceStudentTripAllByDate { get; set; }
        public string ServiceStudentTripByDate { get; set; }
    }
}
