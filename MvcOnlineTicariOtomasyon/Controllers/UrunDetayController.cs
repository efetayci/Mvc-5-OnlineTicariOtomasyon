using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunDetayController : Controller
    {
        // GET: UrunDetay
        Context c = new Context();
        public ActionResult Index()
        {
            UrunAcıklamaDetay dt = new UrunAcıklamaDetay();
            dt.Urun= c.Uruns.Where(x => x.UrunId == 1).ToList();
            dt.UrunDetay = c.UrunDetaylarıs.ToList();
            return View(dt);
        }
    }
}