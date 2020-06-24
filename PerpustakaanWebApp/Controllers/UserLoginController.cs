using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using ViewModels;

namespace PerpustakaanWebApp.Controllers
{
    public class UserLoginController : Controller
    {
        IUserLoginRepository iUserLogin = new UserLoginRepository();
        // GET: UserLogin
        public ActionResult Index()
        {
            IEnumerable<Register_UserVM> iru = iUserLogin.GetAll();
            return View(iru);
        }

        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Register_UserVM model)
        {
            if (ModelState.IsValid)
            {
                if (iUserLogin.Add(model))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("","gagal disimpan");
                }
            }
            else
            {
                ModelState.AddModelError("","invalid");
            }
            return View();
        }

        public ViewResult Edit(int id)
        {
            Register_UserVM ruvm = iUserLogin.GetById(id);
            return View("Create", ruvm);
        }

        [HttpPost]
        public ActionResult Edit(Register_UserVM model)
        {
            if (ModelState.IsValid)
            {
                if (iUserLogin.Update(model))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "proses edit gagal");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid");
            }
            return View("Create",model);
        }

        public RedirectToRouteResult Delete(int id)
        {
            if (iUserLogin.Delete(id))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}