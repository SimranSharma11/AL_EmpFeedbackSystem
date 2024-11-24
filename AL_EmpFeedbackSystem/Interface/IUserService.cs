using AL_EmpFeedbackSystem.Entity.User;

namespace AL_EmpFeedbackSystem.Interface
{
    public interface IUserService
    {
        /// <summary>
        /// Endpoint to create a new user.
        /// </summary>
        /// <param name="userCreate">The user details to create.</param>
        /// <returns>A response message indicating success or failure.</returns>
        Task<string> CreateUser(UserCreate userCreate);

        /// <summary>
        /// Get user details by ID.
        /// </summary>
        /// <param name="id">The ID of the user.</param>
        /// <returns>The user details.</returns>
        Task<UserCreate> GetUserById(int id);

        /// <summary>
        /// Delete a user by ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>A response message indicating success or failure.</returns>
        Task<string> DeleteUserByIdAsync(int id);

        /// <summary>
        /// Get users assigned to the logged-in user.
        /// </summary>
        /// <returns>A list of assigned users.</returns>
        Task<List<UserCreate>> GetAssignedUserAsync(int id);

        /// <summary>
        /// Get users list.
        /// </summary>
        /// <returns>A list of users Id and Name.</returns>
        Task<List<UserDetails>> GetUsersList();
    }
}