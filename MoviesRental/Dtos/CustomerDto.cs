using System;
using System.ComponentModel.DataAnnotations;

namespace MoviesRental.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name.")]
        [StringLength(25, ErrorMessage = "Maximum length is 25")]
        public string Name { get; set; }

        public DateTime? Birthday { get; set; }

        public bool isSubscribedToNewsletter { get; set; }

        public byte MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }


    }
}