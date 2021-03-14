using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class KargoTakip
    {
        [Key]
        public int KargoTakipid { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string TakipKodu { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Acıklama { get; set; }
        public DateTime Tarih { get; set; }
    }
}