using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        Context c = new Context();
        public ActionResult Index()
        {
            var deger = c.SatisHarekets.ToList();
            return View(deger);
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {
            
            List<SelectListItem> urun = (from x in c.Uruns
                                         where x.Durum == true
                                         select new SelectListItem
                                         {
                                             Text=x.UrunAD,
                                             Value = x.UrunId.ToString()
                                         }).ToList();

            ViewBag.urun = urun;

            List<SelectListItem> personel = (from x in c.Personels
                                         select new SelectListItem
                                         {
                                             Text = x.PersonelAd + " "+ x.PersonelSoyad,
                                             Value = x.PersonelId.ToString()
                                         }).ToList();

            ViewBag.personel = personel;

            List<SelectListItem> cari = (from x in c.Caris
                                         where x.Durum == true
                                         select new SelectListItem
                                         {
                                             Text = x.CariAd + " "+ x.CariSoyad ,
                                             Value = x.CariId.ToString()
                                         }).ToList();

            ViewBag.cari = cari;


            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(SatisHareket s)
        {
            s.Tarih = DateTime.Today;
            c.SatisHarekets.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> urun = (from x in c.Uruns
                                         where x.Durum == true
                                         select new SelectListItem
                                         {
                                             Text = x.UrunAD,
                                             Value = x.UrunId.ToString()
                                         }).ToList();

            ViewBag.urun = urun;

            List<SelectListItem> personel = (from x in c.Personels
                                             select new SelectListItem
                                             {
                                                 Text = x.PersonelAd + " " + x.PersonelSoyad,
                                                 Value = x.PersonelId.ToString()
                                             }).ToList();

            ViewBag.personel = personel;

            List<SelectListItem> cari = (from x in c.Caris
                                         where x.Durum == true
                                         select new SelectListItem
                                         {
                                             Text = x.CariAd + " " + x.CariSoyad,
                                             Value = x.CariId.ToString()
                                         }).ToList();

            ViewBag.cari = cari;

            var deger = c.SatisHarekets.Find(id);
            return View("SatisGetir",deger);
        }
        public ActionResult SatisGuncelle(SatisHareket satis)
        {
            var deger = c.SatisHarekets.Find(satis.SatisId);
            deger.Adet = satis.Adet;
            deger.CariId = satis.CariId;
            deger.PersonelId = satis.PersonelId;
            deger.ToplamTutar = satis.ToplamTutar;
            deger.fiyat = satis.fiyat;
            deger.UrunId = satis.UrunId;
            deger.Tarih = satis.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisDetay(int id)
        {
            var deger = c.SatisHarekets.Find(id);
            CultureInfo myCIintl = new CultureInfo("tr-TR");
            ViewBag.deger = myCIintl;
            return View("SatisDetay",deger);
            
        }

    }
}