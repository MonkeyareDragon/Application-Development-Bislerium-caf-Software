using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BisleriumCafé.Data.Models
{
    public class MakePayment
    {
        // Unique identifier for each coffee, automatically generated.
        public Guid PaymentId { get; set; } = Guid.NewGuid();
        public List<AddOrder> Order { get; set; }

        [Required(ErrorMessage = "Customer Name is Required")] // Required attribute ensures that this field is mandatory.
        [Display(Name = "Customer Name")] // Display attribute changes the label that will be shown in the UI.
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Email is required")]  // Similar annotations for Last Name.
        [EmailAddress(ErrorMessage = "Invalid email address")]  // Annotation to ensure a valid email address is provided.
        [Display(Name = "Email")]   // Similar annotations for Last Name.
        public string Email { get; set; }

        [Required(ErrorMessage = "Payment Datetime is required")]
        [Display(Name = "Payment Datetime")]
        public DateTime PaymentDatetime { get; set; }
    }
}
