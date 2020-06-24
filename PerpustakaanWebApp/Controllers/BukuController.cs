using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels;
using DAL;
using System.Diagnostics;

namespace PerpustakaanWebApp.Controllers
{
    public class BukuController : Controller
    {
        IBukuRepository iBuku = new BukuRepository();
        public ActionResult Index()
        {
            IEnumerable<BukuVM> lstBuku = iBuku.getAll();
            return View(lstBuku);
        }

        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BukuVM model)
        {
            if (ModelState.IsValid)
            {
                if (iBuku.Add(model))
                {
                    return RedirectToAction("index");
                }
                else
                {
                    ModelState.AddModelError("", "Error pada saat input data");
                }
            }
            else
            {
                ModelState.AddModelError("", "invalid");
            }

            return View();
        }

        public ViewResult Update(String id)
        {
            BukuVM b = iBuku.getByID(id);
            return View("Create",b);
        }

        [HttpPost]
        public ActionResult Update(BukuVM model)
        {
            if (ModelState.IsValid)
            {
                if (iBuku.Update(model))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("","terjadi kesalahan saat update");
                }
            }
            else
            {
                ModelState.AddModelError("","inVAlid");
            }
            return View("Create",model);
        }

        public RedirectToRouteResult  Delete(String id)
        {
            Debug.WriteLine("cek controler=>" + iBuku.Delete(id));
            if (iBuku.Delete(id))
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