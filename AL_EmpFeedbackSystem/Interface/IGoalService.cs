using AL_EmpFeedbackSystem.Entity.Goal;
using AL_EmpFeedbackSystem.Entity.User;

namespace AL_EmpFeedbackSystem.Interface
{
    public interface IGoalService
    {

        /// <summary>
        /// Endpoint to create a new goal.
        /// </summary>
        /// <param name="goalCreateRequest">The goals details to create.</param>
        /// <returns>A response message indicating success or failure.</returns>
        Task<string> CreateGoal(GoalCreateRequest goalCreateRequest);

        /// <summary>
        /// Delete a goal by ID.
        /// </summary>
        /// <param name="goalId">The ID of the goal.</param>
        /// <returns>A response message indicating success or failure.</returns>
        Task<string> DeleteGoalByIdAsync(int goalId);

        /// <summary>
        /// Getting goal Details
        /// </summary>
        /// <returns>List of Goals.</returns>
        Task<List<GoalDetails>> GetGoalsList();
    }
}
