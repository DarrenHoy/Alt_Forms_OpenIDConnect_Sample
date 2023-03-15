using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Alt_Forms_OpenIDConnect_Sample.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        public ActionResult OpenIdLogin(string redirectUrl)
        {
            if (!HttpContext.GetOwinContext().Authentication.User.Identity.IsAuthenticated)
            {
                HttpContext
                    .GetOwinContext()
                    .Authentication
                    .Challenge(new AuthenticationProperties { 
                        RedirectUri = redirectUrl 
                    }, CookieAuthenticationDefaults.AuthenticationType);
            }
            
            return View();

        }

        [HttpPost]
        public ActionResult StandardLogin(string username, string password, string returnUrl)
        {
            if (password == "password123")
            {
                ClaimsIdentity user = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationType);
                user.AddClaim(new Claim(ClaimTypes.NameIdentifier, username));
                HttpContext.GetOwinContext().Authentication.SignIn(user);
            }

            return Redirect(returnUrl);
        }

        public ActionResult SignOut()
        {
            HttpContext.GetOwinContext().Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
            return RedirectToAction("Protected", "Home");
        }
    }


}