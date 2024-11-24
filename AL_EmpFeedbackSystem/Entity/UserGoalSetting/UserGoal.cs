namespace AL_EmpFeedbackSystem.Entity.UserGoalSetting
{
    public class UserGoal : BaseEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GoalId { get; set; }
        public int DurationId { get; set; }
        public string SelfComment { get; set; }
        public string LeadComment { get; set; } 
        public int? SelfRating { get; set; }
        public int? LeadRating { get; set; }
    }
}
