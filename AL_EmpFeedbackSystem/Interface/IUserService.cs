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
        Task<string> CreateUser(User userCreate, string loggedInUserName);

        /// <summary>
        /// Get user details by ID.
        /// </summary>
        /// <param name="id">The ID of the user.</param>
        /// <returns>The user details.</returns>
        Task<User> GetUserById(int id);

        /// <summary>
        /// Delete a user by ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>A response message indicating success or failure.</returns>
        Task<string> DeleteUserByIdAsync(int id, string loggedInUserName);

        /// <summary>
        /// Get users assigned to the logged-in user.
        /// </summary>
        /// <returns>A list of assigned users.</returns>
        Task<List<User>> GetAssignedUserAsync(int id);

        /// <summary>
        /// Get users list.
        /// </summary>
        /// <returns>A list of users Id and Name.</returns>
        Task<List<ReferenceData>> GetUsersList();

        /// <summary>
        /// Get Designation list.
        /// </summary>
        /// <returns>A list of users Id and Name.</returns>
        Task<List<ReferenceData>> GetDesignationList();

        /// <summary>
        /// Get roles list.
        /// </summary>
        /// <returns>A list of roles Id and Name.</returns>
        Task<List<ReferenceData>> GetRoleList();

        /// <summary>
        /// Get UserDetails list.
        /// </summary>
        /// <returns>A list of UserDetails.</returns>
        Task<List<GetUserDetails>> GetAllUser();

        /// <summary>
        /// Get Recent Users list.
        /// </summary>
        /// <returns>A users list with Id and Name.</returns>
        Task<List<GetUserDetails>> GetRecentUser();
    }
}