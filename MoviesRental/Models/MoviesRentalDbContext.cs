using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MoviesRental.Models
{
    public class MoviesRentalDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        public MoviesRentalDbContext() : base("MovieRentalDb", throwIfV1Schema: false)
        {
        }

        public static MoviesRentalDbContext Create()
        {
            return new MoviesRentalDbContext();
        }
    }
}