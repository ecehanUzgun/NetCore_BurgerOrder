using System.ComponentModel.DataAnnotations;

namespace NetCore_BurgerOrder.Models.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez!")]
        public string Username { get; set; }

        [Display(Name = "Eposta")]
        [Required(ErrorMessage = "Eposta boş geçilemez!")]
        [EmailAddress(ErrorMessage = "Lütfen Eposta formatına uygun değer girin!")]
        public string Email { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre boş geçilemez!")]
        public string Password { get; set; }

        [Display(Name = "Şifre (Tekrar)")]
        [Required(ErrorMessage = "Şifre (Tekrar) boş geçilemez!")]
        [Compare("Password",ErrorMessage ="Şifreler aynı değil")]
        public string ConfirmPassword { get; set; }
    }
}
