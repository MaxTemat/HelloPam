using HelloPam.BLL;
using HelloPam.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloPam.WebApp.Controllers
{
    public class UserController : Controller
    {
        private UserBLO userBLO;
        public UserController()
        {
            this.userBLO = new UserBLO();
        }
        // GET: User
        public ActionResult Index()
        {
            var users = this.userBLO.FindUser(new BO.User());
            var userModels = users?.Select
                (
                    x =>
                    new UserModel
                    (
                       x.Id,
                       x.Username,
                       x.Fullname,
                       x.Password,
                       x.Password,
                       (DateTime)x.CreatedAt,
                       x.Status == true ? "Enable" : "Disable",
                       x.Profile.ToString(),
                       Url.Action("Picture", "User", new { x.Id })
                    )
                ).ToList();
            return View(userModels);
        }
        public FileContentResult Picture(int id)
        {
            var user = this.userBLO.GetUser(id);
            if (user != null && user.Picture != null)
            {
                return File(user.Picture, "image/png");
            }
            return null;
        }
        public ActionResult Edit(int id)
        {
            var user = this.userBLO.GetUser(id);
            if (user == null)
                return HttpNotFound();
            UserModel usermodel = new UserModel
                (
                    user.Id,
                    user.Username,
                    user.Fullname,
                    user.Password,
                    user.Password,
                    (DateTime)user.CreatedAt,
                    user.Status == true ? "Enable" : "Disable",
                    user.Profile.ToString(),
                    Url.Action("Picture", "User", new { user.Id }),
                    Enum.GetValues(typeof(BO.ProfileOptions)).Cast<int>().Select
                    (
                        x =>
                        new SelectListItem
                        {
                            Value = x.ToString(),
                            Text = ((BO.ProfileOptions)x).ToString(),
                            Selected = (int)user.Profile == x
                        }
                    ).ToList()
                );
            return View(usermodel);
        }
    }
}