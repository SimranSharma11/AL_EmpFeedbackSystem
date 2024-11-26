using AL_EmpFeedbackSystem.Entity.UserGoalSetting;

namespace AL_EmpFeedbackSystem.IRepository
{
    public interface IUserGoalRepository
    {
        Task<string> CreateUserGoal(List<CreateUserGoal> createUserGoal, string loggedInUserName);
        Task<List<UserGoal>> GetUserGoalList();
        Task<List<UserGoal>> GetSelfGoalList(int loggedInUserId);
        Task<List<UserGoal>> GetLeadGoalList(int loggedInUserId);
        Task<UserGoal?> GetUserGoalById(int userGoalId);
        Task<string> UpdateUserGoal(UserGoal updatedGoal, string updatedBy);
        Task<List<UserGoal>> GetRecentPendingSelfGoalList(int loggedInUserId);
        Task<List<UserGoal>> GetRecentPendingLeadGoalList(int loggedInUserId);
    }
}
