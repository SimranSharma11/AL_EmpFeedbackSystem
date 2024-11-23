using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AL_EmpFeedbackSystem.Identity.Models
{
    public class ApplicationUser: IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool ActiveStatus { get; set; }

        public int? LeadId { get; set; } 
        [ForeignKey(nameof(LeadId))]
        public virtual ApplicationUser Lead { get; set; } 

        public int? ManagerId { get; set; } 
        [ForeignKey(nameof(ManagerId))]
        public virtual ApplicationUser Manager { get; set; } 

        public DateTime DateOfBirth { get; set; }

        [MaxLength(250)]
        public string Address { get; set; }
        public int PostalCode { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
