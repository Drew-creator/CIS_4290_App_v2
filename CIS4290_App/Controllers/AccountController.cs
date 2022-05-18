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
using System.Net.Http;
using System.Linq;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.JsonPatch;
using System.Text;

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

            var result = await _signInManager.PasswordSignInAsync(
                userModel.Email, userModel.Password, userModel.RememberMe, false);
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

        [HttpPost]
        public async Task<string> PatchUser(ApiData User_Raw)
        {

            Debug.WriteLine("FDHKDJDHSKJDHSKJDHSD " + User_Raw.FirstName);

            using (var client = new HttpClient())
            {
               
                try
                {
                    //converts the UserModel to JsonPatchDocument<UserModel>
                    List <ApiData> body = new List<ApiData>();
                    body.Add(User_Raw);
                    Debug.WriteLine("FDHKDJDHSKJDHSKJDHSD " + body);

                    //Converts the JsonPatchDocument<UserModel> to Json
                    var serializedJsonDocument = JsonConvert.SerializeObject(body);
                    Debug.WriteLine("FDHKDJDHSKJDHSKJDHSD " + serializedJsonDocument);
                    var stringUser = new StringContent(serializedJsonDocument, UnicodeEncoding.UTF8, "application/json-patch+json");

                    //
                    var request = new HttpRequestMessage(new HttpMethod("PATCH"), "https://localhost:7029/api/AspNetUsers/08cd6de5-9eb7-4901-b93f-14874b1cdafb");
                    request.Content = stringUser;

                    //response stores the Post result to later ensure that it has been successful
                    var response = await client.SendAsync(request);
                    response.EnsureSuccessStatusCode();

                    string HttpResponse = await response.Content.ReadAsStringAsync();
                    return HttpResponse;
                }
                catch (HttpRequestException error)
                {
                    return null;
                }
            }
            
        }

    }


}