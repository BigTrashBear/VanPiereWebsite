using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VanPiereWebsite.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace VanPiereWebsite.Authorization
{
    public class UserManager
    {
        public class ContactManagerAuthorizationHandler :
        AuthorizationHandler<OperationAuthorizationRequirement, UserModel>
        {
            protected override Task
                HandleRequirementAsync(AuthorizationHandlerContext context,
                                       OperationAuthorizationRequirement requirement,
                                       UserModel resource)
            {
                if (context.User == null || resource == null)
                {
                    return Task.CompletedTask;
                }

                if (requirement.Name != Constants.ApproveOperationName &&
                    requirement.Name != Constants.RejectOperationName)
                {
                    return Task.CompletedTask;
                }

                if (context.User.IsInRole(Constants.ContactManagersRole))
                {
                    context.Succeed(requirement);
                }

                return Task.CompletedTask;
            }
        }
    }
}
