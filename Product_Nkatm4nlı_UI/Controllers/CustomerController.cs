using BusinessLayer.Concrete;

using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace A_Product_Nkatm4nlı_UI.Controllers
{
    public class CustomerController : Controller
    {
        // validator kuralları ıcın
       
        CustomerManagerBLL _customerManagerBLL = new CustomerManagerBLL(new EfCustomerDAL()); 

        // LİSTELEME
        public IActionResult Index()
        {
           // var values = _customerManagerBLL.GetAllListBLL(); // Meslekler dahil değil
            var values = _customerManagerBLL.GetCustomersListWithJob_BLL(); // Meslekler Dahil buna
            return View(values);
        }
        // EKLEME
        [HttpGet]
        public IActionResult AddCustomer()
        {
            
            // DDList kullanımı// İl ilce // araba marka  vb
            // value=x.Id // text=x.name

            JobManagerBLL _jobManagerBLL = new JobManagerBLL(new EfJobDAL());  // DDList Job
            List<SelectListItem> values=( from x in _jobManagerBLL.GetAllListBLL()
                                          select new SelectListItem
                                          {
                                              Text = x.Name,
                                              Value=x.JobID.ToString(),
                                          }).ToList();

            ViewBag.v=values;

            return View();
        }
        [HttpPost]
        public IActionResult AddCustomer(Customer p)
        {
            _customerManagerBLL.InsertBLL(p);
               return RedirectToAction("Index");
            
        }

        // SİLME
        public IActionResult DeleteCustomer(int id)
        {
            var value = _customerManagerBLL.GetListByIdBLL(id);   // önce Musteriyi  bul
            _customerManagerBLL.DeleteBLL(value);                // sonra sil

            return RedirectToAction("Index");
        }

        // GÜNCELLEME
        [HttpGet]
        public IActionResult UpdateCustomer(int id)
        {
            // DDList kullanımı// İl ilce // araba marka  vb
            // value=x.Id // text=x.name

            JobManagerBLL _jobManagerBLL = new JobManagerBLL(new EfJobDAL());  // DDList Job
            List<SelectListItem> values = (from x in _jobManagerBLL.GetAllListBLL()
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.JobID.ToString(),
                                           }).ToList();

            ViewBag.v = values;
            var value = _customerManagerBLL.GetListByIdBLL(id);    // önce güncellenecek musteriyi bul
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateCustomer(Customer p)
        {
            _customerManagerBLL.UpdateBLL(p);                   // sonra Guncelle
            
                return RedirectToAction("Index");
           
            
        }
    }

    
}
