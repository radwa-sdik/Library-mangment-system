using AutoMapper;
using Library.DTOs;
using Library.Helpers;
using Library.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    /// <summary>
    /// Controller responsible for user authentication operations including registration and login.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JWTHandler _jWTHandler;

        /// <summary>
        /// Initializes a new instance of the AccountController class.
        /// </summary>
        /// <param name="mapper">AutoMapper instance for object mapping</param>
        /// <param name="userManager">ASP.NET Core Identity UserManager</param>
        /// <param name="jWTHandler">JWT token generation handler</param>
        public AccountController(IMapper mapper, UserManager<ApplicationUser> userManager, JWTHandler jWTHandler)
        {
            _mapper = mapper;
            _userManager = userManager;
            _jWTHandler = jWTHandler;
        }

        /// <summary>
        /// Registers a new user in the system.
        /// </summary>
        /// <param name="reqDTO">Sign-up request containing email, password, and role information</param>
        /// <returns>Created response with UserId if successful, BadRequest if validation fails</returns>
        /// <response code="201">User registered successfully</response>
        /// <response code="400">Invalid model state or registration failed</response>
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] SignUpReqDTO reqDTO)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(new { Errors = errors });
            }

            var member = new ApplicationUser
            {
                UserName = reqDTO.Name,
                Email = reqDTO.Email,
                PhoneNumber = reqDTO.PhoneNumber,
                Address = reqDTO.Address,
                MembershipDate = DateTime.Now,
                isActive = true,
                CreatedAt = DateTime.Now,
                LastLogin = DateTime.Now
            };

            var result = await _userManager.CreateAsync(member, reqDTO.Password);

            if (!result.Succeeded)
                return BadRequest(new { Errors = result.Errors.Select(e => e.Description).ToList() });

            await _userManager.AddToRoleAsync(member, reqDTO.Role.ToString());
            return Created("", new { Message = "User registered successfully", UserId = member.Id });
        }

        /// <summary>
        /// Authenticates a user and returns a JWT token.
        /// </summary>
        /// <param name="reqDTO">Sign-in request containing email and password</param>
        /// <returns>OK response with JWT token and user information if successful, Unauthorized if credentials are invalid</returns>
        /// <response code="200">User authenticated successfully with JWT token</response>
        /// <response code="400">Invalid model state</response>
        /// <response code="401">Invalid email or password</response>
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> LogIn([FromBody] SignInReqDTO reqDTO)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(new { Errors = errors });
            }

            var user = await _userManager.FindByEmailAsync(reqDTO.Email);
            if (user == null)
                return Unauthorized(new { Message = "Invalid Email or Password." });

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, reqDTO.Password);
            if (!isPasswordValid)
                return Unauthorized(new { Message = "Invalid Email or Password." });

            var userRoles = await _userManager.GetRolesAsync(user);
            var token = _jWTHandler.GenerateToken(user.Id, user.UserName ?? user.Email ?? "", userRoles);

            user.LastLogin = DateTime.Now;

            return Ok(new
            {
                Token = token,
                UserId = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Roles = userRoles
            });
        }

        
    }
}
