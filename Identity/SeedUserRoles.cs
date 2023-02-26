using CadastroMvc.Identity.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace CadastroMvc.Identity
{
    public class SeedUserRoles : ISeedUserRoles
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedUserRoles(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public void SeedUsers()
        {
            if (_userManager.FindByEmailAsync("user@gmail.com").Result == null)
            {
                var user = new ApplicationUser();
                user.Email = "user@gmail.com";
                user.UserName = "user@gmail.com";
                user.NormalizedEmail = "USER@GMAIL.COM";
                user.NormalizedUserName = "USER@GMAIL.COM";
                user.LockoutEnabled = false;
                user.EmailConfirmed = true;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(user, "@Linkedin23k+").Result;
                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "User").Wait();
                }
            }

            if (_userManager.FindByEmailAsync("admin@gmail.com").Result == null)
            {
                var admin = new ApplicationUser();
                admin.Email = "admin@gmail.com";
                admin.UserName = "admin@gmail.com";
                admin.NormalizedEmail = "ADMIN@GMAIL.COM";
                admin.NormalizedUserName = "ADMIN@GMAIL.COM";
                admin.LockoutEnabled = false;
                admin.EmailConfirmed = true;
                admin.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(admin, "@Linkedin23k+").Result;
                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(admin, "Admin");
                }
            }
        }


        public void SeedRoles()
        {
            if (!_roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                role.NormalizedName = "ADMIN";
                IdentityResult result = _roleManager.CreateAsync(role).Result;
            }

            if (!_roleManager.RoleExistsAsync("User").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "User";
                role.NormalizedName = "USER";
                IdentityResult result = _roleManager.CreateAsync(role).Result;
            }
        }
    }
}
