using Microsoft.AspNetCore.Mvc;
using DatingApp.API.Data;
using System.Threading.Tasks;
using DatingApp.API.Models;
using DatingApp.API.Dtos;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("registar")]

        public async Task<IActionResult> Register(UserForRegisterDto UserForRegisterDto)
        {
            //validation
            // ...

            UserForRegisterDto.Username = UserForRegisterDto.Username.ToLower();

            if (await _repo.UserExists(UserForRegisterDto.Username))
                return BadRequest("Username already exists");

            var userToCreate = new User
            {
                Username = UserForRegisterDto.Username
            };
            //not sure difference in this sytax up and common syntax down
            //User UserToCreate = new User();
            //UserToCreate.Username = username;
 
            var createdUser = await _repo.Register(userToCreate, UserForRegisterDto.Password);

            //to change later StatusCode to CreateAtRoute ...
            return StatusCode(201);

        }
    }
}