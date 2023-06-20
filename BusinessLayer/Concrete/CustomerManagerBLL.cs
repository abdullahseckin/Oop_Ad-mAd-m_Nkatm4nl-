using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CustomerManagerBLL : ICustomerServiceBLL
    {
        //ctor ile değer atama
        ICustomerDAL _customerDAL;
       

        public CustomerManagerBLL(ICustomerDAL customerDAL)
        {
            _customerDAL = customerDAL;
        }

        
        public void DeleteBLL(Customer t)
        {
            _customerDAL.DeleteDAL(t);
        }

        public List<Customer> GetAllListBLL()
        {
            return _customerDAL.GetAllListDAL();
        }

        public List<Customer> GetCustomersListWithJob_BLL()
        {
            return _customerDAL.GetCustomerListWithJob_DAL();
        }

        public Customer GetListByIdBLL(int id)
        {
            return _customerDAL.GetListByIdDAL(id);
        }

        public void InsertBLL(Customer t)
        {
            _customerDAL.InsertDAL(t);
        }

        public void UpdateBLL(Customer t)
        {
            _customerDAL.UpdateDAL(t);
        }
    }
}
