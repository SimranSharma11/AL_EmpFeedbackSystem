using System.ComponentModel.DataAnnotations;

namespace AL_EmpFeedbackSystem.DbModels.Models
{
    public class Goal
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string? UpdatedBy { get; set; }
    }
}
