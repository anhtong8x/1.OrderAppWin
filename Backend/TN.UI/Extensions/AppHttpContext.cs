using Microsoft.AspNetCore.Http;
using System;
namespace TN.UI.Extensions
{
    public static class AppHttpContext
    {
        static IServiceProvider _services = null;
        public static IServiceProvider Services
        {
            get => _services;
            set
            {
                if (_services != null)
                    throw new Exception("Can't set once a value has already been set.");
                _services = value;
            }
        }
        public static HttpContext Current
        {
            get
            {
                IHttpContextAccessor httpContextAccessor =
                    _services.GetService(typeof(IHttpContextAccessor)) as IHttpContextAccessor;
                return httpContextAccessor?.HttpContext;
            }
        }
    }
}
