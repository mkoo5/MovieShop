using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IMovieService
    {
        Task<List<MovieCardResponseModel>> Get30HighestGrossing();
        void CreateMovie(MovieCreateRequestModel model);
        Task<MovieDetailsResponseModel> GetMovieAsync(int id);
        Task<List<MovieCardResponseModel>> GetMoviesByGenreAsync(int genreId);
    }
}
