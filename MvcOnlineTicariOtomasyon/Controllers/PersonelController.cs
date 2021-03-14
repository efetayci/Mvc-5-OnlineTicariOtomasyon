using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Personels.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> deger = (from x in c.Departmans.ToList()
                                          where x.Durum==true
                                          select new SelectListItem
                                          {
                                              Text = x.DepartmanAd,
                                              Value = x.DepartmanId.ToString()
                                          }).ToList();
            ViewBag.list = deger;
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel per)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                per.PersonelResim = "/Image/" + dosyaadi + uzanti;
            }
            c.Personels.Add(per);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> deger = (from x in c.Departmans.ToList()
                                          where x.Durum == true
                                          select new SelectListItem
                                          {
                                              Text = x.DepartmanAd,
                                              Value = x.DepartmanId.ToString()
                                          }).ToList();
            ViewBag.list = deger;
            var deger2 = c.Personels.Find(id);
            return View("PersonelGetir",deger2);
        }
        public ActionResult PersonelGuncelle(Personel per)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                per.PersonelResim = "/Image/" + dosyaadi + uzanti;
            }
            var guncel = c.Personels.Find(per.PersonelId);
            guncel.PersonelAd = per.PersonelAd;
            guncel.PersonelResim = per.PersonelResim;
            guncel.PersonelSoyad = per.PersonelSoyad;
            guncel.DepartmanId = per.DepartmanId;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelListele()
        {
            var deger = c.Personels.ToList();
            return View(deger);
        }

    }
}