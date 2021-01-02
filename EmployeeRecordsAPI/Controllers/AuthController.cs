using EmployeeRecordsAPI.DTOs;
using EmployeeRecordsAPI.Helpers;
using EmployeeRecordsAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRecordsAPI.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        // /auth/signup
        [AllowAnonymous]
        [HttpPost("signup")]
        public async Task<IActionResult> SignUpAsync([FromBody] SignUpDTO model)
        {
            UserManagerResponse response;
            if (!ModelState.IsValid)
            {
                response = CreateResponse.Create("Some model properties are not valid", false, null);

                return BadRequest(response);
            }

            if (model.Password != model.ConfirmPassword)
            {
                response = CreateResponse.Create("Passwords do not match", false, null);

                return BadRequest(response);
            }

            var emailMatch = await _userManager.FindByEmailAsync(model.Email);

            if (emailMatch != null)
            {
                response = CreateResponse.Create("Email already taken", false, null);

                return BadRequest(response);
            }

            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                UserName = model.Email,
            };

            var createUser = await _userManager.CreateAsync(user, model.Password);

            if (createUser.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, model.Role);

                response = CreateResponse.Create("User created", true, null);

                return Ok(response);
            }

            var errors = createUser.Errors.Select(e => e.Description);

            response = CreateResponse.Create("User was not created", false, errors);

            return BadRequest(response);
        }

        // /auth/login
        [AllowAnonymous]
        [HttpPost("signin")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDTO model)
        {
            UserManagerResponse response;
            if (!ModelState.IsValid)
            {
                response = CreateResponse.Create("Some model properties are not valid", false, null);

                return BadRequest(response);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                response = CreateResponse.Create("User does not exist", false, null);

                return BadRequest(response);
            }

            var signin = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: model.RememberMe, false);

            if (signin.Succeeded)
            {
                var token = JwtTokenConfig.GetToken(user, _configuration);

                response = CreateResponse.Create(token, true, null);

                return Ok(response);
            }

            response = CreateResponse.Create("Invalid credentials!", false, null);

            return Unauthorized(response);
        }

        // /auth/logout
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            var response = CreateResponse.Create("Logged out successfully", true, null);

            return Ok(response);
        }
    }
}
