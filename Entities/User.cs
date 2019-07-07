using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BetAPI.Entities
{
     public class User
     {
          [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public int Id { get; set; }
          [Required]
          [MaxLength(100)]
          public string Name { get; set; }
          [Required]
          public int Age { get; set; }
     }
}