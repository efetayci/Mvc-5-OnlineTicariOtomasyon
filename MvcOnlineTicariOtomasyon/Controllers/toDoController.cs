using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;
using MvcOnlineTicariOtomasyon.Models;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class toDoController : Controller
    {
        // GET: toDo
        Context c = new Context();
        public ActionResult Index()
        {
            ViewBag.Musteri = c.Caris.Count().ToString();
            ViewBag.Urun = c.Uruns.Count().ToString();
            ViewBag.Kategori = c.Kategoris.Count().ToString();
            var Sehir = (from x in c.Caris
                         group x by x.CariSehir into g
                         select new SehirGrup
                         {
                             sehir=g.Key,
                             sayi=g.Count()
                         }).ToList();
            ViewBag.Sehir = Sehir.Count();

            var deger = c.todoo.ToList();
            return View(deger);
        }

        [HttpGet]
        public ActionResult YeniToDo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniToDo(toDo does)
        {
            if (ModelState.IsValid)
            {
                c.todoo.Add(does);
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(); //redirect to action da validation mesajları göstermiyor vire olmalı
            }
            
        }
    }
}