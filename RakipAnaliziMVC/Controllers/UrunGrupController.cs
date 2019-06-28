using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RakipAnaliziMVC.Controllers
{
    public class UrunGrupController : Controller
    {
        UnitOfWork _uw = new UnitOfWork();
        // GET: UrunGrup
        public ActionResult Index(int? sil)
        {
            if (sil.HasValue) //sil != null
                _uw.UrunGrubuRep.Sil(sil.Value);

            return View(_uw.UrunGrubuRep.HepsiniGetir());
        }
        [HttpGet]
        public ActionResult Yeni()
        {
            ViewBag.Gruplar = _uw.UrunGrubuRep.HepsiniGetir();
            return View();
        }

        [HttpPost]
        public ActionResult Yeni(UrunGrubu gelen)
        {
            if (ModelState.IsValid)
            {
                _uw.UrunGrubuRep.Ekle(gelen);
                return RedirectToAction("Index");
            }
            //Hem Get hem POST için ViewBag.Gruplar gönderilmeli
            //Çünkü eğer problem varsa POST içinde de View gösteriyoruz
            ViewBag.Gruplar = _uw.UrunGrubuRep.HepsiniGetir();
            return View(gelen);
        }

        [HttpGet]
        public ActionResult Duzenle(int id)
        {
            ViewBag.Gruplar = _uw.UrunGrubuRep.HepsiniGetir();
            return View(_uw.UrunGrubuRep.BirTaneGetir(id));
        }
        [HttpPost]
        public ActionResult Duzenle(UrunGrubu yeni)
        {
            if (ModelState.IsValid)
            {
                _uw.UrunGrubuRep.Guncelle(yeni);
                return RedirectToAction("Index");
            }
            ViewBag.Gruplar = _uw.UrunGrubuRep.HepsiniGetir();
            return View(yeni);
        }
    }
}