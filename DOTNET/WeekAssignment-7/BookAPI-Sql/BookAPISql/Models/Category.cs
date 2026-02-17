using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BookAPISql.Models
{
  public class Category
  {
    [Key]
    public int CategoryId { get; set; }

    [Required]
    public string CategoryName { get; set; }
   
    public List<Books>? bookss { get; set; }
  }
}

