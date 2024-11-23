using AL_EmpFeedbackSystem.Entity.User;
using AL_EmpFeedbackSystem.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AL_EmpFeedbackSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
                // Call the service to create the user and return the result
                var result = await _userService.CreateUser(userCreate);
                return Ok(result); // 200 OK response with the result message
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                Console.WriteLine($"Error: {ex.Message}");

                // Return a bad request response with the error message
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
