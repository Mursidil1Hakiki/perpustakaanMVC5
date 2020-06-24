using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using ViewModels;

namespace PerpustakaanWebApp.Controllers
{
    public class SewaController : Controller
    {
        iSewa sewa = new SewaRepository();
        IBukuRepository buku = new BukuRepository();
        // GET: Sewa
        public ActionResult Index()
        {
            var data = sewa.GetAll();
            return View(data);
            //var role = Session["role"].ToString();
            //var name = Session["user"].ToString();
            //Debug.WriteLine("cek session role sewa=>" + role);
            //if (role == "admin")
            //{
            //    var data = sewa.GetAll();
            //    return View(data);
            //}
            //else
            //{
            //    var data = sewa.GetByName(name);
            //    return View(data);
            //}

        }

        public PartialViewResult LoadDataBuku(string id)
        {
            var dataBuku = buku.getByID(id);
            return PartialView(dataBuku);
        }

        public ViewResult Create()
        {
            var data = buku.getAll();
            ViewBag.ID_Buku = new SelectList(data, "ID_Buku", "JudulBuku");
            return View();
        }

        [HttpPost]
        public ActionResult Create(sewaVM model)
        {

            sewaVM data = new sewaVM();
            data.ID_User = Session[]
            Debug.WriteLine("cek hargasewa==>" + model.ID_Buku);
            
            return RedirectToAction("Index");
        }
    }
}