using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using CIS4290_App.Models;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;

namespace CIS4290_App.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMapper _mapper; // injecting AutoMapper

        // user manager is from Microsoft.Asp.NetCore.Identity namespace
        // provides a set of helper methods to manage users
        private readonly UserManager<User> _userManager; // injecting UserManager

        // provides the api for user sign in with helper methods
        private readonly SignInManager<User> _signInManager;

        public AccountController(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        // GET request to return Register view to user
        public IActionResult Register()
        {
            return View();
        }

        // POST request to send user account info
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(NewUserRegistrationModel userModel)
        { 
            // if model is invalid, return the same view with the invalid model, else continue
            if (!ModelState.IsValid)
            {
                return View(userModel);
            }

            var user = _mapper.Map<User>(userModel);



            // CreateAsync method validates the password related errors
            var result = await _userManager.CreateAsync(user, userModel.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                return View(userModel);
            }

            // await _userManager.AddToRoleAsync(user);

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginModel userModel, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View(userModel);
            }

            var result = await _signInManager.PasswordSignInAsync(userModel.Email, userModel.Password, userModel.RememberMe, false);
            if (result.Succeeded)
            {
                return RedirectToLocal(returnUrl);
            }
            else
            {
                ModelState.AddModelError("", "Invalid User Name or Password");
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            else
                return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [HttpGet]
        [Authorize]
        // GET request to return Card view to user
        public IActionResult CardInformation()
        {
            return View();
        }
    }
}