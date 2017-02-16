using LoginToka.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using static System.Net.WebRequestMethods;

namespace LoginToka.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Página de Inicio";
            User objUser = (User)TempData["objUser"];

            if (Session["id"] != null)
            {
                return View(objUser);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Tarjetas()
        {
            ViewBag.Title = "Página de Tarjetas";
            User objUser = (User)TempData["objUser"];

            if (Session["id"] != null)
            {
                return View(objUser);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Clientes()
        {
            ViewBag.Title = "Página de Clientes";
            User objUser = (User)TempData["objUser"];

            if (Session["id"] != null)
            {
                return View(objUser);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Usuarios()
        {
            ViewBag.Title = "Página de Usuarios";
            User objUser = (User)TempData["objUser"];

            if (Session["id"] != null)
            {
                return View(objUser);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Login()
        {
            ViewBag.Title = "Login";
            User objUser = (User)TempData["objUser"];
            if (Session["id"] != null)
            {
                return RedirectToAction("Index");                
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User objUser)
        {
            if (objUser.IsValidate())
            {
                FormsAuthentication.SetAuthCookie(objUser.usuario, true, "/");

                foreach (PropertyInfo p in objUser.GetType().GetProperties())
                {
                    if (p.Name != "password" && p.Name != "rememberMe")
                    {
                        Session[p.Name] = (string)p.GetValue(objUser, null);
                    }
                }
                Session.Timeout = 60;

                TempData["objUser"] = objUser;
                //return View(objUser);
                return this.RedirectToAction("Usuarios");
            }
            else
            {
                //ViewBag.Message = "Tu usuario y/o contraseña no es correcta.";
                this.ModelState.AddModelError(string.Empty, "Tu usuario y/o contraseña no es correcta.");
                return this.View(objUser);
            }
            //return RedirectToAction("Login"); ;
        }
                
        public ActionResult Logout()
        {            
            //FormsAuthentication.SetAuthCookie(objUser.usuario, true, "/");
            FormsAuthentication.SignOut();
            Session.Abandon();
            return this.RedirectToAction("Login");            
        }
    }
}
