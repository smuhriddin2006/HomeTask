using Domain.Models;

namespace Infrastructure.Interface;

public interface IMovieService
{
    void AddMovie(Movie movie);
    List<Movie> GetAllMovies();
    void DeleteMovie(int id);
    void UpdateMovie(Movie movie);
}
