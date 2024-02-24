using Microsoft.AspNetCore.Identity;

namespace AuthAPI.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }  
    }
}
