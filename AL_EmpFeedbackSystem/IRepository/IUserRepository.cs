﻿using AL_EmpFeedbackSystem.Entity.User;

namespace AL_EmpFeedbackSystem.IRepository
{
    public interface IUserRepository
    {
        /// <summary>
        /// Endpoint to create a new user.
        /// </summary>
        /// <param name="userCreate">The user details to create.</param>
        /// <returns>A response message indicating success or failure.</returns>
        Task<string> CreateUser(UserCreate userCreate);


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
        Task<UserCreate> GetUserByIdAsync(int userId);

        /// <summary>
        /// Delete a user by ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>A response message indicating success or failure.</returns>
        Task<string> DeleteUserByIdAsync(int userId);

        /// <summary>
        /// Get users assigned to the logged-in user.
        /// </summary>
        /// <returns>A list of assigned users.</returns>
        Task<List<UserCreate>> GetAssignedUserAsync(int userId);

        /// <summary>
        /// Get users list.
        /// </summary>
        /// <returns>A list of users Id and Name.</returns>
        Task<List<UserDetails>> GetUsersList();
    }
}
