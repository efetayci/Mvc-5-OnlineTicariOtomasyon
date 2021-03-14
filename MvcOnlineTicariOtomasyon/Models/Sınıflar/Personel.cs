using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Personel
    {
        [Key]
        public int PersonelId { get; set; }

        [Display(Name ="Personel Adı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonelAd { get; set; }

        [Display(Name = "Personel Soyadı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonelSoyad { get; set; }

        [Display(Name = "Personel Görseli")]
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string PersonelResim { get; set; }

        public ICollection<SatisHareket> satisHarekets { get; set; }

        public int DepartmanId { get; set; }
        public virtual Departman departman { get; set; }

    }
}