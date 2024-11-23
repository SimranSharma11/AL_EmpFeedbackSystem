using System.ComponentModel.DataAnnotations;

namespace AL_EmpFeedbackSystem.Entity.Login
{
    public class LoginRequest
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }

        public string Email { get; set; }
    }
}
