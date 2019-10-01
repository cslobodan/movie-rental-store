using MoviesRental.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoviesRental.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Genre is required.")]
        public int GenreId { get; set; }

        public GenreDto Genre { get; set; }

        [Required]
        public DateTime? ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Range(1, 20, ErrorMessage = "Value must be between 1 and 20.")]
        [Required]
        public int? NumberInStock { get; set; }

        public int? NumberAvailable { get; set; }
    }
}