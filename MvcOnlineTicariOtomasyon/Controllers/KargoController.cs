using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KargoController : Controller
    {
        // GET: Kargo
        Context C = new Context();
        public ActionResult Index(string aranan="")
        {
            if (aranan != "")
            {
                var deger = C.KargoDetays.Where(x => x.TakipKodu.Contains(aranan)).ToList();
                return View(deger);
            }
            else
            {
                var deger = C.KargoDetays.ToList();
                return View(deger);
            }
            
        }

        [HttpGet]
        public ActionResult KargoEkle()
        {
            Random rnd = new Random();
            string [] karakterler={ "A","B","C","D"};
            int k1, k2, k3,s1,s2,s3;
            k1 = rnd.Next(0, 4);
            k2 = rnd.Next(0, 4);
            k3 = rnd.Next(0, 4);
            s1 = rnd.Next(100, 1000);
            s2 = rnd.Next(100, 1000);
            s3 = rnd.Next(100, 1000);
            string kod = s1.ToString() + karakterler[k1] + s2 + karakterler[k2] + s3 + karakterler[k3];
            ViewBag.takip = kod;
            return View();
        }
        [HttpPost]
        public ActionResult KargoEkle(KargoDetay dep)
        {          
            C.KargoDetays.Add(dep);
            C.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KargoDetay(string id)
        {
            var deger = C.KargoTakips.Where(x=>x.TakipKodu==id).ToList();
            return View(deger);
        }

    }
}