using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class UrunDetayları
    {
        [Key]
        public int DetayId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string DetayAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(3000)]
        public string DetayAcıklama { get; set; }
    }
}