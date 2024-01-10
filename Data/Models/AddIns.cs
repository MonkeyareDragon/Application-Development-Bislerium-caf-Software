using System.ComponentModel.DataAnnotations;


namespace BisleriumCafé.Data.Models
{
    // This class represents the data structure for a Add-Ins.
    public class AddIns
    {
        // Unique identifier for each addins, automatically generated.
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "The Name is Required")]  // Required attribute ensures that this Name of Add-Ins field is mandatory.
        public string Name { get; set; }

        [Required(ErrorMessage = "The Price is Required")]  // Required attribute ensures that this Price of Add-Ins field is mandatory.
        public double Price { get; set; }
    }
}