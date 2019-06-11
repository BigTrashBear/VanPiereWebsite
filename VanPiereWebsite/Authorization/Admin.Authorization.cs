using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VanPiereWebsite.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;


namespace VanPiereWebsite.Authorization
{
    public class Admin
    {
        public class ContactAdministratorsAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, UserModel>
        {
            protected override Task HandleRequirementAsync(
                                                  AuthorizationHandlerContext context,
                                        OperationAuthorizationRequirement requirement,
                                         UserModel resource)
            {
                if (context.User == null)
                {
                    return Task.CompletedTask;
                }

                if (context.User.IsInRole(Constants.ContactAdministratorsRole))
                {
                    context.Succeed(requirement);
                }

                return Task.CompletedTask;
            }
        }
    }
}
