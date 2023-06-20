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
    public class ProductManagerBLL : IProductServiceBLL
    {
        // ctor ile _productDAL e deger ataması yaparız 
        IProductDAL _productDAL;

        //ctor Yapıcı metot
        public ProductManagerBLL(IProductDAL productDAL)
        {
            _productDAL = productDAL;
        }

        public void DeleteBLL(Product t)
        {
           _productDAL.DeleteDAL(t);
        }

        public List<Product> GetAllListBLL()
        {
            return _productDAL.GetAllListDAL();
        }

        public Product GetListByIdBLL(int id)
        {
            return _productDAL.GetListByIdDAL(id);
        }

        public void InsertBLL(Product t)
        {
            _productDAL.InsertDAL(t);
           
        }

        public void UpdateBLL(Product t)
        {
            _productDAL.UpdateDAL(t);
        }
    }
}
