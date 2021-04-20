using ApplicationCore.Models.Response;
using System.Collections.Generic;

public class CastDetailsResponseModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }
    public string TmdbUrl { get; set; }
    public string ProfilePath { get; set; }
    public IEnumerable<MovieResponseModel> Movies { get; set; }
}