using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Feedback
    {
        public int Id { get; set; }
        [Required] public string Message { get; set; } = null!;
        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
        public int SubmittedById { get; set; }
        public User? SubmittedBy { get; set; }
    }
}