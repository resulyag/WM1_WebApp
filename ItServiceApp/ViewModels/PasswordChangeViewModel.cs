using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ItServiceApp.ViewModels
{
    public class PasswordChangeViewModel
    {
        [Required(ErrorMessage ="Eski şifre alanı gereklidir")]
        [StringLength(100,MinimumLength =6,ErrorMessage ="Şifreniz minimum 6 karakterli olmalıdır!")]
        [Display(Name ="Eski Şifre")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "Yeni şifre alanı gereklidir")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Şifreniz minimum 6 karakterli olmalıdır!")]
        [Display(Name = "Yeni Şifre")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "şifre tekrar alanı gereklidir")]
        [DataType(DataType.Password)]
        [Display(Name = "Yeni Şifre Tekrar")]
        [Compare(nameof(NewPassword))]
        public string ConfirmNewPassword { get; set; }
    }
}
