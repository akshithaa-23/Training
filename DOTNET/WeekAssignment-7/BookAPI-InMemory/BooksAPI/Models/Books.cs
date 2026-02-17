using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BooksAPI.Models
{
  public class Books
  {
    [Key]
    public int BookId { get; set; }

    [Required]
    public string BookName { get; set; }

    [Range(1, 100000)]
    public decimal BookPrice { get; set; }

    [ForeignKey("Category")]
    public int CategoryId { get; set; }
    [JsonIgnore]
    public Category? Category { get; set; }

  }

}
