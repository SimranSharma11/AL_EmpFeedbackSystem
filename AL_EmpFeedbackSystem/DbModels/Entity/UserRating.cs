using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AL_EmpFeedbackSystem.DbModels.Entity
{
    public class UserRating
    {
        [Key]
        public int Id { get; set; }
        public int UserGoalSettingId { get; set; }
        [ForeignKey("UserGoalSettingId")]
        public virtual UserGoalSetting UserGoalSetting { get; set; }
        public int Score { get; set; }

        public string Comments { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? UpdatedBy { get; set; }
    }
}