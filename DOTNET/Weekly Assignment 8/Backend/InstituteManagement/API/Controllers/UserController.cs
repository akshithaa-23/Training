using API.Controllers;
using Application.DTOs;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly PasswordHasher<User> _hasher;

        public UserController(AppDbContext db)
        {
            _db = db;
            _hasher = new PasswordHasher<User>();
        }

        // GET - Admin only
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var users = await _db.Users
                    .Select(u => new UserListDto(u.Id, u.FullName, u.Email, u.Role, u.IsActive))
                    .ToListAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // GET - Admin only
        [HttpGet("stats")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetStats()
        {
            try
            {
                var stats = new StatsDto(
                    TotalStudents: await _db.Users.CountAsync(u => u.Role == "Student"),
                    TotalTrainers: await _db.Users.CountAsync(u => u.Role == "Trainer"),
                    TotalAdmins: await _db.Users.CountAsync(u => u.Role == "Admin"),
                    ActiveUsers: await _db.Users.CountAsync(u => u.IsActive)
                );
                return Ok(stats);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // GET - Admin only
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var user = await _db.Users.FindAsync(id);
                if (user == null) return NotFound("User not found.");
                return Ok(new UserListDto(user.Id, user.FullName, user.Email, user.Role, user.IsActive));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // GET - Admin and Trainer
        [HttpGet("students")]
        [Authorize(Roles = "Admin,Trainer")]
        public async Task<IActionResult> GetStudents()
        {
            try
            {
                var students = await _db.Users
                    .Where(u => u.Role == "Student")
                    .Select(u => new UserListDto(u.Id, u.FullName, u.Email, u.Role, u.IsActive))
                    .ToListAsync();
                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // POST - Admin only
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddUser(AddUserDto dto)
        {
            try
            {
                if (await _db.Users.AnyAsync(u => u.Email == dto.Email))
                    return BadRequest("Email already exists.");

                var validRoles = new[] { "Admin", "Trainer", "Student" };
                if (!validRoles.Contains(dto.Role))
                    return BadRequest("Invalid role.");

                var user = new User
                {
                    FullName = dto.FullName,
                    Email = dto.Email,
                    Role = dto.Role,
                    IsActive = true
                };
                user.PasswordHash = _hasher.HashPassword(user, dto.Password);

                _db.Users.Add(user);
                await _db.SaveChangesAsync();
                return Ok(new UserListDto(user.Id, user.FullName, user.Email, user.Role, user.IsActive));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // PUT - Admin and Trainer
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Trainer")]
        public async Task<IActionResult> EditUser(int id, EditUserDto dto)
        {
            try
            {
                var user = await _db.Users.FindAsync(id);
                if (user == null) return NotFound("User not found.");

                user.FullName = dto.FullName;
                user.Email = dto.Email;
                user.Role = dto.Role;
                await _db.SaveChangesAsync();
                return Ok(new UserListDto(user.Id, user.FullName, user.Email, user.Role, user.IsActive));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // DELETE - Admin only
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var user = await _db.Users.FindAsync(id);
                if (user == null) return NotFound("User not found.");
                _db.Users.Remove(user);
                await _db.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // PUT - Admin only
        [HttpPut("{id}/toggle-active")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ToggleActive(int id)
        {
            try
            {
                var user = await _db.Users.FindAsync(id);
                if (user == null) return NotFound("User not found.");
                user.IsActive = !user.IsActive;
                await _db.SaveChangesAsync();
                return Ok(new UserListDto(user.Id, user.FullName, user.Email, user.Role, user.IsActive));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // PUT - Admin only
        [HttpPut("{id}/role")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AssignRole(int id, [FromBody] string role)
        {
            try
            {
                var validRoles = new[] { "Admin", "Trainer", "Student" };
                if (!validRoles.Contains(role))
                    return BadRequest("Invalid role.");

                var user = await _db.Users.FindAsync(id);
                if (user == null) return NotFound("User not found.");
                user.Role = role;
                await _db.SaveChangesAsync();
                return Ok(new UserListDto(user.Id, user.FullName, user.Email, user.Role, user.IsActive));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
