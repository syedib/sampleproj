using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;
using WebApi.Models;
using WebApi.Repositories;
using WebApi.Services;
using WebApi.Utils;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserRepository _userRepository;
    public AuthController(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [AllowAnonymous]
    [HttpPost("CreateUser")]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserDto userRequest) 
    {
        if (string.IsNullOrEmpty(userRequest.UserName) || string.IsNullOrEmpty(userRequest.Password)) 
        {
            return BadRequest("Incorrect username and password format");
        }

        User user = new User(userRequest.Fullname, userRequest.DateOfBirth) 
        { 
            Email = userRequest.UserName,
            NormalizedEmail = userRequest.UserName.ToUpper(),
            UserName = userRequest.UserName, 
            NormalizedUserName = userRequest.UserName.ToUpper(),
            PasswordHash = PasswordHasher.HashPassword(userRequest.Password) 
        };

        var result = await _userRepository.CreateUser(user);

        return Ok(result);
    }

    [AllowAnonymous]
    [HttpPost("LoginUser")]
    public async Task<IActionResult> Login([FromBody] LoginUser loginUser) 
    {
        var user = await _userRepository.FindUserByEmail(loginUser.UserName);

        if (user == null)
        {
            return NotFound("User not found");
        }

        //Verify Password
        if (!PasswordHasher.Verify(loginUser.Password, user.PasswordHash)) 
        {
            return BadRequest("Invalid Credentials");
        }

        var token = TokenService.GenerateToken(user.Id, user.Email);

        return Ok(new TokenVm(token));
    }

}
