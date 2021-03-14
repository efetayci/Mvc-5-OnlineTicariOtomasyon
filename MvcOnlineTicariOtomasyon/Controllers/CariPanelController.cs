using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariPanelController : Controller
    {
        // GET: CariPanel
        Context c = new Context();

        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];
            var degerler = c.Caris.FirstOrDefault(x => x.Carimail == mail);
            ViewBag.ad=degerler.CariAd.ToString();
            ViewBag.soyad=degerler.CariSoyad.ToString();
            ViewBag.mail=degerler.Carimail.ToString();
            ViewBag.sehir=degerler.CariSehir.ToString();
            ViewBag.sifre=degerler.CariSifre.ToString();
   
            var cari = c.Caris.Where(x => x.Carimail == mail).Select(x => x.CariId).FirstOrDefault();
            var toplamHarcama = c.SatisHarekets.Where(x => (decimal?)x.CariId == cari).Sum(x => (decimal?)x.ToplamTutar);
            if(toplamHarcama == null)
            {
                ViewBag.toplamHarcama = 0;
            }
            else
            {
                ViewBag.toplamHarcama = toplamHarcama;
            }
            var urunSayisi = c.SatisHarekets.Where(x => x.CariId == cari).Sum(x=> (decimal ? )x.Adet);
            if (urunSayisi == null)
            {
                ViewBag.urunSayisi = 0;
            }
            else
            {
                ViewBag.urunSayisi = urunSayisi;
            }
            var Kargo = c.KargoDetays.Where(x => x.Alici == mail).Count().ToString();
            if (Kargo == null)
            {
                ViewBag.Kargo = 0;
            }
            else
            {
                ViewBag.Kargo = Kargo;
            }
            var degerler2 = c.Mesajlars.Where(x => x.Alici == mail).ToList();
            return View(degerler2);
        }
        public ActionResult Siparislerim()
        {
            var mail = (string)Session["CariMail"];
            var id = c.Caris.Where(x => x.Carimail == mail.ToString()).Select(y => y.CariId).FirstOrDefault();
            var degerler = c.SatisHarekets.Where(x => x.CariId == id).ToList();
            return View(degerler);
        }
        public ActionResult KargoTakip(string aranan = null)
        {
            var mail = (string)Session["CariMail"];

            var deger = c.KargoDetays.Where(x => x.TakipKodu == (aranan)).ToList();

            return View(deger);
        }
        public ActionResult KargoDetay(string id)
        {

            var deger = c.KargoTakips.Where(x => x.TakipKodu == id).ToList();
            return View(deger);

        }

        public ActionResult GelenMesajlar()
        {
            string mail = Session["CariMail"].ToString();
            ViewBag.gelen = c.Mesajlars.Where(x => x.Alici == mail).Count();
            ViewBag.gönderilen = c.Mesajlars.Where(x => x.Gonderici == mail).Count();
            var mesajalar = c.Mesajlars.Where(x => x.Alici == mail).OrderByDescending(x => x.Tarih).ToList();
            return View(mesajalar);
        }
        public ActionResult GönderilenMesajlar()
        {
            string mail = Session["CariMail"].ToString();
            ViewBag.gelen = c.Mesajlars.Where(x => x.Alici == mail).Count();
            ViewBag.gönderilen = c.Mesajlars.Where(x => x.Gonderici == mail).Count();
            var mesajalar = c.Mesajlars.Where(x => x.Gonderici == mail).OrderByDescending(x => x.Tarih).ToList();
            return View(mesajalar);
        }
        public ActionResult MesajDetay(int id)
        {
            string mail = Session["CariMail"].ToString();
            ViewBag.gelen = c.Mesajlars.Where(x => x.Alici == mail).Count();
            ViewBag.gönderilen = c.Mesajlars.Where(x => x.Gonderici == mail).Count();
            var degerler = c.Mesajlars.Where(x => x.MesajID == id).FirstOrDefault();
            return View(degerler);
        }


        [HttpGet]
        public ActionResult YeniMesaj()
        {
            string mail = Session["CariMail"].ToString();
            ViewBag.gelen = c.Mesajlars.Where(x => x.Alici == mail).Count();
            ViewBag.gönderilen = c.Mesajlars.Where(x => x.Gonderici == mail).Count();
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(Mesajlar mesaj)
        {
            mesaj.Tarih = DateTime.Now;
            mesaj.Gonderici = (string)Session["CariMail"];
            c.Mesajlars.Add(mesaj);
            c.SaveChanges();
            return RedirectToAction("GelenMesajlar");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index","Login");
        }

        public PartialViewResult Ayarlar()
        {
            var mail = (string)Session["CariMail"];
            var cari = c.Caris.Where(x => x.Carimail == mail).FirstOrDefault();
            return PartialView(cari);
        }
        public ActionResult bilgiGuncelle(Cari cari)
        {
            var yeni = c.Caris.Find(cari.CariId);
            yeni.CariSehir = cari.CariSehir;
            yeni.CariAd = cari.CariAd;
            yeni.CariSoyad = cari.CariSoyad;
            yeni.CariSifre = cari.CariSifre;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public PartialViewResult Duyuru()
        {

            var mesajlar = c.Mesajlars.Where(x => x.Alici == "admin" && x.Gonderici == "admin").OrderByDescending(x=>x.Tarih).ToList();
            return PartialView(mesajlar);
        }

    }
}