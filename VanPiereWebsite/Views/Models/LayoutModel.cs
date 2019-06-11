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
    public class LayoutModel : BasePageModel
    {
        public LayoutModel(

            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager)
            : base(authorizationService, userManager)
        {
        }

        public IList<UserModel> Users { get; set; }

        public async Task OnGetAsync()
        {
            var contacts = from c in Context.Contact
                           select c;

            var isAuthorized = User.IsInRole(Authorization.Constants.ContactManagersRole) ||
                               User.IsInRole(Authorization.Constants.ContactAdministratorsRole);

            var currentUserId = UserManager.GetUserId(User);

            // Only approved contacts are shown UNLESS you're authorized to see them
            // or you are the owner.
            if (!isAuthorized)
            {
                contacts = contacts.Where(c => c.Status == ContactStatus.Approved
                                            || c.OwnerID == currentUserId);
            }

            Contact = await contacts.ToListAsync();
        }
    }
}
