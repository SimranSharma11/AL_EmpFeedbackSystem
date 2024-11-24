using AL_EmpFeedbackSystem.Entity.Register;
using AL_EmpFeedbackSystem.Entity.User;

namespace AL_EmpFeedbackSystem.Interface
{
    public interface IUserService
    {
        Task<string> CreateUser(UserCreate userCreate);
        Task<UserCreate> GetUserById(int id);
        Task<string> DeleteUserByIdAsync(int id);
        Task<List<UserCreate>> GetAssignedUserAsync(int id);
    }
}