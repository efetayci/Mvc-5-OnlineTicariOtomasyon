using MvcOnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        //View ile grafik, veritabanı ile grafik, controller ile grafik, adminlte grafikleri
        
        public ActionResult Index()//VİEW MANUEL
        {
            return View();
        }
        public ActionResult Index2() //MANUEL
        {
            var grafikçiz = new Chart(600, 600);
            grafikçiz.AddTitle("Kategori-Ürün Sayısı").AddLegend("Stok").AddSeries
                ("Degerler", xValue: new[] { "Mobilya","Ofis Eşyaları", "Bilgisayar" },
                yValues: new[] { 85, 66, 98 }).Write();
            return File(grafikçiz.ToWebImage().GetBytes(), "image/jpeg");
            
        }
        Context C = new Context(); 
        public ActionResult Index3() //VERİ TABANI
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var sonuclar = C.Uruns.ToList();
            sonuclar.ToList().ForEach(x => xvalue.Add(x.UrunAD));
            sonuclar.ToList().ForEach(x => yvalue.Add(x.UrunStok));
            var grafik = new Chart(width: 500, height: 500).AddTitle("Ürün-Stok").
                AddSeries(chartType: "Pie", name: "Stok", xValue: xvalue, yValues: yvalue);
            return File(grafik.ToWebImage().GetBytes(), "image/jpeg");


        }

        public PartialViewResult PieChart()
        {
            return PartialView();
        }

        public PartialViewResult LineChart() //google charts line 
        {
            return PartialView();
        }
        public ActionResult Index4() //google charts pie 
        {
            return View();
        }
        public ActionResult Index5() //google charts line 
        {
            return View();
        }
        public ActionResult Index6() //google charts column 
        {
            return View();
        }



        public ActionResult VisualizeUrunResult() //google charts
        {
            return Json(UrunListesi(), JsonRequestBehavior.AllowGet);
        }
        public List<Class1> UrunListesi()
        {
            var deger = C.Uruns.ToList();
            List<Class1> snf = new List<Class1>();
            deger.ToList().ForEach(x => snf.Add(new Class1
            {
                UrunAd = x.UrunAD,
                Stok = x.UrunStok
            }));
            
            return snf;
        }


    }
}