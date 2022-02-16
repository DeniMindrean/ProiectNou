using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MindreanDenisaProject
{
    public class Utility
    {
        public SignInManager<IdentityUser> _signInManager;
        public UserManager<IdentityUser> _userManager;

        public Utility(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public bool CheckIfCurrentUserIsAdmin()
        {
            
            return false;
        }



    }
}
