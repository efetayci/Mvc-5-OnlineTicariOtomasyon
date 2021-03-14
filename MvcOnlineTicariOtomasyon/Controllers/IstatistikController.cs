using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: İstatistik
        Context c = new Context();
        public ActionResult Index()
        {

            ViewBag.toplamCari = c.Caris.Count().ToString();
            ViewBag.d2 = c.Uruns.Count().ToString();
            ViewBag.d3 = c.Personels.Count().ToString();
            ViewBag.d4 = c.Kategoris.Count().ToString();
            ViewBag.d5 = c.Uruns.Sum(x => x.UrunStok).ToString();
            ViewBag.d6 = c.Uruns.Select(x => x.UrunMarka).Distinct().Count().ToString();
            ViewBag.d7 = c.Uruns.Where(x => x.UrunStok < 100).Count().ToString();
            ViewBag.d8 = (from x in c.Uruns orderby x.SatisFiyat descending select x.UrunAD).FirstOrDefault().ToString();
            ViewBag.d9 = (from x in c.Uruns orderby x.SatisFiyat ascending select x.UrunAD).FirstOrDefault().ToString();
            ViewBag.d10 = c.Uruns.GroupBy(x => x.UrunMarka).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault().ToString();
            ViewBag.d11 = c.Uruns.Where(x => x.UrunAD == "Buzdolabı").Count().ToString();
            ViewBag.d12 = c.Uruns.Where(x => x.UrunAD == "Laptop").Count().ToString();
            ViewBag.d13 = c.SatisHarekets.GroupBy(x => x.Urun.UrunAD).OrderByDescending(y => y.Count()).Select(z => z.Key).FirstOrDefault().ToString(); ;
            ViewBag.d14 = c.SatisHarekets.Sum(x => x.ToplamTutar).ToString("N2", new CultureInfo("es-ES"));
            var today = DateTime.Today;
            ViewBag.d15 = c.SatisHarekets.Where(x => x.Tarih == today).Count().ToString();
            var d16 = c.SatisHarekets.Where(x => x.Tarih == today).Sum(x => (decimal?)x.ToplamTutar);
            if (d16 != 0)
            {
                Convert.ToDecimal(d16);
            }
            else
            {
                d16 = 0;
            }
            ViewBag.d16 = d16;


            return View();
        }

        public ActionResult Index2()
        {
            ViewBag.toplamCari = c.Caris.Count().ToString();
            ViewBag.d2 = c.Uruns.Count().ToString();
            ViewBag.d3 = c.Personels.Count().ToString();
            ViewBag.d4 = c.Kategoris.Count().ToString();
            ViewBag.d5 = c.Uruns.Sum(x => x.UrunStok).ToString();
            ViewBag.d6 = c.Uruns.Select(x => x.UrunMarka).Distinct().Count().ToString();
            ViewBag.d7 = c.Uruns.Where(x => x.UrunStok < 100).Count().ToString();
            ViewBag.d8 = (from x in c.Uruns orderby x.SatisFiyat descending select x.UrunAD).FirstOrDefault().ToString();
            ViewBag.d9 = (from x in c.Uruns orderby x.SatisFiyat ascending select x.UrunAD).FirstOrDefault().ToString();
            ViewBag.d10 = c.Uruns.GroupBy(x => x.UrunMarka).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault().ToString();
            ViewBag.d11 = c.Uruns.Where(x => x.UrunAD == "Buzdolabı").Count().ToString();
            ViewBag.d12 = c.Uruns.Where(x => x.UrunAD == "Laptop").Count().ToString();
            ViewBag.d13 = c.SatisHarekets.GroupBy(x => x.Urun.UrunAD).OrderByDescending(y => y.Count()).Select(z => z.Key).FirstOrDefault().ToString(); ;
            ViewBag.d14 = c.SatisHarekets.Sum(x => x.ToplamTutar).ToString("N2", new CultureInfo("es-ES"));
            var today = DateTime.Today;
            ViewBag.d15 = c.SatisHarekets.Where(x => x.Tarih == today).Count().ToString();
            var d16 = c.SatisHarekets.Where(x => x.Tarih == today).Sum(x => (decimal?)x.ToplamTutar);
            if (d16 != 0)
            {
                Convert.ToDecimal(d16);
            }
            else
            {
                d16 = 0;
            }
            ViewBag.d16 = d16;

            return View();
        }
        public ActionResult BasitTablolar()
        {
            return View();
        }
        public PartialViewResult KategoriPartial()
        {
            ViewBag.sayi = c.Kategoris.Count();
            var deger = c.Kategoris.ToList();
            return PartialView(deger);
        }
        public PartialViewResult MusteriSehir()
        {
            var deger = (from x in c.Caris
                         group x by x.CariSehir into g
                         select new SehirGrup
                         {
                             sehir = g.Key,
                             sayi = g.Count()
                         });

            return PartialView(deger.ToList());
        }
        public PartialViewResult PersonelDepartmanPartial()
        {
            ViewBag.toplamPers = c.Personels.Count();
            var deger = (from x in c.Personels group x by x.departman.DepartmanAd  into g
                         select new PersonelDepartman {
                             DepartmanAdi = g.Key,
                             PersonelSayisi = g.Count()
                         }).ToList();
            return PartialView(deger);
        }
        public PartialViewResult CariListesiPartial()
        {
            var deger = c.Caris.ToList();
            return PartialView(deger);
        }
        public PartialViewResult UrunListesiPartial()
        {
            var deger = c.Uruns.ToList();
            return PartialView(deger);
        }
        public PartialViewResult MarkaSayiPartial()
        {
            var deger = (from x in c.Uruns
                         group x by x.UrunMarka into g
                         select new MarkaSayisi
                         {
                             MarkaAd = g.Key,
                             Sayi = g.Count()
                         }).ToList(); 
            return PartialView(deger);
        }

    }
}

