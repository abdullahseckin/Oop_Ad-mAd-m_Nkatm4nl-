using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Proje_Context
{
    //public class Context: DbContext// 1-59 arası
    //{
    //    // sql baglantı sınıfı // 1-59 arası
    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    {
    //        optionsBuilder.UseSqlServer("Server=APOLEX73;initial catalog=DbOOP_Temelleri2_Core6;integrated security=true;User Id=sa;Password=1234;");
    //    }

    //    public DbSet<Customer> Customers { get; set; }
    //    public DbSet<Product> Products { get; set; }
    //    public DbSet<Category> Categories { get; set; }
    //    public DbSet<Job> Jobs { get; set; }
    //}
    //public class Context:IdentityDbContext<> // 59 sonrası İdentity Kutuphanesi
    public class Context:IdentityDbContext<AppUser,AppRole,int> // 64 sonrası İdentity Kutuphanesi
    {
        // sql baglantı sınıfı // 1-59 arası
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=APOLEX73;initial catalog=DbOOP_Temelleri2_Core6;integrated security=true;User Id=sa;Password=1234;");
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Job> Jobs { get; set; }
    }
}
