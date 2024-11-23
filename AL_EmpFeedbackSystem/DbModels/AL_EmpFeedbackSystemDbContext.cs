using AL_EmpFeedbackSystem.DbModels.Models;
using AL_EmpFeedbackSystem.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace AL_EmpFeedbackSystem.DbModels
{
    public class AL_EmpFeedbackSystemDbContext: IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public AL_EmpFeedbackSystemDbContext(DbContextOptions<AL_EmpFeedbackSystemDbContext> options) : base(options) { }

        public virtual DbSet<Goal> Goals { get; set; }
    }
}
