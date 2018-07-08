using mvcTwo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Web.Security;

namespace mvcTwo.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult DoLogin(UserDetails user)
        {
            if (ModelState.IsValid)
            {

                EmployeeBusinessLayer emBO = new EmployeeBusinessLayer();
                UserStatus status = emBO.GetUserValidity(user);
                bool isAdmin = false;
                if (status == UserStatus.AuthenticatedAdmin)
                {
                    isAdmin = true;
                }
                else if (status == UserStatus.AuthentucatedUser)
                {
                    isAdmin = false;
                }
                else
                {
                    ModelState.AddModelError("CredentialError", "Invalid Username or Password");
                    return View("Login");
                }

                FormsAuthentication.SetAuthCookie(user.UserName, false);
                Session["IsAdmin"] = isAdmin;
                return RedirectToAction("Index", "Employee");

            }
            else
            {
                //return RedirectToAction("Login");
                return View("Login");
            }
        }
    }
}