using MoviesRental.Dtos;
using MoviesRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MoviesRental.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private MoviesRentalDbContext _context;

        public NewRentalsController()
        {
            _context = new MoviesRentalDbContext();
        }

        //POST /api/newrentals
        [HttpPost]
        public IHttpActionResult CreateNewRental(NewRentalDto newRental)
        {
            //END: If CustomerId do not exists in database
            Customer customer = _context.Customers.Find(newRental.CustomerId);
            if(customer == null)
                return BadRequest("Customer Id is not valid.");

            //END: If at least one Movie Id is not provided
            if (newRental.MovieIds == null || newRental.MovieIds.Count == 0)
                return BadRequest("No Movie Id has been given.");

            //END: If one or more MovieIds not exist in database
            var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();
            if (movies.Count != newRental.MovieIds.Count)
                return BadRequest("One or more movie Ids are inavlid");

            //Iterating through all provided movies
            foreach(Movie movie in movies)
            {
                //END: If Movie is not available
                if (movie.NumberAvailable == 0)
                    return BadRequest($"Movie '{movie.Name}' is not available");

                //Decreasing availability of movie
                movie.NumberAvailable--;

                //Constructing Rental object
                Rental rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                //Adding new object to Rental table
                _context.Rentals.Add(rental);
            }
            
            //Saving changes
            _context.SaveChanges();

            return Ok();
        }
    }
}
