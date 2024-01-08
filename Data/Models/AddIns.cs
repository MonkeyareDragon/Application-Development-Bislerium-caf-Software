using System.ComponentModel.DataAnnotations;


// This class represents the data structure for a hobby.
namespace BisleriumCafé.Data.Models
{
    public class AddIns
    {
        // Unique identifier for each hobby, automatically generated.
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "The Name is Required")]  // Required attribute ensures that this Name field is mandatory.
        public string Name { get; set; }

        [Required(ErrorMessage = "The Price is Required")]  // Required attribute ensures that this Price field is mandatory.
        public double Price { get; set; }
    }
}