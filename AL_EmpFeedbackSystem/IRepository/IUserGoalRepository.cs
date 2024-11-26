using AL_EmpFeedbackSystem.DbModels.Entity;
using AL_EmpFeedbackSystem.Entity.UserGoalSetting;

namespace AL_EmpFeedbackSystem.IRepository
{
    public interface IUserGoalRepository
    {
        Task<List<UserGoalSetting>> CreateUserGoal(List<CreateUserGoal> createUserGoal, string loggedInUserName);
        Task<List<UserGoal>> GetUserGoalList();
        Task<List<UserGoal>> GetSelfGoalList(int loggedInUserId);
        Task<List<UserGoal>> GetLeadGoalList(string loggedInUserName);
        Task<UserGoal?> GetUserGoalById(int userGoalId);
        Task<string> UpdateUserGoal(UserGoal updatedGoal, string updatedBy);
        Task<List<UserGoal>> GetRecentPendingSelfGoalList(int loggedInUserId);
        Task<List<UserGoal>> GetRecentPendingLeadGoalList(int loggedInUserId);
    }
}
