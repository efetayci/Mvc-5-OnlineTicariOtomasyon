using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class UrunAcıklamaDetay
    {
        public IEnumerable<UrunDetayları> UrunDetay { get; set; }
        public IEnumerable<Urun> Urun { get; set; }
    }
    
}