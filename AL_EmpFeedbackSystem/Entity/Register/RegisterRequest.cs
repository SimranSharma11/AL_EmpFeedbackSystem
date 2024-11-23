using System.ComponentModel.DataAnnotations;

namespace AL_EmpFeedbackSystem.Entity.Register
{
    public class RegisterRequest
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }

        public string Role { get; set; }

        public string FullName { get; set; }
    }
}
