using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace A_Product_Nkatm4nlı_UI.Controllers
{
    public class JobController : Controller
    { 
        // dogrulama için
        JobValidator _validator=new JobValidator();
        // sql bbaglnatı sınıfı içiçn
        JobManagerBLL _jobManagerBLL = new JobManagerBLL( new EfJobDAL());
        // LİSTELEME
        public IActionResult Index()
        {
            var values = _jobManagerBLL.GetAllListBLL();
            return View(values);
        }
        // EKLEME
        [HttpGet]
        public IActionResult AddJob()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddJob(Job p)
        {
            _jobManagerBLL.InsertBLL(p);
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
        // SİLME
        public IActionResult DeleteJob(int id)
        {
            var value = _jobManagerBLL.GetListByIdBLL(id);   // önce silinecek ürünü bul
            _jobManagerBLL.DeleteBLL(value);               // sonra sil

            return RedirectToAction("Index");
        }

        // GÜNCELLEME
        [HttpGet]
        public IActionResult UpdateJob(int id)
        {
            var value = _jobManagerBLL.GetListByIdBLL(id);    // önce güncellenecek ürünü bul
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateJob(Job p)
        {
            _jobManagerBLL.UpdateBLL(p);                   // sonra Guncelle
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
