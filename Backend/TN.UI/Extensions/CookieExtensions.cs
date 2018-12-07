
namespace TN.UI.Extensions
{
    using System;
    using Microsoft.AspNetCore.Http;
    public static class CookieExtensions
    {
        public static void Set(string key, string value, int? expireTime)
        {
            CookieOptions option = new CookieOptions();
            if (expireTime.HasValue)
                option.Expires = DateTime.Now.AddMinutes(expireTime.Value);
            else
                option.Expires = DateTime.Now.AddDays(1);
            option.HttpOnly = true;
           AppHttpContext.Current.Response.Cookies.Append(key, value, option);
        }
        public static void Remove(string key)
        {
            AppHttpContext.Current.Response.Cookies.Delete(key);
        }
        public static string Get(string key)
        {
           return AppHttpContext.Current.Request.Cookies[key];
        }
    }
}
