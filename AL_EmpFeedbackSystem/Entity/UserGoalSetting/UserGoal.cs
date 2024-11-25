﻿namespace AL_EmpFeedbackSystem.Entity.UserGoalSetting
{
    public class UserGoal : BaseEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int GoalId { get; set; }
        public string Goal { get; set; }
        public int DurationId { get; set; }
        public string Duration { get; set; }
        public string SelfComment { get; set; }
        public string LeadComment { get; set; } 
        public int? SelfRating { get; set; }
        public int? LeadRating { get; set; }
        public string SubGoal { get; set; }
        public string Description { get; set; }
    }
}
