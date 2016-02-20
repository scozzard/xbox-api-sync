using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Scozzard.Model;
using Scozzard.Service;
using Scozzard.Web.ViewModels;

namespace Scozzard.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService userService;
        private readonly IXboxUserService xboxUserService;

        public AccountController(IUserService userService, IXboxUserService xboxUserService)
        {
            this.userService = userService;
            this.xboxUserService = xboxUserService;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var user = userService.GetUser(email, password);

            if (user != null)
            {
                // A correct username and password has been entered.
                var ident = new ClaimsIdentity(
                  new[] { 
                        // adding following 2 claim just for supporting default antiforgery provider
                        new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString()),
                        new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "ASP.NET Identity", "http://www.w3.org/2001/XMLSchema#string"),
                        new Claim(ClaimTypes.Name,user.Name),
                        new Claim("ProfileImageUrl", user.XboxUser.GameDisplayPicRaw),
                        new Claim("Gamerscore", user.XboxUser.Gamerscore.ToString()),
                        new Claim("GamerTag", user.XboxUser.GamerTag)
                    },
                    DefaultAuthenticationTypes.ApplicationCookie);

                HttpContext.GetOwinContext().Authentication.SignIn(new AuthenticationProperties { IsPersistent = true }, ident);
                return RedirectToAction("Index", "Feed");
            }

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult MyProfile()
        {
            var userId = int.Parse(User.Identity.GetUserId());

            var user = userService.GetUser(userId);

            return View(user);
        }


        [HttpPost]
        public ActionResult Register(RegisterUserViewModel model)
        {
            // MVC check to make sure all inputed values adhear to the view model's validation attributes.
            if (ModelState.IsValid)
            {
                // check for the user in the repository, if it is there assign that user.
                var user = xboxUserService.GetXboxUser(model.Gamertag);

                // TODO: If it is not in our DB, make a call to xboxapi and is found insert into into our DB and assign the new user.
                // if (user == null) { // check api and assign to user }

                // Good, the gamertag is actually valid - now lets use it to setup a user account.
                if (user != null)
                {
                    var newUser = new User()
                    {
                        Name = model.Name,
                        Email = model.Email,
                        Password = model.Password,
                        XboxUser = user,
                        XboxUserID = user.XboxUserID
                    };

                    userService.CreateUser(newUser);
                    userService.SaveUser();

                    var ident = new ClaimsIdentity(
                      new[] { 
                        // adding following 2 claim just for supporting default antiforgery provider
                        new Claim(ClaimTypes.NameIdentifier,  model.Name),
                        new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "ASP.NET Identity", "http://www.w3.org/2001/XMLSchema#string"),
                        new Claim(ClaimTypes.Name, model.Name)
                        },
                        DefaultAuthenticationTypes.ApplicationCookie);

                    HttpContext.GetOwinContext().Authentication.SignIn(new AuthenticationProperties { IsPersistent = true }, ident);
                    return RedirectToAction("Index", "Feed");
                }
                else
                {
                    // If no user was found in neither our repository or on the xboxpi, then it probably doesn't exist so alert the user.
                    ModelState.AddModelError("Gamertag", "Gamertag not found.");
                }
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult LogOff()
        {
            HttpContext.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }
    }
}