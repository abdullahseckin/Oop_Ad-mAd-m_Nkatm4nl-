using A_Product_Nkatm4nlı_UI.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace A_Product_Nkatm4nlı_UI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // Dependency Injections
        private readonly SignInManager<AppUser> _signInManager;
        //ctor
        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserLoginViewModel p)  // Parametre alması için Bir model olusturmalyız // 3lü yol
        {
            // Login = Sisteme daha önceden kayıt yaptıran kişiler
            // Kullanıcı Girişi
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.Username, p.Password, false, true);
                if (result.Succeeded)
                {
                    // eğer model verileri doğru ise 
                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    // model veriler yanlış ise
                    ModelState.AddModelError("","Hatalı kullanıcı veya şifre");
                }

            }
            return View();
        }

        // çıkış yap
        public  async Task<ActionResult> logOut()
        {   
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Login");
        }
    }
}
