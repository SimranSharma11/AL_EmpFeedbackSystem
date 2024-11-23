using AL_EmpFeedbackSystem.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace AL_EmpFeedbackSystem.DbModels
{
    public class AL_EmpFeedbackSystemDbContext: IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public AL_EmpFeedbackSystemDbContext(DbContextOptions<AL_EmpFeedbackSystemDbContext> options) : base(options) { }
    }
}
