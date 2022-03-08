using HelloPam.BLL;
using HelloPam.WebApp.Models;
using System;
using System.Web.Mvc;
using System.Web.Security;

namespace HelloPam.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserBLO userBLO;
        public AccountController()
        {
            this.userBLO = new UserBLO();
        }
        // GET: Account
        public ActionResult Index(string returnUrl = null)
        {
            var model = new LoginModel { ReturnUrl = returnUrl };
            return View(model);
        }
        public ActionResult Login()
        {
            
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            try
            {
                var user = this.userBLO.AuthenticateUser(model.Username, model.Password);
                FormsAuthentication.SetAuthCookie(user.Username, model.RememberMe);
                if (!string.IsNullOrEmpty(model.ReturnUrl))
                {
                    return Redirect(model.ReturnUrl);
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Error found username or password is incorrect or your account is disabled please try again !");
            }
            return View("Index", model);
        }
        public ActionResult Logout(LoginModel model)
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}