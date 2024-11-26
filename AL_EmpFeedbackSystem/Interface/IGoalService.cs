using AL_EmpFeedbackSystem.DbModels.Entity;
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

        /// <summary>
        /// Getting Duration List
        /// </summary>
        /// <param name="frequencyId">The ID of the frequency.</param>
        /// <returns>List of Duration.</returns>
        Task<List<DurationDetail>> GetDurationList(int frequencyId);

        /// <summary>
        /// Getting Frequency List
        /// </summary>
        /// <returns>List of Frequency.</returns>
        Task<List<FrequencyDetail>> GetFrequencyList();

        /// <summary>
        /// Getting Designation List
        /// </summary>
        /// <returns>List of Designations.</returns>
        Task<List<DesignationDetail>> GetDesignationList();

        /// <summary>
        /// Get users list.
        /// </summary>
        /// <returns>A list of users Id and Name.</returns>
        Task<List<GoalDetails>> GetRecentGoalsList();
    }
}
