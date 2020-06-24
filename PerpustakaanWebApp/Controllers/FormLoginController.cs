using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels;
using DAL;
using System.Data.SqlClient;
using System.Diagnostics;

namespace PerpustakaanWebApp.Controllers
{
    public class FormLoginController : Controller
    {
        IformLogin iLogin = new FormLogin();
        // GET: FormLogin
        public ActionResult Index()
        {

            return View();
        }

        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create( Register_UserVM model)
        {
            if (ModelState.IsValid)
            {
                var getData = iLogin.Validation(model);
                Session["role"] = getData.Role;
                Session["user"] = getData.NamaUser;
                TempData["role"] = getData.Role;
                Debug.WriteLine("cek data->"+ Session["role"], Session["user"]);                
                if (getData  != null)
                {
                    if (getData.Role == "admin")
                    {                        
                        return RedirectToAction("index","Buku");
                    }
                    else
                    {
                        return RedirectToAction("index");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Username dan Password salah");
                }
            }
            else
            {
                ModelState.AddModelError("", "In Valid");
            }
            return View();
        }
    }
}