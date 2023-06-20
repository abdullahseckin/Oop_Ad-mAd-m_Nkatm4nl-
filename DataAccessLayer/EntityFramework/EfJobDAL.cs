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
    // EfJobDAL ne işe yarayacak?
    // projenin ilerleyen aşamalarında sadece EfJobDAL ait her hangi bir yapı(metot,sınıf,fonk ..vb)
    // lazım olursa burada kullanılacaktır
    public class EfJobDAL:GenericRepositoryDAL<Job>,IJobDAL
    {
    }
}
