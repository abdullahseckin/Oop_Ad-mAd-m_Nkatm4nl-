using DataAccessLayer.Abstract;
using DataAccessLayer.Proje_Context;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    // EfCustomerDAL ne işe yarayacak?
    // projenin ilerleyen aşamalarında sadece EfCustomerDAL ait her hangi bir yapı(metot,sınıf,fonk ..vb)
    // lazım olursa burada kullanılacaktır
    public class EfCustomerDAL : GenericRepositoryDAL<Customer>, ICustomerDAL
    {
        // ilişkiden dolayı sadece musteri ve meslekler için yazdık bu metodu
        public List<Customer> GetCustomerListWithJob_DAL() // metot içini doldurduk
        {
            using ( var c = new Context())
            {
                return c.Customers.Include(x=>x.Job).ToList();
            } 
        }
    }
}
