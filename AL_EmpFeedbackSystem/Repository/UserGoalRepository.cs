using AL_EmpFeedbackSystem.DbModels;
using AL_EmpFeedbackSystem.DbModels.Entity;
using AL_EmpFeedbackSystem.Entity.UserGoalSetting;
using AL_EmpFeedbackSystem.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace AL_EmpFeedbackSystem.Repository
{
    public class UserGoalRepository : IUserGoalRepository
    {
        private readonly AL_EmpFeedbackSystemDbContext _entities;

        public UserGoalRepository(AL_EmpFeedbackSystemDbContext entities)
        {
            _entities = entities;
        }

        public async Task<string> CreateUserGoal(List<CreateUserGoal> createUserGoal, string loggedInUserName)
        {
            if (createUserGoal == null || !createUserGoal.Any())
            {
                return "No user goals to create.";
            }

            List<UserGoalSetting> userGoalSettings = new List<UserGoalSetting>();
            foreach (CreateUserGoal userGoal in createUserGoal)
            {
                var goalSetting = new UserGoalSetting
                {
                    UserId = userGoal.UserId,
                    DurationId = userGoal.DurationId,
                    GoalId = userGoal.GoalId,
                    CreatedBy = loggedInUserName,
                    CreatedDate = DateTime.Now
                };
                userGoalSettings.Add(goalSetting);
            }

            await _entities.UserGoalSettings.AddRangeAsync(userGoalSettings);
            await _entities.SaveChangesAsync();

            return "User goals created successfully.";
        }

        public async Task<List<UserGoal>> GetUserGoalList()
        {
            var userGoals = await _entities.UserGoalSettings
                .Select(x => new UserGoal
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    DurationId = x.DurationId,
                    GoalId = x.GoalId,
                    CreatedBy = x.CreatedBy,
                    CreatedDate = x.CreatedDate
                })
                .ToListAsync();

            return userGoals;
        }


        public async Task<List<UserGoal>> GetSelfGoalList(int loggedInUserId)
        {
            var selfGoals = await _entities.UserGoalSettings
                .Where(x => x.UserId == loggedInUserId)
                .Select(x => new UserGoal
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    DurationId = x.DurationId,
                    GoalId = x.GoalId,
                    CreatedBy = x.CreatedBy,
                    CreatedDate = x.CreatedDate
                })
                .ToListAsync();

            return selfGoals;
        }


        public async Task<List<UserGoal>> GetLeadGoalList(int loggedInUserId)
        {
            var userIds = await _entities.Users
                .Where(x => x.LeadId == loggedInUserId || x.ManagerId == loggedInUserId)
                .Select(x => x.Id)
                .ToListAsync();

            var leadGoals = await _entities.UserGoalSettings
                .Where(x => userIds.Contains(x.UserId))
                .Select(x => new UserGoal
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    DurationId = x.DurationId,
                    GoalId = x.GoalId,
                    CreatedBy = x.CreatedBy,
                    CreatedDate = x.CreatedDate
                })
                .ToListAsync();

            return leadGoals;
        }


        public async Task<UserGoal?> GetUserGoalById(int userGoalId)
        {
            var userGoalSettings = await _entities.UserGoalSettings.FirstOrDefaultAsync(x => x.Id == userGoalId);

            if (userGoalSettings == null)
            {
                return null;
            }

            var userGoal = new UserGoal
            {
                Id = userGoalSettings.Id,
                UserId = userGoalSettings.UserId,
                DurationId = userGoalSettings.DurationId,
                GoalId = userGoalSettings.GoalId,
                LeadComment = userGoalSettings.LeadComment,
                SelfComment = userGoalSettings.SelfComment,
                LeadRating = userGoalSettings.LeadRating,
                SelfRating = userGoalSettings.SelfRating,
                CreatedBy = userGoalSettings.CreatedBy,
                CreatedDate = userGoalSettings.CreatedDate,
                UpdatedDate = userGoalSettings.UpdatedDate,
                UpdatedBy = userGoalSettings.UpdatedBy
            };

            return userGoal;
        }


        public async Task<string> UpdateUserGoal(UserGoal updatedGoal, string updatedBy)
        {
            if (updatedGoal == null)
                throw new ArgumentNullException(nameof(updatedGoal), "Updated goal cannot be null.");

            var existingGoal = await _entities.UserGoalSettings.FirstOrDefaultAsync(g => g.Id == updatedGoal.Id);

            if (existingGoal == null)
                throw new InvalidOperationException($"No goal found with ID {updatedGoal.Id}.");

            existingGoal.DurationId = updatedGoal.DurationId;
            existingGoal.GoalId = updatedGoal.GoalId;
            existingGoal.LeadComment = updatedGoal.LeadComment;
            existingGoal.SelfComment = updatedGoal.SelfComment;
            existingGoal.LeadRating = updatedGoal.LeadRating;
            existingGoal.SelfRating = updatedGoal.SelfRating;
            existingGoal.UpdatedBy = updatedBy;
            existingGoal.UpdatedDate = DateTime.Now;

            await _entities.SaveChangesAsync();

            return $"Goal with ID {updatedGoal.Id} has been successfully updated.";
        }
    }
}
