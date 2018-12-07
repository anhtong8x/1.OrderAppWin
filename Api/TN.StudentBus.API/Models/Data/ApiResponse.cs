using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TN.API.Models.Data
{
    public enum ApiResponseErrorCode
    {
        [Display(Name = "")]
        Default,
        [Display(Name = "Chưa nhập đầy đủ thông tin")]
        FalseIsValid,
        [Display(Name = "Lỗi server")]
        ServerError
    }
    public class ApiResponseData<T> where T : class
    {
       
        public bool Status { get; set; } = true;
        public string Message { get; set; }
        public ApiResponseErrorCode ErrorCode { get; set; } = ApiResponseErrorCode.Default;
        public int Output { get; set; }
        public T Data { get; set; }
        public int TotalRecord { get; set; }
        public int Limit { get; set; }
        public int Page { get; set; }
    }
}
