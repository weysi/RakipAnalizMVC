using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RakipAnaliziMVC.Controllers
{
    public class RakipAnalizController : Controller
    {
        // GET: RakipAnaliz
        UnitOfWork _uw = new UnitOfWork();
        public ActionResult Index()
        {
            return View(_uw.RakipAnalizRep.HepsiniGetir());
        }

        [HttpGet]
        public ActionResult Yeni()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Yeni(RakipAnaliz yeni)
        {
            if (ModelState.IsValid)
            {
                _uw.RakipAnalizRep.Ekle(yeni);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}