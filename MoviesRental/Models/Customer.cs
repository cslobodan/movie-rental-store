using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoviesRental.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name.")]
        [StringLength(25, ErrorMessage = "Maximum length is 25")]
        public string Name { get; set; }

        [Min18Years]
        [Display(Name = "Date of Birth")]
        public DateTime? Birthday { get; set; }

        public bool isSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        public int MoviesRented { get; set; }

        public int MoviesReturned { get; set; }

    }
}