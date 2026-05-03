using Microsoft.AspNetCore.Identity;

namespace AuthorizationExample.IdentityEntities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FullName { get; set; } = string.Empty;
        public DateTime DOB {  get; set; }
    }
}
