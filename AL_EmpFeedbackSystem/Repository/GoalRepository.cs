using AL_EmpFeedbackSystem.DbModels;
using AL_EmpFeedbackSystem.DbModels.Entity;
using AL_EmpFeedbackSystem.Entity.Goal;
using AL_EmpFeedbackSystem.Entity.User;
using AL_EmpFeedbackSystem.Extensions;
using AL_EmpFeedbackSystem.Identity.Models;
using AL_EmpFeedbackSystem.IRepository;
using Microsoft.AspNetCore.Identity;
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
    }
}
