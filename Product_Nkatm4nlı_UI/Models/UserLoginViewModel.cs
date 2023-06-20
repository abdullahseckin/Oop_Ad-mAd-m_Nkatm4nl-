using System.ComponentModel.DataAnnotations;

namespace A_Product_Nkatm4nlı_UI.Models
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage ="lütfen kullanıcı adını giriniz")]
        public string Username { get; set; }
        [Required(ErrorMessage ="lütfen şifreyi giriniz")]
        public string Password { get; set; }
    }
}
