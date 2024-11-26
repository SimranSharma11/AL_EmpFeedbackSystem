using AL_EmpFeedbackSystem.DbModels;
using AL_EmpFeedbackSystem.DbModels.Entity;
using AL_EmpFeedbackSystem.Entity.Goal;
using AL_EmpFeedbackSystem.IRepository;
using Microsoft.EntityFrameworkCore;

namespace AL_EmpFeedbackSystem.Repository
{
    public class GoalRepository:IGoalRepository
    {
        private readonly AL_EmpFeedbackSystemDbContext _entities;

        public GoalRepository(AL_EmpFeedbackSystemDbContext entities)
        {
            _entities = entities;
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
                Goal goal = new Goal()
                {
                    Name = goalCreateRequest.Name,
                    Description = goalCreateRequest.Description,
                    CreatedBy = "SYSTEM",
                    CreatedDate = DateTime.Now,
                    UpdatedBy =null,
                    UpdatedDate = null,
                    IsActive = true,
                };

                _entities.Goals.Add(goal);
                var result = await _entities.SaveChangesAsync();

                if (result > 0)
                {
                    return "Goal Created successfully!";
                }
                else
                {
                    return "Something went wrong";
                }
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

            if (goalId > 0)
            {
                var goal = await _entities.Goals.FindAsync(goalId);
                if (goal != null)
                {
                    goal.IsActive = false;
                    await _entities.SaveChangesAsync();
                    return "Deleted Successfully";
                }
                else
                {
                    return "Goal not found";
                }
            }
            else
            {
                return "Invalid Input Params";
            }

        }

        /// <summary>
        /// Getting goal Details
        /// </summary>
        /// <returns>List of Goals.</returns>
        public async Task<List<GoalDetails>> GetGoalsList()
        {
            return await _entities.Goals.Where(x => x.IsActive == true)
                .Select(x => new GoalDetails
                {
                    Id = x.Id,
                    Name = x.Name,
                }).AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Getting Duration List
        /// </summary>
        /// <param name="frequencyId">The ID of the frequency.</param>
        /// <returns>List of Duration.</returns>
        public async Task<List<DurationDetail>> GetDurationList(int frequencyId)
        {
            return await _entities.Durations.Where(x => x.FrequencyId == frequencyId)
                .Select(x => new DurationDetail
                {
                    Id = x.Id,
                    Name = x.Name,
                }).AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Getting Frequency List
        /// </summary>
        /// <returns>List of Frequency.</returns>
        public async Task<List<FrequencyDetail>> GetFrequencyList()
        {
            return await _entities.Frequencies
                .Select(x => new FrequencyDetail
                {
                    Id = x.Id,
                    Name = x.Name,
                }).AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Getting Designation List
        /// </summary>
        /// <returns>List of Designation.</returns>
        public async Task<List<DesignationDetail>> GetDesignationList()
        {
            return await _entities.Designations
                .Select(x => new DesignationDetail
                {
                    Id = x.Id,
                    Name = x.Name,
                }).AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Getting the most recent goal details and total count of active goals.
        /// </summary>
        /// <returns>A tuple containing the list of recent goals and the total count of active goals.</returns>
        public async Task<List<GoalDetails>> GetRecentGoalsList()
        {

            // Query for the most recent three active goals
            var recentGoalsTask = await _entities.Goals
                .Where(x => x.IsActive == true)
                .OrderByDescending(x => x.CreatedDate)
                .Take(3)
                .Select(x => new GoalDetails
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                .AsNoTracking()
                .ToListAsync();
            return recentGoalsTask;
        }

    }
}
