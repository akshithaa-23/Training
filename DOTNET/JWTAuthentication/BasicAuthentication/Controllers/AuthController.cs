using BasicAuthentication.DTO;
using BasicAuthentication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BasicAuthentication.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthContext authContext;
        public AuthController(AuthContext authContext)
        {
            this.authContext = authContext;
        }

        [HttpPost("register")]
        public IActionResult Register(UserDTO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newUser = authContext.Users.FirstOrDefault(u => u.Email == user.Email);
            if (newUser != null)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var userToAdd = new User
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Password = user.Password,
                    isActive = true,
                    date = DateTime.Now
                };
                authContext.Users.Add(userToAdd);
                authContext.SaveChanges();
                return Ok(userToAdd);
            }
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDTO user)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }
            var objUser = authContext.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
            if (objUser != null)
            {
                return Ok("Login successful");
            }
            else
            {
                return BadRequest("Invalid email or password");
            }
        }

        [HttpGet]
        [Route("getAllUsers")]
        public IActionResult GetAllUsers()
        {
            var users = authContext.Users.ToList();

            return Ok(users);

        }

        [HttpGet("{id}")]
    
        public IActionResult GetAllUsersID(int id)
        {
            var users = authContext.Users.FirstOrDefault(u=>u.UserId==id);
            if(User == null)
            {
                return NotFound("User not found");
            }
            return Ok(users);

        }
        [HttpGet("{Email}")]
        public IActionResult GetByEmail(string email)
        {
            var users=authContext.Users.FirstOrDefault(u => u.Email == email);
            if (users == null) { return NotFound("User not found"); }
                        return Ok(users);
        }
    }
}






















    