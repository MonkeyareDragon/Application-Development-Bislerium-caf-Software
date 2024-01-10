using System.ComponentModel.DataAnnotations;

namespace BisleriumCafé.Data.Models
{
    // This class represents the data structure for an Order.
    public class AddOrder
    {
        // Unique identifier for each Order, automatically generated.
        public Guid OrderId { get; set; } = Guid.NewGuid();

        // List of Coffee items included in the order.
        public List<Coffee> Coffee { get; set; }

        // List of add-ins for the order.
        public List<AddIns> AddIns { get; set; }

        // Total price of the order.
        [Required(ErrorMessage = "Total price is required")]
        [Display(Name = "Total price")]
        public double TotalPrice { get; set; }

        // Status of payment for the order.
        public string PaymentStatus { get; set; }

        // Date and time when the order was placed.
        [Required(ErrorMessage = "Order Datetime is required")]
        [Display(Name = "Order Datetime")]
        public DateTime OrderDatetime { get; set; }
    }
}