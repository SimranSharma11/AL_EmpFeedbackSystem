using AL_EmpFeedbackSystem.Entity.User;
using AL_EmpFeedbackSystem.Identity.Models;

namespace AL_EmpFeedbackSystem.IRepository
{
    public interface IUserRepository
    {
        Task<string> CreateUser(UserCreate userCreate);
        Task<bool> FindUserByEmail(string email);
        Task<UserCreate> GetUserByIdAsync(int userId);
        Task<string> DeleteUserByIdAsync(int userId);
        Task<List<UserCreate>> GetAssignedUserAsync(int userId);
    }
}
