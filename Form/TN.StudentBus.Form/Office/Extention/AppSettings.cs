using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TN.StudentBus.Office.Extention
{
    public class AppSettings
    {
        public static string ResetPasswordUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["ResetPasswordUrl"];
            }
        }
        public static string ServerApi
        {
            get
            {
                return ConfigurationManager.AppSettings["ServerApi"];
            }
        }
        public static string LoginUrl
        {
            get
            {
                return ServerApi + ConfigurationManager.AppSettings["LoginUrl"];
            }
        }
        public static string SchoolUrl
        {
            get
            {
                return ServerApi + ConfigurationManager.AppSettings["SchoolUrl"];
            }
        }
        public static string ClassOfSchoollUrl
        {
            get
            {
                return ServerApi + ConfigurationManager.AppSettings["ClassOfSchoollUrl"];
            }
        }
        public static string StudentUrl
        {
            get
            {
                return ServerApi + ConfigurationManager.AppSettings["StudentUrl"];
            }
        }
        public static string IsLoginUrl
        {
            get
            {
                return ServerApi + ConfigurationManager.AppSettings["IsLoginUrl"];
            }
        }
        public static string StudentFingerPrints
        {
            get
            {
                return ServerApi + ConfigurationManager.AppSettings["StudentFingerPrints"];
            }
        }
        public static string StudentByIdUrl
        {
            get
            {
                return ServerApi + ConfigurationManager.AppSettings["StudentByIdUrl"];
            }
        }
        public static string StudentUpdate
        {
            get
            {
                return ServerApi + ConfigurationManager.AppSettings["StudentUpdate"];
            }
        }
        public static string StudentByFinger
        {
            get
            {
                return ServerApi + ConfigurationManager.AppSettings["StudentByFinger"];
            }
        }
        
        public static string StudentCreate
        {
            get
            {
                return ServerApi + ConfigurationManager.AppSettings["StudentCreate"];
            }
        }
        public static string StudentDelete
        {
            get
            {
                return ServerApi + ConfigurationManager.AppSettings["StudentDelete"];
            }
        }
        public static UserInfoModel UserInfo
        {
            get
            {
                string data = ConfigurationManager.AppSettings["UserInfo"];
                if(data==null)
                {
                    return new UserInfoModel();
                }
                UpdateUserInfo(data);
                return Newtonsoft.Json.JsonConvert.DeserializeObject<UserInfoModel>(data);
            }
        }
        public static string StudentUpdateFinger
        {
            get
            {
                return ServerApi + ConfigurationManager.AppSettings["StudentUpdateFinger"];
            }
        }


        public static void RemoveToken()
        {
            Functions.UpdateSetting("UserInfo", "");
        }
        public static void Reload(UserInfoModel use)
        {
            
        }
        public static void UpdateUserInfo(string value)
        {
            Functions.UpdateSetting("UserInfo", value);
        }
    }
}
