using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [AllowAnonymous]
    public class LogInController : Controller
    {
        // GET: LogIn
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
  
        [HttpPost]
        public ActionResult KayıtOl(Cari P)
        {
            c.Caris.Add(P);
            c.SaveChanges();
            return RedirectToAction("Index", "LogIn");
        }
       
        [HttpPost]
        public ActionResult CariGiris(Cari P)
        {

            var deger = c.Caris.FirstOrDefault(x => x.Carimail == P.Carimail && x.CariSifre == P.CariSifre);
            if (deger != null)
            {
                FormsAuthentication.SetAuthCookie(P.Carimail, false);
                Session["CariMail"] = P.Carimail.ToString();
                return RedirectToAction("Index","CariPanel");
            }
            else
            {
                return RedirectToAction("Index","LogIn");
            }
            
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin ad)
        {
            var deger = c.Admins.Where(x => x.KullaniciAd == ad.KullaniciAd && x.Sifre == ad.Sifre).FirstOrDefault();
            if (deger != null)
            {
                FormsAuthentication.SetAuthCookie(ad.KullaniciAd, false);
                Session["Admin"] = ad.KullaniciAd.ToString();
                return RedirectToAction("Index", "Kategori");
            }
            else
            {
                return RedirectToAction("Index", "LogIn");
            }
            
        }

    }
}