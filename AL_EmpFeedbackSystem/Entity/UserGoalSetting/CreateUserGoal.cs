using AL_EmpFeedbackSystem.DbModels.Entity;

namespace AL_EmpFeedbackSystem.Entity.UserGoalSetting
{
    public class CreateUserGoal
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GoalId { get; set; }
        public int DurationId { get; set; }
    }
}
