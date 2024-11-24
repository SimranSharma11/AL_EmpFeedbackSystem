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

        //public async Task<string> CreateUserGoal(List<>)
    }
}
