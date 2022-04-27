using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace WebApplication1.abc
{
    public class SimpHandler : AuthorizationHandler<SReq>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SReq requirement)
        {
            var con = context.Resource as AuthorizationFilterContext;
            if (con == null)
            {
                return Task.CompletedTask;
            }
            return Task.CompletedTask;

            var s = 
                context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}
