using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RakipAnaliziMVC.Controllers
{
    public class UrunController : Controller
    {
        //{controller}/{action}/{id}
        // http://localhost:111/Urun/
        //http://localhost:111/Urun/Index?sil=5

        UnitOfWork _uw = new UnitOfWork();

        public ActionResult Index(int? sil)
        {
            if (sil.HasValue)
                _uw.UrunRep.Sil(sil.Value);

            return View(_uw.UrunRep.HepsiniGetir());
        }
        [HttpGet]
        public ActionResult Yeni()
        {
            ViewBag.Markalar = _uw.MarkaRep.HepsiniGetir();
            ViewBag.UrunGruplar = _uw.UrunGrubuRep.HepsiniGetir();
            return View();
        }
        //model binding: uygun parametreler gelirse modele cevirme
        [HttpPost]
        public ActionResult Yeni(Urun yeniurun, int MarkaId, int[] gruplar)
        {
            if (ModelState.IsValid)
            {
                _uw.UrunRep.GruplaEkle(yeniurun, MarkaId, gruplar);
                return RedirectToAction("Index","Urun");
                //"action","controller"
            }
            ViewBag.Markalar = _uw.MarkaRep.HepsiniGetir();
            ViewBag.UrunGruplar = _uw.UrunGrubuRep.HepsiniGetir();
            ViewBag.SecilenGruplar = gruplar;
            return View(yeniurun);
        }
        [HttpGet]
        public ActionResult Duzenle(int id)
        {
            ViewBag.Markalar = _uw.MarkaRep.HepsiniGetir();
            ViewBag.UrunGruplar = _uw.UrunGrubuRep.HepsiniGetir();
            return View(_uw.UrunRep.BirTaneGetir(id));
        }
        [HttpPost]
        public ActionResult Duzenle(Urun urun, int MarkaId, int[] gruplar)
        {
            if (ModelState.IsValid)
            {
                urun.Marka = _uw.MarkaRep.BirTaneGetir(MarkaId);
                urun.UrunGruplari = _uw.UrunGrubuRep
                    .Ara(x=>gruplar.Contains(x.Id));
                _uw.UrunRep.Guncelle(urun);
                return RedirectToAction("Index");
            }
            ViewBag.Markalar = _uw.MarkaRep.HepsiniGetir();
            ViewBag.UrunGruplar = _uw.UrunGrubuRep.HepsiniGetir();
            return View(urun);
        }
    }
}