using Microsoft.AspNetCore.Identity;

namespace ADemabre.IUT.Forum.Ui.Models
{
    public class Role : IdentityRole<int>
    {
        public string? Description { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
