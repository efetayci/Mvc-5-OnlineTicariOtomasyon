using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class DFatura
    {
        public IEnumerable<Fatura> faturalar { get; set; }
        public IEnumerable<FaturaKalem> kalemler { get; set; }
    }
}