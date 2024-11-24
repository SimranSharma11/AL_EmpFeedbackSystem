using AL_EmpFeedbackSystem.Entity.User;
using AL_EmpFeedbackSystem.Interface;
using AL_EmpFeedbackSystem.IRepository;

namespace AL_EmpFeedbackSystem.Managers
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {

            _userRepository = userRepository;

        }

        /// <summary>
        /// Endpoint to create a new user.
        /// </summary>
        /// <param name="userCreate">The user details to create.</param>
        /// <returns>A response message indicating success or failure.</returns>
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

        /// <summary>
        /// Get user details by ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>The user details.</returns>
        public async Task<UserCreate> GetUserById(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            return user;
        }

        /// <summary>
        /// Delete a user by ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>A response message indicating success or failure.</returns>
        public async Task<string> DeleteUserByIdAsync(int id)
        {
            var result = await _userRepository.DeleteUserByIdAsync(id);
            return result;
        }

        /// <summary>
        /// Get users assigned to the logged-in user.
        /// </summary>
        /// <returns>A list of assigned users.</returns>
        public async Task<List<UserCreate>> GetAssignedUserAsync(int id)
        {
            var result = await _userRepository.GetAssignedUserAsync(id);
            return result;
        }


        /// <summary>
        /// Get users list.
        /// </summary>
        /// <returns>A list of users Id and Name.</returns>
        public async Task<List<UserDetails>> GetUsersList()
        {
            var result = await _userRepository.GetUsersList();
            return result;
        }
    }
}