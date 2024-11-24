using AL_EmpFeedbackSystem.DbModels;
using AL_EmpFeedbackSystem.Entity.User;
using AL_EmpFeedbackSystem.Identity.Models;
using AL_EmpFeedbackSystem.Interface;
using AL_EmpFeedbackSystem.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography;

namespace AL_EmpFeedbackSystem.Managers
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {

            _userRepository = userRepository;

        }

        public async Task<string> CreateUser(UserCreate userCreate)
        {
            bool isEmailExist = false;
            if (userCreate.Id == 0)
                isEmailExist = await _userRepository.FindUserByEmail(userCreate.Email);
            if (!isEmailExist || userCreate.Id > 0)
            {
                var response = await _userRepository.CreateUser(userCreate);
                return response;
            }
            return "Email Already Exist";
        }

        public async Task<UserCreate> GetUserById(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            return user;
        }

        public async Task<string> DeleteUserByIdAsync(int id)
        {
            var result = await _userRepository.DeleteUserByIdAsync(id);
            return result;
        }

        public async Task<List<UserCreate>> GetAssignedUserAsync(int id)
        {
            var result = await _userRepository.GetAssignedUserAsync(id);
            return result;
        }

        
    }
}