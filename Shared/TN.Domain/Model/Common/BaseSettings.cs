using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TN.Domain.Model.Common;

namespace TN.Domain.Model
{
    public class BaseSettings
    {

        [Display(Name = "Định dạng ảnh")]
        [Required(ErrorMessage = "{0} không được để trống!")]
        [StringLength(100, ErrorMessage = "{0} từ {2} đến {1} ký tự!", MinimumLength = 0)]
        public string ImagesType { get; set; }

        [Display(Name = "Kích thước ảnh cho phép")]
        [Required(ErrorMessage = "{0} không được để trống!")]
        public double ImagesMaxSize { get; set; }

        [Display(Name = "Kích thước tài liệu cho phép")]
        [Required(ErrorMessage = "{0} không được để trống!")]
        public double DocumentsMaxSize { get; set; }

        [Display(Name = "Định dạng tài liệu cho phép")]
        [Required(ErrorMessage = "{0} không được để trống!")]
        public string DocumentsType { get; set; }
        public bool MultipleLanguage { get; set; }
        [Display(Name = "Trạng thái capcha")]
        public bool IsCapCha { get; set; }
        [Display(Name = "Capcha Data Site Key")]
        public string CapChaDataSitekey { get; set; }
        [Display(Name = "Capcha Secret")]
        public string CapChaSecret { get; set; }

        [Display(Name = "Google map Key")]
        public string GoogleMapKey { get; set; }

        public string EmailManager { get; set; }

    }
}
