using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context C = new Context();
        public ActionResult Index()
        {
            var degerler = C.Departmans.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmanEkle(Departman dep)
        {
            dep.Durum = true;
            C.Departmans.Add(dep);
            C.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanSil(int id)
        {
            var sil = C.Departmans.Find(id);
            sil.Durum = false;
            C.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanGetir(int id)
        {
            var get = C.Departmans.Find(id);
            return View("DepartmanGetir",get);
        }
        public ActionResult DepartmanGuncelle(Departman dep)
        {
            var guncel = C.Departmans.Find(dep.DepartmanId);
            guncel.DepartmanAd = dep.DepartmanAd;
            C.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanDetay(int id)
        {
            var deger = C.Departmans.Find(id);
            ViewBag.departman = deger.DepartmanAd.ToString();
            var deger2 = C.Personels.Where(x => x.departman.DepartmanId == id).ToList();
            return View("DepartmanDetay",deger2);
        }
        public ActionResult DepartmanPersonelSatıs(int id)
        {
            var personel = C.Personels.Where(x => x.PersonelId == id).Select(x => x.PersonelAd + " " + x.PersonelSoyad).FirstOrDefault();
            ViewBag.personel = personel;
            var deger = C.SatisHarekets.Where(x => x.PersonelId == id).ToList();
            return View("DepartmanPersonelSatıs", deger);
        }








    }
}