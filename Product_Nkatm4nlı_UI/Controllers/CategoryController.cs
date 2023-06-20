using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;


namespace A_Product_Nkatm4nlı_UI.Controllers
{
    public class CategoryController : Controller
    {
        // validator kuralları ıcın
        CategoryValidator _validator = new CategoryValidator();
        // baglantı sınıfı ıcın
        CategoryManagerBLL _categoryManagerBLL = new CategoryManagerBLL(new EfCategoryDAL());

        // LİSTELEME
        public IActionResult Index()
        {
            var values = _categoryManagerBLL.GetAllListBLL();
            return View(values);
        }
        // EKLEME
        [HttpGet]
        public IActionResult AddCategory()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category c)
        {
            _categoryManagerBLL.InsertBLL(c);
            ValidationResult result = _validator.Validate(c);
            if (result.IsValid)
            {
                return RedirectToAction("Index");
            }
            else
            {
                // yanlıslık varsa
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        // SİLME
        public IActionResult DeleteCategory(int id)
        {
            var value = _categoryManagerBLL.GetListByIdBLL(id);   // önce category ürünü bul
            _categoryManagerBLL.DeleteBLL(value);               // sonra sil

            return RedirectToAction("Index");
        }

        // GÜNCELLEME
        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var value = _categoryManagerBLL.GetListByIdBLL(id);    // önce category ürünü bul
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateCategory(Category c)
        {
            _categoryManagerBLL.UpdateBLL(c);                   // sonra Guncelle category
            ValidationResult result = _validator.Validate(c);
            if (result.IsValid)
            {
                return RedirectToAction("Index");
            }
            else
            {
                // yanlıslık varsa
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
