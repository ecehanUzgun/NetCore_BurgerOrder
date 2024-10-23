using System.ComponentModel.DataAnnotations;

namespace NetCore_BurgerOrder.Models.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "Eposta")]
        [Required(ErrorMessage = "Eposta boş geçilemez!")]
        [EmailAddress(ErrorMessage = "Lütfen email formatında bir değer girin!")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage ="Şifre boş geçilemez!")]
        public string Password { get; set; }

        [Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}
