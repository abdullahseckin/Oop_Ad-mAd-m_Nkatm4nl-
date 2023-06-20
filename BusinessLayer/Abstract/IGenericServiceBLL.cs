using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericServiceBLL<T>
    {
        void InsertBLL(T t);
        void DeleteBLL(T t);
        void UpdateBLL(T t);
        List<T> GetAllListBLL();
        T GetListByIdBLL(int id);
    }
}
