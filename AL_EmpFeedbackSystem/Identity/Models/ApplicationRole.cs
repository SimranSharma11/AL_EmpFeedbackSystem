using Microsoft.AspNetCore.Identity;

namespace AL_EmpFeedbackSystem.Identity.Models
{
    public class ApplicationRole: IdentityRole<Guid>
    {
        public string Description { get; set; }
    }
}
