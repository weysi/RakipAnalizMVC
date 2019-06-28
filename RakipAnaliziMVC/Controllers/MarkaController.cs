using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RakipAnaliziMVC.Controllers
{
    public class MarkaController : Controller
    {
        UnitOfWork _uw = new UnitOfWork();

        // GET: Marka
        public ActionResult Index(int? sil)
        {
            if (sil.HasValue)
                _uw.MarkaRep.Sil(sil.Value);

            return View(_uw.MarkaRep.HepsiniGetir());
        }
        [HttpGet]
        public ActionResult Yeni()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Yeni(Marka m)
        {
            if (ModelState.IsValid)
            {
                _uw.MarkaRep.Ekle(m);
                return RedirectToAction("Index");
            }
            return View(m);
        }
        [HttpGet]
        //Marka/Duzenle/5
        //{controller}/{action}/{id}
        public ActionResult Duzenle(int id)
        {
            return View(_uw.MarkaRep.BirTaneGetir(id));
        }
        [HttpPost]
        public ActionResult Duzenle(Marka m)
        {
            if (ModelState.IsValid)
            {
                _uw.MarkaRep.Guncelle(m);
                return RedirectToAction("Index");
            }
            return View(m);
        }
    }
}