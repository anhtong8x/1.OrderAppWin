using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemFramework
{
    public class SystemMessage
    {
        #region "Common"
        public const string CaptionWarningMessage = "Cảnh báo";
        public const string CaptionConfirmMessage = "Xác nhận";
        public const string CaptionInfomationMessage = "Thông báo";
        #endregion

        #region "LogName"
        public const string DeleteLog = "Xóa bản ghi {0} _ bảng {1} ";
        public const string UpdateLog = " Cập nhật bản ghi {0} _ bảng {1}";
        public const string Login = "{0} đăng nhập {1} lúc {2}";
        public const string Logout = "{0} đăng xuất {1} lúc {2}";
        #endregion

        #region "LoginForm"
        public const string WarningUsername = "Tên đăng nhập không để rỗng.";
        public const string WarningPassword = "Mật khẩu không để rỗng.";
        public const string WarningErrorUsername = "Thông tin đăng nhập không chính xác.";
        public const string WarningErrorPassword = "Mật khẩu đăng nhập không đúng.";
        public const string WarningConnection = "Lỗi kết nối.";

        public const string LogLoginSuccess = "Đăng nhập thành công";
        public const string LogUpdateSuccess = "Cập nhật mật khẩu thành công";

        #endregion

        public const string StatusInfo = "Xin chào: {0}";
    }
}
