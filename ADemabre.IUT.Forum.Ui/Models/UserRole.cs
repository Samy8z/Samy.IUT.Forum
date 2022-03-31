using Microsoft.AspNetCore.Identity;

namespace ADemabre.IUT.Forum.Ui.Models
{
    public class UserRole : IdentityUserRole<int>
    {
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
