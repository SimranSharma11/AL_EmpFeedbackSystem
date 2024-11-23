using AL_EmpFeedbackSystem.DbModels;
using AL_EmpFeedbackSystem.Entity.User;
using AL_EmpFeedbackSystem.Identity.Models;
using AL_EmpFeedbackSystem.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography;

namespace AL_EmpFeedbackSystem.Managers
{
    public class UserService : IUserService
    {

        private readonly AL_EmpFeedbackSystemDbContext _entities;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        public UserService(AL_EmpFeedbackSystemDbContext entities, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager) 
        {
            _entities = entities;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<string> CreateUser(UserCreate userCreate)
        {
            if (string.IsNullOrEmpty(userCreate.Id))
            {
                var user = new ApplicationUser();
                user.FirstName = userCreate.FirstName;
                user.LastName = userCreate.LastName;
                user.DataOfBirth = userCreate.DataOfBirth;
                user.Email = userCreate.Email;
                user.UserName = userCreate.Email;
                user.ActiveStatus = userCreate.ActiveStatus;
                user.LeadId = null;
                user.ManagerId = null;
                user.Address = userCreate.Address;
                user.PostalCode = userCreate.PostalCode;
                user.CreatedBy = "SYSTEM";
                var password = GeneratePassword();
                var result = await _userManager.CreateAsync(user, password);
                if (!result.Succeeded)
                    throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));

                var roleExists = await _roleManager.RoleExistsAsync(userCreate.RoleId);
                if (!roleExists)
                    throw new Exception("Role does not exist.");

                await _userManager.AddToRoleAsync(user, userCreate.RoleId);
                return "User registered successfully!";
            }
            else
            {
                var user = new ApplicationUser();
                user.Id = userCreate.Id;
                user.FirstName = userCreate.FirstName;
                user.LastName = userCreate.LastName;
                user.DataOfBirth = userCreate.DataOfBirth;
                user.Email = userCreate.Email;
                user.ActiveStatus = userCreate.ActiveStatus;
                user.LeadId = userCreate.LeadId;
                user.ManagerId = userCreate.ManagerId;
                user.Address = userCreate.Address;
                user.PostalCode = userCreate.PostalCode;
                user.UpdatedDate = DateTime.Now;
                var result = await _userManager.UpdateAsync(user);
                if (!result.Succeeded)
                    throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));

                var roleExists = await _roleManager.RoleExistsAsync(userCreate.RoleId);
                if (!roleExists)
                    throw new Exception("Role does not exist.");

                await _userManager.AddToRoleAsync(user, userCreate.RoleId);
                return "User Updated successfully!";
            }
        }

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

        private static int RandomNumber(RandomNumberGenerator rng, int max)
        {
            var bytes = new byte[4];
            rng.GetBytes(bytes);
            return BitConverter.ToInt32(bytes, 0) & int.MaxValue % max;
        }


    }
}
