using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MovieRepository : EfRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<IEnumerable<Movie>> GetMoviesByGenre(int genreId)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<Movie>> GetTop30HighestGrossingMovies()
        {
            var movies = await _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToListAsync();
            return movies;
        }

        public override async Task<Movie> GetByIdAsync(int id)
        {
            // from Movies table include the Casts for that Movie along with the Genres
            // fetch by matching Movie Id with id in parameters.
            var movie = await _dbContext.Movies.Include(m => m.MovieCasts).ThenInclude(m => m.Cast)
                .Include(m => m.Genres)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                throw new NotFoundException("Movie Not found");
            }

            // get average movie ratings
            var movieRating = await _dbContext.Reviews.Where(r => r.MovieId == id).DefaultIfEmpty()
                .AverageAsync(r => r == null ? 0 : r.Rating);
            if (movieRating > 0) movie.Rating = movieRating;

            return movie;
        } 
        public async Task<IEnumerable<Movie>> GetMoviesByGenreAsync(int genreId)
        {
            var movies = await _dbContext.Genres.Include(g => g.Movies).Where(g => g.Id == genreId)
                .SelectMany(g => g.Movies).OrderByDescending(m => m.Revenue).ToListAsync();
            return movies;
        }

    }
}
