using Castle.MicroKernel.SubSystems.Conversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class KargoDetay
    {
        [Key]
        public int KargoDetayId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Acıklama { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string TakipKodu { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string Personel { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string Alici { get; set; }
        public DateTime Tarih { get; set; }
    }
}