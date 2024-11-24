using AL_EmpFeedbackSystem.Entity.Goal;

namespace AL_EmpFeedbackSystem.IRepository
{
    public interface IGoalRepository
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
