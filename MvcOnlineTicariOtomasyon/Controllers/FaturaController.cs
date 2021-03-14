using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context c = new Context();
        public ActionResult Index()
        {
            var deger = c.Faturas.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Fatura fatura)
        {
            c.Faturas.Add(fatura);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaGetir(int id)
        {
            var deger = c.Faturas.Find(id);
            return View("FaturaGetir", deger);
        }
        public ActionResult FaturaGuncelle(Fatura fatura)
        {
            var deger = c.Faturas.Find(fatura.FaturaId);
            deger.FaturaSeriNo = fatura.FaturaSeriNo;
            deger.FaturaSıraNo = fatura.FaturaSıraNo;
            deger.Saat = fatura.Saat;
            deger.TeslimAlan = fatura.TeslimAlan;
            deger.TeslimAlan = fatura.TeslimAlan;
            deger.VergiDairesi = fatura.VergiDairesi;
            deger.FaturaTarih = fatura.FaturaTarih;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaDetay(int id)
        {
            var deger = c.FaturaKalems.Where(x => x.FaturaId == id).ToList();
            return View("FaturaDetay", deger);
        }
        [HttpGet]
        public ActionResult FaturaKalemEkle(int id)
        {
            ViewBag.id = id;
            return View();
        }
        [HttpPost]
        public ActionResult FaturaKalemEkle(FaturaKalem fk)
        {
            c.FaturaKalems.Add(fk);
            c.SaveChanges();
            return RedirectToAction("FatruaDetay", fk.FaturaId);
        }

        public ActionResult DinamikFaturalar()
        {
            DFatura df = new DFatura();
            df.faturalar = c.Faturas.ToList();
            df.kalemler = c.FaturaKalems.ToList();
            return View(df);
        }

        public ActionResult DinamikFaturaKaydet(string FaturaSeriNo, string FaturaSıraNo, DateTime Tarih, string VergiDairesi, string Saat,
            string TeslimEden, string TeslimAlan, string ToplamTutar, FaturaKalem[] kalemler)
        {
            Fatura f = new Fatura();
            f.FaturaSeriNo = FaturaSeriNo;
            f.FaturaSıraNo = FaturaSeriNo; ;
            f.FaturaTarih = Tarih;
            f.VergiDairesi = VergiDairesi;
            f.Saat = Saat;
            f.TeslimAlan = TeslimAlan;
            f.TeslimEden = TeslimEden;
            f.ToplamTutar = decimal.Parse(ToplamTutar);
            c.Faturas.Add(f);
            foreach (var item in kalemler)
            {
                FaturaKalem fk = new FaturaKalem();
                fk.Aciklama = item.Aciklama;
                fk.BirimFiyat = item.BirimFiyat;
                fk.Miktar = item.Miktar;
                fk.FaturaId = item.FaturaKalemId;
                fk.Tutar = item.Tutar;
                c.FaturaKalems.Add(fk);
            }
            c.SaveChanges();
            return Json("İşlem Başarılı", JsonRequestBehavior.AllowGet);
        }


    }
}