using AL_EmpFeedbackSystem.Entity.Login;
using AL_EmpFeedbackSystem.Entity.Register;
using AL_EmpFeedbackSystem.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AL_EmpFeedbackSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest model)
        {
            try
            {
                var result = await _authService.RegisterAsync(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest model)
        {
            try
            {
                var token = await _authService.LoginAsync(model);
                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        //[Authorize(Roles = "Super Admin")]
        //[HttpGet("admin-data")]
        //public IActionResult GetAdminData()
        //{
        //    return Ok("This data is for Super Admin only.");
        //}

        //[Authorize(Roles = "Manager")]
        //[HttpGet("manager-data")]
        //public IActionResult GetManagerData()
        //{
        //    return Ok("This data is for Managers.");
        //}

    }
}
