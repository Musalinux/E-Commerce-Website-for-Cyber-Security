using Microsoft.AspNetCore.Identity;
namespace SOFT40081_StarterCode.Models
{
    public class AppUser: IdentityUser
       
    { 
        public string FirstName { get; set; }
        public string LastName { get; set; }


    }
}
