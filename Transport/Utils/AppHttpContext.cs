using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Transport.Utils
{
    public class AppHttpContext
    {
        public static string AppBaseUrl(HttpContext Current) => $"{Current.Request.Scheme}://{Current.Request.Host}{Current.Request.PathBase}";

    }
}
