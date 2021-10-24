using ePizzaHut.Entity;
using ePizzaHut.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ePizzaHut.Services.Implementations
{
    public class AuthentationService : IAuthentationService
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly SignInManager<User> _signInManager;
        protected readonly UserManager<User> _userManager;
        protected readonly RoleManager<User> _roleManager;

        public AuthentationService(SignInManager<User> signInManager, 
            UserManager<User> userManager, 
            RoleManager<User> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public User AuthenticateUser(string userName, string password)
        {
            var result = _signInManager.PasswordSignInAsync(
                userName, password, false, lockoutOnFailure: false).Result;
            if (result.Succeeded)
            {
                var user = _userManager.FindByNameAsync(userName).Result;
                var roles = _userManager.GetRolesAsync(user).Result;
                user.Roles = roles.ToArray();
                return user;
            }
            return null;
        }

        public bool CreateUser(User user, string password)
        {
            var result = _userManager.CreateAsync(user, password).Result;
            if (result.Succeeded)
            {
                //Admin/User
                var role = "Admin";
                var res = _userManager.AddToRoleAsync(user, role).Result;
                if (res.Succeeded)
                {
                    return true;
                }
            }
            return false;
        }

        public User GetUser(string userName)
        {
            return _userManager.FindByNameAsync(userName).Result;
        }

        public async Task<bool> SignOut()
        {
            try
            {
                await _signInManager.SignOutAsync();
                return true;
            }
            catch (Exception)
            {
                return false;   
            }
        }
    }
}
