using System.ComponentModel.DataAnnotations;

namespace A_Product_Nkatm4nlı_UI.Models
{
    public class UserEditViewModel
    {
        // Guncellenecek bilgilerin tutuldugu yer
        [Required(ErrorMessage = "lütfen isim giriniz")]
        public string Name { get; set; }

        [Required(ErrorMessage = "lütfen  soy isim giriniz")]
        public string SurName { get; set; }        

        [Required(ErrorMessage = "lütfen kullanıcı adını giriniz")]       
        public string Mail { get; set; }

        [Required(ErrorMessage = "lütfen Cinsiyet  giriniz")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "lütfen şifrenizi giriniz")]
        public string Password { get; set; }

        [Required(ErrorMessage = "lütfen şifrenizi tekrar  giriniz")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "şifrelerin eşlestıgınden emin olunuz")]
        public string ConfirmPassword { get; set; }


    }
}
