using Microsoft.AspNetCore.Mvc;
using PatternsBusStorage.Api.DTOs;
using PatternsBusStorage.Api.DTOs.User;
using PatternsBusStorage.Application.Repositories;
using PatternsBusStorage.Bll.Services;
using PatternsBusStorage.Domain.Aggregates;

namespace PatternsBusStorage.Api.Controllers;

public class UserController : ControllerBase
{
        private readonly IUserRepository _userRepository;
        private readonly UserService _userService;

        public UserController(IUserRepository userRepository, UserService userService)
        {
            _userRepository = userRepository;
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationDto userDto)
        {

            
            // Check if the username is already taken
            if (await _userRepository.IsUsernameTaken(userDto.Username))
            {
                return Conflict("Username is already taken.");
            }

            // Create a new user
            User newUser = new User
            {
                Username = userDto.Username,
                Password = userDto.Password,
                RoleId = 2 // Assuming 2 corresponds to USER role
            };
            
            await _userService.AddUser(newUser);

            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userDto)
        {
            // Validation logic (you may want to add more validation)
            if (string.IsNullOrEmpty(userDto.Username) || string.IsNullOrEmpty(userDto.Password))
            {
                return BadRequest("Username and password are required.");
            }

            var user = await _userService.AuthenticateUser(userDto.Username, userDto.Password);

            return Ok("User logged in successfully.");
        }}