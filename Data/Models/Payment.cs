using System.ComponentModel.DataAnnotations;

namespace BisleriumCafé.Data.Models
{
    // This class represents the data structure for making a payment.
    public class MakePayment
    {
        // Unique identifier for each payment, automatically generated.
        public Guid PaymentId { get; set; } = Guid.NewGuid();

        // List of orders details in the payment.
        public List<AddOrder> Order { get; set; }

        // Name of the customer making the payment.
        [Required(ErrorMessage = "Customer Name is Required")]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        // Email address of the customer making the payment.
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        // Date and time when the payment was made.
        [Required(ErrorMessage = "Payment Datetime is required")]
        [Display(Name = "Payment Datetime")]
        public DateTime PaymentDatetime { get; set; }

        // Number of purchases made by the customer.
        public int PurchasesCount { get; set; }

        // Total amount paid by the customer.
        public double PaidPrice { get; set; }

        // Indicates whether the customer is an active customer.
        public bool IsActiveCustomer { get; set; }
    }
}
