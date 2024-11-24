using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AL_EmpFeedbackSystem.DbModels.Entity
{
    public class Duration
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public int FrequencyId { get; set; }

        [ForeignKey("FrequencyId")]
        public virtual Frequency Frequency { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string? UpdatedBy { get; set; }
    }
}