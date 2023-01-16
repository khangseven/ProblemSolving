using IdentityServer4.Stores;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProblemSolving.Domain.Entities;
using ProblemSolving.Domain.Interfaces;
using ProblemSolving.Domain.ValueObjects;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ProblemSolving.Application.Controllers.UserController
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        public readonly IUserRepository _userRepo;
        private readonly ISigningCredentialStore _signingCredentialStore;

        public UserController(IUserRepository userRepo, ISigningCredentialStore signingCredentialStore)
        {
            _userRepo = userRepo;
            _signingCredentialStore = signingCredentialStore;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userRepo.GetUsers();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(Guid id)
        {
            return await _userRepo.GetUser(id);
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUser(AddUserReq user)
        {
            if (await _userRepo.GetUser(user.UserName) is not null)
            {
                var newUser = new User(new Guid(), user.UserName, user.PassWord, user.FullName, DateTime.UtcNow);
                return await _userRepo.PostUser(newUser);
            }
            else return BadRequest("User name is already in use");
        }

        [HttpPut]
        public async Task<ActionResult<User>> UpdateUser(UpdateUserReq user)
        {
            var userUpdate = await _userRepo.GetUser(user.UserId);
            if(userUpdate is null)
            {
                return NotFound();
            }
            else
            {
                userUpdate.FullName = FullName.Create(user.Fullname);
                userUpdate.PassWord = PassWord.Create(user.Password);
                await _userRepo.UpdateUser(userUpdate);
                return Ok(userUpdate);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(Guid UserId)
        {
            var userUpdate = await _userRepo.GetUser(UserId);
            if (userUpdate is null)
            {
                return NotFound();
            }
            else
            {
                await _userRepo.DeleteUser(UserId);
                return Ok();
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string username, string password)
        {

            var user = await _userRepo.GetUser(username);
            Debug.WriteLine(user);
            if (user is null)
            {
                return NotFound();
            }
            else
            {
                if(user.UserName.Value == username && user.PassWord.Value == password)
                {
                    var signingCredentials = await _signingCredentialStore.GetSigningCredentialsAsync();
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new[] { new Claim("userId", user.Id.ToString())}),
                        Issuer = "Problem solving token test " + DateTime.Now.ToShortTimeString(),
                        IssuedAt = DateTime.UtcNow,
                        Audience = "PostApi",
                        Expires = DateTime.UtcNow.AddDays(1),
                        SigningCredentials = signingCredentials
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    return Ok(tokenHandler.WriteToken(token));
                }
                else
                {
                    return BadRequest("Username or password incorrect!");
                }
               
            }
        }
    }
}
