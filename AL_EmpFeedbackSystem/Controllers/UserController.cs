using AL_EmpFeedbackSystem.Entity.User;
using AL_EmpFeedbackSystem.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AL_EmpFeedbackSystem.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Endpoint to create a new user.
        /// </summary>
        /// <param name="userCreate">The user details to create.</param>
        /// <returns>A response message indicating success or failure.</returns>
        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] UserCreate userCreate)
        {
            try
            {
                var loggedInUserName = this.HttpContext.GetUserName();
                var result = await _userService.CreateUser(userCreate, loggedInUserName);
                return Ok(new { message = "User created successfully", data = result });
            }
            catch (Exception ex)
            {
                // Log exception (you can use ILogger here for logging)
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }

        /// <summary>
        /// Get user details by ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>The user details.</returns>
        [HttpGet("GetUserById")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            try
            {
                var result = await _userService.GetUserById(userId);
                if (result == null)
                {
                    return NotFound(new { message = "User not found" });
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }

        /// <summary>
        /// Delete a user by ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>A response message indicating success or failure.</returns>
        [HttpPost("DeleteUserById")]
        public async Task<IActionResult> DeleteUserByIdAsync(int userId)
        {
            try
            {
                var loggedInUserName = this.HttpContext.GetUserName();
                var result = await _userService.DeleteUserByIdAsync(userId, loggedInUserName);
                return Ok(new { message = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }

        /// <summary>
        /// Get users assigned to the logged-in user.
        /// </summary>
        /// <returns>A list of assigned users.</returns>
        [HttpGet("GetAssignedUser")]
        public async Task<IActionResult> GetAssignedUser()
        {
            try
            {
                var loggedInUserId = this.HttpContext.GetUserId();
                var result = await _userService.GetAssignedUserAsync(loggedInUserId);

                if (result == null || result.Count == 0)
                {
                    return NotFound(new { message = "No assigned users found" });
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }

        /// <summary>
        /// Get users list.
        /// </summary>
        /// <returns>A list of users Id and Name.</returns>
        [HttpGet("GetUsersList")]
        public async Task<IActionResult> GetUsersList()
        {
            try
            {
                var result = await _userService.GetUsersList();

                if (result == null || result.Count == 0)
                {
                    return NotFound(new { message = "No User Present." });
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }

        /// <summary>
        /// Get Designation list.
        /// </summary>
        /// <returns>A list of Designation Id and Name.</returns>
        [HttpGet("GetDesignationList")]
        public async Task<IActionResult> GetDesignationList()
        {
            try
            {
                var result = await _userService.GetDesignationList();

                if (result == null || result.Count == 0)
                {
                    return NotFound(new { message = "No User Present." });
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }


        /// <summary>
        /// Get Role list.
        /// </summary>
        /// <returns>A list of Role Id and Name.</returns>
        [HttpGet("GetRoleList")]
        public async Task<IActionResult> GetRoleList()
        {
            try
            {
                var result = await _userService.GetDesignationList();

                if (result == null || result.Count == 0)
                {
                    return NotFound(new { message = "No User Present." });
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }
    }
}