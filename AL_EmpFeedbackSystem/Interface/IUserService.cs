using AL_EmpFeedbackSystem.Entity.Register;
using AL_EmpFeedbackSystem.Entity.User;

namespace AL_EmpFeedbackSystem.Interface
{
    public interface IUserService
    {
        Task<string> CreateUser(UserCreate userCreate);
    }
}
