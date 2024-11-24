using AL_EmpFeedbackSystem.Entity.Login;
using AL_EmpFeedbackSystem.Entity.Register;
using AL_EmpFeedbackSystem.Identity.Models;
using AL_EmpFeedbackSystem.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AL_EmpFeedbackSystem.Managers
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthService(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task<string> RegisterAsync(RegisterRequest model)
        {
            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                PostalCode = model.PostalCode,
                DesignationId = (int)(model.DesignationId > 0 ? model.DesignationId : 5),
                ActiveStatus = true,
                CreatedBy = "SYSTEM",
                CreatedDate = DateTime.Now,
                UpdatedBy = null,
                UpdatedDate = null
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));

            var roleExists = await _roleManager.RoleExistsAsync(model.Role);
            if (!roleExists)
                throw new Exception("Role does not exist.");

            await _userManager.AddToRoleAsync(user, model.Role);
            return "User registered successfully!";
        }

        public async Task<string> LoginAsync(LoginRequest model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
                throw new Exception("Invalid credentials.");

            return GenerateJwtToken(user, _configuration, _userManager);
        }

        private string GenerateJwtToken(ApplicationUser user, IConfiguration configuration, UserManager<ApplicationUser> userManager)
        {
            var roles = userManager.GetRolesAsync(user).Result;

            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, user.UserName),
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new Claim("loggedInUserName", user.FirstName + " " + user.LastName)
    };
            claims.AddRange(roles.Select(role => new Claim("role", role)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(3),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
