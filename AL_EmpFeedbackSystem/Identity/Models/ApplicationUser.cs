using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace AL_EmpFeedbackSystem.Identity.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool ActiveStatus { get; set; }
        public string? LeadId { get; set; }

        [ForeignKey("LeadId")]
        public virtual ApplicationUser Lead { get; set; }

        public string? ManagerId { get; set; }

        [ForeignKey("ManagerId")]
        public virtual ApplicationUser Manager { get; set; }
        public DateTime DataOfBirth { get; set; }
        [MaxLength(250)]
        public string Address { get; set; }
        public int PostalCode { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
