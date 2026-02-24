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
    public class StudyMaterialController : ControllerBase
    {
        private readonly AppDbContext _db;
        public StudyMaterialController(AppDbContext db) => _db = db;

        // GET: api/studymaterial → all roles can view
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var materials = await _db.StudyMaterials
                    .Include(s => s.UploadedBy)
                    .Select(s => new StudyMaterialDto(
                        s.Id,
                        s.Title,
                        s.Description,
                        s.FileUrl,
                        s.UploadedAt,
                        s.UploadedBy!.FullName
                    ))
                    .ToListAsync();
                return Ok(materials);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // POST: api/studymaterial → only Trainer
        [HttpPost]
        [Authorize(Roles = "Trainer")]
        public async Task<IActionResult> Add(AddStudyMaterialDto dto)
        {
            try
            {
                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
                var material = new StudyMaterial
                {
                    Title = dto.Title,
                    Description = dto.Description,
                    FileUrl = dto.FileUrl,
                    UploadedById = userId
                };
                _db.StudyMaterials.Add(material);
                await _db.SaveChangesAsync();
                return Ok(material);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // DELETE: api/studymaterial/{id} → Admin and Trainer
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Trainer")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var material = await _db.StudyMaterials.FindAsync(id);
                if (material == null) return NotFound("Material not found.");
                _db.StudyMaterials.Remove(material);
                await _db.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // GET: api/studymaterial/mine → Trainer sees only their materials
        [HttpGet("mine")]
        [Authorize(Roles = "Trainer")]
        public async Task<IActionResult> GetMine()
        {
            try
            {
                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
                var materials = await _db.StudyMaterials
                    .Include(s => s.UploadedBy)
                    .Where(s => s.UploadedById == userId)
                    .Select(s => new StudyMaterialDto(
                        s.Id,
                        s.Title,
                        s.Description,
                        s.FileUrl,
                        s.UploadedAt,
                        s.UploadedBy!.FullName
                    ))
                    .ToListAsync();
                return Ok(materials);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}