using BioTime.Models;

namespace BioTime.Services
{
    public class MovieService
    {
        private readonly AppDbContext _context;

        public MovieService(AppDbContext context)
        {
            _context = context;
        }

        public List<Movie> GetAll()
        {
            return _context.Movies.ToList();
        }

        public Movie? GetById(int id)
        {
            return _context.Movies.Find(id);
        }

        public Movie Add(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return movie;
        }

        public Movie? Update(int id, Movie updated)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null) return null;

            movie.Title = updated.Title;
            movie.Genre = updated.Genre;
            movie.Year = updated.Year;

            _context.SaveChanges();
            return movie;
        }

        public bool Delete(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null) return false;

            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return true;
        }
    }
}