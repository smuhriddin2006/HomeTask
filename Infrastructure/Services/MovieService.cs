using System.Threading.Channels;
using Domain.Models;
using Infrastructure.Interface;
using Npgsql;

namespace Infrastructure.Services;

public class MovieService : IMovieService
{
        const string connectionString = $@"Host=localhost;
                                       Database=TheatreDB;
                                       Username=postgres;
                                       Password=umed008";

    public void AddMovie(Movie movie)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                
                string aSM = @"Insert into movies (title, director, year, duration, genre, description)
                               Values (@Title, @Director, @Year, @Duration, @Genre, @Description)";
                NpgsqlCommand cTA = new NpgsqlCommand(aSM, connection);

                cTA.Parameters.AddWithValue("Title", movie.Title);
                cTA.Parameters.AddWithValue("Director", movie.Director);
                cTA.Parameters.AddWithValue("Year", movie.Year);
                cTA.Parameters.AddWithValue("Duration", movie.Duration);
                cTA.Parameters.AddWithValue("Genre", movie.Genre);
                cTA.Parameters.AddWithValue("Description", movie.Description);

                var insert = cTA.ExecuteNonQuery();
                System.Console.WriteLine($"Inserted succsesfullt {insert}");

            }
        }
        catch(Exception ex)
        {
            System.Console.WriteLine($"Inserted Failed {ex.Message}");
        }
    }

    public void DeleteMovie(int id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                
                string dSM = @"Delete from movies 
                               where id = @id";
                NpgsqlCommand cTD = new NpgsqlCommand(dSM, connection);

                cTD.Parameters.AddWithValue("id", id);

                var delete = cTD.ExecuteNonQuery();
                System.Console.WriteLine($"Deleted succsesfullt {delete}");

            }
        }
        catch(Exception ex)
        {
            System.Console.WriteLine($"Deleted Failed {ex.Message}");
        }
    }

    public List<Movie> GetAllMovies()
    {
        List<Movie> movies = new List<Movie>();
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string gAM = "select * from movies";
                NpgsqlCommand cTG = new NpgsqlCommand(gAM, connection);

                var reader = cTG.ExecuteReader();

                while (reader.Read())
                {
                    Movie movie = new Movie()
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Director = reader.GetString(2),
                        Year = reader.GetInt32(3),
                        Duration = reader.GetInt32(4),
                        Genre = reader.GetString(5),
                        Description = reader.GetString(6)
                    };
                       movies.Add(movie);
                }
                return movies;
            }
        }
        catch(Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
        return null;
    }

    public void UpdateMovie(Movie movie)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                
                string uSM = @"Update movies 
                               Set title = @Title,
                               director = @Director,
                               year = @Year,
                               duration = @Duration,
                               genre = @Genre,
                               description = @Description
                               where id = @id";

                NpgsqlCommand cTU = new NpgsqlCommand(uSM, connection);

                cTU.Parameters.AddWithValue("Title", movie.Title);
                cTU.Parameters.AddWithValue("Director", movie.Director);
                cTU.Parameters.AddWithValue("Year", movie.Year);
                cTU.Parameters.AddWithValue("Duration", movie.Duration);
                cTU.Parameters.AddWithValue("Genre", movie.Genre);
                cTU.Parameters.AddWithValue("Description", movie.Description);
                cTU.Parameters.AddWithValue("id", movie.Id);
         
                var update = cTU.ExecuteNonQuery();
                System.Console.WriteLine($"Updated succsesfullt {update}");

            }
        }
        catch(Exception ex)
        {
            System.Console.WriteLine($"Updated Failed {ex.Message}");
        }
    }

    public Movie GetMovieById(int id)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();

            string gMI = @"select * from movies
                           where id = @id";
            NpgsqlCommand cTG = new NpgsqlCommand(gMI, connection);

            cTG.Parameters.AddWithValue("id", id);
            var reader = cTG.ExecuteReader();

            while (reader.Read())
            {
                Movie movie = new()
                {
                    Id = reader.GetInt32(0),
                    Title = reader.GetString(1),
                    Director = reader.GetString(2),
                    Year = reader.GetInt32(3),
                    Duration = reader.GetInt32(4),
                    Genre = reader.GetString(5),
                    Description = reader.GetString(6)
                };
                return movie;
            }

        }

        return null;
    }
}

