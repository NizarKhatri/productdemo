using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Recipe.NetCore.Infrastructure
{
    public class ApplicationContext
    {
        protected ApplicationContext() { }

        public static string GetHttpContextSessionItem(IHttpContextAccessor httpContextManager, string keyName)
        {
            if (httpContextManager == null ||
                httpContextManager.HttpContext == null ||
                httpContextManager.HttpContext.User == null ||
                httpContextManager.HttpContext.User.Claims == null ||
                !httpContextManager.HttpContext.User.Claims.Any())
            {
                return null;
            }

            return httpContextManager.HttpContext.User.FindFirst(keyName).Value;
        }
    }
}
