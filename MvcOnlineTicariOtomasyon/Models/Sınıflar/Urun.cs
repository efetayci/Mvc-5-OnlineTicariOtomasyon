using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Urun
    {
        [Key]
        public int UrunId { get; set; }

        [Column(TypeName="Varchar")]
        [StringLength(30)]
        public string UrunAD { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string UrunMarka { get; set; }
        public short UrunStok { get; set; }
        public decimal AlisFiyat { get; set; }
        public decimal SatisFiyat { get; set; }
        public bool Durum { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string UrunGorsel { get; set; }

        public int KategoriId { get; set; }
        public virtual Kategori Kategori { get; set; } // her ürünün tek kategorisi

        public ICollection<SatisHareket> satisHarekets { get; set; }
    }
}