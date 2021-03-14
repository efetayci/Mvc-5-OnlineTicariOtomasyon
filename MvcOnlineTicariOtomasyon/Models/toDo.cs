using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models
{
    public class toDo
    {

        [Key]
        public int toDoId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        [Required(ErrorMessage ="Bu alanı boş geçemezsiniz.")]
        public string Baslik { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100, ErrorMessage="En fazla 100 karakter yazabilirsiniz")]
        public string Aciklama { get; set; }

        public bool Durum { get; set; }
    }
}