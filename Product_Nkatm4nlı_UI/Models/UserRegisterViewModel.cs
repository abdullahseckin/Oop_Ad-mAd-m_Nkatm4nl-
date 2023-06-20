using System.ComponentModel.DataAnnotations;

namespace A_Product_Nkatm4nlı_UI.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "lütfen isim giriniz")]
        public string Name { get; set; }
        [Required(ErrorMessage = "lütfen  soy isim giriniz")]
        public string SurName { get; set; }
        [Required(ErrorMessage = "lütfen kullanıcı adını giriniz")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "lütfen Mail adresinizi giriniz")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "lütfen şifrenizi giriniz")]
        public string Password { get; set; }
        [Required(ErrorMessage = "lütfen şifrenizi tekrar  giriniz")]
        [System.ComponentModel.DataAnnotations.Compare("Password",ErrorMessage ="şifrelerin eşlestıgınden emin olunuz")]
        public string ConfirmPassword { get; set; }

        
    }
}
