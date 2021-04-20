using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Models.Response;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class CastService: ICastService
    {
        private readonly ICastRepository _castRepository;
        public CastService(ICastRepository castRepository)
        {
            _castRepository = castRepository;
        }
        public async Task<CastDetailsResponseModel> GetCastDetailsWithMovies(int id)
        {
            var cast = await _castRepository.GetByIdAsync(id);
            if (cast == null)
            {
                throw new NotFoundException("Cast", id);
            }
            var movies = new List<MovieResponseModel>();
            foreach (var thing in cast.MovieCasts)
            {
                movies.Add(new MovieResponseModel
                {
                    Id = thing.MovieId,
                    PosterUrl = thing.Movie.PosterUrl,
                    ReleaseDate = (DateTime)thing.Movie.ReleaseDate,
                    Title = thing.Movie.Title
                });
            }
            var response = new CastDetailsResponseModel {
            Id = cast.Id,
            Name = cast.Name,
            Gender = cast.Gender,
            TmdbUrl = cast.TmdbUrl,
            ProfilePath = cast.ProfilePath,
            Movies = movies
            };
            return response;
        }
    }
}
