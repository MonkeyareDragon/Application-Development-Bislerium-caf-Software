using System.ComponentModel.DataAnnotations;

namespace BisleriumCafé.Data.Models
{
    // This class represents the data structure for a Coffee.
    public class Coffee
    {
        // Unique identifier for each coffee, automatically generated.
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "The Name is Required")]  // Required attribute ensures that this Name of Coffee field is mandatory.
        public string CoffeeName { get; set; }

        [Required(ErrorMessage = "The Price is Required")]  // Required attribute ensures that this Price of Coffee field is mandatory.
        public double CoffeePrice { get; set; }
    }
}
