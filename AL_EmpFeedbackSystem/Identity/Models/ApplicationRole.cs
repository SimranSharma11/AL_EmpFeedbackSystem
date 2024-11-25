using Microsoft.AspNetCore.Identity;

namespace AL_EmpFeedbackSystem.Identity.Models
{
    public class ApplicationRole: IdentityRole<int>
    {
        public string Description { get; set; }

        public virtual ICollection<IdentityUserRole<int>> UserRoles { get; set; }
    }
}
