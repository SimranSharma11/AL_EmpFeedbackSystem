﻿using AL_EmpFeedbackSystem.Identity.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AL_EmpFeedbackSystem.DbModels.Entity
{
    public class UserGoalSetting
    {
        [Key]
        public int Id { get; set; }

        public int GoalId { get; set; }
        [ForeignKey("GoalId")]
        public virtual Goal Goal { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser Users { get; set; }

        public int DurationId { get; set; }

        [ForeignKey("DurationId")]
        public virtual Duration Duration { get; set; }

        public int? SelfRating {  get; set; }
        public string? SelfComment { get; set; }
        public int? LeadRating { get; set; }
        public string? LeadComment { get; set; }
        public string SubGoal { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string? UpdatedBy { get; set; }
    }
}
