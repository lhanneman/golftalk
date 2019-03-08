using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using GolfTalk.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using SendGrid.Helpers.Mail;
using System.Linq;
using System;
using SendGrid;

namespace GolfTalk.Controllers
{
    public class AccountController : Controller
    {

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        

        public AccountController()
        {
            
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ActionResult Register()
        {
            return View("Register", new RegisterViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {

            // check if team is full:
            //var team = Context.Teams.FirstOrDefault(t => t.TeamID.Equals(model.TeamID));
            //if (team == null)
            //{
            //    ModelState.AddModelError("Invalid Team", "Invalid Team");
            //}

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new ApplicationUser { UserName = model.DisplayName, Email = model.Email };
            var result = await UserManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await SignInManager.SignInAsync(user, false, false);
                return RedirectToAction("Index", "Home");

                //var emailSendResult = await SendEmailConfirmation(user);
                //return RedirectToAction("confirmation", "account");
            }
            AddErrors(result);

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult Confirmation()
        {
            return View("ConfirmationSent");
        }

        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string token, string code)
        {
            if (token == null || code == null)
            {
                return View("Error");
            }
            // token is user ID:
            var result = await UserManager.ConfirmEmailAsync(token, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //// email confirmation check b/c apparently the SignInStatus.RequiresVerification status doesn't get hit:
            //var user = await UserManager.FindByNameAsync(model.Email);
            //if (user != null)
            //{
            //    if (!await UserManager.IsEmailConfirmedAsync(user.Id)) return View("EmailNotConfirmed");
            //}

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            switch (result)
            {
                case SignInStatus.Success:
                    return string.IsNullOrWhiteSpace(returnUrl)
                        ? RedirectToAction("Index", "Dashboard")
                        : RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }


        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private async Task<dynamic> SendEmailConfirmation(ApplicationUser user)
        {
            ////await SignInManager.SignInAsync(user, isPersistent:false, rememberBrowser:false);

            //// For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
            //// Send an email with this link
            var code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
            var callbackUrl = Url.Action("ConfirmEmail", "Account", new { token = user.Id, code = code }, protocol: Request.Url.Scheme);

            var apiKey = Environment.GetEnvironmentVariable("NAME_OF_THE_ENVIRONMENT_VARIABLE_FOR_YOUR_SENDGRID_KEY");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("admin@YOURSITE.com", "Example User");
            var subject = "Confirm your YOURSITE account";
            var to = new EmailAddress(user.Email, user.UserName);
            var plainTextContent = "Please confirm your account by clicking this link or pasting it into your browser: " + callbackUrl;
            var htmlContent = "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            return await client.SendEmailAsync(msg);
        }
    }
}