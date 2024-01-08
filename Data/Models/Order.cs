using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BisleriumCafé.Data.Models
{
    public class AddOrder
    {
        // Unique identifier for each coffee, automatically generated.
        public Guid OrderId { get; set; } = Guid.NewGuid();
        public List<Coffee> Coffee { get; set; }

        public List<AddIns> AddIns { get; set; }

        [Required(ErrorMessage = "Total price is required")]
        [Display(Name = "Total price")]
        public double TotalPrice { get; set; }

        public string PaymentStatus { get; set; }

        // New properties for order datetime and payment status
        [Required(ErrorMessage = "Order Datetime is required")]
        [Display(Name = "Order Datetime")]
        public DateTime OrderDatetime { get; set; }
    }
}
