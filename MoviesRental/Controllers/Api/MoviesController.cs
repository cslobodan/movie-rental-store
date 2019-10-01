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
    public class MoviesController : ApiController
    {
        private MoviesRentalDbContext _context;

        public MoviesController()
        {
            _context = new MoviesRentalDbContext();
        }

        // GET: api/Movies
        [HttpGet]
        public IHttpActionResult GetMovies(string query = null)
        {
            var moviesQuery = _context.Movies.Include(m => m.Genre);

            if(!String.IsNullOrWhiteSpace(query))
            {
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query) && m.NumberAvailable >0);
            }

            var moviesDto = moviesQuery
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);
            return Ok(moviesDto);
        }

        // GET: api/Movies/5
        [HttpGet]
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            var movieDto = Mapper.Map<Movie, MovieDto>(movie);
            return Ok(movieDto);
        }

        // POST: api/Movies
        [HttpPost]
        //[Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult PostMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            movie.NumberAvailable = movieDto.NumberInStock;
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movieDto.Id), movieDto);
        }

        // PUT: api/Movies/5
        [HttpPut]
        //[Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult PutMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
            {
                return NotFound();
            }

            Mapper.Map(movieDto, movieInDb);
            _context.SaveChanges();
            return Ok();
        }


        // DELETE: api/Movies/5
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
            return Ok();
        }


    }
}