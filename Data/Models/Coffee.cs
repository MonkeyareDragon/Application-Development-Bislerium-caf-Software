using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisleriumCafé.Data.Models
{
    public class Coffee
    {
        // Unique identifier for each coffee, automatically generated.
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "The Name is Required")]  // Required attribute ensures that this Name field is mandatory.
        public string CoffeeName { get; set; }

        [Required(ErrorMessage = "The Price is Required")]  // Required attribute ensures that this Price field is mandatory.
        public double CoffeePrice { get; set; }
    }
}
