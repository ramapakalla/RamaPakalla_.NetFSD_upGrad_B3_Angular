using WebApplication6.Data;
using WebApplication6.Models;

namespace WebApplication6.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieContext _context;

        public MovieRepository(MovieContext context)
        {
            _context = context;
        }

        public List<Movie> GetAllMovies()
        {
            return _context.Movie.ToList();
        }

        public Movie GetMovieById(int id)
        {
            return _context.Movie.Find(id);
        }

        public void AddMovie(Movie movie)
        {
            _context.Movie.Add(movie);
            _context.SaveChanges();
        }

        public void UpdateMovie(Movie movie)
        {
            _context.Movie.Update(movie);
            _context.SaveChanges();
        }

        public void DeleteMovie(int id)
        {
            var movie = _context.Movie.Find(id);

            if (movie != null)
            {
                _context.Movie.Remove(movie);
                _context.SaveChanges();
            }
        }
    }
}