using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using MoviesRental.Dtos;
using MoviesRental.Models;

namespace MoviesRental.Controllers.Api
{
    public class RentalsController : ApiController
    {
        private MoviesRentalDbContext _context;

        public RentalsController()
        {
            _context = new MoviesRentalDbContext();
        }

        //GET /api/rentals
        [HttpGet]
        public IHttpActionResult GetAllRentals()
        {
            var rentals = _context.Rentals
                .Include(m => m.Customer)
                .Include(m => m.Movie)
                .ToList();

            var rentalsDto = rentals
                .ToList()
                .Select(Mapper.Map<Rental, RentalDto>);
            return Ok(rentalsDto);
        }

        //POST /api/rentals
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

                //Increasing rent attribute of customer
                customer.MoviesRented++;

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

        //PUT /api/rental/1
        [HttpPut]
        public IHttpActionResult ReturnMovie(int id)
        {
            Rental rental = _context.Rentals
                .Include(c => c.Movie)
                .Include(c => c.Customer)
                .SingleOrDefault(c => c.Id == id);
            if (rental == null)
                return NotFound();
            rental.DateReturned = DateTime.Now;

            Movie movie = _context.Movies.Find(rental.Movie.Id);
            movie.NumberAvailable++;

            Customer customer = _context.Customers.Find(rental.Customer.Id);
            customer.MoviesReturned++;

            _context.SaveChanges();
            return Ok();
        }


    }
}
