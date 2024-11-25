using AL_EmpFeedbackSystem.Entity.User;

namespace AL_EmpFeedbackSystem.IRepository
{
    public interface IUserRepository
    {
        /// <summary>
        /// Endpoint to create a new user.
        /// </summary>
        /// <param name="userCreate">The user details to create.</param>
        /// <returns>A response message indicating success or failure.</returns>
        Task<string> CreateUser(User userCreate, string loggedInUserName);


        /// <summary>
        /// Finding User By Email.
        /// </summary>
        /// <returns></returns>
        Task<bool> FindUserByEmail(string email);

        /// <summary>
        /// Get user details by ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>The user details.</returns>
        Task<User> GetUserByIdAsync(int userId);

        /// <summary>
        /// Delete a user by ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>A response message indicating success or failure.</returns>
        Task<string> DeleteUserByIdAsync(int userId, string loggedInUserName);

        /// <summary>
        /// Get users assigned to the logged-in user.
        /// </summary>
        /// <returns>A list of assigned users.</returns>
        Task<List<User>> GetAssignedUserAsync(int userId);

        /// <summary>
        /// Get users list.
        /// </summary>
        /// <returns>A list of users Id and Name.</returns>
        Task<List<ReferenceData>> GetUsersList();

        /// <summary>
        /// Get Designation list.
        /// </summary>
        /// <returns>A list of Designation Id and Name.</returns>
        Task<List<ReferenceData>> GetDesignationList();

        /// <summary>
        /// Get Role list.
        /// </summary>
        /// <returns>A list of Roles Id and Name.</returns>
        Task<List<ReferenceData>> GetRoleList();

        /// <summary>
        /// Get Userdetail list.
        /// </summary>
        /// <returns>A list of Userdetail</returns>
        Task<List<GetUserDetails>> GetAllUser();
    }
}
