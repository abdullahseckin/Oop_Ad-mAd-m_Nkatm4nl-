using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    // NOT:Neden AppUser.cs veya AppRole.cs sınıflarını eklemek Istedık??
    // Aslında IdentityDbContext kütüphanesinin içindeki 
    // AspNetUser tablosuda Hazır alanlar (Id,Username,Email,) var  ama 
    // Register(Kayıt Ol) için extradan alanlar (Name,Surname,Gender) eklemek istedik
    // Bu yuzden 
    // EntityLayer katmanına AppUser.cs ve AppRole.cs Sınıfların ekledik
    public class AppUser:IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }


    }
}
