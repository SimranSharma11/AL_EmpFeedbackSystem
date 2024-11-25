using AL_EmpFeedbackSystem.DbModels;
using AL_EmpFeedbackSystem.Entity.User;
using AL_EmpFeedbackSystem.Extensions;
using AL_EmpFeedbackSystem.Identity.Models;
using AL_EmpFeedbackSystem.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace AL_EmpFeedbackSystem.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AL_EmpFeedbackSystemDbContext _entities;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IEmailSender _emailSender;

        public UserRepository(AL_EmpFeedbackSystemDbContext entities, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IEmailSender emailSender)
        {
            _entities = entities;
            _userManager = userManager;
            _roleManager = roleManager;
            _emailSender = emailSender;
        }

        /// <summary>
        /// CreateUser
        /// </summary>
        /// <param name="userCreate"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<string> CreateUser(User userCreate, string loggedInUserName)
        {
            var role = _entities.Roles.FirstOrDefault(x => x.Id == userCreate.RoleId);
            if (userCreate.Id == 0)
            {
                var user = new ApplicationUser();
                user.FirstName = userCreate.FirstName;
                user.LastName = userCreate.LastName;
                user.DateOfBirth = userCreate.DateOfBirth;
                user.Email = userCreate.Email;
                user.UserName = userCreate.Email;
                user.ActiveStatus = userCreate.ActiveStatus;
                user.ServiceStartDate = userCreate.ServiceStartDate;
                user.ServiceEndDate = userCreate.ServiceEndDate;
                user.DesignationId = userCreate.DesignationId;
                user.LeadId = userCreate.LeadId;
                user.ManagerId = userCreate.ManagerId;
                user.Address = userCreate.Address;
                user.PostalCode = userCreate.PostalCode;
                user.CreatedBy = loggedInUserName;
                var password = GeneratePassword();
                var result = await _userManager.CreateAsync(user, password);
                if (!result.Succeeded)
                    throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));

                var roleExists = await _roleManager.RoleExistsAsync(role.Name);
                if (!roleExists)
                    throw new Exception("Role does not exist.");

                await _userManager.AddToRoleAsync(user, role.Name);
                var emailSubject = "Your account has been created";
                var emailBody = $"Hello {user.FirstName} {user.LastName},\n\nYour account has been created successfully. " +
                                $"Your login password is: {password}\n\nPlease change your password after logging in.";

                try
                {
                    await _emailSender.SendEmailAsync(userCreate.Email, emailSubject, emailBody);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error sending email: {ex.Message}");
                }
                return "User registered successfully!";
            }
            else
            {
                var user = new ApplicationUser();
                user.Id = userCreate.Id;
                user.FirstName = userCreate.FirstName;
                user.LastName = userCreate.LastName;
                user.DateOfBirth = userCreate.DateOfBirth;
                user.Email = userCreate.Email;
                user.LeadId = userCreate.LeadId;
                user.ManagerId = userCreate.ManagerId;
                user.ActiveStatus = userCreate.ActiveStatus;
                user.ServiceStartDate = userCreate.ServiceStartDate;
                user.ServiceEndDate = userCreate.ServiceEndDate;
                user.Address = userCreate.Address;
                user.PostalCode = userCreate.PostalCode;
                user.UpdatedDate = DateTime.Now;
                user.UpdatedBy = loggedInUserName;
                var result = await _userManager.UpdateAsync(user);
                if (!result.Succeeded)
                    throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));
                if (role.Id != userCreate.RoleId)
                {
                    var roleExists = await _roleManager.RoleExistsAsync(role.Name);
                    if (!roleExists)
                        throw new Exception("Role does not exist.");

                    await _userManager.AddToRoleAsync(user, role.Name);
                }

                return "User Updated successfully!";
            }
        }

        /// <summary>
        /// GetAllUser
        /// </summary>
        /// <returns></returns>
        public async Task<List<GetUserDetails>> GetAllUser()
        {
            return await (from user in _entities.Users
                          join userRole in _entities.UserRoles on user.Id equals userRole.UserId into userRolesGroup
                          from userRole in userRolesGroup.DefaultIfEmpty()
                          join role in _entities.Roles on userRole.RoleId equals role.Id into rolesGroup
                          from role in rolesGroup.DefaultIfEmpty()
                          select new GetUserDetails
                          {
                              Id = user.Id,
                              FirstName = user.FirstName,
                              LastName = user.LastName,
                              ManagerName = user.ManagerId > 0
                                  ? user.Manager.FirstName.GetFullName(user.Manager.LastName)
                                  : "",
                              LeadName = user.LeadId > 0
                                  ? user.Lead.FirstName.GetFullName(user.Lead.LastName)
                                  : "",
                              Email = user.Email,
                              DateOfBirth = user.DateOfBirth,
                              ServiceEndDate = user.ServiceEndDate,
                              ServiceStartDate = user.ServiceStartDate,
                              PostalCode = user.PostalCode,
                              Address = user.Address,
                              ActiveStatus = user.ActiveStatus,
                              Designation = user.Designation.Name,
                              UserRole = role != null ? role.Name : "No Role"
                          }).ToListAsync();
        }

        /// <summary>
        /// Finding User By Email.
        /// </summary>
        /// <returns></returns>
        public async Task<bool> FindUserByEmail(string email)
        {
            var user = await _entities.Users.Where(x => x.Email.Equals(email)).ToListAsync();
            return user.Count() > 0 ? true : false;

        }

        /// <summary>
        /// Generating Password.
        /// </summary>
        /// <returns></returns>
        private static string GeneratePassword(int length = 8)
        {
            const string upperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string lowerCase = "abcdefghijklmnopqrstuvwxyz";
            const string digits = "0123456789";
            const string specialChars = "!@#$%^&*()";

            // Combine the valid character sets
            const string validChars = upperCase + lowerCase + digits + specialChars;

            // Generate a password
            var password = new char[length];

            using (var rng = RandomNumberGenerator.Create())
            {
                // Ensure at least one character from each category (upper, lower, digit, special) is included
                password[0] = upperCase[RandomNumber(rng, upperCase.Length)];
                password[1] = lowerCase[RandomNumber(rng, lowerCase.Length)];
                password[2] = digits[RandomNumber(rng, digits.Length)];
                password[3] = specialChars[RandomNumber(rng, specialChars.Length)];

                // Fill in the rest of the password with random characters from the valid set
                for (int i = 4; i < length; i++)
                {
                    password[i] = validChars[RandomNumber(rng, validChars.Length)];
                }

                // Shuffle the password to ensure randomness
                return new string(password.OrderBy(c => RandomNumberGenerator.GetInt32(0, length)).ToArray());
            }
        }

        /// <summary>
        /// Random Number.
        /// </summary>
        /// <returns></returns>
        private static int RandomNumber(RandomNumberGenerator rng, int max)
        {
            var bytes = new byte[4];
            rng.GetBytes(bytes);
            return BitConverter.ToInt32(bytes, 0) & int.MaxValue % max;
        }

        /// <summary>
        /// GetUserByIdAsync
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<User> GetUserByIdAsync(int userId)
        {
            if (userId <= 0)
            {
                throw new ArgumentException("Invalid user ID", nameof(userId));
            }

            var user = await _entities.Users.FindAsync(userId);

            if (user == null)
            {
                return null;
            }

            var userCreate = new User
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                LeadId = user.LeadId,
                ManagerId = user.ManagerId,
                Address = user.Address,
                PostalCode = user.PostalCode
            };

            var userRole = await _entities.UserRoles.FirstOrDefaultAsync(x => x.UserId == user.Id);
            if (userRole != null)
            {
                userCreate.RoleId = userRole.RoleId;
            }

            return userCreate;
        }

        /// <summary>
        /// DeleteUserByIdAsync
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<string> DeleteUserByIdAsync(int userId, string loggedInUserName)
        {

            if (userId > 0)
            {
                var user = await _entities.Users.FindAsync(userId);
                if (user != null)
                {
                    user.ActiveStatus = false;
                    user.IsDeleted = true;
                    user.UpdatedDate = DateTime.UtcNow;
                    user.UpdatedBy = loggedInUserName;
                    await _entities.SaveChangesAsync();
                    return "Deleted Successfully";
                }
                else
                {
                    return "User not found";
                }
            }
            else
            {
                return "Invalid User";
            }

        }

        /// <summary>
        /// GetAssignedUserAsync
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<User>> GetAssignedUserAsync(int userId)
        {
            return await _entities.Users.Where(x => (x.LeadId == userId || x.ManagerId == userId) && x.ActiveStatus == true && x.IsDeleted == false)
                .Select(x => new User
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    DateOfBirth = x.DateOfBirth,
                    Email = x.Email,
                    LeadId = x.LeadId,
                    ManagerId = x.ManagerId,
                    Address = x.Address,
                    PostalCode = x.PostalCode
                }).ToListAsync();
        }

        /// <summary>
        /// GetUsersList
        /// </summary>
        /// <returns></returns>
        public async Task<List<ReferenceData>> GetUsersList()
        {
            return await _entities.Users.Where(x => x.ActiveStatus == true && x.IsDeleted == false)
                .Select(x => new ReferenceData
                {
                    Id = x.Id,
                    Name = x.FirstName.GetFullName(x.LastName),
                }).AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// GetDesignationList
        /// </summary>
        /// <returns></returns>
        public async Task<List<ReferenceData>> GetDesignationList()
        {
            return await _entities.Designations.Where(x => x.IsActive == true)
                .Select(x => new ReferenceData
                {
                    Id = x.Id,
                    Name = x.Name,
                }).AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// GetDesignationList
        /// </summary>
        /// <returns></returns>
        public async Task<List<ReferenceData>> GetRoleList()
        {
            return await _entities.Roles
                .Select(x => new ReferenceData
                {
                    Id = x.Id,
                    Name = x.Name,
                }).AsNoTracking().ToListAsync();
        }
    }
}