using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using AutoMapper;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;


        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<List<MovieCardResponseModel>> Get30HighestGrossing()
        {
            var movies = await _movieRepository.GetTop30HighestGrossingMovies();



            var result = new List<MovieCardResponseModel>();



            foreach (var movie in movies)
            {
                result.Add(
                new MovieCardResponseModel
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    PosterUrl = movie.PosterUrl
                });
            }



            return result;
        }

        public void CreateMovie(MovieCreateRequestModel model)
        {
            // take model and convert it to Movie Entity and send it to repository
            // if repository saves successfully return true/id:2
        }

        public async Task<MovieDetailsResponseModel> GetMovieAsync(int id)
        {
            // get movie by id
            var movie = await _movieRepository.GetByIdAsync(id);
            if (movie == null) throw new NotFoundException("Movie", id);
            var genres = new List<GenreModel>();
            var casts = new List<MovieDetailsResponseModel.CastResponseModel>();
            // for every genre in the movie
            foreach (var genre in movie.Genres)
            {
                genres.Add(new GenreModel
                { 
                    Id = genre.Id,
                    Name = genre.Name
                });
            }
            // for every cast in the movie
            foreach (var thing in movie.MovieCasts)
            {
                casts.Add(new MovieDetailsResponseModel.CastResponseModel
                {
                    Id = thing.CastId,
                    Character = thing.Character,
                    Gender = thing.Cast.Gender,
                    Name = thing.Cast.Name,
                    ProfilePath = thing.Cast.ProfilePath,
                    TmdbUrl = thing.Cast.TmdbUrl
                });
            }
            var response = new MovieDetailsResponseModel
            {
                Id = movie.Id,
                Title = movie.Title,
                PosterUrl = movie.PosterUrl,
                BackdropUrl = movie.BackdropUrl,
                Rating = movie.Rating,
                Overview = movie.Overview,
                Tagline = movie.Tagline,
                Budget = movie.Budget,
                Revenue = movie.Revenue,
                ImdbUrl = movie.ImdbUrl,
                TmdbUrl = movie.TmdbUrl,
                ReleaseDate = movie.ReleaseDate,
                RunTime = movie.RunTime,
                Price = movie.Price,
                Casts = casts,
                Genres = genres
            };
            return response;
        }
        public async Task<List<MovieCardResponseModel>> GetMoviesByGenreAsync(int genreId)
        {
            var movies = await _movieRepository.GetMoviesByGenreAsync(genreId);
            var allmovies = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
            {
                allmovies.Add(new MovieCardResponseModel
                {
                    Id = movie.Id,
                    PosterUrl = movie.PosterUrl,
                    Title = movie.Title
                });
            }
            var response = new List<MovieCardResponseModel>();
            // have to limit movies
            foreach(var movie in allmovies)
            {
                if (response.Count < 30)
                {
                    response.Add(movie);
                }
            }
            return response;
        }
    }
}
