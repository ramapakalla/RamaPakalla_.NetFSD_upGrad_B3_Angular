using WebApplication6.Models;
using WebApplication6.Repositories;

namespace WebApplication6.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repository;

        public MovieService(IMovieRepository repository)
        {
            _repository = repository;
        }

        public List<Movie> GetAllMovies()
        {
            return _repository.GetAllMovies();
        }

        public Movie GetMovieById(int id)
        {
            return _repository.GetMovieById(id);
        }

        public void AddMovie(Movie movie)
        {
            _repository.AddMovie(movie);
        }

        public void UpdateMovie(Movie movie)
        {
            _repository.UpdateMovie(movie);
        }

        public void DeleteMovie(int id)
        {
            _repository.DeleteMovie(id);
        }
    }
}