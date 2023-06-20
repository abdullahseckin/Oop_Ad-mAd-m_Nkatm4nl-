using DataAccessLayer.Abstract;
using DataAccessLayer.Proje_Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class GenericRepositoryDAL<T> : IGenericDAL<T> where T : class
    {
        // GENERİC YAPI
        // Context _context=new Context(); 1. kullanım // global tanımla
        //using var _context=new Context(); 2.kullanım farkları nelerdir // yerel tanımla yanı her metot ıçınde tanımla zorunlulugu

        public void DeleteDAL(T t)
        {
            using var _context = new Context();
            _context.Remove(t);
            _context.SaveChanges();
        }

        public List<T> GetAllListDAL()
        {
            using var _context = new Context();
            return _context.Set<T>().ToList();
        }

        public T GetListByIdDAL(int id)
        {
            using var _context = new Context();
            return _context.Set<T>().Find(id);

        }

        public void InsertDAL(T t)
        {
            using var _context = new Context();
            _context.Add(t);
            _context.SaveChanges();
        }

        public void UpdateDAL(T t)
        {
             using var _context = new Context();
            _context.Update(t);
            _context.SaveChanges();
        }
    }
}
