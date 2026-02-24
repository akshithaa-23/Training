using Application.DTOs;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FeedbackController : ControllerBase
    {
        private readonly AppDbContext _db;
        public FeedbackController(AppDbContext db) => _db = db;

        // GET - Admin, Trainer sees all
        [HttpGet("all")]
        [Authorize(Roles = "Admin,Trainer")]
        public async Task<IActionResult> GetAllForTrainer()
        {
            try
            {
                var feedbacks = await _db.Feedbacks
                    .Include(f => f.SubmittedBy)
                    .Select(f => new FeedbackDto(
                        f.Id,
                        f.Message,
                        f.SubmittedAt,
                        f.SubmittedBy!.FullName,
                        f.SubmittedBy!.Role
                    ))
                    .ToListAsync();
                return Ok(feedbacks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // POST - Student submits
        [HttpPost]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> Add(AddFeedbackDto dto)
        {
            try
            {
                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
                var feedback = new Feedback
                {
                    Message = dto.Message,
                    SubmittedById = userId
                };
                _db.Feedbacks.Add(feedback);
                await _db.SaveChangesAsync();
                return Ok(feedback);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // DELETE-Admin only
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var feedback = await _db.Feedbacks.FindAsync(id);
                if (feedback == null) return NotFound("Feedback not found.");
                _db.Feedbacks.Remove(feedback);
                await _db.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // GET - Student sees only their feedback
        [HttpGet("mine")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> GetMine()
        {
            try
            {
                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
                var feedbacks = await _db.Feedbacks
                    .Include(f => f.SubmittedBy)
                    .Where(f => f.SubmittedById == userId)
                    .Select(f => new FeedbackDto(
                        f.Id,
                        f.Message,
                        f.SubmittedAt,
                        f.SubmittedBy!.FullName,
                        f.SubmittedBy!.Role
                    ))
                    .ToListAsync();
                return Ok(feedbacks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}