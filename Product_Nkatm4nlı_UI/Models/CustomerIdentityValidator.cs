using Microsoft.AspNetCore.Identity;

namespace A_Product_Nkatm4nlı_UI.Models
{
    
    public class CustomerIdentityValidator:IdentityErrorDescriber
    {
        // Şifre Belirleme Kuralları bilgi Mesajları
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError()
            {
                Code = "PasswordTooShort",
                Description = "Parola en az 6 karakter olmalı"
            };  
        }
        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresUpper",
                Description = "Parola en az 1 buyuk karakter içermeli"
            };
        }
        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresLower",
                Description = "Parola en az 1 kucuk karakter içermeli"
            };
        }
        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresNonAlphanumeric",
                Description = "Parola en az 1 alfa numerik karakter içermeli"
            };
        }
    }
}
