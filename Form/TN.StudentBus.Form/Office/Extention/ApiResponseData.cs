using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TN.StudentBus.Office.Extention
{
    public class ApiResponseData<T> where T : class
    {

        public bool Status { get; set; } = true;
        public string Message { get; set; }
        public int ErrorCode { get; set; }
        public int Output { get; set; }
        public T Data { get; set; }
        public int TotalRecord { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }
    }
    public class ApiResponseData
    {

        public bool Status { get; set; } = true;
        public string Message { get; set; }
        public int ErrorCode { get; set; }
        public int Output { get; set; }
        public int Data { get; set; }
        public int TotalRecord { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }
    }
}
