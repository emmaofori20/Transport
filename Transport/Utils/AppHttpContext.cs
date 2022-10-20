using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Transport.Utils
{
    public class AppHttpContext
    {
        private static IHttpContextAccessor _httpContextAccessor;

        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public static HttpContext Current => _httpContextAccessor.HttpContext;
        public static string AppBaseUrl => $"{Current.Request.Scheme}://{Current.Request.Host}{Current.Request.PathBase}";
    }
}
