using AL_EmpFeedbackSystem.Entity.Goal;
using AL_EmpFeedbackSystem.Entity.User;
using AL_EmpFeedbackSystem.Interface;
using AL_EmpFeedbackSystem.IRepository;
using AL_EmpFeedbackSystem.Repository;

namespace AL_EmpFeedbackSystem.Managers
{
    public class GoalService:IGoalService
    {
        private readonly IGoalRepository _goalRepository;

        public GoalService(IGoalRepository goalRepository)
        {
            _goalRepository = goalRepository;
        }

        /// <summary>
        /// Endpoint to create a new goal.
        /// </summary>
        /// <param name="goalCreateRequest">The goals details to create.</param>
        /// <returns>A response message indicating success or failure.</returns>
        public async Task<string> CreateGoal(GoalCreateRequest goalCreateRequest)
        {
            try
            {
                var response = await _goalRepository.CreateGoal(goalCreateRequest);
                return response;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// Delete a goal by ID.
        /// </summary>
        /// <param name="goalId">The ID of the goal.</param>
        /// <returns>A response message indicating success or failure.</returns>
        public async Task<string> DeleteGoalByIdAsync(int goalId)
        {
            var result = await _goalRepository.DeleteGoalByIdAsync(goalId);
            return result;
        }

        /// <summary>
        /// Get users list.
        /// </summary>
        /// <returns>A list of users Id and Name.</returns>
        public async Task<List<GoalDetails>> GetGoalsList()
        {
            var result = await _goalRepository.GetGoalsList();
            return result;
        }
    }
}
