using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context c = new Context();
        public ActionResult Index()
        {
            var cariler = c.Caris.Where(x => x.Durum == true).ToList(); 
            return View(cariler);
        }

        [HttpGet]
        public ActionResult CariEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CariEkle(Cari cari)
        {
            cari.Durum = true;
            c.Caris.Add(cari);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariSil(int id)
        {
            var cari = c.Caris.Find(id);
            cari.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariGetir(int id)
        {
            var cariler = c.Caris.Find(id);
            return View("CariGetir",cariler);
        }
        public ActionResult CariGuncelle(Cari cari)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            var deger = c.Caris.Find(cari.CariId);
            deger.CariAd = cari.CariAd;
            deger.CariSehir = cari.CariSehir;
            deger.CariSoyad = cari.CariSoyad;
            deger.Carimail = cari.Carimail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariHareket(int id)
        {
            var deger = c.SatisHarekets.Where(x => x.CariId == id).ToList();
            ViewBag.isim = c.Caris.Where(x => x.CariId == id).Select(x => x.CariAd + " " + x.CariSoyad).FirstOrDefault();
            return View("CariHareket",deger);
        }


    }
}