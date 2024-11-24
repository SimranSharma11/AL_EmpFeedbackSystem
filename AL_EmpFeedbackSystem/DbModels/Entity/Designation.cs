using AL_EmpFeedbackSystem.Identity.Models;
using System.ComponentModel.DataAnnotations;

namespace AL_EmpFeedbackSystem.DbModels.Entity
{
    public class Designation
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }

    }
}
