using AL_EmpFeedbackSystem.Entity.Login;
using AL_EmpFeedbackSystem.Entity.Register;

namespace AL_EmpFeedbackSystem.Interface
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(RegisterRequest model);
        Task<string> LoginAsync(LoginRequest model);
    }
}
