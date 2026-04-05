using Microsoft.EntityFrameworkCore;
using WebApplication6.Models;

namespace WebApplication6.Data
{
    public class MovieContext : DbContext    {
        public MovieContext(DbContextOptions<MovieContext> options)
            : base(options)
        {
        }

    public DbSet<Movie> Movie { get; set; }
}
}
