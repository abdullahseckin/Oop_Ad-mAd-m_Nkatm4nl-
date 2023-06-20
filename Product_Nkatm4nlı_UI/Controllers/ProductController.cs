using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace A_Product_Nkatm4nlı_UI.Controllers
{
    public class ProductController : Controller
    {
        ProductValidator _validator =new ProductValidator(); // validator kuralları ıcın
        ProductManagerBLL _productManagerBLL=new ProductManagerBLL(new EfProductDAL()); // baglantı sınıfı ıcın

        // LİSTELEME
        public IActionResult Index()
        {
            var values=_productManagerBLL.GetAllListBLL();
            return View(values);
        }
        // EKLEME
        [HttpGet]
        public IActionResult AddProduct()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product p)
        {
           _productManagerBLL.InsertBLL(p);
            ValidationResult result= _validator.Validate(p);
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
        public IActionResult DeleteProduct( int id)
        {
            var value=_productManagerBLL.GetListByIdBLL(id);   // önce silinecek ürünü bul
            _productManagerBLL.DeleteBLL(value);               // sonra sil

            return RedirectToAction("Index");
        }

        // GÜNCELLEME
        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var value = _productManagerBLL.GetListByIdBLL(id);    // önce güncellenecek ürünü bul
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product p)
        {
            _productManagerBLL.UpdateBLL(p);                   // sonra Guncelle
            ValidationResult result = _validator.Validate(p);
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
