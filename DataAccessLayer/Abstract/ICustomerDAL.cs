using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICustomerDAL:IGenericDAL<Customer>
    {
        // birleştirmelerde Normalde Mvc de Joın kullanılırdı
        //Ama .Net Core ile birlikte Join Yerine İNCLUDE() metodu kullanılabılır

        // sadece Customer ait old için buraya yazdım yoksa 
        // herkes /genel için olsaydı IGenericDAL için yazardım

        List<Customer> GetCustomerListWithJob_DAL();  //imza ttık

    }
}
