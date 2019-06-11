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
    public class BasePageModel : PageModel
    {
        protected IAuthorizationService AuthorizationService { get; }
        protected UserManager<IdentityUser> UserManager { get; }

        public BasePageModel(
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager) : base()
        { 
            UserManager = userManager;
            AuthorizationService = authorizationService;
        }
    }
    
}
