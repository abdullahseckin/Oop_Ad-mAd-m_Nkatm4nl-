using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICustomerServiceBLL:IGenericServiceBLL<Customer>
    {
        // İNCLUDE Metodu için 
        // Musteri listesinin içine Meslekleri cektıgım için buraya yazdım

        List<Customer> GetCustomersListWithJob_BLL();
    }
}
