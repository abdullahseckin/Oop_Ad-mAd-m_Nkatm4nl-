using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManagerBLL : ICategoryServiceBLL
    {
        //ctor ile deger atama
        ICategoryDAL _categoryDAL; //nesne uret

        public CategoryManagerBLL(ICategoryDAL categoryDAL) // nesneye deger ataması yapalım
        {
            _categoryDAL = categoryDAL;
        }

        public void DeleteBLL(Category t)
        {
            _categoryDAL.DeleteDAL(t);
        }

        public List<Category> GetAllListBLL()
        {
            return _categoryDAL.GetAllListDAL();
        }

        public Category GetListByIdBLL(int id)
        {
            return _categoryDAL.GetListByIdDAL(id);
        }

        public void InsertBLL(Category t)
        {
            _categoryDAL.InsertDAL(t);
        }

        public void UpdateBLL(Category t)
        {
            _categoryDAL.UpdateDAL(t);
        }
    }
}
