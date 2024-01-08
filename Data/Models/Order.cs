using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BisleriumCafé.Data.Models
{
    public class AddOrder
    {
        [Required(ErrorMessage = "Coffee Name is Required")]
        [Display(Name = "Coffee Name")]
        public string Coffee { get; set; }

        public List<AddIns> AddIns { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [Display(Name = "Address")]
        public double TotalPrice { get; set; }

        [Required(ErrorMessage = "Payment Status is required")]
        [Display(Name = "Payment Status")]
        public string PaymentStatus { get; set; }

        // New properties for order datetime and payment status
        [Required(ErrorMessage = "Order Datetime is required")]
        [Display(Name = "Order Datetime")]
        public DateTime OrderDatetime { get; set; }
    }
}
