using AL_EmpFeedbackSystem.Entity.Register;
using AL_EmpFeedbackSystem.Entity.UserGoalSetting;
using AL_EmpFeedbackSystem.Interface;
using AL_EmpFeedbackSystem.Managers;
using Microsoft.AspNetCore.Mvc;

namespace AL_EmpFeedbackSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGoalController : Controller
    {
        private readonly IUserGoalService _userGoalService;

        public UserGoalController(IUserGoalService userGoalService)
        {
            _userGoalService = userGoalService;
        }

        [HttpPost("CreateUserGoal")]
        public async Task<IActionResult> CreateUserGoal(List<CreateUserGoal> createUserGoal)
        {
            try
            {
                var loggedInUserName = this.HttpContext.GetUserName();
                var result = await _userGoalService.CreateUserGoal(createUserGoal, loggedInUserName);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get a list of all user goals.
        /// </summary>
        [HttpGet("GetAllUserGoalList")]
        public async Task<IActionResult> GetUserGoalList()
        {
            var userGoals = await _userGoalService.GetUserGoalList();
            return Ok(userGoals);
        }

        /// <summary>
        /// Get a list of goals for the currently logged-in user.
        /// </summary>
        [HttpGet("GetSelfGoalList")]
        public async Task<IActionResult> GetSelfGoalList()
        {
            var loggedInUserId = this.HttpContext.GetUserId();
            var userGoals = await _userGoalService.GetSelfGoalList(loggedInUserId);
            return Ok(userGoals);
        }

        /// <summary>
        /// Get a list of goals for the users reporting to the specified lead/manager.
        /// </summary>
        [HttpGet("GetLeadGoalList")]
        public async Task<IActionResult> GetLeadGoalList()
        {
            var loggedInUserName = this.HttpContext.GetUserName();
            var leadGoals = await _userGoalService.GetLeadGoalList(loggedInUserName);
            return Ok(leadGoals);
        }

        /// <summary>
        /// Get a specific user goal by its ID.
        /// </summary>
        [HttpGet("GetUserGoalById")]
        public async Task<IActionResult> GetUserGoalById(int userGoalId)
        {
            var userGoal = await _userGoalService.GetUserGoalById(userGoalId);
            if (userGoal == null)
                return NotFound($"No user goal found with ID {userGoalId}");

            return Ok(userGoal);
        }

        /// <summary>
        /// Update a specific user goal.
        /// </summary>
        [HttpPost("UpdateUserGoal")]
        public async Task<IActionResult> UpdateUserGoal([FromBody] UserGoal updatedGoal)
        {
            if (updatedGoal == null)
                return BadRequest("Updated goal data cannot be null.");

            try
            {
                var loggedInUserName = this.HttpContext.GetUserName();
                var result = await _userGoalService.UpdateUserGoal(updatedGoal, loggedInUserName);
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        /// <summary>
        /// Get a list of goals for the users reporting to the specified lead/manager.
        /// </summary>
        [HttpGet("GetRecentPendingSelfGoalList")]
        public async Task<IActionResult> GetRecentPendingSelfGoalList()
        {
            var loggedInUserId = this.HttpContext.GetUserId();
            var leadGoals = await _userGoalService.GetRecentPendingSelfGoalList(loggedInUserId);
            return Ok(leadGoals);
        }

        /// <summary>
        /// Get a list of goals where logged in user is Lead for the users reporting to the specified lead/manager.
        /// </summary>
        [HttpGet("GetRecentPendingLeadGoalList")]
        public async Task<IActionResult> GetRecentPendingLeadGoalList()
        {
            var loggedInUserId = this.HttpContext.GetUserId();
            var leadGoals = await _userGoalService.GetRecentPendingLeadGoalList(loggedInUserId);
            return Ok(leadGoals);
        }
    }
}
