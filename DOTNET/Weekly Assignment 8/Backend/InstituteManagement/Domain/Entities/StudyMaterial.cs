using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class StudyMaterial
    {
        public int Id { get; set; }
        [Required] public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string? FileUrl { get; set; }
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
        public int UploadedById { get; set; }
        public User? UploadedBy { get; set; }
    }
}