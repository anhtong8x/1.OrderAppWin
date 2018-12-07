using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TN.API.Models
{
    public class ApiResponseModel
    {
        public object Data { get; set; }
        public bool Status { get; set; } = true;
    }
}
