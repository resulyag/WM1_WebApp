using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ilk_Mvc_Pojesi.ViewModels
{
    public class CategoryViewModel
    {
        [Required(ErrorMessage = "Kategori adı alanı gereklidir")]
        [StringLength(15, ErrorMessage = "Kategori adı alanı en fazla 15 karakter olabilir")]
        [Display(Name ="Kategori Adı")]
        public string CategoryName { get; set; }
        [Display(Name ="Açıklama")]
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
}
