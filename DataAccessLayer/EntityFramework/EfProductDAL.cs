using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    // EfProductDAL ne işe yarayacak?
    // projenin ilerleyen aşamalarında sadece EfProductDAL ait her hangi bir yapı(metot,sınıf,fonk ..vb)
    // lazım olursa burada kullanılacaktır
    public class EfProductDAL:GenericRepositoryDAL<Product>,IProductDAL
    {
    }
}
