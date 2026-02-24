using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using static Application.DTOs.AuthDtos;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly PasswordHasher<User> _hasher;
        private readonly JwtService _jwt;
        private static readonly string[] ValidRoles = { "Admin", "Trainer", "Student" };

        public AuthController(AppDbContext db, JwtService jwt)
        {
            _db = db;
            _hasher = new PasswordHasher<User>();
            _jwt = jwt;
        }

        // POST 
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            try
            {
                if (!ValidRoles.Contains(dto.Role))
                    return BadRequest("Invalid role. Choose: Admin, Trainer, or Student.");

                if (await _db.Users.AnyAsync(u => u.Email == dto.Email))
                    return BadRequest("Email already registered.");

                var user = new User
                {
                    FullName = dto.FullName,
                    Email = dto.Email,
                    Role = dto.Role
                };

                user.PasswordHash = _hasher.HashPassword(user, dto.Password);
                _db.Users.Add(user);
                await _db.SaveChangesAsync();

                var token = _jwt.GenerateToken(user);
                return Ok(new AuthResultDto(token, user.FullName, user.Email, user.Role));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // POST 
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            try
            {
                var user = await _db.Users.SingleOrDefaultAsync(u => u.Email == dto.Email);
                if (user == null) return Unauthorized("Invalid credentials.");

                var result = _hasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
                if (result == PasswordVerificationResult.Failed)
                    return Unauthorized("Invalid credentials.");

                var token = _jwt.GenerateToken(user);
                return Ok(new AuthResultDto(token, user.FullName, user.Email, user.Role));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // GET 
        [HttpGet("me")]
        [Authorize]
        public IActionResult Me()
        {
            try
            {
                return Ok(new
                {
                    Id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                    FullName = User.FindFirst(ClaimTypes.Name)?.Value,
                    Email = User.FindFirst(ClaimTypes.Email)?.Value,
                    Role = User.FindFirst(ClaimTypes.Role)?.Value
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}