﻿using AL_EmpFeedbackSystem.Entity.Goal;
using AL_EmpFeedbackSystem.Entity.User;
using AL_EmpFeedbackSystem.Interface;
using AL_EmpFeedbackSystem.Managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AL_EmpFeedbackSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GoalController : ControllerBase
    {
        private readonly IGoalService _goalService;

        public GoalController(IGoalService goalService)
        {
            _goalService =goalService;
        }

        /// <summary>
        /// Endpoint to create a new goal.
        /// </summary>
        /// <param name="goalCreateRequest">The goals details to create.</param>
        /// <returns>A response message indicating success or failure.</returns>
        [HttpPost("CreateGoal")]
        public async Task<IActionResult> CreateGoal([FromBody] GoalCreateRequest goalCreateRequest)
        {
            try
            {
                var result = await _goalService.CreateGoal(goalCreateRequest);
                return Ok(new { message = "Goal created successfully", data = result });
            }
            catch (Exception ex)
            {
                // Log exception (you can use ILogger here for logging)
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }

        /// <summary>
        /// Delete a goal by ID.
        /// </summary>
        /// <param name="goalId">The ID of the goal.</param>
        /// <returns>A response message indicating success or failure.</returns>
        [HttpDelete("DeleteGoalById")]
        public async Task<IActionResult> DeleteGoalByIdAsync(int goalId)
        {
            try
            {
                var result = await _goalService.DeleteGoalByIdAsync(goalId);
                return Ok(new { message = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }

        /// <summary>
        /// Getting goal Details
        /// </summary>
        /// <returns>List of Goals.</returns>
        [HttpGet("GetGoalsList")]
        public async Task<IActionResult> GetGoalsList()
        {
            try
            {
                var result = await _goalService.GetGoalsList();

                if (result == null || result.Count == 0)
                {
                    return NotFound(new { message = "No Goals Present." });
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }

        /// <summary>
        /// Getting Duration List
        /// </summary>
        /// <param name="frequencyId">The ID of the frequency.</param>
        /// <returns>List of Duration.</returns>
        [HttpGet("GetDurationListByFreqId")]
        public async Task<IActionResult> GetDurationList(int frequencyId)
        {
            try
            {
                var result = await _goalService.GetDurationList(frequencyId);

                if (result == null || result.Count == 0)
                {
                    return NotFound(new { message = "Empty." });
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }

        /// <summary>
        /// Getting FrequencyList List
        /// </summary>
        /// <returns>List of Duration.</returns>
        [HttpGet("GetFrequencyList")]
        public async Task<IActionResult> GetFrequencyList()
        {
            try
            {
                var result = await _goalService.GetFrequencyList();

                if (result == null || result.Count == 0)
                {
                    return NotFound(new { message = "Empty." });
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }

        /// <summary>
        /// Getting Designation List
        /// </summary>
        /// <returns>List of Designations.</returns>
        [HttpGet("GetDesignationList")]
        public async Task<IActionResult> GetDesignationList()
        {
            try
            {
                var result = await _goalService.GetDesignationList();

                if (result == null || result.Count == 0)
                {
                    return NotFound(new { message = "Empty." });
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }

        /// <summary>
        /// Getting recent goals List
        /// </summary>
        /// <returns>List of Goals.</returns>
        [HttpGet("GetRecentGoalsList")]
        public async Task<IActionResult> GetRecentGoalsList()
        {
            try
            {
                var result = await _goalService.GetRecentGoalsList();

                if (result == null || result.Count == 0)
                {
                    return NotFound(new { message = "No Goals Present." });
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
