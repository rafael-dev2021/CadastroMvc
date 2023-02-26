﻿using CadastroMvc.Identity.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace CadastroMvc.Identity
{
    public class AuthenticateService : IAuthenticate
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthenticateService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> Authenticate(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, false, lockoutOnFailure: false);
            return result.Succeeded;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<bool> Register(string email, string password)
        {
            var userApp = new ApplicationUser()
            {
                UserName = email,
                Email = email
            };

            var result = await _userManager.CreateAsync(userApp, password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(userApp, isPersistent: false);
            }
            return result.Succeeded;
        }
    }
}
