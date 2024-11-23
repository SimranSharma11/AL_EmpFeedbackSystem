using Microsoft.AspNetCore.Identity;

namespace AL_EmpFeedbackSystem.Identity.Models
{
    public class ApplicationRole: IdentityRole
    {
        public string Description { get; set; }
    }
}
