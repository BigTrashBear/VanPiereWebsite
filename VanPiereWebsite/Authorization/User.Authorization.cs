using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VanPiereWebsite.Data;
using VanPiereWebsite.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace VanPiereWebsite.Authorization
{
    public class User
    {
        public class UserIsOwnerAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, UserModel>
        {
            UserManager<IdentityUser> _userManager;

            public UserIsOwnerAuthorizationHandler(UserManager<IdentityUser> userManager)
            {
                _userManager = userManager;
            }

            protected override Task HandleRequirementAsync(AuthorizationHandlerContext _context, OperationAuthorizationRequirement _requirement, UserModel _resource)
            {
                if (_context.User == null || _resource == null)
                {
                    return Task.CompletedTask;
                }

                
                if (_requirement.Name != Constants.CreateOperationName &&
                    _requirement.Name != Constants.ReadOperationName &&
                    _requirement.Name != Constants.UpdateOperationName &&
                    _requirement.Name != Constants.DeleteOperationName)
                {
                    return Task.CompletedTask;
                }

                if (_resource.UserID.ToString() == _userManager.GetUserId(_context.User))
                {
                    _context.Succeed(_requirement);
                }

                return Task.CompletedTask;
            }
        }
    }
}
