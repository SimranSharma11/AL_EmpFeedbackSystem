using AL_EmpFeedbackSystem.DbModels.Entity;
using AL_EmpFeedbackSystem.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace AL_EmpFeedbackSystem.DbModels
{
    public class AL_EmpFeedbackSystemDbContext: IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public AL_EmpFeedbackSystemDbContext(DbContextOptions<AL_EmpFeedbackSystemDbContext> options) : base(options) { }
        public virtual DbSet<Designation> Designations { get; set; }
    }
}
