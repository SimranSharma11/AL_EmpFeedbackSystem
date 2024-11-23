using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AL_EmpFeedbackSystem.Identity.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string FullName { get; set; }
        public bool ActiveStatus { get; set; }
        public DateTime DataOfBirth { get; set; }
        [MaxLength(250)]
        public string Address { get; set; }
        public int PostalCode { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
