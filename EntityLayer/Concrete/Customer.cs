using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Customer
    {
        // property---->// public int a { get; set; }
        // değişken---->// int a;

        //public int ID { get; set; }
        //public string Name { get; set; }
        //public string City { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }

        //ilişkiler job 1 muster sonsuz
        public int JobID { get; set; }   //--sonsuz
        public Job Job { get; set; }
    }
}
