using AL_EmpFeedbackSystem.DbModels.Entity;
using AL_EmpFeedbackSystem.Entity.UserGoalSetting;
using AL_EmpFeedbackSystem.Interface;
using AL_EmpFeedbackSystem.IRepository;

namespace AL_EmpFeedbackSystem.Managers
{
    public class UserGoalService : IUserGoalService
    {
        private readonly IUserGoalRepository _userGoalRepository;
        public UserGoalService(IUserGoalRepository userGoalRepository) 
        {
            _userGoalRepository = userGoalRepository;
        }

        public async Task<List<UserGoalSetting>> CreateUserGoal(List<CreateUserGoal> createUserGoal, string loggedInUserName)
        {
            var result = await _userGoalRepository.CreateUserGoal(createUserGoal, loggedInUserName);
            return result;
        }
        public async Task<List<UserGoal>> GetUserGoalList()
        {
            var result = await _userGoalRepository.GetUserGoalList();
            return result;
        }
        public async Task<List<UserGoal>> GetSelfGoalList(int loggedInUserId)
        {
            var result = await _userGoalRepository.GetSelfGoalList(loggedInUserId);
            return result;
        }
        public async Task<List<UserGoal>> GetLeadGoalList(int loggedInUserId)
        {
            var result = await _userGoalRepository.GetLeadGoalList(loggedInUserId);
            return result;
        }
        public async Task<UserGoal?> GetUserGoalById(int userGoalId)
        {
            var result = await _userGoalRepository.GetUserGoalById(userGoalId);
            return result;
        }
        public async Task<string> UpdateUserGoal(UserGoal userGoal, string loggedInUserName)
        {
            var result = await _userGoalRepository.UpdateUserGoal(userGoal, loggedInUserName);
            return result;
        }

        public async Task<List<UserGoal>> GetRecentPendingSelfGoalList(int loggedInUserId)
        {
            var result = await _userGoalRepository.GetRecentPendingSelfGoalList(loggedInUserId);
            return result;
        }
        public async Task<List<UserGoal>> GetRecentPendingLeadGoalList(int loggedInUserId)
        {
            var result = await _userGoalRepository.GetRecentPendingLeadGoalList(loggedInUserId);
            return result;
        }
    }
}
