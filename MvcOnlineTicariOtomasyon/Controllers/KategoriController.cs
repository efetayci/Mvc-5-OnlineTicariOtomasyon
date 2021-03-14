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
    public class KategoriController : Controller
    {
        // GET: Kategori

        Context C = new Context();

        
        public ActionResult Index(int sayfa = 1)
        {
            
            var kategoriler = C.Kategoris.ToList().ToPagedList(sayfa,10);
            return View(kategoriler);
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategori yeni)
        {
            C.Kategoris.Add(yeni);
            C.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriSil(int id)
        {
            var değer = C.Kategoris.Find(id);
            C.Kategoris.Remove(değer);
            C.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var kategori = C.Kategoris.Find(id);
            return View("KategoriGetir",kategori);
        }
        public ActionResult KategoriGuncelle(Kategori deger)
        {
            var degis = C.Kategoris.Find(deger.KategoriId);
            degis.KategoriAd = deger.KategoriAd;
            C.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Cascading()
        {
            Cascading cs = new Cascading();
            cs.Kategoriler = new SelectList(C.Kategoris,"KategoriId","KategoriAd");
            cs.Urunler = new SelectList(C.Uruns, "UrunId", "UrunAD");
            return View(cs);
        }
        public JsonResult UrunGetir(int p)
        {
            var urun = (from x in C.Uruns
                        join y in C.Kategoris
                        on x.Kategori.KategoriId equals y.KategoriId
                        where x.Kategori.KategoriId == p
                        select new
                        {
                            Text = x.UrunAD,
                            Value = x.UrunId.ToString()
                        }).ToList();
            return Json(urun, JsonRequestBehavior.AllowGet);
        }


    }
}