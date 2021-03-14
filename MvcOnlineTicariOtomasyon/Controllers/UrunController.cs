using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;
using PagedList;
using PagedList.Mvc;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        Context C = new Context();
        public ActionResult Index(int sayfa=1,string aranan="")
        {
            if (!string.IsNullOrEmpty(aranan))
            {
                var degerler = C.Uruns.Where(x => x.UrunAD.Contains(aranan)).ToList().ToPagedList(sayfa, 6);
                return View(degerler);
            }
            else
            {
                var degerler = C.Uruns.ToList().ToPagedList(sayfa,6);
                return View(degerler);
            }
           
        }

        [HttpPost]
        public ActionResult UrunEkle(Urun urun)
        {
            C.Uruns.Add(urun);
            C.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
            // dropdpwnlist oluşturma

            List<SelectListItem> deger = (from x in C.Kategoris.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.KategoriAd,
                                              Value = x.KategoriId.ToString()
                                          }).ToList();
            ViewBag.deger1 = deger;

            return View();
        }
        public ActionResult UrunSil(int id)
        {
            var deger = C.Uruns.Find(id);
            deger.Durum = false;
            C.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {

            List<SelectListItem> deger = (from x in C.Kategoris.ToList()
                                          select new SelectListItem
                                          {
                                              Value = x.KategoriId.ToString(),
                                              Text = x.KategoriAd
                                          }
                                          ).ToList();

            ViewBag.deger = deger;

            var degerler = C.Uruns.Find(id);
            return View("UrunGetir",degerler);
        }
        public ActionResult UrunGuncelle(Urun urun)
        {
            var deger = C.Uruns.Find(urun.UrunId);
            deger.UrunAD = urun.UrunAD;
            deger.KategoriId = urun.KategoriId;
            deger.SatisFiyat = urun.SatisFiyat;
            deger.AlisFiyat = urun.AlisFiyat;
            deger.UrunMarka = urun.UrunMarka;
            deger.UrunStok = urun.UrunStok;
            deger.Durum = urun.Durum;
            deger.UrunGorsel = urun.UrunGorsel;
            C.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunListesi()
        {
            var degerler = C.Uruns.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult SatisYap(int id)
        {
            ViewBag.id = id;
            var deger = C.Uruns.Find(id);
            ViewBag.ad = deger.UrunAD.ToString();
            ViewBag.fiyat = deger.SatisFiyat;
            
            List<SelectListItem> personel = (from x in C.Personels
                                             select new SelectListItem
                                             {
                                                 Text = x.PersonelAd + " " + x.PersonelSoyad,
                                                 Value = x.PersonelId.ToString()
                                             }).ToList();

            ViewBag.personel = personel;

            List<SelectListItem> cari = (from x in C.Caris
                                         where x.Durum == true
                                         select new SelectListItem
                                         {
                                             Text = x.CariAd + " " + x.CariSoyad,
                                             Value = x.CariId.ToString()
                                         }).ToList();

            ViewBag.cari = cari;
            return View();
        }
        [HttpPost]
        public ActionResult SatisYap(SatisHareket sat)
        {  
            sat.Tarih = DateTime.Today;
            C.SatisHarekets.Add(sat);
            C.SaveChanges();
            return RedirectToAction("Index","Satis");
        }


    }
}