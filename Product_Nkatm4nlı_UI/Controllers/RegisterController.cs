using A_Product_Nkatm4nlı_UI.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace A_Product_Nkatm4nlı_UI.Controllers
{
    public class RegisterController : Controller
    {
        // DependencyInjectioın
        private readonly UserManager<AppUser> _userManager;
        // ctor
        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index( UserRegisterViewModel p) // 3 farklı yol var
        {
            // 1--Model olusturarak // UserRegisterViewModel
            // 2--Model kaldırarak
            // 3--Mimari üzerinden

            AppUser appUser = new AppUser()
            {
                // model= p dedık
                Name = p.Name,
                Surname=p.SurName,
                UserName=p.UserName,
                Email=p.Mail,
                Gender="Null"
                
            };
            if (p.Password==p.ConfirmPassword)
            {
                var result= await _userManager.CreateAsync(appUser,p.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("",item.Description);
                    }
                }
            }
            return View(p);
        }
    }
}
// default sifre işlemleri
// en az 6 karakter
// 1 adet kucuk harf
// 1 adet buyuk harf
// 1 adet sembol +-* gibi
