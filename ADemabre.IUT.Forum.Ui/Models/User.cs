using Microsoft.AspNetCore.Identity;

namespace ADemabre.IUT.Forum.Ui.Models
{
    public class User : IdentityUser<int>
    {
        public ICollection<Message> Messages { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<IdentityUserClaim<int>> Claims { get; set; }
        public virtual ICollection<IdentityUserLogin<int>> Logins { get; set; }
        public virtual ICollection<IdentityUserToken<int>> Tokens { get; set; }
    }
}
