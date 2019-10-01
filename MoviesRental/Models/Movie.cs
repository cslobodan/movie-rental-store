using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoviesRental.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Required(ErrorMessage = "Genre is required.")]
        public int GenreId { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Display(Name="Number in stock")]
        [Range(1, 20, ErrorMessage = "Value must be between 1 and 20.")]
        [Required]
        public int? NumberInStock { get; set; }

        public int? NumberAvailable { get; set; }

    }
}