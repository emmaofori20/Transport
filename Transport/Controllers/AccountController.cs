using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Utils;

namespace Transport.Controllers
{
    public class AccountController : Controller
    {
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            string url = "";

            try
            {

                string finalURL = "";

                var baseUrl = AppHttpContext.AppBaseUrl(HttpContext);

                var userClaim = User.Claims.Where(x => x.Type.ToLower() == "Name".ToLower()).FirstOrDefault();

                if (userClaim == null)
                {
                    return await Logout();
                }

                string username = userClaim.Value;
                url = User.Claims.Where(x => x.Type.ToLower() == "PathURL".ToLower()).FirstOrDefault().Value;

                finalURL = baseUrl + url;

                return Redirect(finalURL);
            }
            catch (Exception ex)
            {
                return await Logout();
            }
        }

        public async Task<IActionResult> Unauthorized()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            return SignOut("Cookies", "oidc");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


       
    }
}
