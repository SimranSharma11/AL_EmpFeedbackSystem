using System.ComponentModel.DataAnnotations;

namespace AL_EmpFeedbackSystem.DbModels.Entity
{
    public class Frequency
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string? UpdatedBy { get; set; }

    }
}