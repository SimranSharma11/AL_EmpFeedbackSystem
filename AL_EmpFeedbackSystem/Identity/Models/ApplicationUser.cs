using Microsoft.AspNetCore.Identity;

namespace AL_EmpFeedbackSystem.Identity.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string FullName { get; set; }
        public bool ActiveStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
