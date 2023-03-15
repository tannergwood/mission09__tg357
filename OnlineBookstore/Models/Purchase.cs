using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Models
{
    public class Purchase
    {
        [Key]
        [BindNever]
        public int PurchaseId { get; set; }

        [BindNever]
        public ICollection<BasketLineItem> Lines { get; set; }

        [Required(ErrorMessage ="Please enter First Name")]
        public string FName { get; set; }

        [Required(ErrorMessage = "Please enter Last Name")]
        public string LName { get; set; }

        [Required(ErrorMessage = "Please enter Address")]
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string AddressLine3 { get; set; }

        [Required(ErrorMessage = "Please enter the city")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter the state")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please enter the Country")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Please enter the ZIP")]
        public string Zip { get; set; }
    }
}
