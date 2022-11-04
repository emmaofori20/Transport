using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Transport.Models.Data;
using Transport.Utils;

namespace Transport.Handlers
{
    public class CustomAuthorizationHandler  : AuthorizationHandler<CustomAuthorizationRequirement>
    {
        private readonly TransportDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CustomAuthorizationHandler(TransportDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
        }
        protected async override Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomAuthorizationRequirement requirement)
        {
            //check that the user is authenticated
            if (!context.User.Identity.IsAuthenticated)
            {
                context.Fail();
                return;
            }
            

            var nameClaim = context.User.Identities
                            .FirstOrDefault()
                            .Claims.Where(x => x.Type == ClaimsEnum.Name.ToString().ToLower())
                            .FirstOrDefault();

            if (nameClaim == null)
            {
                context.Fail();
                return;
            }

            string username = nameClaim.Value;

            var user = _dbContext.ApplicationUsers.Where(x => x.UserName == username).FirstOrDefault();

            if (user != null)
            {
                context.Succeed(requirement);
                return;
            }
            else
            {
                context.Fail();
                return;
            }

        }
    }
}
