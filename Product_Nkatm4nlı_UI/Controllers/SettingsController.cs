
using A_Product_Nkatm4nlı_UI.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace A_Product_Nkatm4nlı_UI.Controllers
{
    public class SettingsController : Controller
    {
        // Ayarlar Sayfası  AuthenticatedUser()
        // daha onceden kayıt yapmıs ama hatalı bir durum varsa duzeltmek için // Register kayıt ol

        // DependencyInjectioın
        private readonly UserManager<AppUser> _userManager;

        public SettingsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        // ctor

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // sisteme daha once login/AuthenticatedUser() olanları bul
            var values = await _userManager.FindByNameAsync(User.Identity.Name);

            UserEditViewModel _userEditViewModel = new UserEditViewModel(); // 1/3'lü yol  model ile SOLİD ezdik
            _userEditViewModel.Name = values.Name;   // Sonra Mimarıye taşıyacagız
            _userEditViewModel.SurName = values.Surname;
            _userEditViewModel.Mail = values.Email;
            _userEditViewModel.Name = values.Gender;

            
            
            return View(_userEditViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel p)
        {
            // sisteme daha once login/AuthenticatedUser() olanları bul
            var _user = await _userManager.FindByNameAsync(User.Identity.Name);

            // normal alanların güncellenmessi        //   1/3'lü yol  model ile SOLİD ezdik //sonra mimarı ile yapılacak
            _user.Name = p.Name;
            _user.Surname = p.SurName;
            _user.Email = p.Mail;
            _user.Gender = p.Gender;

            // şifre guncellme için cevirme işlemi yapılıyor
            _user.PasswordHash = _userManager.PasswordHasher.HashPassword(_user,p.Password);
            var result=await _userManager.UpdateAsync(_user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index","Product");
            }
            else
            {
                // hata mesajları
                foreach (var item in result.Errors)
                {
                        // model veriler yanlış ise
                        // ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                        // ModelState.AddModelError("", item.Description);                    
                        ModelState.AddModelError("", "Hatalı kullanıcı veya şifre");
                
                }
            }




            return View();
        }
    }
}
