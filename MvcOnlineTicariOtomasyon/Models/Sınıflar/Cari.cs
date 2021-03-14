using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Cari
    {
        [Key]
        public int CariId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage ="En fazla 30 karakter yazabilirsiniz")]
        public string CariAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Required(ErrorMessage ="Bu alanı boş geçemezsiniz ")]
        public string CariSoyad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string CariSehir { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Carimail { get; set; }
        

        public bool Durum { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CariSifre { get; set; }

        public ICollection<SatisHareket> satisHarekets { get; set; }
    }
}