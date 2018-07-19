using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AspCat.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
