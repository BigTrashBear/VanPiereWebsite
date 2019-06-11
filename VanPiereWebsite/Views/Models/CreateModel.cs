using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VanPiereWebsite.Models.Users;
using VanPiereWebsite.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace VanPiereWebsite.Views.Models
{
    public class CreateModel : BasePageModel
    {
        public CreateModel(
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager)
            : base(authorizationService, userManager)
        {
        }
    }
}
